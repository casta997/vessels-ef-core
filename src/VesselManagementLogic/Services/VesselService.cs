using Microsoft.EntityFrameworkCore;
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
    public class VesselService : IVessel
    {
        private static VesselManagemetContext context = new VesselManagemetContext();
        private static MenuService menuService = new MenuService();
        private static OwnerService ownerService = new OwnerService();

        //Method used for the creation of a vessel
        public void Create()
        {
            //Do-while for the input imoNumber
            string imoNumber;
            do
            {
                Console.Clear();
                Console.Write("Create a vessel" +
                                "\n\nImo number: ");
                imoNumber = Console.ReadLine().Trim();
            }
            //Validation of the input imoNumber
            while (menuService.CheckImoNumber(imoNumber));

            //Do-while for the input idOwner
            string idOwner;
            do
            {
                Console.Clear();
                Console.Write("Create a vessel" +
                                $"\n\nImo number: {imoNumber}" +
                                $"\nOwner id (write \"no\" for no owners): ");
                idOwner = Console.ReadLine().Replace(" ", "").ToUpper();
            }
            //Validation of the input idOwner
            while (menuService.CheckIdOwner(idOwner));

            //If idOwner equals 'no' then the vessel will be created without an owner
            if (idOwner == "NO")
            {
                Vessel newVessel = new() { ImoNumber = imoNumber };

                if (imoNumber != null)
                {
                    context.Add(newVessel);
                    context.SaveChanges();
                    Console.WriteLine("\nVessel created with success!");
                }
                else
                {
                    Console.WriteLine("\nError during the creation!");
                }
            }
            //Else check for the id and than used for the creation of a vessel with an owner
            else
            {
                bool idToConvert = int.TryParse(idOwner, out int idParsed);
                var ownerFound = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);
                Vessel newVessel = new() { ImoNumber = imoNumber, OwnerId = idParsed };

                if (imoNumber != null && ownerFound != null)
                {
                    context.Add(newVessel);
                    context.SaveChanges();
                    Console.WriteLine("\nVessel created with success!");
                }
                else
                {
                    Console.WriteLine("\nError during the creation!");
                }
            }
        }

        //Method that prints the vessel table
        public void PrintTable()
        {
            var x = new VesselManagemetContext();
            Console.WriteLine("\nList of vessels:\n");
            x.Vessels.ToList().ForEach(vessel => Console.WriteLine($"ID: {vessel.Id}\tIMO NUMBER: {vessel.ImoNumber}\tOWNER: {vessel.OwnerId}"));
        }

        //Method used for updating the details of a vessel
        public void Update()
        {
            PrintTable();
            Console.Write("\nUpdate a vessel" +
                                "\n\nId: ");
            string idVesselToUpdate = Console.ReadLine().Replace(" ", "");
            bool idToConvert = int.TryParse(idVesselToUpdate, out int idParsed);

            //Check to see if the id is valid
            if (idToConvert)
            {
                var itemToUpdate = context.Vessels.FirstOrDefault(vessel => vessel.Id == idParsed);

                //Check to see if the id exist in the db
                if (itemToUpdate != null)
                {
                    //Do-while for the input imoNumber
                    string imoNumber;
                    do
                    {
                        Console.Clear();
                        PrintTable();
                        ownerService.PrintTable();
                        Console.Write($"\nUpdate vessel: {idVesselToUpdate}" +
                                    "\n\nImo number: ");
                        imoNumber = Console.ReadLine().Trim();
                    }
                    while (menuService.CheckImoNumber(imoNumber));

                    //Do-while for the input idOwner
                    string idOwner;
                    do
                    {
                        Console.Clear();
                        PrintTable();
                        ownerService.PrintTable();
                        Console.Write($"\nUpdate vessel: {idVesselToUpdate}" +
                                        $"\n\nImo number: {imoNumber}" +
                                        $"\nId owner (write \"no\" for no owners): ");
                        idOwner = Console.ReadLine().Replace(" ", "").ToUpper();
                    }
                    while (menuService.CheckIdOwner(idOwner));

                    //If idOwner equals 'no' then the vessel will be updated without an owner
                    if (idOwner == "NO")
                    {
                        if (imoNumber != null)
                        {
                            itemToUpdate.OwnerId = null;
                            itemToUpdate.ImoNumber = imoNumber;
                            context.SaveChanges();

                            Console.WriteLine("\nVessel updated with success!");
                        }
                        else
                        {
                            Console.WriteLine("\nError during the update!");
                        }
                    }
                    //Else check for the id and than used for the update of the vessel
                    else
                    {
                        var ownerFound = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);
                        bool idOwnerToConvert = int.TryParse(idOwner, out int idOwnerParsed);

                        if (imoNumber != null && ownerFound != null)
                        {
                            itemToUpdate.ImoNumber = imoNumber;
                            itemToUpdate.OwnerId = idOwnerParsed;
                            context.SaveChanges();

                            Console.WriteLine("\nVessel updated with success!");
                        }
                        else
                        {
                            Console.WriteLine("\nError during the update!");
                        }
                    }
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

        //Method used to delete a vessel by its id
        public void Delete()
        {
            PrintTable();
            ownerService.PrintTable();
            Console.Write("\nDelete a vessel" +
                                "\n\nId: ");
            string idVesselToDelete = Console.ReadLine().Replace(" ", "");
            bool idToConvert = int.TryParse(idVesselToDelete, out int idParsed);

            //Check to see if the id is valid
            if (idToConvert)
            {
                var itemToDelete = context.Vessels.FirstOrDefault(vessel => vessel.Id == idParsed);
                
                //Check to see the id exist in the db
                if (itemToDelete != null)
                {
                    context.Remove(itemToDelete);
                    context.SaveChanges();

                    Console.WriteLine("\nVessel deleted with success!");
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
