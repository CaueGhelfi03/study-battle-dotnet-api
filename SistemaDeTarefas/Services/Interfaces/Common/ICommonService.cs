namespace TaskSystem.Services.Interfaces.ICommon
{
    public interface ICommonService
    {
        bool IsValidEmail(string email);
        string PasswordEncoder(string password);
    }
}
