using System;
using System.ComponentModel.DataAnnotations;

namespace NF4T.OData.Models
{
    public class CMEnvironment
    {
        public CMEnvironment()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }
    }
}