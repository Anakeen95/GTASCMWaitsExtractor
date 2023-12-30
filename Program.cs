namespace GetAllSCMWaits {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading;

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
                            Console.WriteLine("You selected Option 1.");
                            Console.ReadLine(); // Pause to allow the user to read the message
                            goto MainMenu;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("You selected Option 2.");
                            Console.ReadLine(); // Pause to allow the user to read the message
                            goto MainMenu;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("You selected Option 3.");
                            Console.ReadLine(); // Pause to allow the user to read the message
                            goto MainMenu;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("You selected the option 4 (Get the Waits Offsets from GTA SA).");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue....");
                            Console.ReadLine(); // Pause to allow the user to read the message
                            Console.WriteLine("Proceeding to extract the waits offsets from the GTA SA Main SCM...");
                            Thread.Sleep(3000);

                            // Path to your SCM file
                            string inputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"inputfiles\SA_main_1.0.txt"); //"D:\\Dev\\C#\\GetAllSCMWaits\\inputfiles\\test.txt";     

                            // Path to your output fileSA_main_1.0
                            string outputfile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"output\output.txt");

                            try {
                                // Calls the procedures of the application to work with the files
                                List<int> waitsoffsets = ExtractWaitsOffsets(inputfile, "} 0001: wait");
                                if (waitsoffsets.Count > 0) {
                                    WriteNumbersToFile(outputfile, waitsoffsets);
                                    Console.WriteLine("");
                                    Console.WriteLine("Numbers extracted and written to the output file successfully.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Press any key to continue....");
                                    Console.ReadLine();
                                    Console.WriteLine("Opening the outputfile with all the data obtained...");
                                    Thread.Sleep(3000);
                                    Process.Start("notepad.exe", outputfile);
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
                            Console.ReadLine(); // Pause to allow the user to read the message
                            goto End;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue....");
                            Console.ReadLine(); // Pause to allow the user to read the message
                            goto MainMenu;
                    }
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadLine(); // Pause to allow the user to read the message
                    goto MainMenu;
                }
            }
        End:
            Console.Clear();
            Console.WriteLine("Press any key to exit the program....");
            Console.ReadLine();
        }
        // Function to extract the waits and the next instruction of the waits offsets numbers from the SCM File
        static List<int> ExtractWaitsOffsets(string filePath, string searchString) {
            List<int> offsets = new List<int>();
            using (StreamReader reader = new StreamReader(filePath)) {
                // Reads the line of the wait offset
                string line;
                while ((line = reader.ReadLine()) != null) {
                    if (line.Contains(searchString)) {
                        // Uses a regular expression to find all the global offsets from the threads and external scripts in the line of the wait instruction
                        MatchCollection matchesthreadscriptwaits = Regex.Matches(line, @"\{(\d+)\}");
                        
                        // Converts and adds each matched offset number to the list
                        foreach (Match match in matchesthreadscriptwaits) {
                            GroupCollection threadscriptsoffsetswaitsgroup = match.Groups;
                            string globaloffsetsthreadscriptswaits = threadscriptsoffsetswaitsgroup[1].Value;
                            if (int.TryParse(globaloffsetsthreadscriptswaits, out int number)) {
                                offsets.Add(number);
                            }
                        }

                        // Reads the line of the next instruction of the wait offset
                        string nextLine = reader.ReadLine();

                        // Uses a regular expression to find all the global offsets from the threads and external scripts in the line of the next instruction of the wait instruction
                        MatchCollection matchesthreadscriptsnexts = Regex.Matches(nextLine, @"\{(\d+)\}");

                        // Converts and adds each matched offset number to the list
                        foreach (Match match in matchesthreadscriptsnexts) {
                            GroupCollection threadscriptsoffsetsnextsgroup = match.Groups;
                            string globaloffsetsthreadscriptssnexts = threadscriptsoffsetsnextsgroup[1].Value;
                            if (int.TryParse(globaloffsetsthreadscriptssnexts, out int number)) {
                                offsets.Add(number);
                            }
                        }

                        // Uses a regular expression to find all the global and local offsets from the mission scripts in the line of the wait instruction
                        MatchCollection matchesmissionwaits = Regex.Matches(line, @"\{(\d+)\s+(\d+)\}");

                        // Converts and adds each matched offset number to the list
                        foreach (Match match in matchesmissionwaits) {
                            GroupCollection missionswaitsoffsetsgroup = match.Groups;
                            string globaloffsetmissionswait = missionswaitsoffsetsgroup[1].Value;
                            string localoffsetmissionswait = missionswaitsoffsetsgroup[2].Value;
                            if (int.TryParse(globaloffsetmissionswait, out int waitnumberglobal)) {
                                offsets.Add(waitnumberglobal);
                            }
                            if (int.TryParse(localoffsetmissionswait, out int waitnumberlocal)) {
                                offsets.Add(waitnumberlocal);
                            }
                        }

                        // Uses a regular expression to find all the global offsets from the mission scripts in the line of the next instruction of the wait instruction
                        MatchCollection matchesmissionnext = Regex.Matches(nextLine, @"\{(\d+)\s+(\d+)\}");

                        // Converts and adds each matched offset number to the list
                        foreach (Match match in matchesmissionnext) {
                            GroupCollection missionsnextoffsetsgroup = match.Groups;
                            string globaloffsetmissionwait = missionsnextoffsetsgroup[1].Value;
                            string localoffsetmissionswait = missionsnextoffsetsgroup[2].Value;
                            if (int.TryParse(globaloffsetmissionwait, out int nextnumberglobal)) {
                                offsets.Add(nextnumberglobal);
                            }
                            if (int.TryParse(localoffsetmissionswait, out int nextnumberlocal)) {
                                offsets.Add(nextnumberlocal);
                            }
                        }
                    }
                }
            }
            return offsets;
        }
        // Procedure to Write the ouput file with the offsets numbers from the SCM File
        static void WriteNumbersToFile(string filePath, List<int> numbers) {
            using (StreamWriter writer = new StreamWriter(filePath)) {
                writer.WriteLine(); // Move to the next line after writing headers
                foreach (int number in numbers) {
                    writer.WriteLine(number);
                }
            }
        }
    }
}
