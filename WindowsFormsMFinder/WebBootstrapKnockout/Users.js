var newUser = { 'firstname': '', 'lastname': '', 'ramal': '', 'dpto': -1, 'role': -1, 'id': -1 }
var request = { 'limit': 10, 'offset': 0 }

window.jqReady = function () {

    function UsersViewModel(dptos, roles) {
        var self = this;
        self.dptos = ko.observableArray(dptos)
        self.roles = ko.observableArray(roles)
        self.users = ko.observableArray([]);
        self.users.subscribe(function (array) {
            self.setUsersLabels(array);
        });
        self.request = ko.observable(ko.mapping.fromJS(request))
        self.isVisible = ko.observable(false);

        self.setUsersLabels = function (array) {
            _.each(array, function (item) {
                dptoObj = _.find(self.dptos(), function (dpto) {
                    return item.dpto == dpto.id;
                })
                item.dptoName = ko.observable(dptoObj.name);
                roleObj = _.find(self.roles(), function (role) {
                    return item.role == role.id;
                })
                item.roleName = ko.observable(roleObj.name);
            })
        };

        self.setUsersLabels(self.users());

        self.onRemoveClicked = function (item) {
            bootbox.confirm("Are you sure you want to remove user=" + item.firstname + " " + item.lastname + "?", function (result) {
                if (result) {
                    var deep = _.cloneDeep(newUser);
                    deep.id = item.id
                    $.ajax({
                        type: "POST",
                        url: "Users.aspx/removeUser",
                        contentType: "application/json; charset=utf-8",
                        data: '{user: ' + JSON.stringify(deep) + '}',
                        dataType: 'json',
                        success: function (response) {
                            self.users(response.d);
                            toastr.success("User successfully removed!");
                        },
                        failure: function (response) {
                            alert(response);
                        },
                        error: function (response) {
                            alert(response);
                        }
                    });
                }
            });
        }

        self.mountRequest = function () {
            return JSON.stringify({ 'request': ko.mapping.toJS(self.request) });
        }

        self.findUsers = (function () {
            return function (offset, showmessage) {
                self.request().offset(offset);
                return utils.postJSON("Users.aspx/searchUsers", self.mountRequest(), function (data) {
                    data = data.d;
                    self.request().offset(data.offset);
                    if (data.total === 0) {
                        if (showmessage) {
                            toastr.success("No user found!");
                        }
                        self.users([]);
                    } else {
                        if (showmessage) {
                            toastr.success("Successfully found" + data.total + " users!");
                        }
                        self.users(data.list);
                        self.generatePager(data, self);
                    }
                });
            };
        })();

        self.generatePager = (function (self) {
            return function (data, self) {
                var pagerOpts;
                pagerOpts = {
                    div: $('#pager'),
                    offset: data.offset,
                    limit: self.request().limit(),
                    total: data.total,
                    onClick: function (e, page) {
                        e.preventDefault();
                        if (page.enabled) {
                            return self.findUsers(page.offset, false);
                        }
                    }
                };
                return pager.gen(pagerOpts);
            };
        })();

        self.findUsers(0, false);
    }

    $(document).ready(function () {
        ko.components.register('user-create', {
            viewModel: { require: 'components/user-create/usercreate.js' },

            template: { require: 'Scripts/text!components/user-create/usercreate.html' }
        });
        ko.applyBindings(new UsersViewModel(dptos, roles), document.getElementById('users'));

        $('.modal').on('show.bs.modal', function () {
            $(this).find('.modal-body').css({
                width: 'auto', //probably not needed
                height: 'auto', //probably not needed 
                'max-height': '100%',
                'max-width': '100%'
            });
        });
    });
}