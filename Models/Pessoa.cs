using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Models
{
    public class Pessoa
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
