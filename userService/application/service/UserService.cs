public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync() => await _unitOfWork.UserRepository.GetAllUsersAsync();

    public async Task<UserDto?> GetUserByIdAsync(Guid userId) => await _unitOfWork.UserRepository.GetUserByIdAsync(userId);

    public async Task<UserDto> CreateUser(User user)
    {
        await _unitOfWork.UserRepository.CreateUser(user);
        await _unitOfWork.CommitAsync();

        return new UserDto(user.UserName);
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        var user = await _unitOfWork.UserRepository.DeleteUserAsync(userId);
        await _unitOfWork.CommitAsync();

        return user;
    }
}