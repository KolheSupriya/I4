﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InventoryManagementSystem
{
    class PRODUCT_CATEGORIES
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Product_Category_ID { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(15)]
        [MinLength(4)]
        public string Product_Name{ get; set; }
        //[Required]
        //public string ModifiedBy { get; set; }
        //[Required]
        //public DateTime ModifiedOn { get; set; } = DateTime.Now;
        //[Required]
        //public string CreatedBy { get; set; }
        //[Required]
        //public DateTime CreatedOn { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        public string Description { get; set; }
        //[Required]
        //[MaxLength(30)]
        //[MinLength(1)]
        //public int Current_Storage { get; set; }
        //[Required]
        //[MaxLength(30)]
        //[MinLength(1)]
        //public int Sold { get; set; }
        //[Required]
        //[MaxLength(30)]
        //[MinLength(1)]
        //public int Remaining_Quantity { get; set; }
        //[Required]
        //[MaxLength(30)]
        //[MinLength(1)]
        //public int Unit_Price { get; set; }
        //[Required]
        //[MaxLength(30)]
        //[MinLength(1)]
        //public int Total_Selling_Amount { get; set; }

        public ICollection<PRODUCTS> Products { get; set; }

    }
}
