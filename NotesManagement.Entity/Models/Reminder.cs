﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NotesManagement.Entity.Models
{
    public class Reminder
    {
        public int ReminderId { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public DateTime ReminderDateTime { get; set; }

        public int UserId { get; set; }
    }
}
