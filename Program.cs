namespace DEPARTMENT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHumanResourceManager hrManager = new HumanResourceManager();

           
            hrManager.AddDepartment("HR", 10, 10000);
            hrManager.AddDepartment("Finance", 5, 50000);

            hrManager.AddEmployee("Safarov Samir", "MapCreator", 5000, "HR");
            hrManager.AddEmployee("Xalid Memmedov", "Devoloper", 3000, "HR");

            foreach (Department department in hrManager.Departments)
            {
                Console.WriteLine($"Department: {department.Name}");
                Console.WriteLine($"Worker limit: {department.WorkerLimit}");
                Console.WriteLine($"Salary limit: {department.SalaryLimit}");
                Console.WriteLine($"Average salary: {department.CalcSalaryAverage()}");

                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine($"Employee no: {employee.No}");
                    Console.WriteLine($"Fullname: {employee.Fullname}");
                    Console.WriteLine($"Position: {employee.Position}");
                    Console.WriteLine($"Salary: {employee.Salary}");
                }
            }
        }
    }
}
    