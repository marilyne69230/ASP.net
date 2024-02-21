using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontalMVC.Models.EF
{
    public class Equipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nom { get; set; }


        private int _MaxMembres;

        [DisplayName("Nbre max d'inscrits")]
        [Required(ErrorMessage ="Pas de max, pas de chocolat")]
        [Range(0,50, ErrorMessage ="Entre 1 et 50 svp")]
        public int MaxMembres
        {
            get { return _MaxMembres; }
            set { _MaxMembres = (value >= 1) ? value : 1; }
        }

        public virtual IList<joueur>? Joueurs { get; set; }
    }
}
