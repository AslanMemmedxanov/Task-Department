using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT
{
    public class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> Departments { get; private set; }

        public HumanResourceManager()
        {
            Departments = new List<Department>();
        }

        public void AddDepartment(string name, int workerLimit, decimal salaryLimit)
        {
            Department department = new Department();
            department.Name = name;
            department.WorkerLimit = workerLimit;
            department.SalaryLimit = salaryLimit;
            department.Employees = new List<Employee>();
            Departments.Add(department);
        }

        public List<Department> GetDepartments()
        {
            return Departments;
        }

        public void EditDepartment(string name, string newName)
        {
            Department department = Departments.Find(d => d.Name == name);
            if (department == null)
            {
                throw new Exception("Department not found");
            }
            department.Name = newName;
        }

        public void AddEmployee(string fullname, string position, decimal salary, string departmentName)
        {
            Department department = Departments.Find(d => d.Name == departmentName);
            if (department == null)
            {
                throw new Exception("Department not found");
            }
            Employee employee = new Employee();
            employee.No = department.Name.Substring(0, 2).ToUpper() + (department.Employees.Count + 1000).ToString().Substring(1);
            employee.Fullname = fullname;
            employee.Position = position;
            employee.Salary = salary;
            employee.DepartmentName = departmentName;
            department.Employees.Add(employee);
        }

        public void RemoveEmployee(string departmentName, string employeeNo)
        {
            Department department = Departments.Find(d => d.Name == departmentName);
            if (department == null)
            {
                throw new Exception("Department not found");
            }
            Employee employee = department.Employees.Find(e => e.No == employeeNo);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            department.Employees.Remove(employee);
        }

        public void EditEmployee(string employeeNo, string fullname, decimal salary, string position)
        {
            Employee employee = null;
            foreach (Department department in Departments)
            {
                employee = department.Employees.Find(e => e.No == employeeNo);
                if (employee != null)
                {
                    break;
                }
            }
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            employee.Fullname = fullname;
            employee.Salary = salary;
            employee.Position = position;
        }
    }
}
