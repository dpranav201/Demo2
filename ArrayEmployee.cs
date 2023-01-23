using System;

namespace ArrayAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number of Batches");
            int batch_no=Convert.ToInt32(Console.ReadLine());
            int stu_no;
            int[][] arr=new int[batch_no][];
           for(int i=0;i<batch_no;i++) 
            {
                Console.WriteLine("Enter The number of student in="+(i+1));
                 stu_no=int.Parse(Console.ReadLine());
                arr[i]=new int[stu_no];
            }
            Console.WriteLine();
            for(int i=0;i< arr.Length;i++) 
            {
                for(int j = 0; j < arr[i].Length;j++)
                {
                    Console.WriteLine("Enter the marks of {0} {1}", i, j);
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for(int i=0;i<batch_no;i++) 
            {
                for(int j=0;j< arr[i].Length;j++) 
                {
                    Console.WriteLine("Marks of Student of roll no {1} of Batch {0} is {2} ", i, j, arr[i][j]);
                }
            }
            
                   
        }
    }
}