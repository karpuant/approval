using System.Collections.Generic;
using System.Linq;

namespace Approval.StateMachine
{
    public class ApprovalContext
    {
        public PayrollTransaction Transaction { get; set; }
        public UserInfo CurrentUser { get; set; }
        public List<ValidationFault> ValidationFaults { get; set; }

        public bool IsValid => !ValidationFaults.Any();

        public void Save()
        {
            //Save transaction to db
            Utility.LogInformation("  Saving transaction with state: " + Transaction.State);
        }

        public void Delete()
        {
            //Save transaction to db
            Utility.LogInformation("  Deleting transaction");
        }
        public void Update()
        {
            //Save transaction to db
            Utility.LogInformation("  Updating transaction with state: " + Transaction.State);
        }
    }
}