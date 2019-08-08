$(document).ready(function () {
    $("#btnGetEmployee").on("click", getEmployees)
});

function getEmployees() {
    let employeeId = $("#employeeId").val();
    let url = "api/Employee/GetEmployees";
    if (employeeId != "") {
        url = url + "?employeeId=" + employeeId;
    }

    $.ajax({
        url: url,
        contentType: "application/json",
        dataType: 'json',
    }).done(function (result) {
        bindGrid(result);
    }).fail(function (result) {
        alert(result.responseJSON.Message);
    });
}

function bindGrid(employeesData) {
    $("#grid").kendoGrid({
        dataSource: {
            data: employeesData
        },
        height: 550,
        groupable: true,
        sortable: true,   
        noRecords: {
            template: "No records found."
        },
        columns: [
            {
                field: "Id",
                title: "Employee Id",
                attributes: { style: "text-align:center;" }
            },
            {            
                field: "Name",
                title: "Name",
            },            
            {
                field: "RoleName",
                title: "Role"
            },
            {
                field: "ContractTypeName",
                title: "Contract Type"
            },
            {
                field: "HourlySalary",
                title: "Hourly Salary",
                format: "{0:c2}",
                attributes: { style: "text-align:right;" }
            },
            {
                field: "MonthlySalary",
                title: "Monthly Salary",
                format: "{0:c2}",
                attributes: { style: "text-align:right;" }
            },
            {
                field: "AnualSalary",
                title: "Anual Salary",
                format: "{0:c2}",
                attributes: { style: "text-align:right;" }
            }
        ]
    });
}