using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT
{
    

    public class Employee
    {
        public string No { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 250)
                {
                    throw new Exception("Salary cannot be less than 250");
                }
                salary = value;
            }
        }
        public string DepartmentName { get; set; }
    }

    public class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public decimal SalaryLimit { get; set; }
        public List<Employee> Employees { get; set; }
        public decimal CalcSalaryAverage()
        {
            decimal totalSalary = 0;
            foreach (Employee employee in Employees)
            {
                totalSalary += employee.Salary;
            }
            return totalSalary / Employees.Count;
        }
    }

    public interface IHumanResourceManager
    {
        List<Department> Departments { get; }
        void AddDepartment(string name, int workerLimit, decimal salaryLimit);
        List<Department> GetDepartments();
        void EditDepartment(string name, string newName);
        void AddEmployee(string fullname, string position, decimal salary, string departmentName);
        void RemoveEmployee(string departmentName, string employeeNo);
        void EditEmployee(string employeeNo, string fullname, decimal salary, string position);
    }

    
}


