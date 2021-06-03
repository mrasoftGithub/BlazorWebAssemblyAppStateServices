using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorBlogProject.Shared;
using BlazorBlogProject.Client.Model;

namespace BlazorBlogProject.Client.ViewModels
{
    public class TotaalAantalViewModel : ITotaalAantalViewModel
    {
        public int TotAantalEigenaren { get; set; }

        readonly private IModel _serviceModel;

        public TotaalAantalViewModel(IModel serviceModel)
        {
            // Constructor - injecteer de model
            _serviceModel = serviceModel;
        }

        public async Task<IEnumerable<EIGENAAR>> GetLijstEigenaren()
        {
            //-------------------------------------------------
            // directe aanroep
            // return await _serviceModel.GetLijstEigenaren();
            //-------------------------------------------------

            TotAantalEigenaren = await _serviceModel.GetTotaalAantalEigenaren();

            //-------------------------------------------------
            // met een task
            return await Task.Run(() =>
            {
                return _serviceModel.GetLijstEigenaren();
            });
        }

    }
}
