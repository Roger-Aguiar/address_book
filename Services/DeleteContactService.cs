namespace AddressBook
{
    public class DeleteContactService
    {
        private readonly IDeleteContact _delete;
        
        public DeleteContactService(IDeleteContact delete)
        {
            _delete = delete;
        }

        public void Delete(Contact contact)
        {
            _delete.Delete(contact);
        }
        
    }
}