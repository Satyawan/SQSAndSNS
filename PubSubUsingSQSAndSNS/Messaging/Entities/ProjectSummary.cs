using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Entities
{
    public class ProjectSummary
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public long Transactions { get; set; }
    }
}
