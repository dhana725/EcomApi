using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class AuthController : ControllerBase
{
    private readonly IAuthRepo _repo;
    public AuthController(IAuthRepo repo)
    {
        _repo = repo;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var result = await _repo.RegisterAsync(dto);
        if (!result)
            return BadRequest("Email already exists.");

        return Ok(new { message = "User registered successfully" });
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var response = await _repo.LoginAsync(dto);
        if (response == null)
            return Unauthorized(new{ message = "Invalid credentials."});
return Ok(new {message = response,});
        
    }

}
