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
                                $"\nOwner id: ");
                idOwner = Console.ReadLine().Trim().ToUpper();
            }
            while (menuService.CheckIdOwner(idOwner));

            if(idOwner == "NO")
            {
                Vessel newVessel = new() { ImoNumber = imoNumber};
                context.Add(newVessel);
                context.SaveChanges();

                Console.WriteLine("\nVessel created with success!");
            }
            else
            {
                bool idToConvert = int.TryParse(idOwner, out int idParsed);
                var ownerFound = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);

                Vessel newVessel = new() { ImoNumber = imoNumber, OwnerId = idParsed };
                context.Add(newVessel);
                context.SaveChanges();

                Console.WriteLine("\nVessel created with success!");
            }
        }

        public void Read()
        {
            Console.WriteLine("List of vessels:\n");
            context.Vessels.ToList().ForEach(vessel => Console.WriteLine($"ID: {vessel.Id}\tIMO NUMBER: {vessel.ImoNumber}\tOWNER: {vessel.OwnerId}"));
        }

        public void Update() 
        {

        }

        public void Delete()
        {

        }
    }
}
