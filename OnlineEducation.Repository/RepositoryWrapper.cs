
namespace OnlineEducation.Repository
{
	
public class RepositoryWrapper
{
    private RepositoryContext context;


    private AnswerRepository answerRepository;

    private CategoryRepository categoryRepository;

    private CommentRepository commentRepository;

    private CourceGroupRepository courceGroupRepository;

    private CourceLessonRepository courceLessonRepository;

    private CourceRepository courceRepository;

    private LessonRepository lessonRepository;

    private QuestionRepository questionRepository;

    private RoleRepository roleRepository;

    private TestRepository testRepository;

    private UserCourceGroupRepository userCourceGroupRepository;

    private UserRepository userRepository;


    public RepositoryWrapper(RepositoryContext context)
    {
        this.context = context;
    }

    public AnswerRepository AnswerRepository
    {
        get
        {
            if (answerRepository == null)
                answerRepository = new AnswerRepository(context);
            return answerRepository;
        }
    }

    public CategoryRepository CategoryRepository
    {
	    get
	    {
		    if (categoryRepository == null)
			    categoryRepository = new CategoryRepository(context);
		    return categoryRepository;
	    }
    }

    public CommentRepository CommentRepository
    {
	    get
	    {
		    if (commentRepository == null)
			    commentRepository = new CommentRepository(context);
		    return commentRepository;
	    }
    }

    public CourceGroupRepository CourceGroupRepository
	{
	    get
	    {
		    if (courceGroupRepository == null)
			    courceGroupRepository = new CourceGroupRepository(context);
		    return courceGroupRepository;
	    }
    }

    public CourceLessonRepository CourceLessonRepository
	{
	    get
	    {
		    if (courceLessonRepository == null)
			    courceLessonRepository = new CourceLessonRepository(context);
		    return courceLessonRepository;
	    }
    }

    public CourceRepository CourceRepository
	{
	    get
	    {
		    if (courceRepository == null)
			    courceRepository = new CourceRepository(context);
		    return courceRepository;
	    }
    }

    public LessonRepository LessonRepository
	{
	    get
	    {
		    if (lessonRepository == null)
			    lessonRepository = new LessonRepository(context);
		    return lessonRepository;
	    }
    }

    public QuestionRepository QuestionRepository
	{
	    get
	    {
		    if (questionRepository == null)
			    questionRepository = new QuestionRepository(context);
		    return questionRepository;
	    }
    }

    public RoleRepository RoleRepository
	{
	    get
	    {
		    if (roleRepository == null)
			    roleRepository = new RoleRepository(context);
		    return roleRepository;
	    }
    }

    public TestRepository TestRepository
	{
	    get
	    {
		    if (testRepository == null)
			    testRepository = new TestRepository(context);
		    return testRepository;
	    }
    }

    public UserCourceGroupRepository UserCourceGroupRepository
	{
	    get
	    {
		    if (userCourceGroupRepository == null)
			    userCourceGroupRepository = new UserCourceGroupRepository(context);
		    return userCourceGroupRepository;
	    }
    }

    public UserRepository UserRepository
	{
	    get
	    {
		    if (userRepository == null)
			    userRepository = new UserRepository(context);
		    return userRepository;
	    }
    }
	

	public void SaveChanges()
    {
        context.SaveChanges();
    }
}
}
