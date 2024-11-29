using BookShop.Data;
using BookShop.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Repository
{
    public class LanguageRepository
    {
        private readonly BookShopContext _context = null;
        public LanguageRepository(BookShopContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetAllLanguage()
        {
            var languages =await  _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name=x.Name,
                Description=x.Description,
            }).ToListAsync();
            return languages; 
        }
    }
}
