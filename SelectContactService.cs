namespace AddressBook
{
    public class SelectContactService
    {
        private readonly ISelectContacts _select;

        public SelectContactService(ISelectContacts select)
        {
            _select = select;
        }

        public string Select()
        {
            return _select.SelectContacts();
        }
    }
}