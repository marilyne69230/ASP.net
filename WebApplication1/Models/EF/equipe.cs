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

        public int MaxMembres
        {
            get { return _MaxMembres; }
            set { _MaxMembres = (value >= 1) ? value : 1; }
        }

        public IEnumerable<joueur> Joueurs { get; set; }
    }
}
