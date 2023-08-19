using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblCourceGroup")]
public class CourceGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public CourceGroup()
    {
        UserCourceGroups = new HashSet<UserCourceGroup>();
        Comments = new HashSet<Comment>();
    }
    
    public virtual ICollection<UserCourceGroup> UserCourceGroups { get; set; }
    
    public virtual ICollection<Comment> Comments { get; set; }
}