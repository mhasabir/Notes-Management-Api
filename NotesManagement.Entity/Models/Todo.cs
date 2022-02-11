using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NotesManagement.Entity.Models
{
    public class Todo
    {
        public int TodoId { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsComplete { get; set; }

        public int UserId { get; set; }
    }
}
