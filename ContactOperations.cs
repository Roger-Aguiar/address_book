using System;
using System.Linq;
using AddressBook.Models;

namespace AddressBook
{
    public class ContactOperations : ICreateContact, ISelectContacts, IUpdateContact
    {
        AddressBookContext contactTable = new AddressBookContext();
        public void Create(Contact contact)
        {
            using(contactTable)
            {
                contactTable.Add(new ContactModel {Name = contact.Name, WorkInfo = contact.WorkInfo, 
                                         PhoneNumber = $"{long.Parse(contact.PhoneNumber):(00)0-0000-0000}",                                         
                                         City = contact.City, State = contact.State});
                contactTable.SaveChanges();            
            }            
        }

        public string SelectById(int id)
        {
            string contactLayout;

            using(contactTable)
            {
                var contactId = contactTable.Contacts.Find(id);
                contactLayout = "Name: " + contactId.Name + "\nWork info: " + contactId.WorkInfo +
                                "\nPhone number: " + contactId.PhoneNumber + "\nCity: " + contactId.City +
                                "\nState: " + contactId.State;
            }
            return contactLayout;
        }

        public string SelectContacts()
        {
            string contactsLayout;
            contactsLayout = "My Contacts\n=================================================================\n";

            using(contactTable)
            {
                var contactList = contactTable.Contacts.OrderBy(contacts  => contacts.Name);

                foreach (var item in contactList)
                {
                    contactsLayout += "\nId: " + item.Id + "\nName: " + item.Name +
                                      "\nWork Info: " + item.WorkInfo + "\nPhone number: " + item.PhoneNumber +
                                      "\nCity: " + item.City + "\nState: " + item.State +
                                      "\n\n=================================================================\n";                                
                }
            }
            return contactsLayout;
        }

        public void Update(Contact contact)
        {
            using(contactTable)
            {
                var contactId = contactTable.Contacts.Find(contact.Id);
                contactId.Name = contact.Name;
                contactId.WorkInfo = contact.WorkInfo;
                contactId.PhoneNumber = contact.PhoneNumber;
                contactId.City = contact.City;
                contactId.State = contact.State;

                contactTable.SaveChanges();
            }
        }
    }
}