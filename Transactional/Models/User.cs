using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Transactional.Models
{
    [Table("user_")]
    public partial class User
    {
        public User()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("id_no")]
        [StringLength(50)]
        public string IdNo { get; set; }
        [Column("name")]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [Column("password")]
        [StringLength(70)]
        public string Password { get; set; }

        [InverseProperty(nameof(Transaction.IdNoNavigation))]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
