using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorBlogProject.Shared;

namespace BlazorBlogProject.Client.Model
{
    public interface IModel
    {

        Task<int> GetTotaalAantalEigenaren();

        Task VoegToe(EIGENAAR eigenaar);

        Task<IEnumerable<EIGENAAR>> GetLijstEigenaren();

    }
}
