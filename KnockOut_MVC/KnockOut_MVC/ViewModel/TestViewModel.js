$(document).ready(function () {

    IntializeTest();
    GetCountryInformation();
});


function TestViewModel() {
    var that = this;    

    that.ID = ko.observable("");
    
    that.CountryList = ko.observableArray();
                   //$.ajax({
                   //    type: "GET",
                   //    url: "/Employee/GetCountryInformation",
                   //    //contentType: "application/json; charset=utf-8",
                   //    dataType: "json",
                   //    success: function (data) {
                   //        debugger;
                   //        //for (var i = 0; i < data.CountryList.length; i++) {
                   //        //    [{
                   //        //        name: data.CountryList[i].Key,
                   //        //        selected: data.CountryList[i].Value
                   //        //    }]                                
                   //        //}
                   //        //BindCountryData(data);
                   //        //  Employees = getDataInArray(data); 
                   //        //Employees = data;
                   //        //self.Data(data);
                   //    },
                   //    error: function (err) {
                   //        alert("Error : " + err.status + "   " + err.statusText);
                   //    }
                   //});    
    //[
    //    { name: 'India', selected: true },
    //    { name: 'UK', selected: false },
    //    { name: 'Germany', selected: false },
    //    { name: 'Japan', selected: false }
    //]
    
    //using javascript
    that.selectedItems = function () {
        var selectedItems = [];
        for (var i = 0, len = that.CountryList.length; i < len; i++) {
            if (that.CountryList[i].selected) {
                selectedItems.push(that.CountryList[i]);
            }
        }
        return selectedItems;
    }

    //using knockout utils
    //that.selectedItemsKO = function () {
    //    return ko.utils.arrayFilter(that.CountryList, function (CountryList) {
    //        return CountryList.selected;
    //    });
    //};
}

//Intialize Employee
function IntializeTest() {    
    testViewModel = new TestViewModel();
    ko.applyBindings(testViewModel);

}

function GetCountryInformation()
{
    //var jqxhr = $.getJSON("/Employee/GetCountryInformation", function (result) {
    //    //alert("Function Called");
    //    debugger;
    //    BindCountryData(result);
    //}).done(function (result) {
    //    // some action to be performed
    //})
    //    .fail(function (result, textStatus, error) {
    //        debugger;
    //        var err = textStatus + ", " + error;
    //        alert("Request Failed: " + err);
    //    });

    $.ajax({
        type: "GET",
        url: "/Employee/GetCountryInformation",
        //contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {           
            BindCountryData(data);
            //  Employees = getDataInArray(data); 
            //Employees = data;
            //self.Data(data);
        },
        error: function (err) {            
            alert("Error : " + err.status + "   " + err.statusText);
        }
    });
}

function BindCountryData(result)
{
    testViewModel.ID(result.ID);
    testViewModel.CountryList(result.CountryList);
}