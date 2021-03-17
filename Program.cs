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
            using IHost host = InjectDependencies(args).Build();

            List<string> fields = GetFields();
            
            Create(host.Services, fields);
            Console.WriteLine("\nOperation has been completed.");

            return host.StopAsync();            
        }

        static void DisplayFields(List<string> fields) => fields.ForEach(field => Console.WriteLine(field));

        static List<string> GetFields()
        {
            List<string> fields = new List<string>();

            Console.Write("Enter the name: ");
            fields.Add(Console.ReadLine());
            Console.Write("Enter the work info: ");
            fields.Add(Console.ReadLine());
            Console.Write("Enter the phone number: (Just numbers) ");
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
            .AddTransient<CreateContactService>()
            .AddTransient<SelectContactService>());

        static void Create(IServiceProvider services, List<string> fields)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            CreateContactService contactService = provider.GetRequiredService<CreateContactService>();
            contactService.Create(new Contact(fields[0], fields[1], fields[2], fields[3], fields[4]));
        }
    }
}
