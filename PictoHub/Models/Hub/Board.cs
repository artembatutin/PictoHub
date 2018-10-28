using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PictoHub.Models.Hub;
using System.ComponentModel;

namespace PictoHub.Models {

    [Table("Boards")]
    public class Board {

        [Key]
        public int Id { get; set; }
        [DisplayName("Board title")]
        [Required(ErrorMessage = "This value is required")]
        public string Title { get; set; }
        [DisplayName("Description")]
        [Required(ErrorMessage = "This value is required")]
        public string Desc { get; set; }
        [DisplayName("Board Color")]
        [Required(ErrorMessage = "This value is required")]
        public HubColor Color { get; set; }

        public Board() {
            //empty
        }

        public Board(int Id, string Title, string Desc, HubColor Color) {
            this.Id = Id;
            this.Title = Title;
            this.Desc = Desc;
            this.Color = Color;
        }

    }
}