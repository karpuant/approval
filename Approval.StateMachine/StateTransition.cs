using Approval.StateMachine.States;

namespace Approval.StateMachine
{
    /// <summary>
    /// state transition stores a combination of a state and a command 
    /// </summary>
    class StateTransition
    {
        readonly StateType CurrentState;
        readonly Command Command;

        public StateTransition(StateType currentState, Command command)
        {
            CurrentState = currentState;
            Command = command;
        }

        // This class is used as a key in hash tables
        public override int GetHashCode()
        {
            return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var st = obj as StateTransition;
            return st != null && this.CurrentState == st.CurrentState && this.Command == st.Command;
        }
    }

}
