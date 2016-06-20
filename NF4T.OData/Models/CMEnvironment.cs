using System;
using System.ComponentModel.DataAnnotations;

namespace NF4T.OData.Models
{
    public class CMEnvironment
    {
        [Key]
        public Guid Id { get; set; }
    }
}