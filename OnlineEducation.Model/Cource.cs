using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblCource")]
public class Cource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
    
    public Cource()
    {
        Tests = new HashSet<Test>();
        Lessons = new HashSet<Lesson>();
    }

    public virtual ICollection<Test> Tests { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; }
}