using BlazorBlogProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBlogProject.Client.ViewModels
{
    public interface ITotaalAantalViewModel
    {
        public int TotAantalEigenaren { get; set; }

        Task<IEnumerable<EIGENAAR>> GetLijstEigenaren();
    }
}
