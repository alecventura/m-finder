function LoansViewModel(loansJSON, dptos) {
    var self = this;
    self.loans = ko.observableArray(loansJSON);
    self.dptos = ko.observableArray(dptos)
    self.loans.subscribe(function (array) {
        self.setLabels(array);
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
}

$(document).ready(function () {
    ko.applyBindings(new LoansViewModel(loansJSON, dptos), document.getElementById('loans'));
    self.dptos = ko.observableArray(dptos)
});