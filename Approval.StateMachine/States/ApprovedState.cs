namespace Approval.StateMachine.States
{
    internal class ApprovedState: IState
    {
        #region Singleton
        private static ApprovedState _instance = new ApprovedState();
        private ApprovedState() { }
        public static IState instance() { return _instance; }
        #endregion
        
        public StateType Type => StateType.ApprovedState;

        public void Enter(ref ApprovalContext context)
        {
            Utility.LogInformation("Enter Approved state");
            
            // Change state
            context.Transaction.State = StateType.ApprovedState.ToString();
            context.Save();

            // Assign and notify approvers
            Utility.NotifyEmployees();
            
            Utility.LogInformation("Exit Approved state");
        }
    }
}