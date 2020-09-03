using sccmclictr.automation;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace sccmremote
{
    public class Reference
    {
        public static string version = "0.1.0";

        public static void ShowBanner()
        {
            Console.WriteLine(" __________________________________________________________________ ");
            Console.WriteLine("| SCCMRemote - v" + version + "                                              |");
            Console.WriteLine("| By Wilson Stewart, with credit to Roger Zander and JP Dillingham |");
            Console.WriteLine("|__________________________________________________________________|");
            Console.WriteLine();
        }

        public static void ShowHelptext()
        {
            Console.WriteLine("Please run with one or more of the following arguments:");
            //Console.WriteLine("_______________________________________________");
            Console.WriteLine();

            Console.WriteLine("[TRIGGER TASK SEQUENCE]");
            Console.WriteLine();
            Console.WriteLine(" Purpose:");
            Console.WriteLine("    Trigger a task sequence that has already been advertised to the host.");
            Console.WriteLine("    Defaults to 'localhost' unless specified with '-h' or '--hostname'.");
            Console.WriteLine();
            Console.WriteLine(" Usage:");
            Console.WriteLine("    -t [Task Sequence Name] OR --TSName [Task Sequence Name]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("[SET HOSTNAME]");
            Console.WriteLine();
            Console.WriteLine(" Purpose:");
            Console.WriteLine("    Sets the hostname of the machine with the SCCM Agent to connect to.");
            Console.WriteLine();
            Console.WriteLine(" Usage:");
            Console.WriteLine("    -h [DNS Hostname or IP Address] OR --Hostname [DNS Hostname or IP Address]");
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}