using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesManagement.Entity.Models
{
    public class Bookmark
    {
        public int BookmarkId { get; set; }

        public string WebURL { get; set; }

        public int UserId { get; set; }
    }
}
