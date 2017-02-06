using System;

namespace Approval.StateMachine
{
    public class ApprovalProcessFactory
    {
        public static IApprovalProcess GetProcess(string processName, PayrollTransaction transaction, UserInfo userInfo)
        {
            switch (processName)
            {
                case "GenericApproval":
                    return new GenericApprovalProcess(transaction, userInfo);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}