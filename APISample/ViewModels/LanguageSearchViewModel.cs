using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISample.Models;

namespace APISample.ViewModels
{
    public class LanguageSearchViewModel
    {
        public List<Language> languages { get; set; }
        public string purpose { get; set; }
    }
}
