using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblCourceLesson")]
public class CourceLesson
{
    public int Id { get; set; }
    public int CourceId { get; set; }
    public int LessonId { get; set; }
}