function LayoutViewModel() {
    var self = this;
    self.isUserLogged = (userLogged.toLowerCase() == 'true');
}

$(document).ready(function () {
    ko.applyBindings(new LayoutViewModel(), document.getElementById('menu'));
});