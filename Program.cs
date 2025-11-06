using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main()
    {
        List<Student> studentsInfo = new List<Student>();
        string file = "students.json";

        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            studentsInfo = JsonSerializer.Deserialize<List<Student>>(json);
        }

        while (true)
        {
            Console.WriteLine("\n===== STUDENT MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // TODO: Add student
                    break;
                case "2":
                    // TODO: View students
                    break;
                case "3":
                    // TODO: Update student
                    break;
                case "4":
                    // TODO: Delete student
                    break;
                case "5":
                    Console.WriteLine("Save and Exit");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

         static void AddStudent(List<Student> studentsInfo)
    {
        Console.Write("\nEnter index number: ");
        string indexNumber = Console.ReadLine();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        
        Console.Write("Enter course: ");
        string course = Console.ReadLine();
        


        Student student = new Student(indexNumber, name , age, email, course);
        studentsInfo.Add(student);

        Console.WriteLine("\n✅ Student added successfully!\n");
    }



    }
}