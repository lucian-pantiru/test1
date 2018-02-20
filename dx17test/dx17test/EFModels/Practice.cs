namespace dx17test.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Practice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PracticeName { get; set; }
    }
}
