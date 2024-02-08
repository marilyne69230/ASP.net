namespace FrontalMVC.Models.Perso
{
    public class Generateur : IGenerateur
    {
        public List<int> Generer(int nombre)
        {
            List<int> listSerie = new List<int>();

            for (int i = 0; i < nombre; i++)
            {
                listSerie.Add((new Random()).Next(150, 1000));
            }
            return listSerie;
        }
    }
}
