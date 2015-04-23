ko.bindingHandlers.pickadate = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var element;
        var options = ko.utils.unwrapObservable(valueAccessor()) || {};
        element = $(element).pickadate(options);
        element.pickadate('picker').clear()
    },
    update: function (element, valueAccessor) {
        var $e, picker, current, dateval, format, localdate, obs;
        $e = $(element);
        obs = valueAccessor();
        format = "MMMM D, YYYY";
        dateval = ko.utils.unwrapObservable(obs);
        //current = moment.utc($e.val());
        picker = $e.data('pickadate');
        $e.parent("li, .control-group").removeClass('error');
        if (!dateval || dateval < 0) {
            $e.val('');
            return;
        }
        if (_.isString(dateval)) {
            dateval = moment.utc(dateval);
            obs(dateval.toDate());
        }
        if (_.isDate(dateval)) {
            dateval = moment.utc(dateval);
        }
        if (dateval === current && current && dateval.format(format) === current.format(format)) {
            return;
        }
        picker.set('select', obs())
        //$e.val(localdate.format(format));
    }
};