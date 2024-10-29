using System;
using System.Collections.Generic;
using System.Text;

namespace Sparcpoint.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public List<string> Categories { get; set; }
    }
}
