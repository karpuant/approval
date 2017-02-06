namespace Approval.StateMachine.States
{
    internal class TransferedState : IState
    {
        #region Singleton
        private static TransferedState _instance = new TransferedState();
        private TransferedState() { }
        public static IState instance() { return _instance; }
        #endregion
        
        public StateType Type => StateType.TransferedState;

        public void Enter(ref ApprovalContext context)
        {
            Utility.LogInformation("Enter Transfered state");
            
            // Change state
            context.Transaction.State = StateType.TransferedState.ToString();
            context.Save();
            
            Utility.LogInformation("Exit Transfered state");
        }
    }
}