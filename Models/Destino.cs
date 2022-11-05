using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebCSharp.Models
{
    [Table("destino")]
    public class Destino
    {   
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "É necessário preencher o campo local")]
        public string Local { get; set; }

        [Required(ErrorMessage ="É necessário preencher o campo descricao")]
        public string Descricao { get; set; }
    }
}
