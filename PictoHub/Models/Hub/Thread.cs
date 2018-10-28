using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PictoHub.Models.Hub;
using System.ComponentModel;

namespace PictoHub.Models {

    [Table("Threads")]
    public class Thread {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This value is required")]
        public int Board { get; set; }
        [DisplayName("Thread Title")]
        [Required(ErrorMessage = "This value is required")]
        public string Title { get; set; }
        [DisplayName("Content")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "This value is required")]
        public string Content { get; set; }
        [DisplayName("Author")]
        [Required(ErrorMessage = "This value is required")]
        public string Author { get; set; }
        [DisplayName("Thread color")]
        [Required(ErrorMessage = "This value is required")]
        public HubColor Color { get; set; }
        [DisplayName("Date")]
        [Required(ErrorMessage = "This value is required")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [DisplayName("Comments")]
        public int CommentsCount { get; set; }

        public List<Comment> Comments;
       
        public void AddComment(ApplicationDbContext db, Comment comment) {
            CommentsCount++;
            comment.ThreadId = Id;
            comment.Date = DateTime.Now;
            db.Comments.Add(comment);
            db.SaveChanges();
            db.Entry(this).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        
        public void GetComments(ApplicationDbContext db) {
            Comments = db.Comments.Where(c => c.ThreadId == Id).ToList();
        }

    }
}