namespace ArrayAssignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] arr = new Employee[5];
            for(int i=0;i<arr.Length;i++)
            {
                Console.WriteLine("Enter the id of {0} employee", i);
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the name of {0} employee", i);
                string name = Console.ReadLine();
                Console.WriteLine("Enter the salary of {0} employee", i);
                int salary = Convert.ToInt32(Console.ReadLine());
                arr[i] = new Employee(id,name,salary);
            }
           for(int i=0;i<arr.Length;i++)
            {
                Console.WriteLine("the name of Employee={1} and id={0} ", arr[i].id, arr[i].name, arr[i].salary);
            }
           
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("the name of Employee={1} and id={0} ", arr[i].id, arr[i].name, arr[i].salary);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter the id of Employee tobe search");
            int x = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<arr.Length;i++)
            {
                if (x == arr[i].id)
                {
                    Console.WriteLine("The Details of Employe of id {0}", x);
                    Console.WriteLine("Id={0} name={1} salary={2}", arr[i].id, arr[i].name, arr[i].salary);
                }
            }
        }

        /*static void Main5()
        {
            Employee[] arr = new Employee[5];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Employee();

                Console.WriteLine(arr[i].EmpNo);
                Console.WriteLine(arr[i].Name);
            }
            foreach (Employee item in arr)
            {
                //item = new Employee();
                item.EmpNo = 10;
                Console.WriteLine(item.EmpNo);
            }
        }*/

    }
    public class Employee
    {
        public int id;
        public string name;
        public int salary;
        public Employee(int id, string name,int salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
       
    }
}