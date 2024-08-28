using BlazorServerAppDemo.Models;

namespace BlazorServerAppDemo.Services
{
    public class ContactService : IContactService
    {

        List<Contact> _contacts;
        public ContactService()
        {
            _contacts = new List<Contact>();
        }
        public List<Contact> ContactList { get  { return _contacts; } }
        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }
    }
}
