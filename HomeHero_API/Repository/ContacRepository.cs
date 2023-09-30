using HomeHero_API.Data;
using HomeHero_API.Models;
using HomeHero_API.Models.Dto.ContactDto;
using HomeHero_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HomeHero_API.Repository
{
    public class ContacRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;
        public ContacRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateContact(CreateContactDto newContact)
        {
            int id = _context.User.FirstOrDefault(u => u.Email.Equals(newContact.email.Trim())).UserId;
            _context.Contact.Add(new Contact
            {
                NumPhone = newContact.NumPhone,
                UserID_Contact = id
            });
            return save();
        }

        public bool DeleteContact(Contact contact)
        {
            _context.Contact.Remove(contact);
            return save();
        }
 

        public bool existContact(CreateContactDto newContact)
        {
            var contact = _context.Contact
                .FirstOrDefault(c => c.User_Contact.Email.Equals(newContact.email) && c.NumPhone.Equals(newContact.NumPhone));
            return contact == null ? false : true;
        }

        public Contact GetContact(int id)
        {
            return _context.Contact.Include(c => c.User_Contact).FirstOrDefault(c => c.ContactID == id);
        }

        public Contact GetContact(string email, string numberContact)
        {
            return _context.Contact
                .Include(c => c.User_Contact)
                .FirstOrDefault(c => c.User_Contact.Email.Equals(email.Trim()) && c.NumPhone == numberContact);
        }

        public ICollection<Contact> GetContacts()
        {
            return _context.Contact.Include(c => c.User_Contact).ToList();
        }

        public int getLastID()
        {
            return _context.Contact.OrderByDescending(c => c.ContactID).FirstOrDefault().ContactID;
        }

        public ICollection<Contact> GetUserContacts(string email)
        {
            return _context.Contact.Include(c => c.User_Contact).Where(c => c.User_Contact.Email.Equals(email)).ToList();
        }

        public bool save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateContact(UpdateContactDto updateContact)
        {
            var contact = _context.Contact
                .FirstOrDefault(c => c.User_Contact.Email.Equals(updateContact.OwnerUserEmail) && c.NumPhone.Equals(updateContact.OldNumberPhone));
            contact.NumPhone = updateContact.NewNumberPhone;
            return save();
        }
    }
}
