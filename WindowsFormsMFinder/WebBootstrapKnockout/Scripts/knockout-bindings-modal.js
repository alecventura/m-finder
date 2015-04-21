ko.bindingHandlers.isVisible = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var $element = $(element),
            value = valueAccessor();
        if (typeof value !== 'undefined') {
            $(element).modal(!ko.unwrap(value) ? 'hide' : 'show');
        }
    },
    update: function (element, valueAccessor) {
        var value = valueAccessor();

        if (typeof value !== 'undefined') {
            $(element).modal(!ko.unwrap(value) ? 'hide' : 'show');
        }
    }

};