using System;

namespace NF4T.Models
{
    public class Subject
    {
        public string TcmId { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string SchemaTcmId { get; set; }
    }
}