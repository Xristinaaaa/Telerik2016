using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new FormatException("Grade should be a positive number.");
        }
        if (minGrade < 0)
        {
            throw new FormatException("Minimal grade should be a positive number.");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Maximal grade should be greater than the minimal.");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("Comments are undefined.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
