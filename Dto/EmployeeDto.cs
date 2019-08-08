using System;
using System.Runtime.Serialization;

namespace Dto
{
    [DataContract]
    public class EmployeeDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ContractTypeName { get; set; }

        [DataMember]
        public string RoleId { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public double HourlySalary { get; set; }

        [DataMember]
        public double MonthlySalary { get; set; }

        [DataMember]
        public double AnualSalary { get; set; }

    }
}
