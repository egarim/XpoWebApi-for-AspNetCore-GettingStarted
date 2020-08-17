using BIT.Xpo;
using BIT.Xpo.Providers.WebApi.Client;
using DevExpress.Xpo;
using System;

namespace XpoWebApiClientApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Register XpoWebApiProvider 
            XpoWebApiProvider.Register();

            var XpoWebApiAspNetCore = XpoWebApiProvider.GetConnectionString("https://localhost:44359", "/XpoWebApi", string.Empty, "002");
            XpoInitializer xpoInitializer = new XpoInitializer(XpoWebApiAspNetCore, typeof(Person));

            xpoInitializer.InitSchema();


            var UoW = xpoInitializer.CreateUnitOfWork();
            Person JocheOjeda = new Person(UoW) { Name = "Jose Manuel Ojeda Melgar" };
            Person RoccoOjeda = new Person(UoW) { Name = "Rocco Ojeda Melgar" };

            if (UoW.InTransaction)
                UoW.CommitChanges();


            var UoWRead = xpoInitializer.CreateUnitOfWork();
            XPCollection<Person> people = new XPCollection<Person>(UoWRead);

            foreach (Person person in people)
            {
                Console.WriteLine(person.Name);
            }
            Console.ReadKey();

            //https://localhost:44359/XpoWebApi
        }
    }
}
