using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main()
    {
        List<Student> studentsInfo = LoadStudents();
        string file = "students.json";

        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            studentsInfo = JsonSerializer.Deserialize<List<Student>>(json)!;
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

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    AddStudent(studentsInfo);
                    break;
                case "2":
                    ViewStudent(studentsInfo);
                    break;
                case "3":
                    UpdateStudent(studentsInfo);
                    break;
                case "4":
                    DeleteStudent(studentsInfo);
                    break;
                case "5":
                    Console.WriteLine("Save and Exit");
                    SaveStudents(studentsInfo);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

static void AddStudent(List<Student> studentsInfo)
    {
        Console.WriteLine("Enter index number: ");
        string indexNumber = Console.ReadLine()!;

        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine()!;

        Console.WriteLine("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter email: ");
        string email = Console.ReadLine()!;

        Console.WriteLine("Enter course: ");
        string course = Console.ReadLine()!;



        Student student = new Student(indexNumber!, name!, age, email!, course!);
        studentsInfo.Add(student);

        Console.WriteLine("\n✅ Student added successfully!\n");
    }

    static void ViewStudent(List<Student> studentsInfo)
    {
        Console.WriteLine("\n===STUDENTS===");
        if (studentsInfo.Count == 0)
        {
            Console.WriteLine("No information available!\n");
            return;
        }

        for (int i = 0; i < studentsInfo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Index Number: {studentsInfo[i].IndexNumber}| Name: {studentsInfo[i].Name} | Age: {studentsInfo[i].Age} | Email: {studentsInfo[i].Email} | Course: {studentsInfo[i].Course}");
        }
    }

    static void UpdateStudent(List<Student> studentsInfo)
    {
        Console.Write("What are you searching for: ");
        string searchedStudent = Console.ReadLine()!.ToLower();

        bool found = false;

        foreach (var student in studentsInfo)
        {
            if (student.Name!.ToLower().Contains(searchedStudent) ||
                student.IndexNumber!.ToLower().Contains(searchedStudent) ||
                student.Course!.ToLower().Contains(searchedStudent))
            {
                Console.WriteLine($"\nFound: Index Number: {student.IndexNumber}, Name: {student.Name}, Age: {student.Age}, Email: {student.Email}, Course: {student.Course}");
                
                found =true;

                Console.WriteLine("\nType in the changes: ");

                Console.WriteLine("Enter new index number: ");
                student.IndexNumber = Console.ReadLine();

                Console.WriteLine("Enter new name: ");
                student.Name = Console.ReadLine();

                Console.WriteLine("Enter new age: ");
                student.Age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter new email: ");
                student.Email = Console.ReadLine();

                Console.WriteLine("Enter new course: ");
                student.Course = Console.ReadLine();

                Console.WriteLine("\n✅ Updated successfully!\n");
                break;
            }
        }

        if (found == false)
        {
            Console.WriteLine("\n❌ Student not found!\n");
        }
    }

    static void DeleteStudent(List<Student> studentsInfo)
    {
        if (studentsInfo.Count == 0)
        {
            Console.WriteLine("\nNo students to delete.\n");
            return;
        }

        Console.Write("\nEnter the Index Number of the student to delete: ");
        string indexToDelete = Console.ReadLine()!;

        Student studentToRemove = studentsInfo.Find(s => s.IndexNumber!.Equals(indexToDelete, StringComparison.OrdinalIgnoreCase))!;

        if (studentToRemove != null)
        {
            studentsInfo.Remove(studentToRemove);
            Console.WriteLine("\n🗑️  Student deleted successfully!\n");
        }
        else
        {
            Console.WriteLine("\n❌ No student found with that Index Number.\n");
        }
    }

    static List<Student> LoadStudents()
    {
        List<Student> studentsInfo = new List<Student>();
        string file = "students.json";

    if (File.Exists(file))
{
    string json = File.ReadAllText(file);
   
}


        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            studentsInfo = JsonSerializer.Deserialize<List<Student>>(json)!;

            Console.WriteLine("\n📂 Students loaded successfully!\n");
        }
        else
        {
            Console.WriteLine("\nNo saved students found.\n");
        }

        return studentsInfo;
    }

static void SaveStudents(List<Student> studentsInfo)
{
    string json = JsonSerializer.Serialize(studentsInfo, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText("students.json", json);
    Console.WriteLine("\n💾 Students saved successfully!\n");
}
}