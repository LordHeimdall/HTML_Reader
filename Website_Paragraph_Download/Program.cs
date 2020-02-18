using System;
using System.IO;
using System.Net;

//Created by LordHeimdall

namespace HTML_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            //CREATING AND INITIALIZING VARIABLES
            string Scan_Result;
            string Company_Start = "<h1 class=\"title light big white\">";
            string Company_End = "</h1>";
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string File_Name = "Test.txt";
            getBetween Company_Class = new getBetween();
            using (WebClient client = new WebClient())
            {
                try
                {
                    //IF THE FILE ISNT FOUND, WE CREATE IT
                    if (File.Exists(Path + @"\Test.txt"))
                    {
                        Console.WriteLine("File exists, proceeding...\n");
                    }
                    else {
                        Console.WriteLine("Creating File...\n");
                        var MyFile = File.Create(File_Name);
                        MyFile.Close();
                    }

                   for (int i = 30; i <= 50; i++)   //LOOPING THROUGH THE DIFFERENT ID'S
                   {
                    Console.WriteLine("Extracting from " + i + "Out of 50");
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://rae.inadem.gob.mx/providers/provider/id/" + i);
                    myRequest.Method = "GET";
                    WebResponse myResponse = myRequest.GetResponse();

                        //CRETING STREAMREADER AND READING THE HTML FROM WEBSITE
                    StreamReader SR = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);

                        //ADDING STREAMREADER TO THE STRING FOR SCANNING...
                    string Result_SR = SR.ReadToEnd();
                    SR.Close();
                    myResponse.Close();
                        //SPACES AND \n's ARE WEIRD IN HTML, THIS SOMETIMES HELPS:
                        //String No_Spaces = Regex.Replace(Result_SR, @"\s+", string.Empty); <--UNCOMMENT THIS FOR TRIMMING SPACES

                    //GETTING THE STRING BETWEEN START AND END, ADDING IT TO RESULT_RS
                    Scan_Result = Company_Class.GetBetween(Result_SR, Company_Start, Company_End);
                    
                    //APPENDING RESULT TO TEXT FILE
                    File.AppendAllText(Path + @"\Test.txt", "Company: " + Scan_Result + "\n");
                    }
               }
                catch (Exception e) {
                    Console.WriteLine("Error " + e);
                }
                Console.ReadLine();
                Environment.Exit(0);
            }

        }
    }
}
