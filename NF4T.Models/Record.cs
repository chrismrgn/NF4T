using System;
using System.ComponentModel.DataAnnotations;
using NF4T.OData.Models;

namespace NF4T.Models
{
    public class Record
    {
        public Record()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid Id { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public Subject Subject { get; set; }

        /// <summary>
        /// CM Environment from which the event originated
        /// </summary>
        public CMEnvironment Environment { get; set; }

        public Event Event { get; set; }
    }
}