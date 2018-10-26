using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PictoHub.Models {

    [Table("Threads")]
    public class Thread {

        [Key]
        public int Id { get; set; }
        public int Board { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        

    }
}