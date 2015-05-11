define([], function () {
    function UserCreateViewModel(params) {
        var newUser = { 'firstname': '', 'lastname': '', 'ramal': '', 'dpto': -1, 'role': -1, 'id': -1 }
        var self = this;
        self.isEdit = params.isEdit
        self.search = params.search;

        if (params.isEdit == true) {
            self.objModal = ko.observable(ko.mapping.fromJS(params.objModal));
        } else {
            self.objModal = ko.observable(ko.mapping.fromJS(newUser));
        }

        if (params.isVisible != null) {
            self.isVisible = params.isVisible;
        } else {
            self.isVisible = ko.observable(false);
        }

        self.isVisible.subscribe(function (newValue) {
            if (!self.isEdit && !newValue) {
                self.objModal(ko.mapping.fromJS(newUser));
            }
        });

        self.dptos = params.dptos;
        self.roles = params.roles;
        self.users = params.users;

        self.onSaveClicked = function () {
            $.ajax({
                type: "POST",
                url: "Users.aspx/saveUser",
                contentType: "application/json; charset=utf-8",
                data: '{user: ' + JSON.stringify(ko.mapping.toJS(self.objModal)) + '}',
                dataType: 'json',
                success: function (response) {
                    self.search(0, false);
                    self.isVisible(false);
                    $('.modal-backdrop').remove();
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

    }
    return UserCreateViewModel;

});