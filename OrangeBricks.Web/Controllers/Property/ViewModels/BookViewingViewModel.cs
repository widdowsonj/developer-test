using System;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class BookViewingViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        public DateTime ViewingAt { get; set; }
    }
}