public interface IUserService
{
    public Task<IEnumerable<User>> GetAllUsersAsync();

    public Task<UserDto?> GetUserByIdAsync(Guid userId);

    public Task<UserDto> CreateUser(User user);


    public Task<bool> DeleteUserAsync(Guid userId);


}