using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StruggleBus.Models
{
    public class DefaultMessage
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string InputMessage { get; set; }

        [Required]
        [MaxLength(500)]
        public string OutputMessage { get; set; }
    }
}
