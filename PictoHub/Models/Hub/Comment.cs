using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictoHub.Models.Hub {
    public class Comment {

        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public HubColor Color { get; set; }

    }
}