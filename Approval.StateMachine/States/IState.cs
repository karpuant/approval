namespace Approval.StateMachine.States
{
    public interface IState
    {
        StateType Type { get; }
        void Enter(ref ApprovalContext context);
    }
}