using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StruggleBus.Models
{
    public class DefaultActive
    {
        public int Id { get; set; }

        [Required]
        public int MessageId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool Active { get; set; }

    }
}
