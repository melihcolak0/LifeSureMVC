using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _07PC_MVC.Models.ViewModels
{
    public class LinkedinViewModel
    {
        // Linkedin
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public List<string> Industries { get; set; }
        public int? FoundedYear { get; set; }
        public int EmployeeCount { get; set; }
        public int FollowerCount { get; set; }
        public string LogoUrl { get; set; }

        // Twitter
        public string TwitterName { get; set; }
        public string TwitterDescription { get; set; }
        public int TwitterFollowersCount { get; set; }
        public int TwitterFriendsCount { get; set; }
        public int TwitterMediaCount { get; set; }
        public string TwitterAvatarUrl { get; set; }
        public string TwitterScreenName { get; set; }    
    }
}