using Microsoft.EntityFrameworkCore;

namespace AddressBook.Models
{
    public class AddressBookContext : DbContext
    {
        public DbSet<ContactModel> Contacts{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AddressBook;Integrated Security=True");
        }
    }
}