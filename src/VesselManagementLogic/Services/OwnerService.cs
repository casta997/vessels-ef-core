using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesselManagementData;
using VesselManagementData.Models;
using VesselManagementLogic.Interfaces;

namespace VesselManagementLogic.Services
{
    public class OwnerService : IOwner
    {
        private static VesselManagemetContext context = new VesselManagemetContext();
        private static MenuService menuService = new MenuService();

        public void Create()
        {
            string name;
            do
            {
                Console.Clear();
                Console.Write("Create an owner" +
                                "\n\nFirst name: ");
                name = Console.ReadLine().Trim();
            }
            while (menuService.CheckInput(name));

            string surname;
            do
            {
                Console.Clear();
                Console.Write("Create an owner" +
                                $"\n\nFirst name: {name}"+
                                $"\nLast name: ");
                surname = Console.ReadLine().Trim();
            }
            while (menuService.CheckInput(surname));

            Owner newOwner = new() { FirstName = name, LastName = surname};
            context.Add( newOwner );
            context.SaveChanges();

            Console.WriteLine("\nOwner created with success!");
        }

        public void Read()
        {
            Console.WriteLine("List of owners:\n");
            context.Owners.ToList().ForEach(owner => Console.WriteLine($"ID: {owner.Id}\tFIRST NAME: {owner.FirstName}\tLAST NAME: {owner.LastName}"));
        }

        public void Update()
        {
            Console.Write("Update an owner" +
                                "\n\nId: ");
            string idOwnerToUpdate = Console.ReadLine();
            bool idToConvert = int.TryParse(idOwnerToUpdate, out int idParsed);

            if (idToConvert)
            {
                var itemToUpdate = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);

                if (itemToUpdate != null)
                {
                    string name;
                    do
                    {
                        Console.Clear();
                        Console.Write($"Update owner: {idOwnerToUpdate}" +
                                        "\n\nFirst name: ");
                        name = Console.ReadLine().Trim();
                    }
                    while (menuService.CheckInput(name));

                    string surname;
                    do
                    {
                        Console.Clear();
                        Console.Write($"Update owner: {idOwnerToUpdate}" +
                                        $"\n\nFirst name: {name}" +
                                        $"\nLast name: ");
                        surname = Console.ReadLine().Trim();
                    }
                    while (menuService.CheckInput(surname));

                    itemToUpdate.FirstName = name;
                    itemToUpdate.LastName = surname;
                    context.SaveChanges();

                    Console.WriteLine("\nOwner updated with success!");
                }
                else
                {
                    Console.WriteLine("\nId not found!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input!");
            } 
        }

        public void Delete()
        {
            Console.Write("Delete an owner"+
                                "\n\nId: ");
            string idOwnerToDelete = Console.ReadLine();
            bool idToConvert = int.TryParse(idOwnerToDelete, out int idParsed);

            if (idToConvert)
            {
                var itemToDelete = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);

                if (itemToDelete != null)
                {
                    context.Owners.Remove(itemToDelete);
                    context.SaveChanges();

                    Console.WriteLine("\nOwner deleted with success!");
                }
                else
                {
                    Console.WriteLine("\nId not found!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input!");
            }
        }
    }
}
