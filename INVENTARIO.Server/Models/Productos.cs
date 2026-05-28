using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace INVENTARIO.Server.Models
{
    [Table("productos")]
    public class Productos
    {
        [Key]
        [Column("empid")]
        public int empid { get; set; }
        [Column("nombre")]
        public string NOMBRE { get; set; }
        [Column("cantidad")]
        public int CANTIDAD { get; set; }
    }
}
