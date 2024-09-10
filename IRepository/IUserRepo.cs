using skySwapper.Model;

namespace skySwapper.IRepository
{
    public interface IUserRepo
    {
        User GetUser(string email, string password);
        bool CheackUser(string email);
        bool Save();
        bool CreateUser(User user);
    }
}
