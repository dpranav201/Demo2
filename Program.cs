namespace EmployeeAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool sel = true;
            Console.WriteLine("1 for General Manager 2 for Manger 3 for CEO");
            do
            {
                
                Console.WriteLine("Enter Your Choice");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch(choice) 
                {
                    case 1: Console.WriteLine("Enter the Name");
                        string name=Console.ReadLine();
                        Console.WriteLine("Insert Basic Salary");
                        decimal basic=Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter the Deptno");
                        short deptno=Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Enter Departm");
                        string deptname=Console.ReadLine();
                        Console.WriteLine("enter tyhe perks");
                        string perks=Console.ReadLine();
                        GeneralManager m=new GeneralManager(name,deptno,deptname,perks,basic);
                        PrintfGM(m);
                        Console.WriteLine("enter true or false");
                        m.insert();
                        sel =Convert.ToBoolean(Console.ReadLine());
                        

                        break;
                        /*GeneralManager m = new GeneralManager("parag", 10, "GM", "ABC", 50000);
                        Console.WriteLine(m.Name);
                        Console.WriteLine(m.EmpNo);
                        Console.WriteLine(m.Basic);
                        Console.WriteLine(m.DeptNo);
                        Console.WriteLine(m.Designation);
                        Console.WriteLine(m.Perks);
                        Console.WriteLine(m.CalcNetSalary());
                        m.insert();*/
                }

            }while(sel);
            static void PrintfGM(GeneralManager m)
            {
                Console.WriteLine(m.Name);
                Console.WriteLine(m.EmpNo);
                Console.WriteLine(m.Basic);
                Console.WriteLine(m.DeptNo);
                Console.WriteLine(m.Designation);
                Console.WriteLine(m.Perks);
                Console.WriteLine(m.CalcNetSalary());
            }
             
        }
        public interface IDbf
        {
            void insert();
            void delete();
            void update();

        }
        public abstract class Employee : IDbf
        {
            public string Name { set; get; }
            public static int empno = 1;

            public abstract decimal Basic { set; get; }
            protected decimal basic;
            public short DeptNo { set; get; }
            public int EmpNo { get; set; }

            public static int NextEmpNo
            {

                get { return empno++; }
            }
            public abstract decimal CalcNetSalary();

            public void insert()
            {
                Console.WriteLine("insert employee");
            }

            public void delete()
            {
                Console.WriteLine("delete employee");
            }

            public void update()
            {
                Console.WriteLine("update employee");
            }

            public Employee(string name = "", decimal basic = 0, short deptno = 0)
            {


                Name = name;
                DeptNo = deptno;
                EmpNo = NextEmpNo;

            }

        }
        class Manager : Employee
        {

            public string Designation { get; set; }
            // private decimal basic;
            public Manager() : base()
            {
            }

            public Manager(string name = "", short deptNo = 0, string designation = "", decimal basic = 0) : base(name, deptNo)
            {
                if (name == "")
                {
                    Console.WriteLine("Invalid Input");

                }
                if (basic <= 0)
                {
                    Console.WriteLine("Invalid Input");
                }
                if (deptNo <= 0)
                {
                    Console.WriteLine("Invalid Input");
                }

                DeptNo = deptNo;
                Designation = designation;

                Basic = basic;

            }

            public Manager(string name = "", short deptNo = 0, string designation = "")
            {

                Name = name;
                DeptNo = deptNo;
                Designation = designation;
            }

            public override decimal Basic
            {
                set
                {
                    if (value > 30000)
                    {
                        basic = value;
                    }
                    else
                    {
                        Console.WriteLine("Increase the salary of manager");

                    }
                }
                get { return basic; }
            }

            public override decimal CalcNetSalary()
            {
                // Logic to calculate net salary goes here
                basic = basic + 1000;
                return basic;

            }

        }

        class GeneralManager : Manager
        {
            public string Perks { get; set; }
            //  private decimal basic;

            public GeneralManager() : base()
            {
            }

            public GeneralManager(string name = "", short deptNo = 0, string designation = "", string perks = "", decimal basic = 0) : base(name, deptNo, designation)
            {
                if (name == "")
                {
                    Console.WriteLine("Invalid Input");

                }
                if (basic <= 0)
                {
                    Console.WriteLine("Invalid Input");
                }
                if (deptNo <= 0)
                {
                    Console.WriteLine("Invalid Input");
                }
                Perks = perks;
                Basic = basic;
            }

            public override decimal Basic
            {
                set
                {
                    if (value > 40000)
                    {
                        basic = value;

                    }
                    else
                    {
                        Console.WriteLine("Increase the salary of General manager");

                    }


                }
                get { return basic; }
            }

            public override decimal CalcNetSalary()
            {
                // Logic to calculate net salary goes here
                basic = basic + 3000;
                return basic;
            }
        }

        class CEO : Employee
        {

            // private decimal basic;
            public CEO() : base()
            {
            }

            public CEO(string name = "", short deptNo = 0, decimal basic = 0) : base(name, deptNo)
            {
                DeptNo = deptNo;
                Basic = basic;
            }

            public override decimal Basic
            {
                set
                {
                    if (value > 50000)
                    {
                        basic = value;
                    }
                    else
                    {
                        Console.WriteLine("Increase the salary of manager");

                    }




                }
                get { return basic; }
            }

            public sealed override decimal CalcNetSalary()
            {
                // Logic to calculate net salary goes here
                basic = basic + 5000;
                return basic;
            }



        }
    }
}