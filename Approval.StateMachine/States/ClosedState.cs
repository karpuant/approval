
namespace Approval.StateMachine.States
{
    internal class ClosedState : IState
    {
        #region Singleton
        private static ClosedState _instance = new ClosedState();
        private ClosedState() { }
        public static IState instance() { return _instance; }
        #endregion
        
        public StateType Type => StateType.ClosedState;

        public void Enter(ref ApprovalContext context)
        {
            Utility.LogInformation("Enter Closed state");
            
            // Change state
            context.Transaction.State = StateType.ClosedState.ToString();
            context.Save();
            
            Utility.LogInformation("Exit Closed state");
        }
    }
}