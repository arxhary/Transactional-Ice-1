using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Transactional.Models
{
    [Table("transaction_")]
    public partial class Transaction
    {
        [Key]
        [Column("transaction_id")]
        public int TransactionId { get; set; }
        [Column("id_no")]
        [StringLength(50)]
        public string IdNo { get; set; }
        [Column("amount")]
        public int? Amount { get; set; }
        [Column("transaction_type")]
        [StringLength(50)]
        public string TransactionType { get; set; }

        [ForeignKey(nameof(IdNo))]
        [InverseProperty(nameof(User.Transactions))]
        public virtual User IdNoNavigation { get; set; }
    }
}
