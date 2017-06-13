using System;

namespace Messaging.Commands
{
    public class RollForward
    {
        public Guid ProjectId { get; set; }

        public DateTime NewFiscalYearEnd { get; set; }
    }
}
