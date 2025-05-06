using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]

    public async Task<IActionResult> Get() => Ok(await _userService.GetAllUsersAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null) return NotFound();

        return Ok(user);

    }

    [HttpPost]
    public async Task<IActionResult> Post(AddUserRequest request)
    {
        var user = new User(request.firstName, request.lastName, request.userEmail, request.userPassword, request.address, request.reference);

        var userResponse = await _userService.CreateUser(user);

        if (userResponse == null) return BadRequest();


        return Ok(userResponse);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _userService.DeleteUserAsync(id);

        if(user) return NoContent();

        return NotFound();
    }


}