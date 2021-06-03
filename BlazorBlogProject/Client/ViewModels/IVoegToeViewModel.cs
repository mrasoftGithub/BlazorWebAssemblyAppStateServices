using System.Threading.Tasks;

namespace BlazorBlogProject.Client.ViewModels
{
    public interface IVoegToeViewModel
    {
        public string Omschrijving { get; set; }
        
        public string Regio { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public int TotaalAantalEigenaren { get; set; }

        Task GetTotaalAantalEigenaren();

        Task VoegToe();
    }
}
