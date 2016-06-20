using System;
using System.ComponentModel.DataAnnotations;

namespace NF4T.OData.Models
{
    public class Event
    {
        public Event()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string SubjectId { get; set; }

        /// <summary>
        /// CM Environment from which the event originated
        /// </summary>
        public CMEnvironment Environment { get; set; }
    }
}