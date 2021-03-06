﻿var newMachine = { 'model': '', 'name': '', 'serialnumber': '', 'aquisitionDate': "2015-04-27T03:00:00.000Z", 'warrantyExpirationDate': "2015-04-27T03:00:00.000Z", 'id': -1 }
var newUser = { 'firstname': '', 'lastname': '', 'ramal': '', 'dpto': -1, 'role': -1, 'id': -1 }
var newLoan = { 'machine': ko.observable(ko.mapping.fromJS(_.cloneDeep(newMachine))), 'user': ko.observable(ko.mapping.fromJS(_.cloneDeep(newUser))), 'aditional': ko.observable(ko.mapping.fromJS({ 'loanDate': "2015-04-27T03:00:00.000Z" })) }

var machineRequest = { 'model': ko.observable(), 'serialnumber': ko.observable(), 'name': ko.observable(), 'limit': ko.observable(10), 'offset': ko.observable(0) }
var userRequest = { 'firstname': ko.observable(), 'lastname': ko.observable(), 'dpto': ko.observable(), 'ramal': ko.observable(), 'limit': ko.observable(10), 'offset': ko.observable(0) }
var request = { 'limit': 10, 'offset': 0 }

window.jqReady = function () {

    function LoansViewModel(dptos, roles) {
        var self = this;
        self.loanRequest = ko.observable(ko.mapping.fromJS(request))
        self.loans = ko.observableArray([]);
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

        self.isVisible.subscribe(function (bool) {
            if (bool) {
                self.newLoan(ko.mapping.fromJS(newLoan))
            }
        });


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
            self.findMachines(0, true);
        };

        self.selectMachine = function (item) {
            item.warrantyExpirationDate = moment(item.warrantyExpirationDate).toDate();
            item.aquisitionDate = moment(item.aquisitionDate).toDate();
            self.newLoan().machine(ko.mapping.fromJS(item))
        }

        self.searchUsers = function () {
            self.findUsers(0, true);
        };

        self.selectUser = function (item) {
            self.newLoan().user(ko.mapping.fromJS(item))
        };

        self.onSaveClicked = function () {
            self.newLoan().aditional().loanDate(moment(self.newLoan().aditional().loanDate()).toDate())
            $.ajax({
                type: "POST",
                url: "Loans.aspx/saveNewLoan",
                contentType: "application/json; charset=utf-8",
                data: '{"loan": ' + JSON.stringify(ko.mapping.toJS(self.newLoan)) + '}',
                dataType: 'json',
                success: function (response) {
                    self.findLoans(0, false);
                    self.isVisible(false);
                    toastr.success("Successfully created a new loan!");
                },
                failure: function (response) {
                    alert(response);
                },
                error: function (response) {
                    alert(response);
                }
            });
        };

        self.onReturnLoanClicked = function (item) {
            bootbox.confirm("Are you sure you want to return this loan?", function (result) {
                if (result) {
                    $.ajax({
                        type: "POST",
                        url: "Loans.aspx/returnLoan",
                        contentType: "application/json; charset=utf-8",
                        data: '{id: ' + JSON.stringify(item.id) + '}',
                        dataType: 'json',
                        success: function (response) {
                            self.loans(response.d);
                            self.isVisible(false);
                            toastr.success("Loan was successfully returned!");
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

        self.mountRequest = function (obj) {
            return JSON.stringify({ 'request': ko.mapping.toJS(obj) });
        }

        self.findMachines = (function () {
            return function (offset, showmessage) {
                self.machineRequest().offset(offset);
                return utils.postJSON("Machines.aspx/searchMachines", self.mountRequest(self.machineRequest), function (data) {
                    data = data.d;
                    self.machineRequest().offset(data.offset);
                    data.limit = self.machineRequest().limit();
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
                        self.generatePager(data, self, self.findMachines, '#pager-machines');
                    }
                });
            };
        })();

        self.findUsers = (function () {
            return function (offset, showmessage) {
                self.userRequest().offset(offset);
                return utils.postJSON("Users.aspx/searchUsers", self.mountRequest(self.userRequest), function (data) {
                    data = data.d;
                    self.userRequest().offset(data.offset);
                    data.limit = self.userRequest().limit();
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
                        self.generatePager(data, self, self.findUsers, '#pager-users');
                    }
                });
            };
        })();

        self.findLoans = (function () {
            return function (offset, showmessage) {
                self.loanRequest().offset(offset);
                return utils.postJSON("Loans.aspx/searchLoans", self.mountRequest(self.loanRequest), function (data) {
                    data = data.d;
                    self.loanRequest().offset(data.offset);
                    data.limit = self.loanRequest().limit();
                    if (data.total === 0) {
                        if (showmessage) {
                            toastr.success("No loan found!");
                        }
                        self.loans([]);
                    } else {
                        if (showmessage) {
                            toastr.success("Successfully found" + data.total + " loans!");
                        }
                        self.loans(data.list);
                        self.generatePager(data, self, self.findLoans, '#pager-loans');
                    }
                });
            };
        })();

        self.generatePager = (function (self) {
            return function (data, self, searchFunction, pagerId) {
                var pagerOpts;
                pagerOpts = {
                    div: $(pagerId),
                    offset: data.offset,
                    limit: data.limit,
                    total: data.total,
                    onClick: function (e, page) {
                        e.preventDefault();
                        if (page.enabled) {
                            return searchFunction(page.offset, false);
                        }
                    }
                };
                return pager.gen(pagerOpts);
            };
        })();

        self.findLoans(0, false);
    }

    $(document).ready(function () {
        ko.applyBindings(new LoansViewModel(dptos, roles), document.getElementById('loans'));
    });
}
