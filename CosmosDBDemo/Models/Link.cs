using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBDemo.Models
{
    public class Link
    {
        public string? Url { get; set; }
        public string? Text { get; set; }
        public string? Category { get; set; }
        public string? LearningPath { get; set; }
    }
}
