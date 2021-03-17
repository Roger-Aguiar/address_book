namespace AddressBook
{
    public class UpdateContactService
    {
        private readonly IUpdateContact _update;

        public UpdateContactService(IUpdateContact update)
        {
            _update = update;
        }
        
        public void Update(Contact contact)
        {
            _update.Update(contact);
        }
        
    }
}