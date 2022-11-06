using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogTrackerMVC.Models
{
    public class Blog
    {
            public int BlogId { get; set; }
            public string Title { get; set; }
            public string Subject { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfCreation { get; set; }
            public string BlogUrl { get; set; }
            public string Email { get; set; }
        
    }
}