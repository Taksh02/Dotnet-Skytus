using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<StudentDetails> students = new List<StudentDetails>();

    static void Main(string[] args)
    {
        int choice = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("===== STUDENT DETAILS MANAGEMENT =====");
            Console.WriteLine("1. Add Student Details");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Display Name and Department");
            Console.WriteLine("4. Students with Marks > 75");
            Console.WriteLine("5. Students from Specific Department");
            Console.WriteLine("6. Sort Students by Marks (Descending)");
            Console.WriteLine("7. Display Top Scorer");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input!");
                Pause();
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    DisplayAllStudents();
                    break;

                case 3:
                    DisplayNameAndDepartment();
                    break;

                case 4:
                    DisplayHighScorers();
                    break;

                case 5:
                    DisplayByDepartment();
                    break;

                case 6:
                    SortByMarks();
                    break;

                case 7:
                    DisplayTopScorer();
                    break;

                case 8:
                    Console.WriteLine("Exiting application...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            if (choice != 8)
                Pause();

        } while (choice != 8);
    }

    // 1. Accept student details
    static void AddStudent()
    {
        StudentDetails student = new StudentDetails();

        Console.Write("Enter Student ID: ");
        student.student_id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        student.name = Console.ReadLine() ?? "";

        Console.Write("Enter Department: ");
        student.department = Console.ReadLine() ?? "";

        Console.Write("Enter Marks: ");
        student.marks = Convert.ToInt32(Console.ReadLine());

        students.Add(student);
        Console.WriteLine("Student added successfully!");
    }

    // 2. Display all student records
    static void DisplayAllStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        Console.WriteLine("\nID\tName\tDepartment\tMarks");
        Console.WriteLine("----------------------------------------");

        foreach (var s in students)
        {
            Console.WriteLine($"{s.student_id}\t{s.name}\t{s.department}\t\t{s.marks}");
        }
    }

    // 3. Display only name and department
    static void DisplayNameAndDepartment()
    {
        Console.WriteLine("\nName\tDepartment");
        Console.WriteLine("-------------------");

        foreach (var s in students)
        {
            Console.WriteLine($"{s.name}\t{s.department}");
        }
    }

    // 4. Students with marks > 75
    static void DisplayHighScorers()
    {
        Console.WriteLine("\nStudents with Marks > 75:");

        foreach (var s in students.Where(s => s.marks > 75))
        {
            Console.WriteLine($"{s.name} - {s.marks}");
        }
    }

    // 5. Students from specific department
    static void DisplayByDepartment()
    {
        Console.Write("Enter Department: ");
        string dept = Console.ReadLine() ?? "";

        Console.WriteLine($"\nStudents from {dept} Department:");

        foreach (var s in students.Where(s => 
            s.department.Equals(dept, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"{s.name} - {s.marks}");
        }
    }

    // 6. Sort students by marks (descending)
    static void SortByMarks()
    {
        var sortedStudents = students.OrderByDescending(s => s.marks);

        Console.WriteLine("\nStudents Sorted by Marks (Descending):");

        foreach (var s in sortedStudents)
        {
            Console.WriteLine($"{s.name} - {s.marks}");
        }
    }

    // 7. Display top scorer
    static void DisplayTopScorer()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        var top = students.OrderByDescending(s => s.marks).First();

        Console.WriteLine("\nTop Scorer:");
        Console.WriteLine($"Name: {top.name}");
        Console.WriteLine($"Department: {top.department}");
        Console.WriteLine($"Marks: {top.marks}");
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}

// StudentDetails class
class StudentDetails
{
    public int student_id { get; set; }
    public string name { get; set; } = "";
    public string department { get; set; } = "";
    public int marks { get; set; }
}
