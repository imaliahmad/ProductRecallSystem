using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BOL
{
    [Table("Announcements")]
    public class Announcements
    {
        [Key]
        public int AnnouncementId { get; set; }
        public string Description { get; set; }

        [ForeignKey("Recalls")]
        public int RecallId { get; set; }
        public virtual Recalls Recalls { get; set; }
    }
}
