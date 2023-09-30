using HomeHero_API.Models;
using HomeHero_API.Models.Dto.ContactDto;

namespace HomeHero_API.Repository.IRepository
{
    public interface IContactRepository
    {
        ICollection<Contact> GetContacts();
        ICollection<Contact> GetUserContacts(string email);

        Contact GetContact(int id);
        Contact GetContact(string email, string numberContact);
        bool existContact(CreateContactDto newContact);
        bool DeleteContact(Contact contact);
        bool UpdateContact(UpdateContactDto updateContact);
        bool save();
        bool CreateContact(CreateContactDto newContact);
        int getLastID();
    }
}
