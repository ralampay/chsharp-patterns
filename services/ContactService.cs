using CSharpPatterns.Models;
using CSharpPatterns.Conf;

namespace CSharpPatterns.Services
{
    public class ContactService
    {
        public ContactService()
        {

        }

        public Contact FindById(int id)
        {
            ApplicationContext context = ApplicationContext.Instance;
            return context.GetContacts().Where(contact => contact.Id == id).FirstOrDefault();
        }

        public List<Contact> GetAll()
        {
            ApplicationContext context = ApplicationContext.Instance;

            return context.GetContacts();
        }

        public void Save(Contact c)
        {
            ApplicationContext context = ApplicationContext.Instance;

            context.GetContacts().Add(c);
        }
    }
}