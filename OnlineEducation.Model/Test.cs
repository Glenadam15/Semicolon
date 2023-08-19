using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblTest")]
public class Test
{
    public int Id { get; set; }
    public int CourceId { get; set; }
    public int QuestionNumber { get; set; }
    public string? Duration { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public int ComposerId { get; set; }
    public bool IsActive { get; set; }
    
    public Test()
    {
        Questions = new HashSet<Question>();
    }
    
    public virtual ICollection<Question> Questions { get; set; }
}