using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;
[Table("tblComment")]
public class Comment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CourceGroupId { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public int Point { get; set; }
    public int? Like { get; set; }
    public int? DisLike { get; set; }
    public bool IsApproved { get; set; }
    public DateTime ApprovalDate { get; set; }
    public int ApproverUserId { get; set; }
}