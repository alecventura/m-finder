define([], function () {
    function MachineCreateViewModel(params) {
        var newMachine = { 'model': '', 'name': '', 'serialnumber': '', 'aquisitionDate': moment().format('L'), 'warrantyExpirationDate': moment().format('L'), 'id': -1 }
        var self = this;
        self.isEdit = params.isEdit;
        self.search = params.search;

        if (params.isEdit == true) {
            self.objModal = ko.observable(ko.mapping.fromJS(params.objModal));
        } else {
            self.objModal = ko.observable(ko.mapping.fromJS(newMachine));
        }

        if (params.isVisible != null) {
            self.isVisible = params.isVisible;
        } else {
            self.isVisible = ko.observable(false);
        }

        self.isVisible.subscribe(function (newValue) {
            if (!self.isEdit && !newValue) {
                self.objModal(ko.mapping.fromJS(newMachine));
            }
        });

        self.dptos = params.dptos;
        self.machines = params.machines;

        self.onSaveClicked = function () {
            $.ajax({
                type: "POST",
                url: "Machines.aspx/saveMachine",
                contentType: "application/json; charset=utf-8",
                data: '{machine: ' + JSON.stringify(ko.mapping.toJS(self.objModal)) + '}',
                dataType: 'json',
                success: function (response) {
                    self.search(0, false);
                    self.isVisible(false);
                    $('.modal-backdrop').remove();
                    toastr.success("Machine successfully saved!");
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
    return MachineCreateViewModel;

});