namespace GetAllSCMWaits {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    class Program {
        static void Main() {
            // Path to your SCM file
            string inputfile = "F:\\Speedrun\\Grand Theft Auto San Andreas 1.01\\Useful Documents\\Decompiled Mission Script GTA SA By GTAG (with local offsets).txt";

            // Path to your output file
            string outputfile = "D:\\Dev\\C#\\GetAllSCMWaits\\output\\output.txt";

            try {
                //Calls the procedures of the application
                List<int> waitsoffsets = ExtractWaitsOffsets(inputfile, "} 0001: wait");
                if (waitsoffsets.Count > 0) {
                    WriteNumbersToFile(outputfile, waitsoffsets);
                    Console.WriteLine("Numbers extracted and written to the output file successfully.");
                }
                // Read all lines from the SCM file
                //string[] lines = File.ReadAllLines(inputfile);

                // Search for lines containing the wait instruction string
                /* foreach (string line in lines) {
                    if (line.Contains("} 0001: wait")) {
   
                        // Extract the offsets numbers from the wait instruction
                        List<int> waitsoffsets = ExtractWaitsOffsets(line);

                        /* Print the waits offsets numbers
                        Console.WriteLine("Wait Offset: " + string.Join(", ", waitsoffsets));*/
                //}
                //}
                // Search for lines containing the wait instruction string and gets the next instrucion of the wait
                /* for (int i = 0; i < lines.Length - 1; i++) {
                    if (lines[i].Contains("} 0001: wait")) {
                        string linebelowait = lines[i + 1];
                        List<int> nextintructionoffsets = ExtractWaitsOffsets(linebelowait);

                        /* Print the next instruction of the wait offsets
                        Console.WriteLine("Next Intruction of the Wait Offset: " + string.Join(", ", nextintructionoffsets));*/
                //}
                //} 
            }
            catch (Exception e) {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
        // Procedure to extract the waits and the next instruction of the waits offsets numbers from the SCM File
        static List<int> ExtractWaitsOffsets(string filePath, string searchString) {
            List<int> offsets = new List<int>();
            using (StreamReader reader = new StreamReader(filePath)) {
                // Reads the line of the wait offset
                string line;
                while ((line = reader.ReadLine()) != null) {
                    if (line.Contains(searchString)) {
                        // Use a regular expression to find all numbers of the line
                        MatchCollection matcheswais = Regex.Matches(line, @"\b\d+\b");

                        // Convert and add each matched number to the list
                        foreach (Match match in matcheswais) {
                            if (int.TryParse(match.Value, out int number)) {
                                offsets.Add(number);
                            }
                        }

                        //Reads the line of the next instruction of the wait offset
                        string nextLine = reader.ReadLine();

                        // Use a regular expression to find all numbers of the line
                        MatchCollection matchesnext = Regex.Matches(nextLine, @"\b\d+\b");

                        // Convert and add each matched number to the list
                        foreach (Match match in matchesnext) {
                            if (int.TryParse(match.Value, out int number)) {
                                offsets.Add(number);
                            }
                        }
                    }
                }
            }
            return offsets;
        }
        //Procedure to Write the ouput file with the offsets numbers from the SCM File
        static void WriteNumbersToFile(string filePath, List<int> numbers) {
            using (StreamWriter writer = new StreamWriter(filePath)) {
                foreach (int number in numbers) {
                    writer.WriteLine(number);
                }
            }
        }
    }
}
