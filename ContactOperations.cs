using System;

namespace AddressBook
{
    public class ContactOperations : ICreateContact, ISelectContacts
    {
        public void Create(Contact contact)
        {
            Console.WriteLine("Name: " + contact.Name);
            Console.WriteLine("Work Info: " + contact.WorkInfo);
            Console.WriteLine("Phone number: " + $"{long.Parse(contact.PhoneNumber):(00)0-0000-0000}");
            Console.WriteLine("City: " + contact.City);
            Console.WriteLine("State: " + contact.State);
        }
        public void SelectContacts()
        {
            throw new NotImplementedException();
        }
    }
}