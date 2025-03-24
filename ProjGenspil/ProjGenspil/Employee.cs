using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    internal class Employee
    {
        private string _employeeName;
        private int _employeeID;
        private List<Employee> _employeeList;

        public string EmployeeName { get => _employeeName; set => _employeeName = value; }
        public int EmployeeID { get => _employeeID; set => _employeeID = value; }
        public List<Employee> EmployeeList { get => _employeeList; set => _employeeList = value; }

        public Employee(string employeeName, int employeeID, List<Employee> employeeList)
        {
            EmployeeName = employeeName;
            EmployeeID = employeeID;
            EmployeeList = employeeList;
        }
    }
}
