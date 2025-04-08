namespace ProjGenspil
{
    class Employee
    {
        private string _employeeName;
        private int _employeeID;
        private List<Employee> _employeeList;

        public string EmployeeName { get => _employeeName; set => _employeeName = value; }
        public int EmployeeID { get => _employeeID; set => _employeeID = value; }
        public List<Employee> EmployeeList { get => _employeeList; set => _employeeList = value; }

        public Employee(string employeeName, int employeeID)
        {
            EmployeeName = employeeName;
            EmployeeID = employeeID;

        }
    }
}
