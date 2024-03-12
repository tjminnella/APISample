using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISample.Models;
using System.Web;

namespace APISample.Controllers
{
    public class LanguageController : Controller
    {
        private ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public ObjectResult GetLanguagesByPurpose(string purpose)
        {
            return new ObjectResult(_languageRepository.GetLanguagesByPurpose(purpose));
        }
    }
}
