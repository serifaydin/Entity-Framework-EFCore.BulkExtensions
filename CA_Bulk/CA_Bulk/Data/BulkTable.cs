using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CA_Bulk.Data
{
    [Table("BulkTable")]
    public class BulkTable
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Surname")]
        public string Surname { get; set; }
    }
}
