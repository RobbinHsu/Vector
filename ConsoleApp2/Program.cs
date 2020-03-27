using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp2
{
    public class Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    internal class Program
    {
        //private static object syncRoot = new object();
        private static List<Student> studentsList => students.Values.ToList();
        private static ConcurrentDictionary<string, Student> students=new ConcurrentDictionary<string, Student>();

        //private static ConcurrentBag<Student> students = new ConcurrentBag<Student>();
        //private static BlockingCollection<Student> students = new BlockingCollection<Student>();
        //private static SynchronizedCollection<Student> students = new SynchronizedCollection<Student>();

        private static void Main(string[] args)
        {
            InitialData();

            //打印姓名
            //Thread t = new Thread(new ThreadStart(ListMember));

            Console.WriteLine("Start：");
            Console.WriteLine();
            Thread.Sleep(2500);
            new Thread(ListMember).Start();
            new Thread(AddAndRemoveMember).Start();
            try
            {
                //PrintList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //PrintList();
                Console.ReadKey();
            }

            //Console.WriteLine("刪除after：");
            //foreach (var stu in stuList)
            //{
            //    Console.WriteLine(stu.Name + " ");
            //}
            Console.ReadKey();
        }

        private static void InitialData()
        {
            students = new ConcurrentDictionary<string, Student>();
            students.TryAdd("Tom", new Student("Tom", 19));
            students.TryAdd("Tang", new Student("Tang", 19));
            students.TryAdd("Wang", new Student("Wang", 20));
            students.TryAdd("Lili", new Student("Lili", 19));
        }

        private static void PrintList()
        {
            Console.WriteLine();
            Console.WriteLine("=============");
            foreach (var stu in studentsList)
            {
                Console.Write(stu.ToString() + " || ");
            }

            var student = students.First();
            Console.Write(student.Value + " || ");
            Console.WriteLine();
            Console.WriteLine("=============");
            Console.WriteLine();
        }

        private static void ListMember()
        {
            Console.WriteLine("打印姓名：");
            while (true)
            {
                //lock (syncRoot)
                {
                    //students.ForEach(stu =>
                    //{
                    //    Console.Write(stu + " || ");
                    //});

                    foreach (var stu in studentsList)
                    {
                        //Thread.Sleep(25);
                        Console.Write(stu + " || ");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void AddAndRemoveMember()
        {
            int i = 0;
            var student = new Student("Temp", 90);
            var Tom = new Student("Tom6666", 19);
            while (true)
            {
                Thread.Sleep(1);
                //lock (syncRoot)
                {
                    if (i % 2 == 0)
                    {
                        students.TryAdd(student.Name, student);
                    }
                    else
                    {
                        //students.Remove(student);
                        //students.TryTake(out student);
                        students.TryRemove(student.Name, out _);
                    }

                    i++;
                }
            }
        }
    }
}