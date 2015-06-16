$(document).ready(function () {

    IntializeEmployee();
    GetEmployeeInformation();    
});




function EmployeeViewModel() {
    var that = this;
    //that.Employee = new Employee();
    that.FirstName = ko.observable("");
    that.LastName = ko.observable("");
    that.FullName = ko.computed(function () {
        return that.FirstName() + " " + that.LastName();
    });
    that.DateOfBirth = ko.observable("");
    that.EMail = ko.observable("");
    //that.EducationList = ko.observableArray();
    that.Gender = ko.observable("0");
    that.DivisionList = ko.observableArray();
    //that.Division = ko.observable();
    //that.ExpertiseList = ko.observableArray([{ Id: '0', Name: "Java" }, { Id: '1', Name: "ASP.Net" }]);
    that.ExpertiseId = ko.observable("");
    that.MobileNumber = ko.observable("");
    that.Graduation = ko.observable("");
    that.PostGraduation = ko.observable("");    
    //that.Employee = new EmployeeViewModel();
    that.Submit = function () {
        var postData = ko.toJSON(this);
    //    //var postData = {firstName:this.FirstName()};
    //    $.getJSON("/Employee/SaveEmployee",postData, function (result) {
    //        alert("Save");
    //        BindEmployeeData(result);
    //    }).done(function (result) {
    //        // some action to be performed
    //    })
    //.fail(function (result, textStatus, error) {
    //    var err = textStatus + ", " + error;
    //    alert("Request Failed: " + err);
    //});
        $.ajax({
            url: "http://localhost:5050/api/employeesave",
            type: 'POST',
            dataType: 'json',
            data: postData,
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                alert("Save");
                var message = data.Message;
            }
        });
    };

    that.Reset = function () {
        $.ajax({
            url: '/Employee/NewEmployee',
            type: 'POST',
            dataType: 'json',
            //data: postData,
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                alert("New");
                var message = data.Message;
            }
        });
    };
}

//Intialize Employee
function IntializeEmployee()
{
    employeeViewModel = new EmployeeViewModel();
    ko.applyBindings(employeeViewModel);

}


function GetEmployeeInformation() {

    $.ajax({
        //type: "GET",
        //url: "http://localhost:5050/api/employee",
        url: '/Employee/GetEmployeeInformation',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {            
            BindEmployeeData(data);
            //  Employees = getDataInArray(data); 
            //Employees = data;
            //self.Data(data);
        },
        error: function (err) {
            debugger;
            alert("Error : " + err.status + "   " + err.statusText);
        }
    });

    //var jqxhr = $.getJSON("/Employee/GetEmployeeInformation", function (result) {
    //debugger;
    //var jqxhr = $.getJSON("http://192.168.31.44:5050/api/employee", function (result) {
    //    //alert("Function Called");
    //    debugger;
    //    BindEmployeeData(result);
    //}).done(function (result) {
    //    // some action to be performed
    //})
    //    .fail(function (result, textStatus, error) {
    //        debugger;
    //        var err = textStatus + ", " + error;
    //        alert("Request Failed: " + err);
    //    });
}

//Bind data to respected controlls
function BindEmployeeData(result)
{
    employeeViewModel.FirstName(result.FirstName);
    employeeViewModel.LastName(result.LastName);
    employeeViewModel.EMail(result.EMail);
    employeeViewModel.DateOfBirth(result.DateOfBirth);
    employeeViewModel.Gender(result.Gender);
    employeeViewModel.MobileNumber(result.MobileNumber);
    employeeViewModel.ExpertiseId(result.ExpertiseId);
    employeeViewModel.Graduation(result.Graduation);
    employeeViewModel.PostGraduation(result.PostGraduation);
    employeeViewModel.DivisionList(result.DivisionList);
}