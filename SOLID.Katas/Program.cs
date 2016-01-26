using SOLID.Katas.OCP;
using SOLID.Katas.OCP.Actions;
using SOLID.Katas.SRP;
using SOLID.Katas.SRP.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter:");
            Console.WriteLine("\t'S' to run the SRP program");
            Console.WriteLine("\t'O' to run the OCP program");
            var option = Console.ReadLine();
            switch (option.Trim().ToUpper())
            {
                case "S": 
                    Program.RunSrp();
                    break;
                case "O":
                    Program.RunOcp();
                    break;
                default:
                    Console.WriteLine("Unrecognized option");
                    break;
            }

            Console.WriteLine("Enter any key to finish");
            Console.ReadKey();
        }

        static void RunSrp()
        {
            var controller = new UserController();

            Console.WriteLine("Creating first user...");
            var user = controller.Create(new UserDTO { Email = "foo@foo.com", Name = "Foo" });                        
            
            Console.WriteLine("Creating second user...");
            controller.Create(new UserDTO { Email = "bar@bar.com", Name = "Bar" });
            
            Console.WriteLine("Getting first user by Id");
            var retrievedUser = controller.Get(user.Id);
            Console.WriteLine(retrievedUser != null ? "OK" : "FAILED");
            
            Console.WriteLine("Adding third user");
            controller.Create(new UserDTO { Email = "bar@bar.com", Name = "Bar2" });
            
            Console.WriteLine("Getting all users");
            var users = controller.GetAll();
            Console.WriteLine(users.Count() == 3 ? "OK" : "FAILED");
        }

        static void RunOcp()
        {
            var actionExecutor = new ActionExecutor();
            
            Console.WriteLine("Executing start recording action");
            var startRecordingAction = new StartRecordingAction { RecordingId = 1, ChannelId = 42, StartTime = DateTime.Now, StopTime = DateTime.Now.AddHours(2) };
            actionExecutor.ExecuteActions(new List<RecordingAction> { startRecordingAction });

            Console.WriteLine("Executing stop recording action");
            var stopRecordingAction = new StopRecordingAction { RecordingId = 1, StopTime = DateTime.Now.AddHours(1) };
            actionExecutor.ExecuteActions(new List<RecordingAction> { stopRecordingAction });

            Console.WriteLine("Executing list of actions");
            actionExecutor.ExecuteActions(new List<RecordingAction> { 
                new StopRecordingAction { RecordingId = 9287, StopTime = DateTime.Now },
                new StartRecordingAction { RecordingId = 322, ChannelId = 11, StartTime = DateTime.Now.AddMinutes(15), StopTime = DateTime.Now.AddHours(1) },
                new StartRecordingAction { RecordingId = 23, ChannelId = 4, StartTime = DateTime.Now, StopTime = DateTime.Now.AddMinutes(30) }
            });
        }
    }
}
