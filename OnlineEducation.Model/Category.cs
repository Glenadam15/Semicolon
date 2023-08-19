using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblCategory")]
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Category()
    {
        Cources = new HashSet<Cource>();
    }
    
    public virtual ICollection<Cource> Cources { get; set; }
}