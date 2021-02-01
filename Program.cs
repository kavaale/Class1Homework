using System;
using System.IO;

namespace Class1Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!File.Exists("text.txt")){
                StreamWriter sw = new StreamWriter("text.txt");
                sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                sw.Close();
            }
            int x = 1;
            while(x == 1){
                x = MainMenu();
            }
        }

        static int MainMenu(){
            //terminal for program
            int x = 1;
            Console.WriteLine("Select Command");
            Console.WriteLine("1. Add Ticket");
            Console.WriteLine("2. Remove Ticket");
            Console.WriteLine("3. List Tickets");
            Console.WriteLine("4. Close");
            String choice = Console.ReadLine();
            if(choice == "1"){
                Console.WriteLine();
                RunAdd();
            }
            else if(choice == "2"){
                Console.WriteLine();
                RunRemove();
            }
            else if(choice == "3"){
                Console.WriteLine();
                RunList();
            }
            else if(choice == "4"){
                x = 0;
            }
            else{
                Console.WriteLine("Unrecognized Command");
            }
            return x;
        }


        static void RunAdd(){
            //adds ticket into file
            Console.WriteLine("Enter Ticket Info");
            Console.Write("Ticket ID: ");
            String ticketID = Console.ReadLine();
            Console.Write("Summary: ");
            String summary = Console.ReadLine();
            Console.Write("Status: ");
            String status = Console.ReadLine();
            Console.Write("Priority: ");
            String priority = Console.ReadLine();
            Console.Write("Submitter: ");
            String submitter = Console.ReadLine();
            Console.Write("Assigned: ");
            String assigned = Console.ReadLine();
            int x = 1;
            String watching = String.Empty;
            while(x == 1){
                Console.Write("Watching: ");
                watching = watching + "|" + Console.ReadLine();
                Console.WriteLine("Add another watcher? 1=yes 2=no");
                x = int.Parse(Console.ReadLine());
            }
            watching=watching.Substring(1);
            String fullString = ticketID + "," + summary + "," + status + "," + priority + "," + submitter + "," + assigned + "," + watching;
            StreamWriter sw = new StreamWriter("text.txt", true);
            sw.WriteLine(fullString);
            sw.Close();
            Console.WriteLine("Ticket Added");
            Console.WriteLine();
        }

        static void RunRemove(){
            Console.WriteLine("Ticket Removal");
            StreamReader sr = new StreamReader("text.txt");
            string[] wholeFile = File.ReadAllLines("text.txt");
            int i = 1;
            int x = 0;
            while(i < wholeFile.Length){
                string[] lineHolder = wholeFile[i].Split(",");
                string[] watchHolder = lineHolder[6].Split("|");
                i++;
                x = 1;
                String watchString = watchHolder[0];
                while(x < watchHolder.Length){
                    watchString = watchString + ", " + watchHolder[x];
                    x++;
                }
                Console.WriteLine(i-1 + ". TicketID: " + lineHolder[0] + " Summary: " + lineHolder[1] + " Status: " + lineHolder[2] + " Priority: " + lineHolder[3] + " Submitter: " + lineHolder[4] + 
                " Assigned: " + lineHolder[5] + " Watching: " + watchString);
            }
            sr.Close();


            Console.WriteLine("Which file would you like to delete? 0=exit");
            x = int.Parse(Console.ReadLine());
            if(x != 0){
                String[] newFile = new String[wholeFile.Length-1];
                i = 0;
                int b = 0;
                while(i < wholeFile.Length){
                    if(x != i){
                        newFile[b] = wholeFile[i];
                        b++;
                    }
                    i++;
                }
                StreamWriter sw = new StreamWriter("text.txt");
                i = 0;
                while(i < newFile.Length){
                    sw.WriteLine(newFile[i]);
                    i++;
                }
                sw.Close();
                Console.WriteLine("Ticket Removed");
            }
            Console.WriteLine();
        }
        static void RunList(){
            Console.WriteLine("Ticket List");
            StreamReader sr = new StreamReader("text.txt");
            string[] wholeFile = File.ReadAllLines("text.txt");
                int i = 1;
                int x = 0;
            while(i < wholeFile.Length){
                string[] lineHolder = wholeFile[i].Split(",");
                string[] watchHolder = lineHolder[6].Split("|");
                i++;
                x = 1;
                String watchString = watchHolder[0];
                while(x < watchHolder.Length){
                    watchString = watchString + ", " + watchHolder[x];
                    x++;
                }
                Console.WriteLine(i-1 + ". TicketID: " + lineHolder[0] + " Summary: " + lineHolder[1] + " Status: " + lineHolder[2] + " Priority: " + lineHolder[3] + " Submitter: " + lineHolder[4] + 
                " Assigned: " + lineHolder[5] + " Watching: " + watchString);
            }
            sr.Close();
            Console.WriteLine();
        }
    }
}
