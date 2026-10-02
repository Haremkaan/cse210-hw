using System;
public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor calls base constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Unique method for writing info
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}
