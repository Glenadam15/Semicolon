using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblRole")]
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Role()
    {
        Users = new HashSet<User>();
    }
    
    public virtual ICollection<User> Users { get; set; }
}