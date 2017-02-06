using System;
using Approval.StateMachine;

namespace ApprovalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction = new PayrollTransaction
            {
                ReasonText = "Vacation",
                State = ""
            };
            var userInfo = new UserInfo();

            var process = ApprovalProcessFactory.GetProcess("GenericApproval", transaction, userInfo);


            var command = string.Empty;
            while (command != "x")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Choose command: [p]ost, [u]pdate, [d]elete, [a]pprove, [r]eject, [t]ransfer or e[x]it");
                command = Console.ReadLine();
                switch (command)
                {
                    case "p":
                        process.ProcessCommand(Command.Post); break;
                    case "u":
                        process.ProcessCommand(Command.Update); break;
                    case "d":
                        process.ProcessCommand(Command.Delete); break;
                    case "a":
                        process.ProcessCommand(Command.Approve); break;
                    case "r":
                        process.ProcessCommand(Command.Reject); break;
                    case "t":
                        process.ProcessCommand(Command.Transfer); break;
                    case "x":
                        break;
                }
            }
        }
    }
}
