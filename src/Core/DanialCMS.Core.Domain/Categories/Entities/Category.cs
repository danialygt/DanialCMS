using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Categories.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        
        public long? ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }


        

    }
}
