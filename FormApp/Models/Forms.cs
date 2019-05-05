namespace FormApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Forms
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public int FieldId { get; set; }

        public virtual Fields Fields { get; set; }

        public virtual Users Users { get; set; }
    }
}
