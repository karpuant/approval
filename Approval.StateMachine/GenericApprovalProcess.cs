using System;
using System.Collections.Generic;
using Approval.StateMachine.States;

namespace Approval.StateMachine
{
    public class GenericApprovalProcess : IApprovalProcess
    {
        private readonly Dictionary<StateTransition, StateType> _transitions;
        public IState CurrentState { get; private set; }
        private ApprovalContext _context;

        public GenericApprovalProcess(PayrollTransaction transaction, UserInfo userInfo)
        {
            _context = new ApprovalContext
            {
                CurrentUser = userInfo,
                Transaction = transaction,
                ValidationFaults = new List<ValidationFault>()
            };

            _transitions = new Dictionary<StateTransition, StateType>
            {
                // Initial state transition
                {new StateTransition(StateType.InitialState, Command.Post), StateType.NewState},
                // New state transitions 
                {new StateTransition(StateType.NewState, Command.Next), StateType.ApprovalState},
                // Waiting for approval state transitions
                {new StateTransition(StateType.ApprovalState, Command.Delete), StateType.DeletedState},
                {new StateTransition(StateType.ApprovalState, Command.Update), StateType.ApprovalState},
                {new StateTransition(StateType.ApprovalState, Command.Approve), StateType.ApprovedState},
                {new StateTransition(StateType.ApprovalState, Command.Reject), StateType.RejectedState},
                // Rejected state transitions
                {new StateTransition(StateType.RejectedState, Command.Approve), StateType.ApprovalState},
                {new StateTransition(StateType.RejectedState, Command.Reject), StateType.RejectedState},
                // Approved state transitions
                {new StateTransition(StateType.ApprovedState, Command.Delete), StateType.DeletedState},
                {new StateTransition(StateType.ApprovedState, Command.Approve), StateType.TransferWaitState},
                {new StateTransition(StateType.ApprovedState, Command.Reject), StateType.ApprovalState},
                // Waiting for transfer state transitions
                {new StateTransition(StateType.TransferWaitState, Command.Reject), StateType.ApprovalState},
                {new StateTransition(StateType.TransferWaitState, Command.Approve), StateType.TransferWaitState},
                {new StateTransition(StateType.TransferWaitState, Command.Delete), StateType.DeletedState},
                {new StateTransition(StateType.TransferWaitState, Command.Transfer), StateType.TransferedState},
                // Transfered state transitions
                {new StateTransition(StateType.TransferedState, Command.Next), StateType.ClosedState},
                {new StateTransition(StateType.TransferedState, Command.Delete), StateType.DeletedState}
            };

            // Choose current state
            switch (transaction.State)
            {
                case "New":
                    CurrentState = StateFactory.GetState(StateType.NewState);
                    break;
                case "Approval":
                    CurrentState = StateFactory.GetState(StateType.ApprovalState);
                    break;
                case "Approved":
                    CurrentState = StateFactory.GetState(StateType.ApprovedState);
                    break;
                case "Rejected":
                    CurrentState = StateFactory.GetState(StateType.RejectedState);
                    break;
                case "TransferWait":
                    CurrentState = StateFactory.GetState(StateType.TransferWaitState);
                    break;
                case "Transfered":
                    CurrentState = StateFactory.GetState(StateType.TransferedState);
                    break;
                default:
                    CurrentState = StateFactory.GetState(StateType.InitialState);
                    break;
            }
        }

        private IState GetNext(Command command)
        {
            var transition = new StateTransition(CurrentState.Type, command);
            StateType nextState;
            if (!_transitions.TryGetValue(transition, out nextState))
                throw new Exception("Invalid transition: " + CurrentState.Type + " -> " + command);
            return StateFactory.GetState(nextState);
        }

        public void ProcessCommand(Command command)
        {
            Utility.LogInformation("Current state: " + CurrentState.Type);

            try
            {
                var newState = GetNext(command);
                newState.Enter(ref _context);
                CurrentState = newState;
            }
            catch (Exception e)
            {
                Utility.LogError(e.Message);
                return;
            }

            // If there are unconditional transitions in transitions dictionary 
            // process Next commandv
            ProcessCommand(Command.Next);
        }
    }
}