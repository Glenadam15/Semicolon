using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Model;

[Table("tblUser")]
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool? EmailIsValid { get; set; }
    public DateTime? EmailValidationDate { get; set; }
    public bool IsActive { get; set; }
    
    public User()
    {
        Tests = new HashSet<Test>();
        Questions = new HashSet<Question>();
        Comments = new HashSet<Comment>();
        UserCourceGroups = new HashSet<UserCourceGroup>();
    }


    public virtual ICollection<Test> Tests { get; set; }
    
    public virtual ICollection<Question> Questions { get; set; }
    
    public virtual ICollection<Comment> Comments { get; set; }
    
    public virtual ICollection<UserCourceGroup> UserCourceGroups { get; set; }
}