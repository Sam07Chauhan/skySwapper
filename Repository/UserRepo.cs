using skySwapper.Data;
using skySwapper.IRepository;
using skySwapper.Model;

namespace skySwapper.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool CheackUser(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public User GetUser(string email, string password)
        {
            return _context.Users.Where(a=> a.Email == email && a.Password == password).FirstOrDefault();
        }

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved > 0 ? true : false;
        }

        bool IUserRepo.CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }
    }
}
