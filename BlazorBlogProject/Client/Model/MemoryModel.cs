using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorBlogProject.Shared;

namespace BlazorBlogProject.Client.Model
{
    public class MemoryModel : IModel
    {
        readonly private List<EIGENAAR> _Eigenaren = new List<EIGENAAR>
        {
            new EIGENAAR() { ID =1, Omschrijving="Sandra's auto Interne array", Regio="Noord", Voornaam="Sandra", Achternaam="Jansen"},
            new EIGENAAR() { ID =2, Omschrijving="Peter's auto Interne array", Regio="Midden", Voornaam="Peter", Achternaam="Veerman"},
            new EIGENAAR() { ID =3, Omschrijving="Olga's auto Interne array", Regio="Zuid", Voornaam="Olga", Achternaam="Mulder"}
        };

        public async Task<IEnumerable<EIGENAAR>> GetLijstEigenaren()
        {
            return await Task.Run(() => _Eigenaren);
        }

        public async Task<int> GetTotaalAantalEigenaren()
        {
            return await Task.Run(() => _Eigenaren.Count);
        }

        public async Task VoegToe(EIGENAAR eigenaar)
        {
            await Task.Run(() =>
            {
                // Bepaal de ID
                eigenaar.ID = _Eigenaren.Max(e => e.ID) + 1;

                // Toevoegen
                _Eigenaren.Add(eigenaar);
            });
        }
    }
}
