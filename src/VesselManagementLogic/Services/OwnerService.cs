using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesselManagementData;
using VesselManagementData.Models;

namespace VesselManagementLogic.Services
{
    public class OwnerService
    {
        static VesselManagemetContext context = new VesselManagemetContext();
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
            foreach (var owner in context.Owners)
            {
                Console.WriteLine($"ID: {owner.Id}\tFIRST NAME: {owner.FirstName}\tLAST NAME: {owner.LastName}");
            }
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}
