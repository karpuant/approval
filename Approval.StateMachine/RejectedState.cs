using Approval.StateMachine.States;

namespace Approval.StateMachine
{
    internal class RejectedState : IState
    {
        #region Singleton
        private static RejectedState _instance = new RejectedState();
        private RejectedState() { }
        public static IState instance() { return _instance; }
        #endregion
        
        public StateType Type => StateType.RejectedState;

        public void Enter(ref ApprovalContext context)
        {
            Utility.LogInformation("Enter Rejected state");
            
            // Change state
            context.Transaction.State = StateType.RejectedState.ToString();
            context.Save();

            // Assign and notify approvers
            Utility.NotifyEmployees();
            
            Utility.LogInformation("Exit Rejected state");
        }
    }
}