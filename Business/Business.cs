using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Data;
using Dto;
using Enums;

namespace Business
{
    public class Business
    {
        public IEnumerable<EmployeeDto> GetEmployees(int? employeeId)
        {
            DataAccess data = new DataAccess();
            //getting the serialized object
            var jsonData = data.GetEmployees();
            //deserializing the object
            JavaScriptSerializer js = new JavaScriptSerializer();
            var employees = js.Deserialize<List<EmployeeDto>>(jsonData);
            List<EmployeeDto> employeesResult;

            if (!employeeId.HasValue)
            {
                employeesResult = employees;
            }
            else
            {
                employeesResult = employees.FindAll(x => x.Id == employeeId);
            }

            //Calculating anual salary
            foreach (EmployeeDto employee in employeesResult)
            {
                employee.AnualSalary = CalculateAnualSalary(employee);
            }

            return employeesResult;
        }

        /// <summary>
        /// Calculate the anual salary based on contract type
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public double CalculateAnualSalary(EmployeeDto employee)
        {
            //This method should be private, it was created public for unit test purposes
            double anualSalary = 0;

            if (employee.ContractTypeName == ContractTypes.HourlySalaryEmployee.ToString())
            {
                anualSalary = 120 * employee.HourlySalary * 12;
            }
            else if (employee.ContractTypeName == ContractTypes.MonthlySalaryEmployee.ToString())
            {
                anualSalary = employee.MonthlySalary * 12;
            }

            return anualSalary;
        }
    }
}
