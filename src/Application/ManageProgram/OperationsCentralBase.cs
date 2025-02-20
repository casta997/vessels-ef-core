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
        public OperationsCentralBase() 
        {
            var db = new ManageVesselContext();
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
            var existImoNumber = false;
            while (!existImoNumber)
            {
                Console.WriteLine("Insert IMO Number of the vessel:");
                string msgConsole = Console.ReadLine();

                if (msgConsole.Length != 0)
                {
                    imoNumber = msgConsole;
                    existImoNumber = true;
                }

                if (msgConsole.Length == 0)
                {
                    Console.WriteLine("IMO Number is a required field!");
                    Console.Write("Press enter to continue...");
                    Console.Read();                    
                }
                Console.Clear();
            }
            
            return imoNumber;
        }

        internal string AddVessel()
        {
            var vessel = createVessel();
            return vessel.ToString();
        }
    }
}
