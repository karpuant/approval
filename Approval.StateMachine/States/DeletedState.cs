namespace Approval.StateMachine.States
{
    internal class DeletedState : IState
    {
        #region Singleton
        private static DeletedState _instance = new DeletedState();
        private DeletedState() { }
        public static IState instance() { return _instance; }
        #endregion
        
        public StateType Type => StateType.DeletedState;

        public void Enter(ref ApprovalContext context)
        {
            Utility.LogInformation("Enter Deleted state");
            
            // Change state
            context.Transaction.State = StateType.DeletedState.ToString();
            context.Delete();
            
            Utility.LogInformation("Exit Deleted state");
        }
    }
}