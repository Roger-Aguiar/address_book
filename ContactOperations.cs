using System;
using System.Linq;
using AddressBook.Models;

namespace AddressBook
{
    public class ContactOperations : ICreateContact, ISelectContacts
    {
        public void Create(Contact contact)
        {
            using(var db = new AddressBookContext())
            {
                db.Add(new ContactModel {Name = contact.Name, WorkInfo = contact.WorkInfo, 
                                         PhoneNumber = $"{long.Parse(contact.PhoneNumber):(00)0.0000-0000}",                                         
                                         City = contact.City, State = contact.State});
                db.SaveChanges();            
            }            
        }

        public void SelectContacts()
        {
            throw new NotImplementedException();
        }
    }
}