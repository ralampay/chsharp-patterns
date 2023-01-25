using CSharpPatterns.Models;

namespace CSharpPatterns.Conf
{
    // Implemented as a singleton class
    // Singleton: Exactly one instance of this class exists
    public class ApplicationContext
    {
        private List<Contact> contacts;
        
        private static ApplicationContext instance = null;

        public static ApplicationContext Instance
        {
            get {
                if(instance == null) {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }

        public ApplicationContext()
        {
            this.contacts = new List<Contact>();
        }

        public List<Contact> GetContacts()
        {
            return this.contacts;
        }
    }
}