using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class UserRepository : RepositoryBase<User>
{
    public UserRepository(RepositoryContext context) : base(context)
    {
        
    }
}