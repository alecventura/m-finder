var newUser = { 'firstname': '', 'lastname': '', 'ramal': '', 'dpto': -1, 'role': -1, 'id': -1 }

function UsersViewModel(usersJSON, dptos, roles) {
    var self = this;
    self.dptos = ko.observableArray(dptos)
    self.roles = ko.observableArray(roles)
    self.users = ko.observableArray(usersJSON);
    self.users.subscribe(function (array) {
        self.setUsersLabels(array);
    });
    self.isVisible = ko.observable(false);
    self.userModal = ko.observable()
    self.isVisible.subscribe(function (newValue) {
        if (!newValue) {
            self.userModal(ko.mapping.fromJS(newUser));
        }
    });

    self.onEditUserClicked = function (user) {
        self.userModal(ko.mapping.fromJS(user));
        self.isVisible(true);
    };

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

    self.onRemoveUserClicked = function (user) {
        $.ajax({
            type: "POST",
            url: "Users.aspx/removeUser",
            contentType: "application/json; charset=utf-8",
            data: '{user: ' + JSON.stringify(ko.mapping.toJS(user)) + '}',
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

    self.onSaveUserClicked = function () {
        $.ajax({
            type: "POST",
            url: "Users.aspx/saveUser",
            contentType: "application/json; charset=utf-8",
            data: '{user: ' + JSON.stringify(ko.mapping.toJS(self.userModal)) + '}',
            dataType: 'json',
            success: function (response) {
                self.users(response.d);
                self.isVisible(false);
                toastr.success("User successfully saved!");
            },
            failure: function (response) {
                alert(response);
            },
            error: function (response) {
                alert(response);
            }
        });
    }

    self.onAddNewUserClicked = function () {
        self.userModal(ko.mapping.fromJS(newUser));
        self.isVisible(true);
    }
}

$(document).ready(function () {
    ko.applyBindings(new UsersViewModel(usersJSON, dptos, roles), document.getElementById('users'));
});