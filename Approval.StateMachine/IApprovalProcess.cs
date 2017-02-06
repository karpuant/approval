namespace Approval.StateMachine
{
    public interface IApprovalProcess
    {
        void ProcessCommand(Command command);
    }
}