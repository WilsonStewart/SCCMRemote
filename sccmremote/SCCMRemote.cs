/* SCCMRemoteTS
 * by Wilson Stewart
 * v0.1.0
 * 
 * Full credit goes to Roger Zander for his sccmclictr.automation.dll library.
 * See https://github.com/rzander/sccmclictrlib.
 * 
 * Full credit goes to JP Dillingham for his Utility.CommandLine.Arguments library.
 * See https://github.com/jpdillingham/Utility.CommandLine.Arguments.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using sccmclictr.automation;
using sccmclictr.automation.functions;
using Utility.CommandLine;

namespace sccmremote
{
    internal class SCCMRemote
    {
        [Argument('h', "Hostname", "Hostname for SCCM Client system to connect to. Default is 'localhost'")]
        private static string argHostname { get; set; }

        [Argument('t', "TSName", "Task Sequence to run on target host.")]
        private static string argTSName { get; set; }
        
        public static void Main(string[] args)
        {
            // Initiates the arguments provided into their respective vars.
            Arguments.Populate();

            // Displays the program name, version, and other pertinant info.
            Reference.ShowBanner();

            // Shows helptext if no arugments were given.
            if (args.Length == 0)
            {
                Reference.ShowHelptext();
                System.Environment.Exit(0);
            }

            // The following are a number of 'if' statements to parse the commandline arugments.

            // Initates the TSTrigger function with the required TSName and optional host.
            if (argTSName != null)
            {
                if (argHostname == null)
                {
                    SCCMControl.TSTrigger("localhost", argTSName);
                }
                else
                {
                    SCCMControl.TSTrigger(argHostname, argTSName);
                }
            }
        }

    }
}