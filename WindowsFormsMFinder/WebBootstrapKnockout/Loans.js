var newMachine = { 'model': '', 'name': '', 'serialnumber': '', 'aquisitionDate': "2015-04-27T03:00:00.000Z", 'warrantyExpirationDate': "2015-04-27T03:00:00.000Z", 'id': -1 }
var newUser = { 'firstname': '', 'lastname': '', 'ramal': '', 'dpto': -1, 'role': -1, 'id': -1 }
var newLoan = { 'machine': ko.observable(ko.mapping.fromJS(_.cloneDeep(newMachine))), 'user': ko.observable(ko.mapping.fromJS(_.cloneDeep(newUser))), 'aditional': ko.observable(ko.mapping.fromJS({ 'loanDate': "2015-04-27T03:00:00.000Z" })) }

var machineRequest = { 'model': ko.observable(), 'serialnumber': ko.observable(), 'name': ko.observable() }
var userRequest = { 'firstname': ko.observable(), 'lastname': ko.observable(), 'dpto': ko.observable(), 'ramal': ko.observable() }

window.jqReady = function () {

    function LoansViewModel(loansJSON, dptos, roles) {
        var self = this;
        self.loans = ko.observableArray(loansJSON);
        self.dptos = ko.observableArray(dptos)
        self.roles = ko.observableArray(roles)
        self.loans.subscribe(function (array) {
            self.setLabels(array);
        });

        self.newLoan = ko.observable(ko.mapping.fromJS(newLoan))

        // Wizard Logic
        self.hasChangedTab = ko.observable(false);
        self.isFinalStep = ko.computed(function () {
            self.hasChangedTab();
            return $('#aditionalInfo').hasClass('active');
        });
        self.canGoNext = ko.computed(function () {
            var canChange = false;
            self.hasChangedTab();
            //self.newLoan();
            //self.newLoan().machine();
            //self.newLoan().user();
            if (self.newLoan().machine().id() != null && self.newLoan().machine().id() > 0) {
                canChange = $('#machine').hasClass('active');
            }
            if (self.newLoan().user().id() != null && self.newLoan().user().id() > 0 && !canChange) {
                canChange = $('#user').hasClass('active');
            }
            return canChange;
        });

        // Machines Logic
        self.machines = ko.observableArray();
        self.machines.subscribe(function (array) {
            self.setsLabels(array);
        });
        self.setsLabels = function (array) {
            _.each(array, function (item) {
                item.aquisitionDateText = moment(item.aquisitionDate).format('L');
                item.warrantyExpirationDateText = moment(item.warrantyExpirationDate).format('L');
            })
        };
        self.hasSelectedMachine = ko.computed(function () {
            return self.newLoan().machine().id() != null && self.newLoan().machine().id() > 0;
        });

        // Users Logic
        self.users = ko.observableArray();
        self.users.subscribe(function (array) {
            self.setUsersLabels(array);
        });
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
        self.hasSelectedUser = ko.computed(function () {
            return self.newLoan().user().id() != null && self.newLoan().user().id() > 0;
        });

        // Request objects
        self.machineRequest = ko.observable(_.cloneDeep(machineRequest));
        self.userRequest = ko.observable(_.cloneDeep(userRequest));

        self.isVisible = ko.observable(false);

        //self.isVisible.subscribe(function (bool) {
        //    if (bool) {
        //        var desiredWidth = $(window).width() * 0.8;
        //        var desiredHeight = $(window).height() * 0.8;
        //        var desiredMargin = $(window).height() * 0.2;

        //        $('.modal-dialog', '.modal').css('width', (desiredWidth));
        //        $('.modal-dialog', '.modal').css('height', (desiredHeight));
        //        $('.modal-dialog', '.modal').css('margin-left', (desiredMargin));
        //    }
        //});


        self.setLabels = function (array) {
            _.each(array, function (item) {
                dptoObj = _.find(self.dptos(), function (dpto) {
                    return item.userDpto == dpto.id;
                })
                item.dptoText = ko.observable(dptoObj.name);
                item.loanDateText = moment(item.loanDate).format('L');
            })
        };

        self.setLabels(self.loans());

        $(document).ready(function () {
            $('#rootwizard').bootstrapWizard({
                'nextSelector': '.button-next',
                'previousSelector': '.button-previous',
                'isModal': true,
                onTabChange: function (tab, navigation, index) {
                    self.hasChangedTab(!self.hasChangedTab());
                }
            });
        });

        self.changeUser = function () {
            self.newLoan().user(ko.mapping.fromJS(newUser))
        }

        self.changeMachine = function () {
            self.newLoan().machine(ko.mapping.fromJS(newMachine))
        }

        self.searchMachines = function () {
            $.ajax({
                type: "POST",
                url: "Loans.aspx/searchMachines",
                contentType: "application/json; charset=utf-8",
                data: '{machineRequest: ' + JSON.stringify(ko.mapping.toJS(self.machineRequest)) + '}',
                dataType: 'json',
                success: function (response) {
                    self.machines(response.d);
                    toastr.success("TODO!");
                },
                failure: function (response) {
                    alert(response);
                },
                error: function (response) {
                    alert(response);
                }
            });
        };

        self.selectMachine = function (item) {
            item.warrantyExpirationDate = moment(item.warrantyExpirationDate).toDate();
            item.aquisitionDate = moment(item.aquisitionDate).toDate();
            self.newLoan().machine(ko.mapping.fromJS(item))
        }

        self.searchUsers = function () {
            $.ajax({
                type: "POST",
                url: "Loans.aspx/searchUsers",
                contentType: "application/json; charset=utf-8",
                data: '{userRequest: ' + JSON.stringify(ko.mapping.toJS(self.userRequest)) + '}',
                dataType: 'json',
                success: function (response) {
                    self.users(response.d);
                    toastr.success("TODO!");
                },
                failure: function (response) {
                    alert(response);
                },
                error: function (response) {
                    alert(response);
                }
            });
        };

        self.selectUser = function (item) {
            self.newLoan().user(ko.mapping.fromJS(item))
        };

        self.onSaveClicked = function () {
            $.ajax({
                type: "POST",
                url: "Loans.aspx/saveNewLoan",
                contentType: "application/json; charset=utf-8",
                data: '{loan: ' + JSON.stringify(ko.mapping.toJS(self.newLoan)) + '}',
                dataType: 'json',
                success: function (response) {
                    self.loans(response.d);
                    self.isVisible(false);
                    toastr.success("TODO!");
                },
                failure: function (response) {
                    alert(response);
                },
                error: function (response) {
                    alert(response);
                }
            });
        };
    }

    $(document).ready(function () {
        ko.applyBindings(new LoansViewModel(loansJSON, dptos, roles), document.getElementById('loans'));
    });
}
