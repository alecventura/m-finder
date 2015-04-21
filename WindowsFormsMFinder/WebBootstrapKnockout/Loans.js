function LoansViewModel(loansJSON) {
    var self = this;
    self.loans = ko.observableArray(loansJSON);
}

$(document).ready(function () {
    ko.applyBindings(new LoansViewModel(loansJSON), document.getElementById('loan'));
});