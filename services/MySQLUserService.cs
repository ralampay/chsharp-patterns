using CSharpPatterns.Interfaces;
using CSharpPatterns.Models;

namespace CSharpPatterns.Services
{
    // Class needs to comply with the interface.
    // It has to implement all methods declared in the interface which assures us of expected method calls.
    public class MySQLUserService : IUserService
    {
        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Save(User user)
        {
            throw new NotImplementedException();
        }
    }
}