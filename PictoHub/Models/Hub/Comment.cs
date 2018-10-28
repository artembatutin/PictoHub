using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PictoHub.Models.Hub {

    [Table("Comments")]
    public class Comment {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This value is required")]
        public int ThreadId { get; set; }
        [DisplayName("Author")]
        [Required(ErrorMessage = "This value is required")]
        public string Author { get; set; }
        [DisplayName("Comment")]
        [Required(ErrorMessage = "This value is required")]
        public string Content { get; set; }
        [DisplayName("Color")]
        [Required(ErrorMessage = "This value is required")]
        public HubColor Color { get; set; }
        public DateTime Date { get; set; }

        public Comment() {
            //Empty
        }

        public Comment(string Author, string Content, HubColor Color) {
            this.ThreadId = ThreadId;
            this.Author = Author;
            this.Content = Content;
            this.Color = Color;
        }

    }
}