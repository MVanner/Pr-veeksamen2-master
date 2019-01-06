using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Gift
    {
        [Key]
        public Guid GiftNumber { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public bool BoyGift { get; set; }
        [Required]
        public bool GirlGift { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

    }
}
