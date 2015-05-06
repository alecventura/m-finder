require.config({
    wrapShim: true,
    baseUrl: "/",
    paths: {},
    shim: {}
});

define([], function () {
    function LayoutViewModel() {
        var self = this;
        self.isUserLogged = (userLogged.toLowerCase() == 'true');
        var ok = _.isString('a');
    }

    $(document).ready(function () {
        ko.applyBindings(new LayoutViewModel(), document.getElementById('menu'));
    });

    if (window.hasOwnProperty('jqReady')) $(function () { window.jqReady(); });
});












//require.config({
//    wrapShim: true,
//    baseUrl: "/",
//    paths: {
//        "bootstrap": "Scripts/bootstrap.min",
//        "jquery": "Scripts/jquery-1.9.1.min",
//        "knockout": "Scripts/knockout-3.3.0",
//        "text": "Scripts/require/text",
//        "knockout.mapping": "Scripts/knockout.mapping-latest",
//        "toastr": "Scripts/toastr",
//        "underscore": "Scripts/lodash",
//        "knockout-withComponent": "Scripts/knockout-withComponent",
//        "knockout-bindings-modal": "Scripts/knockout-bindings-modal",
//        "knockout-bindings-toggle": "Scripts/knockout-bindings-toggle",
//        "knockout-bindings-pickadate": "Scripts/knockout-bindings-pickadate",
//        "picker": "Scripts/pickadate/picker",
//        "picker.date": "Scripts/pickadate/picker.date",
//        "picker.time": "Scripts/pickadate/picker.time",
//        "picker.legacy": "Scripts/pickadate/legacy"
//    },
//    shim: {
//        "jquery": {
//            exports: '$'
//        },
//        "underscore": {
//            deps: ["jquery"],
//            exports: '_'
//        },
//        "bootstrap": {
//            deps: ["jquery"]
//        },
//        "knockout": {
//            deps: ["jquery"]
//        },
//        "knockout.mapping": {
//            deps: ["knockout"]
//        },
//        "toastr": {
//            deps: ["jquery"]
//        },
//        "knockout-withComponent": {
//            deps: ["knockout"]
//        },
//        "knockout-bindings-modal": {
//            deps: ["knockout"]
//        },
//        "knockout-bindings-toggle": {
//            deps: ["knockout"]
//        },
//        "knockout-bindings-pickadate": {
//            deps: ["knockout-withComponent"]
//        },
//        "picker": {
//            deps: ["jquery"]
//        },
//        "picker.date": {
//            deps: ["picker"]
//        },
//        "picker.time": {
//            deps: ["picker"]
//        },
//        "picker.legacy": {
//            deps: ["picker"]
//        }
//    }
//});
