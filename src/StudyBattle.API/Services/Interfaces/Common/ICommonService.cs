namespace StudyBattle.API.Interfaces.ICommon
{
    public interface ICommonService
    {
        bool IsValidEmail(string email);
        string PasswordEncoder(string password);
    }
}
