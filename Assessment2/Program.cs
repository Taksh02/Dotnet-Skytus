using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 4. Create multiple student objects
        List<Student> students = new List<Student>
        {
            new Student(1, "Rahul", "IT", 3, 82),
            new Student(2, "Anita", "CS", 2, 91),
            new Student(3, "Karan", "IT", 4, 74),
            new Student(4, "Priya", "CS", 3, 88),
            new Student(5, "Amit", "EC", 2, 79)
        };

        // 5. Display all student records
        Console.WriteLine("===== ALL STUDENT RECORDS =====");
        DisplayStudents(students);

        // 6. Students with marks > 75
        Console.WriteLine("\n===== STUDENTS WITH MARKS > 75 =====");
        var highScorers = students.Where(s => s.Marks > 75).ToList();
        DisplayStudents(highScorers);

        // 7. Sort students by marks (Descending)
        Console.WriteLine("\n===== STUDENTS SORTED BY MARKS =====");
        var sortedStudents = students.OrderByDescending(s => s.Marks).ToList();
        DisplayStudents(sortedStudents);

        // 8. Display top 3 scorers
        Console.WriteLine("\n===== TOP 3 SCORERS =====");
        var top3 = students.OrderByDescending(s => s.Marks).Take(3).ToList();
        DisplayStudents(top3);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void DisplayStudents(List<Student> students)
    {
        Console.WriteLine("ID\tName\tDepartment\tYear\tMarks");
        Console.WriteLine("------------------------------------------------");

        foreach (var s in students)
        {
            Console.WriteLine($"{s.StudentId}\t{s.Name}\t{s.Department}\t\t{s.Year}\t{s.Marks}");
        }
    }
}

// 1. Student class
class Student
{
    // 3. Encapsulation (private fields)
    private int studentId;
    private string name;
    private string department;
    private int year;
    private int marks;

    // 2. Constructor to initialize values
    public Student(int studentId, string name, string department, int year, int marks)
    {
        this.studentId = studentId;
        this.name = name;
        this.department = department;
        this.year = year;
        this.marks = marks;
    }

    // 3. Getters and Setters (Properties)
    public int StudentId
    {
        get { return studentId; }
        set { studentId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public int Marks
    {
        get { return marks; }
        set { marks = value; }
    }
}
