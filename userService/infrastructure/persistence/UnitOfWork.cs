public class UnitOfWork : IUnitOfWork
{
    private readonly UserDbContext _userDbContext;

    public IUserRepository UserRepository { get; }
    public UnitOfWork(UserDbContext userDbContext, IUserRepository userRepository)
    {
        _userDbContext = userDbContext;
        UserRepository = userRepository;
    }

    public async Task<int> CommitAsync()
    {
        return await _userDbContext.SaveChangesAsync();
    }
}