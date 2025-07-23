using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07PC_MVC.Models.ViewModels
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}