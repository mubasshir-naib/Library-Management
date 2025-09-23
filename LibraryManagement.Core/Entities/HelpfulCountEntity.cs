using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class HelpfulCountEntity
    {
        public Guid Id { get; set; }
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }

        public bool? IsHelpful { get; set; }
    }
}
