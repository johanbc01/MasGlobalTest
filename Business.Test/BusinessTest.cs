using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Dto;

namespace Business.Test
{
    [TestClass]
    public class BusinessTest
    {
        [TestMethod]
        public void TestCalculateAnualSalary()
        {
            Business bus = new Business();
            EmployeeDto emp = new EmployeeDto
            {
                Id = 1,
                ContractTypeName = "MonthlySalaryEmployee",
                MonthlySalary = 1000
            };
            double anualSalary = bus.CalculateAnualSalary(emp);
            Assert.AreEqual(anualSalary, 12000);
        }
    }
}
