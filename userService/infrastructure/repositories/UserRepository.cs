using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _userDbContext;

    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync() => await _userDbContext.Users.AsNoTracking().ToListAsync();

    public async Task<UserDto?> GetUserByIdAsync(Guid userId)
    {
        var user = await _userDbContext.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();

        if (user == null) return null;

        return new UserDto(user.UserName);
    }

    public async Task<UserDto> CreateUser(User user)
    {
        await _userDbContext.Users.AddAsync(user);

        return new UserDto(user.UserName);
    }


    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        var user = await _userDbContext.Users.FindAsync(userId);

        if (user == null) return false;

        return true;

    }
}