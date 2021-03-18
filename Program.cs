using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static Task Main(string[] args)
        {
            Console.Title = "Address Book";
            List<string> fields = new List<string>();
            int option = 0;
            int idContact = 0;

            using IHost host = InjectDependencies(args).Build();
                        
            do
            {
                Console.Clear();
                Menu();
                Console.Write("\nEnter one option: ");
                option = Int32.Parse(Console.ReadLine());
                
                switch(option)
                {
                    case 1:
                        Console.Clear();
                        fields = GetFields();            
                        Create(host.Services, fields);
                        Console.WriteLine("\nOperation has been completed. \nPress any key to return to the Menu!");
                        Console.ReadKey();                        
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(Select(host.Services));
                        Console.Write("Enter the Id: ");
                        idContact = Int32.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine(SelectById(host.Services, idContact) + "\n");                        
                        fields = GetFields();
                        fields.Insert(0, idContact.ToString());
                        Update(host.Services, fields);
                        Console.WriteLine("\nOperation has been completed! Press any key to return to the menu!");
                        Console.ReadKey();                                                
                        break;
                    case 3: 
                        Console.Clear();
                        Console.WriteLine(Select(host.Services));
                        Console.Write("Enter the Id: ");
                        idContact = Int32.Parse(Console.ReadLine());
                        Delete(host.Services, idContact);
                        Console.WriteLine("\nOperation has been completed!\nPress any key to return to the Menu!");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine(Select(host.Services));
                        Console.WriteLine("\nPress any key to return to the Menu!");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("End program! Press any key to exit the application!");
                        Console.ReadKey();
                        break;
                }
            }while(option != 5);
                       
            return host.StopAsync();            
        }
        
        static void Menu()
        {
            Console.WriteLine("Menu\n");

            Console.WriteLine("1 - Create contact");
            Console.WriteLine("2 - Update contact");
            Console.WriteLine("3 - Delete contact");
            Console.WriteLine("4 - Display contacts");
            Console.WriteLine("5 - Exit");
        }

        static List<string> GetFields()
        {
            List<string> fields = new List<string>();

            Console.Write("Enter the name: ");
            fields.Add(Console.ReadLine());
            Console.Write("Enter the work info: ");
            fields.Add(Console.ReadLine());
            Console.Write("Enter the phone number: (Just numbers with DDD (00)) ");
            fields.Add(Console.ReadLine());
            Console.Write("Enter the city: ");
            fields.Add(Console.ReadLine());
            Console.Write("Enter the state: ");
            fields.Add(Console.ReadLine());
            
            return fields;
        }

        static IHostBuilder InjectDependencies(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            services.AddTransient<ICreateContact, ContactOperations>()
            .AddTransient<ISelectContacts, ContactOperations>()
            .AddTransient<IUpdateContact, ContactOperations>()  
            .AddTransient<IDeleteContact, ContactOperations>()      
            .AddTransient<CreateContactService>()
            .AddTransient<SelectContactService>()
            .AddTransient<UpdateContactService>()
            .AddTransient<DeleteContactService>());

        static void Create(IServiceProvider services, List<string> fields)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            CreateContactService contactService = provider.GetRequiredService<CreateContactService>();
            contactService.Create(new Contact(fields[0], fields[1], fields[2], fields[3], fields[4]));
        }
        
        static void Update(IServiceProvider services, List<string> fields)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            UpdateContactService contactService = provider.GetRequiredService<UpdateContactService>();
            contactService.Update(new Contact(Convert.ToInt32(fields[0].ToString()), fields[1], fields[2], fields[3], fields[4], fields[5]));
        }

        static void Delete(IServiceProvider services, int id)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            DeleteContactService contactService = provider.GetRequiredService<DeleteContactService>();
            contactService.Delete(new Contact(id));
        }

        static string Select(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            SelectContactService contactService = provider.GetRequiredService<SelectContactService>();
            return contactService.Select();
        }

        static string SelectById(IServiceProvider services, int id)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            SelectContactService contactService = provider.GetRequiredService<SelectContactService>();
            return contactService.SelectById(id);
        }
    }
}
