using AutoMapper;
using Phonebook.Helpers;
using Phonebook.Models;
using Phonebook.Requests;


namespace Phonebook.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
        Contact GetById(int id);
        void Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
    public class ContactService : IContactService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ContactService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts;
        }

        public Contact GetById(int id)
        {
            return getContact(id);
        }

        public void Create(CreateRequest model)
        {
            // validate
            if (_context.Contacts.Any(x => x.PhoneNumber == model.PhoneNumber))
                throw new AppException("Contact with the number '" + model.PhoneNumber + "' already exists");

            // map model to new user object
            var contact = _mapper.Map<Contact>(model);

            // save user
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var contact = getContact(id);

            // validate
            if (model.PhoneNumber != contact.PhoneNumber && _context.Contacts.Any(x => x.PhoneNumber == model.PhoneNumber))
                throw new AppException("Contact with the phone '" + model.PhoneNumber + "' already exists");

            // copy model to contact and save
            _mapper.Map(model, contact);
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getContact(id);
            _context.Contacts.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private Contact getContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) throw new KeyNotFoundException("Contact not found");
            return contact;
        }
    }
}
