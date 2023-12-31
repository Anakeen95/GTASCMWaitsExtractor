﻿namespace GetAllSCMWaits {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading;

    // OffsetData Class structure of the Offsets on the SCM
    class OffsetData {
        public int ThreadScriptsWaitGlobalOffset { get; set; }
        public int ThreadScriptsNextGlobalOffset { get; set; }
        public int MissionsWaitGlobalOffset { get; set; }
        public int MissionsWaitLocalOffset { get; set; }
        public int MissionsNextGlobalOffset { get; set; }
        public int MissionsNextLocalOffset { get; set; }
        public int WaitMilliseconds { get; set; }
    }

    // Main Program Class
    class Program {
        static void Main() {
            ShowMenu();
        }
        // Procedure to show the main menu of the program
        static void ShowMenu() {
            while (true) {
            MainMenu:
                Console.Clear(); // Clear the console for a clean menu appearance

                Console.WriteLine("------------------GTASCMWaitsExtractor-------------------");
                Console.WriteLine("Select an option (1-5): ");
                Console.WriteLine("1. Get the Waits Offsets from GTA III");
                Console.WriteLine("2. Get the Waits Offsets from GTA VC International");
                Console.WriteLine("3. Get the Waits Offsets from GTA VC Japanese");
                Console.WriteLine("4. Get the Waits Offsets from GTA SA");
                Console.WriteLine("5. Exit the program");
                Console.WriteLine("----------------------------------------------------------");

                Console.WriteLine("");

                if (int.TryParse(Console.ReadLine(), out int choice)) {
                    switch (choice) {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("You selected the option 1 (Get the Waits Offsets from GTA III).");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue....");
                            Console.ReadLine();
                            Console.WriteLine("Proceeding to count and extract the waits offsets from the GTA III Main SCM...");
                            Thread.Sleep(3000);

                            // Path to your SCM file
                            string iiiinputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"inputfiles\III_main_1.1.txt");  

                            // Path to your output file
                            string iiioutputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"output\output.txt");

                            try {
                                // Calls the procedures and functions of the application to work with the files
                                List<OffsetData> iiiwaitsoffsets = ExtractWaitsOffsets(iiiinputfile, "} 0001: wait");
                                if (iiiwaitsoffsets.Count > 0) {
                                    WriteOffsetsToFile(iiioutputfile, iiiwaitsoffsets, iiiinputfile, "} 0001: wait");
                                    Console.WriteLine("");
                                    int iiiwaits = WaitsCounter(iiiinputfile, "} 0001: wait");
                                    Console.WriteLine($"{iiiwaits} waits found in the III SCM.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Extracting the Wait Offsets and the Next Instruction from the input file...");
                                    Thread.Sleep(3000);
                                    Console.WriteLine("");
                                    Console.WriteLine("Wait Offsets extracted and written to the output file successfully.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Press any key to continue....");
                                    Console.ReadLine();
                                    Console.WriteLine("Opening the outputfile with all the data obtained...");
                                    Thread.Sleep(3000);
                                    Process.Start("notepad.exe", iiioutputfile);
                                    goto MainMenu;
                                }
                            }
                            catch (Exception e) {
                                Console.WriteLine("An error occurred: " + e.Message);
                                goto MainMenu;
                            }
                            goto MainMenu;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("You selected the option 1 (Get the Waits Offsets from GTA VC International).");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue....");
                            Console.ReadLine();
                            Console.WriteLine("Proceeding to count and extract the waits offsets from the GTA VC International Main SCM...");
                            Thread.Sleep(3000);

                            // Path to your SCM file
                            string vcintinputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"inputfiles\VC_main_INTL.txt");

                            // Path to your output file
                            string vcintoutputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"output\output.txt");

                            try {
                                // Calls the procedures and functions of the application to work with the files
                                List<OffsetData> vcintwaitsoffsets = ExtractWaitsOffsets(vcintinputfile, "} 0001: wait");
                                if (vcintwaitsoffsets.Count > 0) {
                                    WriteOffsetsToFile(vcintoutputfile, vcintwaitsoffsets, vcintinputfile, "} 0001: wait");
                                    Console.WriteLine("");
                                    int vcintwaits = WaitsCounter(vcintinputfile, "} 0001: wait");
                                    Console.WriteLine($"{vcintwaits} waits found in the VC INT SCM.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Extracting the Wait Offsets and the Next Instruction from the input file...");
                                    Thread.Sleep(3000);
                                    Console.WriteLine("");
                                    Console.WriteLine("Wait Offsets extracted and written to the output file successfully.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Press any key to continue....");
                                    Console.ReadLine();
                                    Console.WriteLine("Opening the outputfile with all the data obtained...");
                                    Thread.Sleep(3000);
                                    Process.Start("notepad.exe", vcintoutputfile);
                                    goto MainMenu;
                                }
                            }
                            catch (Exception e) {
                                Console.WriteLine("An error occurred: " + e.Message);
                                goto MainMenu;
                            }
                            goto MainMenu;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("You selected the option 3 (Get the Waits Offsets from GTA VC Japanese).");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue....");
                            Console.ReadLine();
                            Console.WriteLine("Proceeding to count and extract the waits offsets from the GTA VC Japanese Main SCM...");
                            Thread.Sleep(3000);

                            // Path to your SCM file
                            string vcjpinputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"inputfiles\VC_main_JP.txt");

                            // Path to your output file
                            string vcjpoutputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"output\output.txt");

                            try {
                                // Calls the procedures and functions of the application to work with the files
                                List<OffsetData> vcjpwaitsoffsets = ExtractWaitsOffsets(vcjpinputfile, "} 0001: wait");
                                if (vcjpwaitsoffsets.Count > 0) {
                                    WriteOffsetsToFile(vcjpoutputfile, vcjpwaitsoffsets, vcjpinputfile, "} 0001: wait");
                                    Console.WriteLine("");
                                    int vcjpwaits = WaitsCounter(vcjpinputfile, "} 0001: wait");
                                    Console.WriteLine($"{vcjpwaits} waits found in the VC JP SCM.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Extracting the Wait Offsets and the Next Instruction from the input file...");
                                    Thread.Sleep(3000);
                                    Console.WriteLine("");
                                    Console.WriteLine("Wait Offsets extracted and written to the output file successfully.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Press any key to continue....");
                                    Console.ReadLine();
                                    Console.WriteLine("Opening the outputfile with all the data obtained...");
                                    Thread.Sleep(3000);
                                    Process.Start("notepad.exe", vcjpoutputfile);
                                    goto MainMenu;
                                }
                            }
                            catch (Exception e) {
                                Console.WriteLine("An error occurred: " + e.Message);
                                goto MainMenu;
                            }
                            goto MainMenu;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("You selected the option 4 (Get the Waits Offsets from GTA SA).");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue....");
                            Console.ReadLine();
                            Console.WriteLine("Proceeding to count and extract the waits offsets from the GTA SA Main SCM...");
                            Thread.Sleep(3000);

                            // Path to your SCM file
                            string sainputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"inputfiles\SA_main_1.0.txt");  

                            // Path to your output file
                            string saoutputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"output\output.txt");

                            try {
                                // Calls the procedures and functions of the application to work with the files
                                List<OffsetData> sawaitsoffsets = ExtractWaitsOffsets(sainputfile, "} 0001: wait");
                                if (sawaitsoffsets.Count > 0) {
                                    WriteOffsetsToFile(saoutputfile, sawaitsoffsets, sainputfile, "} 0001: wait");
                                    Console.WriteLine("");
                                    int sawaits = WaitsCounter(sainputfile, "} 0001: wait");
                                    Console.WriteLine($"{sawaits} waits found in the SA SCM.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Extracting the Wait Offsets and the Next Instruction from the input file...");
                                    Thread.Sleep(3000);
                                    Console.WriteLine("");
                                    Console.WriteLine("Wait Offsets extracted and written to the output file successfully.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Press any key to continue....");
                                    Console.ReadLine();
                                    Console.WriteLine("Opening the outputfile with all the data obtained...");
                                    Thread.Sleep(3000);
                                    Process.Start("notepad.exe", saoutputfile);
                                    goto MainMenu;
                                }
                            }
                            catch (Exception e) {
                                Console.WriteLine("An error occurred: " + e.Message);
                                goto MainMenu;
                            }
                            goto MainMenu;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Exiting the program. Goodbye!");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue....");
                            // Pause to allow the user to read the message
                            Console.ReadLine(); 
                            goto End;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue....");
                            // Pause to allow the user to read the message
                            Console.ReadLine(); 
                            goto MainMenu;
                    }
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue....");
                    // Pause to allow the user to read the message
                    Console.ReadLine(); 
                    goto MainMenu;
                }
            }
        End:
            Console.Clear();
            Console.WriteLine("Press any key to exit the program....");
            Console.ReadLine();
        }
        // Function to extract the waits and the next instruction of the waits offsets numbers from the SCM File
        static List<OffsetData> ExtractWaitsOffsets(string filePath, string searchString) {
            List<OffsetData> offsets = new List<OffsetData>();

            using (StreamReader reader = new StreamReader(filePath)) {
                string line;
                // Reads the line of the wait instruction
                while ((line = reader.ReadLine()) != null) {
                    if (line.Contains(searchString)) {
                        OffsetData offsetData = new OffsetData();

                        // Uses a regular expression to get all the global offsets from the threads and external scripts in the line of the wait instruction
                        MatchCollection matchesThreadScriptsWaits = Regex.Matches(line, @"\{(\d+)\}");
                        foreach (Match match in matchesThreadScriptsWaits) {
                            offsetData.ThreadScriptsWaitGlobalOffset = GetOffsetFromMatch(match.Groups[1]);
                        }

                        // Reads the line of the next instruction of the wait offset
                        string nextLine = reader.ReadLine();

                        // Uses a regular expression to get all the global offsets from the threads and external scripts in the line of the next instruction of the wait instruction
                        MatchCollection matchesThreadScriptsNexts = Regex.Matches(nextLine, @"\{(\d+)\}");
                        foreach (Match match in matchesThreadScriptsNexts) {
                            offsetData.ThreadScriptsNextGlobalOffset = GetOffsetFromMatch(match.Groups[1]);
                        }

                        // Uses a regular expression to get all the global and local offsets from the mission scripts in the line of the wait instruction
                        MatchCollection matchesMissionsWaits = Regex.Matches(line, @"\{(\d+)\s+(\d+)\}");
                        foreach (Match match in matchesMissionsWaits) {
                            offsetData.MissionsWaitGlobalOffset = GetOffsetFromMatch(match.Groups[1]);
                            offsetData.MissionsWaitLocalOffset = GetOffsetFromMatch(match.Groups[2]);
                        }

                        // Uses a regular expression to get all the global offsets from the mission scripts in the line of the next instruction of the wait instruction
                        MatchCollection matchesMissionsNext = Regex.Matches(nextLine, @"\{(\d+)\s+(\d+)\}");
                        foreach (Match match in matchesMissionsNext) {
                            offsetData.MissionsNextGlobalOffset = GetOffsetFromMatch(match.Groups[1]);
                            offsetData.MissionsNextLocalOffset = GetOffsetFromMatch(match.Groups[2]);
                        }

                        // Uses a regular expression to get the miliseconds of the waits intructions
                        MatchCollection matchesWaitsMilliseconds = Regex.Matches(line, @"0001: wait (\d+) ms");
                        foreach (Match match in matchesWaitsMilliseconds) {
                            offsetData.WaitMilliseconds = GetOffsetFromMatch(match.Groups[1]);
                        }

                        // Uses a regular expression to get the miliseconds of the next instruction of the waits intructions
                        MatchCollection matchesWaitsMillisecondsNext = Regex.Matches(nextLine, @"0001: wait (\d+) ms");
                        foreach (Match match in matchesWaitsMillisecondsNext) {
                            offsetData.WaitMilliseconds = GetOffsetFromMatch(match.Groups[1]);
                        }
                        offsets.Add(offsetData);
                    }
                }
            }
            return offsets;
        }
        // Function to Match the Offset Group to the criteria
        static int GetOffsetFromMatch(Group matchGroup) {
            // Returns each matched offset number
            if (int.TryParse(matchGroup.Value, out int offset)) {
                return offset;
            }
            // Returns the 0 as default value if parsing fails
            return 0; 
        }
        // Procedure to Write the ouput file with the offsets numbers from the SCM File as a table
        static void WriteOffsetsToFile(string filePath, List<OffsetData> numbers, string filePath2, string searchString) {
            using (StreamWriter writer = new StreamWriter(filePath)) {
                // Write table headers
                int scmwaits = WaitsCounter(filePath2, searchString);
                writer.WriteLine($"There are {scmwaits} waits in the SCM selected, which are the following: ");
                writer.WriteLine("");
                writer.WriteLine("-----------------------------------\t-----------------------------------\t-----------------------------\t----------------------------\t-----------------------------\t----------------------------\t------------------");
                writer.WriteLine("Thread Scripts Waits Global Offsets\tThread Scripts Nexts Global Offsets\tMissions Waits Global Offsets\tMissions Waits Local Offsets\tMissions Nexts Global Offsets\tMissions Nexts Local Offsets\tWaits Milliseconds");
                writer.WriteLine("----------------------------------- \t-----------------------------------\t-----------------------------\t----------------------------\t-----------------------------\t----------------------------\t------------------");

                // Write numbers in a tabular format
                foreach (var row in numbers) {
                    writer.WriteLine($"{row.ThreadScriptsWaitGlobalOffset,-34}|\t{row.ThreadScriptsNextGlobalOffset,-34}|\t{row.MissionsWaitGlobalOffset,- 28}|\t{row.MissionsWaitLocalOffset,-27}|\t{row.MissionsNextGlobalOffset,-28}|\t{row.MissionsNextLocalOffset,-27}|\t{row.WaitMilliseconds,-17}|\t");
                }
            }
        }
        // Function to Count how many waits are in the SCM File
        static int WaitsCounter(string filePath, string searchString) {
            int count = 0;

            try {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Count occurrences in each line
                foreach (string line in lines) {
                    count += WaitsCounterInLine(line, searchString);
                }
            }
            catch (Exception e) {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            return count;
        }
        // Function to Count how many waits are in the SCM File by Line
        static int WaitsCounterInLine(string line, string searchString) {
            int count = 0;
            int index = -1;

            // Count occurrences in the line
            while ((index = line.IndexOf(searchString, index + 1)) != -1) {
                count++;
            }
            return count;
        }
    }
}

