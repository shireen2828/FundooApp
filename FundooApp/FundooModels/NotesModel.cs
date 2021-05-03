﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
    public class NotesModel
    {
        [Key]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Remainder { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        [DefaultValue(false)]
        public bool pin { get; set; }
        [DefaultValue(false)]
        public bool Archive { get; set; }
        [DefaultValue(false)]
        public bool Trash { get; set; }

        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }
        public virtual RegisterModel RegisterModel { get; set; }
    }
}
