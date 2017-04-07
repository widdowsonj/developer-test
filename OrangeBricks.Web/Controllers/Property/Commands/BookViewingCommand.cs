using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookViewingCommand
    {
        [Required]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "A viewing date time is required")]
        public DateTime ViewingAt { get; set; }

        [Required]
        public string BuyerUserId { get; set; }
    }
}