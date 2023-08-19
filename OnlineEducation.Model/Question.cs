using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblQuestion")]
public class Question
{
    public int Id { get; set; }
    public int TestId { get; set; }
    public string QuestionDescription { get; set; }
    public int Point { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public int ComposerId { get; set; }
    public bool IsActive { get; set; }
    
    public Question()
    {
        Answers = new HashSet<Answer>();
    }
    
    public virtual ICollection<Answer> Answers { get; set; }
}