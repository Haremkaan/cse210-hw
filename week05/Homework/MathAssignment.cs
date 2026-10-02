using System;
public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // Constructor calls base constructor for common attributes
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Unique method for math homework
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
