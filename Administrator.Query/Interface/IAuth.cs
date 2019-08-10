namespace Administrator.Query.Interface
{
    public interface IChangeCredential
    {
        bool Check(int id, string password);
        bool ChangeEmail(int id, string email);
        bool ChangePassword(int id, string password);
    }
}
