using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblAnswer")]
public class Answer
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string? AnswerOption { get; set; }
    public int Sequence { get; set; }
    public bool IsCorrect { get; set; }
}