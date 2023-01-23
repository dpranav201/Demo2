using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUDOps1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int empno;
            string name;
            decimal basic;
            int deptno;
            int selection;
            do
            {
                Display();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Insert data");
                Console.WriteLine("2. Update data");
                Console.WriteLine("3. Delete data");
                Console.WriteLine("4. Display data");
                Console.WriteLine("5. Exit");

                selection = int.Parse(Console.ReadLine());
                Employee obj;
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Enter empno:");
                        empno = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter basic:");
                        basic = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter deptno:");
                        deptno = int.Parse(Console.ReadLine());


                        obj = new Employee { EmpNo = empno, Name = name, Basic = basic, DeptNo = deptno };
                        InsertData(obj);
                        break;
                    case 2:
                        Console.WriteLine("Enter empno you want to update:");
                        empno = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter basic:");
                        basic = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter deptno:");
                        deptno = int.Parse(Console.ReadLine());


                        obj = new Employee { EmpNo = empno, Name = name, Basic = basic, DeptNo = deptno };

                        UpdateData(obj);
                        break;
                    case 3:
                        Console.WriteLine("Enter empno you want to delete:");
                        empno = int.Parse(Console.ReadLine());

                        DeleteData(empno);
                        break;
                    case 4:
                        // Console.WriteLine("display database");
                        Display();
                        break;
                    case 5:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            } while (selection != 5);

        }
        static void InsertData(Employee obj)
        {
            // Insert data code here
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=thane;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertEmployeeWithStored";
                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                // Never Write code in this pattern.
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Successfully inserted");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally { cn.Close(); }


        }
        static void UpdateData(Employee obj)
        {
            // Update data code here
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=thane;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;

                cmdInsert.CommandText = "UpdateEmployee";
                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                // Never Write code in this pattern.
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Successfully updated");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally { cn.Close(); }

        }
        static void DeleteData(int i)
        {
            // Delete data code here
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=thane;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "DeleteEmployee";
                cmdInsert.Parameters.AddWithValue("@EmpNo", i);
                //cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                //cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                //cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                // Never Write code in this pattern.
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("deleted record successfully");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally { cn.Close(); }

        }
        static void Display()
        {
            DataSet ds;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                ds = new DataSet();

                cmd.CommandText = "select * from Employees";
                da.Fill(ds, "Emps");

                cmd.CommandText = "select * from Departments";
                da.Fill(ds, "Deps");

                //primary key constraint
                DataColumn[] arrCols = new DataColumn[1];
                arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"];
                ds.Tables["Emps"].PrimaryKey = arrCols;


                //foreign key constraint
                ds.Relations.Add(ds.Tables["Deps"].Columns["DeptNo"],
                    ds.Tables["Emps"].Columns["DeptNo"]);

                //column level constraint
                ds.Tables["Deps"].Columns["DeptName"].Unique = true;

                //dataGridView1.DataSource = ds.Tables[0];
                // dataGridView1.DataSource = ds.Tables["Emps"];
                //dataGridView1.DataSource = ds.Tables["Deps"];
                // Console.WriteLine("----------------------------------------------------");
                foreach (DataRow row in ds.Tables["Emps"].Rows)
                {
                    Console.WriteLine("----------------------------------------------------");
                    foreach (DataColumn col in ds.Tables["Emps"].Columns)
                    {
                        Console.Write(row[col] + "            ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("----------------------------------------------------");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }
        public class Employee
        {
            public int EmpNo { get; set; }
            public string Name { get; set; }

            public decimal Basic { get; set; }

            public int DeptNo { get; set; }

        }

    }

}
