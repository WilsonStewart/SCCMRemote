using sccmclictr.automation;
using sccmclictr.automation.functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sccmremote
{
    class SCCMControl
    {
        // Method to connect to an SCCM Agent on a machine, specified by hostname.
        public static SCCMAgent ConnectAgent(string Hostname)
        {
            Console.WriteLine("Attempting to initiate connection to SCCM Agent on host '" + Hostname + "'...");
            try
            {
                SCCMAgent agent = new SCCMAgent(Hostname);
                if (agent.isConnected)
                {
                    Console.WriteLine("Successfully connected to SCCM Agent on host '" + Hostname + "'!");
                    Console.WriteLine();
                    return agent;
                }
            } catch
            {
                Console.WriteLine("<ERROR> Unable to connect to SCCM Agent on host '" + Hostname + "'!");
                System.Environment.Exit(1);
            }
            return null;
        }

        // Method to trigger an already advertised task sequence immediatly.
        public static void TSTrigger(string Hostname, string TSName)
        {
            // Initilize some variables that we will need later on.
            softwaredistribution.CCM_SoftwareDistribution selectedAdvert = null;

            // Connects to the SCCM Agent on the target machine.
            SCCMAgent oAgent = ConnectAgent(Hostname);

            // Adds all adverts available on target to a list.
            var allAdverts = oAgent.Client.SoftwareDistribution.Advertisements_(true);
            Console.WriteLine("The host '" + Hostname + "' has the following advertisements assigned to it:");
            //Console.WriteLine("------------------------------");
            // Loops through all the adverts and 1) Prints them; 2) Selects the targeted advert via the supplied TSName var and prepares it to be triggered.
            foreach (softwaredistribution.CCM_SoftwareDistribution adv in allAdverts)
            {
                Console.WriteLine("-->  " + adv.PKG_Name);
                if (adv.PKG_Name == TSName)
                {
                    selectedAdvert = adv;
                }
            }
            Console.WriteLine();

            // Shows the selected advert if it exists, catches the error if it doesn't.
            try
            {
                Console.WriteLine("The following advertisement has been selected for install:");
                Console.WriteLine("-->  " + selectedAdvert.PKG_Name);
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("<ERROR> The advertisment '" + TSName + "' was not found!");
                System.Environment.Exit(1);
            }


            // Sets the selected advert to immediatly start.
            Console.WriteLine("Triggering " + selectedAdvert.PKG_Name + "...");
            selectedAdvert.TriggerSchedule(true);
            Console.WriteLine("Advertisment '" + selectedAdvert.PKG_Name + "' triggered.");
            Console.WriteLine();
        }

        // Method to trigger a machine policy update.
        // public static void TriggerMachinePolicyUpdate(string Hostname) {
 
           //SCCMAgent oAgent = ConnectAgent(Hostname);
           //oAgent.Client
        //}

        
    }
}
