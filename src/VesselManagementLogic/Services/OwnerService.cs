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
        static VesselManagemetContext context { get => new VesselManagemetContext(); }
        private static MenuService menuService = new MenuService();
        private static VesselService vesselService = new VesselService();

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

        public void Show()
        {
            Console.WriteLine("List of owners:\n");
            context.Owners.ToList().ForEach(owner => Console.WriteLine($"ID: {owner.Id}\tFIRST NAME: {owner.FirstName}\tLAST NAME: {owner.LastName}"));
        }

        public void Update()
        {
            Show();
            Console.Write("\nUpdate an owner" +
                                "\n\nId: ");
            string idOwnerToUpdate = Console.ReadLine().Replace(" ", "");
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
                        Show();
                        Console.Write($"\nUpdate owner: {idOwnerToUpdate}" +
                                        "\n\nFirst name: ");
                        name = Console.ReadLine().Trim();
                    }
                    while (menuService.CheckInput(name));

                    string surname;
                    do
                    {
                        Console.Clear();
                        Show();
                        Console.Write($"\nUpdate owner: {idOwnerToUpdate}" +
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
            Show();
            Console.Write("Delete an owner"+
                                "\n\nId: ");
            string idOwnerToDelete = Console.ReadLine().Replace(" ", "");
            bool idToConvert = int.TryParse(idOwnerToDelete, out int idParsed);

            if (idToConvert)
            {
                var itemToDelete = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);

                if (itemToDelete != null)
                {
                    var vesselWithOwnerToDelete = context.Vessels.Where(v => v.OwnerId == idParsed).ToList();
                    vesselWithOwnerToDelete.ForEach(v => v.OwnerId = null);

                    context.Remove(itemToDelete);                    
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

        public void AssignVessel()
        {
            Show();
            Console.WriteLine();
            vesselService.Show();
            Console.Write("\nAssign vessel\n\nId Vessel: ");
            string idVesselToAssign = Console.ReadLine().Replace(" ", "");

            bool idToConvert = int.TryParse(idVesselToAssign, out int idParsed);

            if (idToConvert)
            {
                var itemToAssign = context.Vessels.FirstOrDefault(vessel => vessel.Id == idParsed);

                if (itemToAssign != null)
                {
                    Console.Write("\nId Owner: ");
                    string idOwner = Console.ReadLine().Replace(" ", "");

                    bool idOwnerToConvert = int.TryParse(idOwner, out int idOwnerParsed);

                    if (idOwnerToConvert)
                    {
                        var itemAssignedTo = context.Owners.FirstOrDefault(owner => owner.Id == idOwnerParsed);

                        if (itemAssignedTo != null)
                        {
                            itemToAssign.OwnerId = idOwnerParsed;
                            context.SaveChanges();

                            Console.WriteLine("\nVessel assigned with success!");
                        }
                        else
                        {
                            Console.WriteLine("\nItem not found!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("\nItem not found!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input!");
            }
        }
    }
}
