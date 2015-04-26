var newMachine = { 'model': '', 'name': '', 'serialnumber': '', 'aquisitionDate': -1, 'warrantyExpirationDate': -1, 'id': -1 }

function MachineCreateViewModel(dptos, objModal, isVisible, machines) {
    var self = this;
    self.dptos = dptos;
    self.objModal = objModal;
    self.isVisible = isVisible;
    self.machines = machines;

    self.onEditClicked = function (item) {
        self.objModal(ko.mapping.fromJS(item));
        self.isVisible(true);
    };

    self.onSaveClicked = function () {
        $.ajax({
            type: "POST",
            url: "Machines.aspx/saveMachine",
            contentType: "application/json; charset=utf-8",
            data: '{machine: ' + JSON.stringify(ko.mapping.toJS(self.objModal)) + '}',
            dataType: 'json',
            success: function (response) {
                self.machines(response.d);
                self.isVisible(false);
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

    self.onAddNewClicked = function () {
        self.objModal(ko.mapping.fromJS(newMachine));
        self.isVisible(true);
    }
}

$(document).ready(function () {
    ko.applyBindings(new MachineCreateViewModel(dptos));
});
