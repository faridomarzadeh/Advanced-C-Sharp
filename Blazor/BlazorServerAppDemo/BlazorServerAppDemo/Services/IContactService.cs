using BlazorServerAppDemo.Models;

namespace BlazorServerAppDemo.Services
{
    public interface IContactService
    {
        List<Contact> ContactList { get; }
        void Add(Contact contact);
    }
}
