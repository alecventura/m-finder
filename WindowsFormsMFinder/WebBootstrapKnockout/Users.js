function UsersViewModel(usersJSON, dptos, roles) {
    var self = this;
    self.users = ko.observableArray(usersJSON);
    self.isVisible = ko.observable(false);
    self.userModal = ko.observable()
    self.dptos = ko.observableArray(dptos)
    self.roles = ko.observableArray(roles)

    self.onEditUserClicked = function (user) {
        self.userModal(ko.mapping.fromJS(user));
        self.isVisible(true);
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
                self.userModal(null);
            },
            failure: function (response) {
                alert(response);
            },
            error: function (response) {
                alert(response);
            }
        });
    }
}

$(document).ready(function () {
    ko.applyBindings(new UsersViewModel(usersJSON, dptos, roles), document.getElementById('users'));
});