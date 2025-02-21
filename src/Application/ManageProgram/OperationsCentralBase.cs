using Application.DBContext;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ManageProgram
{
    internal class OperationsCentralBase
    {
        private readonly ManageVesselContext db;
        public OperationsCentralBase() 
        {
            db = new ManageVesselContext();
        }

        private Vessel createVessel() 
        {
            var imoNumber = insertImoNumber();
            Vessel createdVessel = new Vessel();
            createdVessel.ImoNumber = imoNumber;
            return createdVessel; 
        }

        private string insertImoNumber()
        {
            var imoNumber = "";
            var msgConsole = "";
            var existImoNumber = false;
            while (!existImoNumber)
            {
                Console.Clear();
                Console.WriteLine("Insert IMO Number of the vessel:");
                msgConsole = Console.ReadLine();

                if (msgConsole.Trim().Length != 0)
                {
                    imoNumber = msgConsole;
                    existImoNumber = true;
                } else
                {
                    Console.WriteLine("IMO Number is a required field!");
                    Console.Write("Press any key to continue... ");
                    Console.ReadKey();
                }
            }
            
            return imoNumber;
        }

        private List<Vessel> getVessels()
        {
            var vessels = db.Vessels.ToList();
            return vessels;
        }

        internal string AddVessel()
        {
            var msgAddVessel = "Vessel added correctly!";
            var vessel = createVessel();

            try
            {
                db.Vessels.Add(vessel);
                db.SaveChanges();
            } catch 
            {
                msgAddVessel = "Error with adding of the vessel";
            }

            return msgAddVessel;
        }

        internal void ShowVessels()
        {
            var vessels = getVessels();

            vessels.ForEach(ve => {
                Console.WriteLine(ve);
            });
        }
    }
}
