var Codestellar;
(function (Codestellar) {
    var TypewriterDemo;
    (function (TypewriterDemo) {
        var TypeScriptTemplates;
        (function (TypeScriptTemplates) {
            // $Classes/Enums/Interfaces(filter)[template][separator]
            // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
            // template: The template to repeat for each matched item
            // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]
            // More info: http://frhagn.github.io/Typewriter/
            var CustomerModel = (function () {
                function CustomerModel() {
                    // ID
                    this.id = 0;
                    // NAME
                    this.name = null;
                    // ORDERS
                    this.orders = [];
                }
                return CustomerModel;
            }());
            TypeScriptTemplates.CustomerModel = CustomerModel;
        })(TypeScriptTemplates = TypewriterDemo.TypeScriptTemplates || (TypewriterDemo.TypeScriptTemplates = {}));
    })(TypewriterDemo = Codestellar.TypewriterDemo || (Codestellar.TypewriterDemo = {}));
})(Codestellar || (Codestellar = {}));
//# sourceMappingURL=CustomerModel.js.map