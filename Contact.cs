namespace AddressBook
{
    public class Contact
    {
        public Contact(string name, string workInfo, string phoneNumber, string city, string state)
        {
            Name = name;
            WorkInfo = workInfo;
            PhoneNumber = phoneNumber;
            City = city;
            State = state;
        }

        public string Name {get; init;}
        public string WorkInfo {get; init;}
        public string PhoneNumber {get; init;}
        public string City {get; init;}
        public string State {get; init;}
    }
}