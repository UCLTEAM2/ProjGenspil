using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    internal class Employee
    {
        private string employeeName;
        private int employeeID;
        private List<Employee> employeeList;

        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        internal List<Employee> EmployeeList { get => employeeList; set => employeeList = value; }

        public Employee(string employeeName, int employeeID, List<Employee> employeeList)
        {
            EmployeeName = employeeName;
            EmployeeID = employeeID;
            EmployeeList = employeeList;
        }
    }
}
