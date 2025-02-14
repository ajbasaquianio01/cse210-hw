using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Ian Capanay", "Addition");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Jhaylars Alviar", "Fractions", "2.7", "6-32");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Johndel Macalalad", "Philippine History", "The Causes of Philippine Revolution");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}