using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontalMVC.Models.EF
{
    public class joueur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID{ get; set; }
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public int IDEquipe { get; set; }

        [ForeignKey("IDEquipe")]
        public Equipe Equipe { get; set; }
    }
}
