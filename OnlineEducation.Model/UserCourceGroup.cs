using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblUserCourceGroup")]
public class UserCourceGroup
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CourceGroupId { get; set; }
}