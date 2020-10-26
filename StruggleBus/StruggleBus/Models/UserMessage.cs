using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StruggleBus.Models
{
    public class UserMessage
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(25)]
        public string InputMessage { get; set; }

        [Required]
        [MaxLength(500)]
        public string OutputMessages { get; set; }
    }
}
