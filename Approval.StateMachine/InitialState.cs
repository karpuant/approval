using Approval.StateMachine.States;

namespace Approval.StateMachine
{
    /// <summary>
    ///  The very first state in approval process
    /// </summary>
    public class InitialState : IState
    {
        #region Singleton
        private static InitialState _instance = new InitialState();
        private InitialState() { }
        public static IState instance() { return _instance; }
        #endregion

        public StateType Type => StateType.InitialState;

        public void Enter(ref ApprovalContext context)
        {
            // Do nothing, it is a first state
        }
    }
}