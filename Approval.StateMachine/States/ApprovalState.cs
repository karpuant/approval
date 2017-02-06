namespace Approval.StateMachine.States
{
    internal class ApprovalState: IState
    {
        #region Singleton
        private static ApprovalState _instance = new ApprovalState();
        private ApprovalState() { }
        public static IState instance() { return _instance; }
        #endregion
        
        public StateType Type => StateType.ApprovalState;

        public void Enter(ref ApprovalContext context)
        {
            Utility.LogInformation("Enter Approval state");

            // Change state
            context.Transaction.State = StateType.ApprovalState.ToString();
            context.Save();

            // Assign and notify approvers
            Utility.AssignAndNotifyApprovers();
            
            Utility.LogInformation("Exit Approval state");
        }
    }
}