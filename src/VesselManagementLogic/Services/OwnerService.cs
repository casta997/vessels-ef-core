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
        private static VesselService vesselService = new VesselService();

        //Method used for the creation of a owner
        public void Create()
        {
            //Do-while for the input name
            string name;
            do
            {
                Console.Clear();
                Console.Write("Create an owner" +
                                "\n\nFirst name: ");
                name = Console.ReadLine().Trim();
            }
            //Validation of the input name
            while (menuService.CheckInput(name));

            //Do-while for the input surname
            string surname;
            do
            {
                Console.Clear();
                Console.Write("Create an owner" +
                                $"\n\nFirst name: {name}"+
                                $"\nLast name: ");
                surname = Console.ReadLine().Trim();
            }
            //Validation of the input surname
            while (menuService.CheckInput(surname));

            if (name != null && surname != null)
            {
                Owner newOwner = new() { FirstName = name, LastName = surname };
                context.Add(newOwner);
                context.SaveChanges();

                Console.WriteLine("\nOwner created with success!");
            }
            else
            {
                Console.WriteLine("\nError during the creation!");
            }
            
        }

        //Method that prints the owner table
        public void PrintTable()
        {
            Console.WriteLine("\nList of owners:\n");
            context.Owners.ToList().ForEach(owner => Console.WriteLine($"ID: {owner.Id}\tFIRST NAME: {owner.FirstName}\tLAST NAME: {owner.LastName}"));
        }

        //Method used for updating the details of an owner
        public void Update()
        {
            PrintTable();
            Console.Write("\nUpdate an owner" +
                                "\n\nId: ");
            string idOwnerToUpdate = Console.ReadLine().Replace(" ", "");
            bool idToConvert = int.TryParse(idOwnerToUpdate, out int idParsed);

            //Check to see if the id is valid
            if (idToConvert)
            {
                var itemToUpdate = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);

                //Check to see if the id exist in the db
                if (itemToUpdate != null)
                {
                    //Do-while for the input name
                    string name;
                    do
                    {
                        Console.Clear();
                        vesselService.PrintTable();
                        PrintTable();
                        Console.Write($"\nUpdate owner: {idOwnerToUpdate}" +
                                        "\n\nFirst name: ");
                        name = Console.ReadLine().Trim();
                    }
                    //Validation of the input name
                    while (menuService.CheckInput(name));

                    //Do-while for the input surname
                    string surname;
                    do
                    {
                        Console.Clear();
                        vesselService.PrintTable();
                        PrintTable();
                        Console.Write($"\nUpdate owner: {idOwnerToUpdate}" +
                                        $"\n\nFirst name: {name}" +
                                        $"\nLast name: ");
                        surname = Console.ReadLine().Trim();
                    }
                    //Validation of the input surname
                    while (menuService.CheckInput(surname));

                    if (name != null && surname != null)
                    {
                        itemToUpdate.FirstName = name;
                        itemToUpdate.LastName = surname;
                        context.SaveChanges();

                        Console.WriteLine("\nOwner updated with success!");
                    }
                    else
                    {
                        Console.WriteLine("\nError during the update!");
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

        //Method used to delete a owner by its id
        public void Delete()
        {
            vesselService.PrintTable();
            PrintTable();
            Console.Write("Delete an owner"+
                                "\n\nId: ");
            string idOwnerToDelete = Console.ReadLine().Replace(" ", "");
            bool idToConvert = int.TryParse(idOwnerToDelete, out int idParsed);

            //Check to see if the id is valid
            if (idToConvert)
            {
                var itemToDelete = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);

                //Check to see the id exist in the db
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

        //Method used to assign an owner to a vessel
        public void AssignVessel()
        {
            //Do-while for the input idVesselToAssign
            string idVesselToAssign;
            do
            {
                Console.Clear();
                vesselService.PrintTable();
                PrintTable();
                Console.Write("\nAssign vessel\n\nId Vessel: ");
                idVesselToAssign = Console.ReadLine().Replace(" ", "");
            }
            //Validation of the input
            while (menuService.CheckIdVessel(idVesselToAssign));

            //Do-while for the input idOwnerToAssign
            string idOwnerToAssign;
            do
            {
                Console.Clear();
                vesselService.PrintTable();
                Console.WriteLine();
                PrintTable();
                Console.Write($"\nAssign vessel\n\nId Vessel: {idVesselToAssign}\nId Owner: ");
                idOwnerToAssign = Console.ReadLine().Replace(" ", "");
            }
            //Validation of the input
            while (menuService.CheckIdOwner(idOwnerToAssign));

            bool idVesselToConvert = int.TryParse(idVesselToAssign, out int idVesselParsed);
            bool idOwnerToConvert = int.TryParse(idOwnerToAssign, out int idOwnerParsed);
            var itemToUpdate = context.Vessels.FirstOrDefault(vessel => vessel.Id == idVesselParsed);

            if (itemToUpdate != null)
            {
                itemToUpdate.OwnerId = idOwnerParsed;
                context.SaveChanges();

                Console.WriteLine("\nVessel assigned with success!");
            }
            else
            {
                Console.WriteLine("\nVessel not found!");
            }

            //PrintTable();
            //Console.WriteLine();
            //vesselService.PrintTable();
            //Console.Write("\nAssign vessel\n\nId Vessel: ");
            //string idVesselToAssign = Console.ReadLine().Replace(" ", "");

            //bool idToConvert = int.TryParse(idVesselToAssign, out int idParsed);

            //if (idToConvert)
            //{
            //    var itemToAssign = context.Vessels.FirstOrDefault(vessel => vessel.Id == idParsed);

            //    if (itemToAssign != null)
            //    {
            //        Console.Write("\nId Owner: ");
            //        string idOwner = Console.ReadLine().Replace(" ", "");

            //        bool idOwnerToConvert = int.TryParse(idOwner, out int idOwnerParsed);

            //        if (idOwnerToConvert)
            //        {
            //            var itemAssignedTo = context.Owners.FirstOrDefault(owner => owner.Id == idOwnerParsed);

            //            if (itemAssignedTo != null)
            //            {
            //                itemToAssign.OwnerId = idOwnerParsed;
            //                context.SaveChanges();

            //                Console.WriteLine("\nVessel assigned with success!");
            //            }
            //            else
            //            {
            //                Console.WriteLine("\nItem not found!");
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("\nInvalid input!");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("\nItem not found!");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("\nInvalid input!");
            //}
        }
    }
}
