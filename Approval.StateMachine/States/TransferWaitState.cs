namespace Approval.StateMachine.States
{
    internal class TransferWaitState : IState
    {
        #region Singleton
        private static TransferWaitState _instance = new TransferWaitState();
        private TransferWaitState() { }
        public static IState instance() { return _instance; }
        #endregion
        
        public StateType Type => StateType.TransferWaitState;

        public void Enter(ref ApprovalContext context)
        {
            Utility.LogInformation("Enter TransferWait state");
            
            Utility.PrepareForTransfer();

            // Change state
            context.Transaction.State = StateType.TransferWaitState.ToString();
            context.Save();
            
            Utility.LogInformation("Exit TransferWait state");
        }
    }
}