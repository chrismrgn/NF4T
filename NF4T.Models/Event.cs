using System;

namespace NF4T.Models
{
    public class Event
    {
        public Type Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsNewItem { get; set; }
    }
}