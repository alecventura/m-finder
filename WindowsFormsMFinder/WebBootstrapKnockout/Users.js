var newUser = { 'firstname': '', 'lastname': '', 'ramal': '', 'dpto': -1, 'role': -1, 'id': -1 }

window.jqReady = function () {

    function UsersViewModel(usersJSON, dptos, roles) {
        var self = this;
        self.dptos = ko.observableArray(dptos)
        self.roles = ko.observableArray(roles)
        self.users = ko.observableArray(usersJSON);
        self.users.subscribe(function (array) {
            self.setUsersLabels(array);
        });
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
    }

    $(document).ready(function () {
        ko.components.register('user-create', {
            viewModel: { require: 'components/user-create/usercreate.js' },

            template: { require: 'Scripts/text!components/user-create/usercreate.html' }
        });
        ko.applyBindings(new UsersViewModel(usersJSON, dptos, roles), document.getElementById('users'));

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