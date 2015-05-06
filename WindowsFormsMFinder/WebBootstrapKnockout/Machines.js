var newMachine = { 'model': '', 'name': '', 'serialnumber': '', 'aquisitionDate': "2015-04-27T03:00:00.000Z", 'warrantyExpirationDate': "2015-04-27T03:00:00.000Z", 'id': -1 }

window.jqReady = function () {

    function MachineViewModel(machines, dptos) {
        var self = this;
        self.dptos = ko.observableArray(dptos)
        self.machines = ko.observableArray(machines);
        self.machines.subscribe(function (array) {
            self.setsLabels(array);
        });
        self.isVisible = ko.observable(false);
        self.objModal = ko.observable()

        self.setsLabels = function (array) {
            _.each(array, function (item) {
                item.aquisitionDateText = moment(item.aquisitionDate).format('L');
                item.warrantyExpirationDateText = moment(item.warrantyExpirationDate).format('L');
            })
        };

        self.setsLabels(self.machines());

        self.onRemoveClicked = function (item) {
            bootbox.confirm("Are you sure you want to remove machine with serialnumber=" + item.serialnumber + "?", function (result) {
                if (result) {
                    var deep = _.cloneDeep(newMachine);
                    deep.id = item.id
                    $.ajax({
                        type: "POST",
                        url: "Machines.aspx/removeMachine",
                        contentType: "application/json; charset=utf-8",
                        data: '{machine: ' + JSON.stringify(deep) + '}',
                        dataType: 'json',
                        success: function (response) {
                            self.machines(response.d);
                            toastr.success("Machine successfully removed!");
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
        ko.components.register('machine-create', {
            viewModel: { require: 'components/machine-create/machinecreate.js' },

            template: { require: 'Scripts/text!components/machine-create/machinecreate.html' }
        });
        ko.applyBindings(new MachineViewModel(machines, dptos), document.getElementById('machines'));

    });
}