using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class CategoryEntity
    {
       public  Guid Id { get; set; }
       public string? Name { get; set; }
       public string? Slug { get; set; }
        
    }
}
