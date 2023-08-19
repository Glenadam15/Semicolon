using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblLesson")]
public class Lesson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

	public Lesson()
	{
		CourceLessons = new HashSet<CourceLesson>();
	}

	public virtual ICollection<CourceLesson> CourceLessons { get; set; }
}