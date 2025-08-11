public interface IAuthRepo
{
   Task<bool> RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
}