using System;

namespace Approval.StateMachine.States
{
    public class NewState : IState
    {
        #region Singleton
        private static NewState _instance = new NewState();
        private NewState() { }
        public static IState instance() { return _instance; }
        #endregion

        public StateType Type => StateType.NewState;
        public void Enter(ref ApprovalContext context)
        {
            Utility.LogInformation("Enter New state");
            // New transaction arrived
            try
            {
                // Instead of calling validation and calculation workflows - use methods directly
                var calculationResult = Utility.CalculateTransaction(context.Transaction);
                context.ValidationFaults.AddRange(Utility.ValidateTransaction(context.Transaction));
                Utility.SaveCalculatedTransactions(calculationResult);
            }
            catch (Exception e)
            {
                // if smth goes wrong update faults in context
                context.ValidationFaults.Add(new ValidationFault());
                Utility.LogError(e.Message);
            }
            context.Transaction.State = StateType.NewState.ToString();
            context.Save();
            Utility.LogInformation("Exit New state");
        }
    }
}