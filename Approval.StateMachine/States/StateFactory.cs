using System;

namespace Approval.StateMachine.States
{
    public class StateFactory
    {
            public static IState GetState(StateType type)
            {
                switch (type)
                {
                    case StateType.InitialState:
                        return InitialState.instance();
                    case StateType.NewState:
                        return NewState.instance();
                    case StateType.ApprovalState:
                        return ApprovalState.instance();
                    case StateType.ApprovedState:
                        return ApprovedState.instance();
                    case StateType.RejectedState:
                        return RejectedState.instance();
                    case StateType.DeletedState:
                        return DeletedState.instance();
                    case StateType.TransferWaitState:
                        return TransferWaitState.instance();
                    case StateType.TransferedState:
                        return TransferedState.instance();
                    case StateType.ClosedState:
                        return ClosedState.instance();
                    default:
                        throw new NotSupportedException();
                }
            }
    }

    public enum StateType
    {
        InitialState,
        NewState,
        ApprovalState,
        ApprovedState,
        RejectedState,
        TransferWaitState,
        TransferedState,
        PartTransferedState,
        ClosedState,
        ErrorState,
        DeletedState
    }
}