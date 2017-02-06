namespace Approval.StateMachine
{
    /// <summary>
    /// All the commands used in workflows to trigger state transition
    /// </summary>
    public enum Command
    {
        Post,       // start new process
        Update,     // update transaction
        Delete,     // delete transaction
        Approve,    // approve && task.approve
        Reject,     // reject && task.reject
        Transfer,   // transfer
        Next        // used in unconditional or scheduled state transitions (e.g. transition should be performed after 24 hours)
    }
}