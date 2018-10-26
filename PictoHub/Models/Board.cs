using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PictoHub.Models {

    [Table("Boards")]
    public class Board {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

    }
}