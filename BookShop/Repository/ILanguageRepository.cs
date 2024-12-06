using BookShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetAllLanguage();
    }
}