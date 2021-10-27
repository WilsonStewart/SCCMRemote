![](attachments/161808529/161808530.png?height=250)

**Overview**
============

SCCMRemote is a console .NET application written in C#. By utilizing the [sccmclictr](https://github.com/rzander/sccmclictr) library, it can, amongst its other functions, be used to trigger a previously deployed task sequence from either the localhost or for a remote machine.

**Basic Operation**
===================

The following is the help text from the program, which explains the basic command line arguments:

![](attachments/161808529/161808537.png?effects=drop-shadow)

The program requires three files in its directory in order to work:

*   `sccmremote.exe`
*   `sccmclictr.automation.dll`
*   `Utility.CommandLine.Arguments.dll`

**How to trigger a task sequence**
==================================

In order to trigger a task sequence, first deploy the TS to the host using ConfigManager.

Then, run `sccmremote.exe` with the command line arugment `-t` or `--TSName` followed by the name of the task sequence in double quotes.

_EXAMPLE: `sccmremote.exe -t "Deploy Windows 10 1909"`_ 

The previous example will deploy the task sequence to the local host. In order to specify a remote host, add the `-h`  or `--Hostname` argument, followed by the DNS hostname.

_EXAMPLE: `sccmremote.exe -t "Deploy Windows 10 1909"`  `-h 100100-HA412`_

**Other helpful information**
=============================

*   If an argument switch isn't working, make sure you're using dash (vs slash) notation. E.g. `-t Deploy Windows 10 1909` instead of `/t Deploy Windows 10 1909` .
*   If the program is run from a command prompt with no arguments, it will display the help text shown above.
*   In order to trigger the task sequence when nobody is logged in, run the program as a scheduled task using the `SYSTEM` account.