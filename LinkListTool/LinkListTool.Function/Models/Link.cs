using Azure.Data.Tables;
using Azure;

namespace LinkList.Models
{
    public class Link : ITableEntity
    {
        public string? Url { get; set; }
        public string? Text { get; set; }
        public string? Category { get; set; }
        public string? LearningPath { get; set; }
        public string? PartitionKey { get; set; }
        public string? RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
