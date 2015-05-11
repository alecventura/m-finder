var newMachine = { 'model': '', 'name': '', 'serialnumber': '', 'aquisitionDate': "2015-04-27T03:00:00.000Z", 'warrantyExpirationDate': "2015-04-27T03:00:00.000Z", 'id': -1 }
var request = { 'limit': 10, 'offset': 0 }

window.jqReady = function () {

    function MachineViewModel(dptos) {
        var self = this;
        self.dptos = ko.observableArray(dptos)
        self.machines = ko.observableArray([]);
        self.machines.subscribe(function (array) {
            self.setsLabels(array);
        });
        self.request = ko.observable(ko.mapping.fromJS(request))
        self.isVisible = ko.observable(false);
        self.objModal = ko.observable();

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
                            self.findMachines(0, false);
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

        self.mountRequest = function () {
            return JSON.stringify({ 'request': ko.mapping.toJS(self.request) });
        }

        self.findMachines = (function () {
            return function (offset, showmessage) {
                self.request().offset(offset);
                return utils.postJSON("Machines.aspx/searchMachines", self.mountRequest(), function (data) {
                    data = data.d;
                    self.request().offset(data.offset);
                    if (data.total === 0) {
                        if (showmessage) {
                            toastr.success("No machine found!");
                        }
                        self.machines([]);
                    } else {
                        if (showmessage) {
                            toastr.success("Successfully found" + data.total + " machines!");
                        }
                        self.machines(data.list);
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
                            return self.findMachines(page.offset, false);
                        }
                    }
                };
                return pager.gen(pagerOpts);
            };
        })();

        self.findMachines(0, false);
    }

    $(document).ready(function () {
        ko.components.register('machine-create', {
            viewModel: { require: 'components/machine-create/machinecreate.js' },

            template: { require: 'Scripts/text!components/machine-create/machinecreate.html' }
        });
        ko.applyBindings(new MachineViewModel(dptos), document.getElementById('machines'));

    });
}