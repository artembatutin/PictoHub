using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PictoHub.Models.Hub;

namespace PictoHub.Models {

    [Table("Threads")]
    public class Thread {

        [Key]
        public int Id { get; set; }
        public int Board { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public HubColor Color { get; set; }
        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; }

    }
}