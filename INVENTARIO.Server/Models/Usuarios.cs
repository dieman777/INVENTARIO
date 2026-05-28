using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INVENTARIO.Server.Models
{
    [Table("usuarios")]
    public class Usuarios
    {
        [Key]
        [Column("empid")]
        public int empId { get; set; }
        [Column("usuario")]
        public string USUARIO { get; set; }
        [Column("contrasena")]
        public string CONTRASENA { get; set; }
    }
}
