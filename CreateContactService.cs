namespace AddressBook
{
    public class CreateContactService
    {
        private readonly ICreateContact _create;        
       
        public CreateContactService(ICreateContact create)
        {
            _create = create;
        }

        public void Create(Contact contact)
        {
            _create.Create(contact);
        }
        
    }
}