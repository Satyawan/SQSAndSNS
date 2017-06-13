using Messaging.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Events
{
    public class NewTop10
    {
        public IEnumerable<ProjectSummary> ProjectSummaries { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
