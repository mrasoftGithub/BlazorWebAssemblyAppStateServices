using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BlazorBlogProject.Shared;
using BlazorBlogProject.Client.Model;

namespace BlazorBlogProject.Client.ViewModels
{
    public class VoegToeViewModel : IVoegToeViewModel
    {
        [Required(ErrorMessage = "Geef een omschrijving.")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "De regio ontbreekt.")]
        public string Regio { get; set; }

        [Required(ErrorMessage = "Geen voornaam opgegeven.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Geen achternaam opgegeven.")]
        public string Achternaam { get; set; }

        public int TotaalAantalEigenaren { get; set; }

        readonly private IModel _serviceModel;

        public VoegToeViewModel(IModel serviceModel)
        {
            // Constructor - injecteer de model
            _serviceModel = serviceModel;
        }

        public static implicit operator EIGENAAR(VoegToeViewModel serviceViewModel)
        {
            // Map de ViewModel naar de Model //
            return new EIGENAAR
            {
                Omschrijving = serviceViewModel.Omschrijving,
                Regio = serviceViewModel.Regio,
                Voornaam = serviceViewModel.Voornaam,
                Achternaam = serviceViewModel.Achternaam,
            };
        }

        public async Task GetTotaalAantalEigenaren()
        {
            TotaalAantalEigenaren = await _serviceModel.GetTotaalAantalEigenaren();
        }

        public async Task VoegToe()
        {
            // Door de implicit operator wordt de 
            // ViewModel gemapped naar de Model (EIGENAAR)
            EIGENAAR eigenaar = this;

            // Toevoegen
            await _serviceModel.VoegToe(eigenaar);

            // Schonen velden
            Omschrijving = "";
            Regio = "";
            Voornaam = "";
            Achternaam = "";

            // Feedback...
            TotaalAantalEigenaren = await _serviceModel.GetTotaalAantalEigenaren();
        }
    }
}
