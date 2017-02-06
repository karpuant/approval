using System;
using System.Collections.Generic;

namespace Approval.StateMachine
{
    public class Utility
    {
        public static void SaveCalculatedTransactions(List<PayrollTransaction> calculationResult)
        {
            // Do saving
            LogInformation("  Saving calculated transactions");
        }

        public static List<PayrollTransaction> CalculateTransaction(PayrollTransaction transaction)
        {
            // Call calculation set for payroll instance
            LogInformation("  Calculating transaction");
            return new List<PayrollTransaction>();
        }

        internal static void PrepareForTransfer()
        {
            LogInformation("  Preparing for transfer");
        }

        internal static void NotifyEmployees()
        {
            LogInformation("  Sending notifications to employees");
        }

        public static List<ValidationFault> ValidateTransaction(PayrollTransaction transaction)
        {
            // Call validation set for payroll instance
            LogInformation("  Validating transaction");
            return new List<ValidationFault>();
        }

        public static void AssignAndNotifyApprovers()
        {
            LogInformation("  Assigning approvers");
        }
        
        #region Logging
        public static void LogError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
        }
        public static void LogWarning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
        }
        public static void LogInformation(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
        }
        #endregion
    }
}