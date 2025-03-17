using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    internal class Employee
    {
        private int employeeName;
        private char employeeID;
        private List<Employee> employeeList;

        public int EmployeeName { get => employeeName; set => employeeName = value; }
        public char EmployeeID { get => employeeID; set => employeeID = value; }
        internal List<Employee> EmployeeList { get => employeeList; set => employeeList = value; }
    }
}
