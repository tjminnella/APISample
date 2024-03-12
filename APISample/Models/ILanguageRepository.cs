using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.Models
{
    public interface ILanguageRepository
    {
        Language GetLanguageById(int Id);
        List<Language> GetLanguagesByPurpose(string Purpose);
        List<Language> GetAllLanguages();
    }
}
