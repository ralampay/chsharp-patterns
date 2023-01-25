using CSharpPatterns.Models;

namespace CSharpPatterns.Interfaces 
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User Save(User user);
        public void Delete(User user);
        public User FindById(int id);
    }
}