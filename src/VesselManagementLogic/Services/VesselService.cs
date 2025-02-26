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
        static VesselManagemetContext context { get => new VesselManagemetContext(); }
        private static MenuService menuService = new MenuService();

        public void Create()
        {
            string imoNumber;
            do
            {
                Console.Clear();
                Console.Write("Create a vessel" +
                                "\n\nImo number: ");
                imoNumber = Console.ReadLine().Trim();
            }
            while (menuService.CheckImoNumber(imoNumber));

            string idOwner;
            do
            {
                Console.Clear();
                Console.Write("Create a vessel" +
                                $"\n\nImo number: {imoNumber}" +
                                $"\nOwner id (write \"no\" for no owners): ");
                idOwner = Console.ReadLine().Replace(" ", "").ToUpper();
            }
            while (menuService.CheckIdOwner(idOwner));

            if (idOwner == "NO")
            {
                Vessel newVessel = new() { ImoNumber = imoNumber };
                context.Add(newVessel);
                context.SaveChanges();

                Console.WriteLine("\nVessel created with success!");
            }
            else
            {
                bool idToConvert = int.TryParse(idOwner, out int idParsed);

                Vessel newVessel = new() { ImoNumber = imoNumber, OwnerId = idParsed };
                context.Add(newVessel);
                context.SaveChanges();

                Console.WriteLine("\nVessel created with success!");
            }
        }

        public void Show()
        {
            Console.WriteLine("List of vessels:\n");
            context.Vessels.ToList().ForEach(vessel => Console.WriteLine($"ID: {vessel.Id}\tIMO NUMBER: {vessel.ImoNumber}\tOWNER: {vessel.OwnerId}"));
        }

        public void Update()
        {
            Show();
            Console.Write("\nUpdate a vessel" +
                                "\n\nId: ");
            string idVesselToUpdate = Console.ReadLine().Replace(" ", "");
            bool idToConvert = int.TryParse(idVesselToUpdate, out int idParsed);

            if (idToConvert)
            {
                var itemToUpdate = context.Vessels.FirstOrDefault(vessel => vessel.Id == idParsed);

                if (itemToUpdate != null)
                {
                    string imoNumber;
                    do
                    {
                        Console.Clear();
                        Show();
                        Console.Write($"\nUpdate vessel: {idVesselToUpdate}" +
                                    "\n\nImo number: ");
                        imoNumber = Console.ReadLine().Trim();
                    }
                    while (menuService.CheckImoNumber(imoNumber));

                    string idOwner;
                    do
                    {
                        Console.Clear();
                        Show();
                        Console.Write($"\nUpdate vessel: {idVesselToUpdate}" +
                                        $"\n\nImo number: {imoNumber}" +
                                        $"\nId owner (write \"no\" for no owners): ");
                        idOwner = Console.ReadLine().Replace(" ", "").ToUpper();
                    }
                    while (menuService.CheckIdOwner(idOwner));

                    if (idOwner == "NO")
                    {
                        itemToUpdate.OwnerId = null;
                        itemToUpdate.ImoNumber = imoNumber;
                        context.SaveChanges();

                        Console.WriteLine("\nVessel created with success!");
                    }
                    else
                    {
                        bool idOwnerToConvert = int.TryParse(idOwner, out int idOwnerParsed);

                        itemToUpdate.ImoNumber = imoNumber;
                        itemToUpdate.OwnerId = idOwnerParsed;
                        context.SaveChanges();

                        Console.WriteLine("\nVessel updated with success!");
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

        public void Delete()
        {
            Console.Write("Delete a vessel" +
                                "\n\nId: ");
            string idVesselToDelete = Console.ReadLine().Replace(" ", "");
            bool idToConvert = int.TryParse(idVesselToDelete, out int idParsed);

            if (idToConvert)
            {
                var itemToDelete = context.Vessels.FirstOrDefault(vessel => vessel.Id == idParsed);

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
