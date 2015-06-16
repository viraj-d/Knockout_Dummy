/// <reference path="jQuery-1.4.4.js"/>
/// <reference path="jquery.templ.js"/>
/// <reference path="knockout-1.1.1.js"/>

var viewModel = {
    availableProducts: ko.observableArray([]),
    availableSelected: ko.observableArray([]),
    requestedProducts: ko.observableArray([]),
    requestedSelected: ko.observableArray([]),                                    
    addRequested: function(){
        var requested = this.requestedProducts;
        $.each(this.availableSelected(), function(n, item) {
            requested.push(item);
        });
        this.availableProducts.removeAll(this.availableSelected());
        this.availableSelected.splice(0,this.availableSelected().length);
    },            
    removeRequested: function(){
        var available = this.availableProducts;
        $.each(this.requestedSelected(), function(n, item) {
            available.push(item);
        });
        this.requestedProducts.removeAll(this.requestedSelected());
        this.requestedSelected.splice(0,this.requestedSelected().length);
    },
    onSubmit: function(){                
        var ids = [];
        $.each(this.requestedProducts(), function(n, item) {
            ids.push(item.Id);
        });
        $("#SavedRequested").val(ids.join());
        return true;
    }
};

viewModel.requestedTotal = ko.dependentObservable(function() {
    var total = 0;
    $.each(this.requestedProducts(), function(n, item) {
        total = total + item.Price;
    });
    return total;
}, viewModel)

viewModel.canSubmit = ko.dependentObservable(function() {    
    return this.requestedProducts().length > 0 && this.requestedProducts().length <= 3 && this.requestedTotal() <= 400;
}, viewModel);  

$(function() {
    $.ajax({
        url: "/GetProductList/",
        type: "post",
        success: function(data) {
            viewModel.availableProducts = ko.observableArray(data);
            SetupBindings();
        }
    });
});

function SetupBindings() {
    $("#AvailableSelected").attr("data-bind", "options:availableProducts, selectedOptions:availableSelected, optionsText:'Name'");
    $("#RequestedSelected").attr("data-bind", "options:requestedProducts, selectedOptions:requestedSelected, optionsText:'Name'");
    $("#tableBody").attr("data-bind", "template: { name: 'requestedTemplate', foreach: requestedProducts }");
    $("#total").attr("data-bind", "text:requestedTotal");
    $("#add").attr("data-bind", "click:addRequested, enable:availableSelected().length > 0");
    $("#remove").attr("data-bind", "click:removeRequested, enable:requestedSelected().length > 0");
    $("#send").attr("data-bind", "enable:canSubmit");
    $("form").attr("data-bind", "submit:onSubmit");
    
    //create the script element for the template
    //instead of hardcoding could fetch this through ajax or something
    $("body").after('<script type="text/html" id="requestedTemplate"><tr><td>${Name}</td><td>${Description}</td><td>${Price}</td></tr></script>');
    ko.applyBindings(viewModel);
}