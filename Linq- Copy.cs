namespace Linq
{
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static void Main()
        {
             bool sel = false;
            do
            {
                Console.WriteLine("Enter Choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        selectMethod();
                        break;

                    case 2:
                        NameOfEmp();
                        break;
                    case 3:
                        SelectEmpNameAndEmpNo();
                        break;
                    case 4:
                        WhereClause();
                        break;
                    case 5:
                        main11();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (sel);
             void selectMethod()
            {
                AddRecs();
                var emps = from emp in lstEmp select emp;
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp);
                }
                Console.WriteLine("Do Again want to perform operation");
                sel=bool.Parse(Console.ReadLine());
            }
             void NameOfEmp()
            {
                AddRecs();
                var emps = from emp in lstEmp select emp.Name;
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp);
                }
                Console.WriteLine("Do Again want to perform operation");
                sel = bool.Parse(Console.ReadLine());
            }
             void SelectEmpNameAndEmpNo()
            {
                AddRecs();
                //var emps = from emp in lstEmp select emp.Name;
                //var emps = from emp in lstEmp select emp.Basic;
                var emps = from emp in lstEmp select new { emp.Name, emp.EmpNo };
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.EmpNo);
                    Console.WriteLine(emp.Name);
                }
                Console.WriteLine("Do Again want to perform operation");
                sel = bool.Parse(Console.ReadLine());
            }
             void WhereClause()
            {
                AddRecs();
                var emps = from emp in lstEmp
                           where emp.Basic > 10000
                           select emp;

                //var emps = from emp in lstEmp
                //           where emp.Basic > 10000 && emp.Basic < 12000
                //           select emp;

                //var emps = from emp in lstEmp
                //           where emp.Name.StartsWith("V")
                //           select emp;
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp);
                }
                Console.WriteLine("Do Again want to perform operation");
                sel = bool.Parse(Console.ReadLine());


            }
             void OrderByClause()
            {
                AddRecs();


                //var emps = from emp in lstEmp
                //           //where emp.Basic > 10000
                //           orderby emp.Name 
                //           select emp;
                //var emps = from emp in lstEmp
                //           orderby emp.Name descending
                //           select emp;

                var emps = from emp in lstEmp
                           orderby emp.DeptNo ascending, emp.Name descending
                           select emp;


                foreach (var emp in emps)
                {
                    Console.WriteLine(emp);
                }

                Console.ReadLine();

            }
             void Join()
            {
                AddRecs();
                var emps = from emp in lstEmp
                           join dept in lstDept
                                 on emp.DeptNo equals dept.DeptNo
                           select emp;

                var emps1 = from emp in lstEmp
                            join dept in lstDept
                                  on emp.DeptNo equals dept.DeptNo
                            select dept;

                var emps2 = from emp in lstEmp
                            join dept in lstDept
                                  on emp.DeptNo equals dept.DeptNo
                            select new { emp, dept };


                var emps3 = from emp in lstEmp
                            join dept in lstDept
                                  on emp.DeptNo equals dept.DeptNo
                            select new { emp.Name, dept.DeptName };

                foreach (var emp in emps2)
                {
                    Console.WriteLine(emp.dept.DeptName);
                    Console.WriteLine(emp.emp.Name);

                }

                foreach (var emp in emps3)
                {
                    Console.WriteLine(emp.Name);
                    Console.WriteLine(emp.DeptName);
                }
                Console.ReadLine();
            }
            void main11()
            {
                var emps = from emp in lstEmp
                           where emp.Name.StartsWith("V")
                           select emp;
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);

                }
            }

        }
    }

        
    
}