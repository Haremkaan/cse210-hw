using System;
public class Assignment
{
    private string _studentName;
    private string _topic;

    // Constructor initializes values
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Helper method to access student name (needed later)
    public string GetStudentName()
    {
        return _studentName;
    }
}
