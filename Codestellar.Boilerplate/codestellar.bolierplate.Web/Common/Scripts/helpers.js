var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('bolierplate');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);