using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.Models
{
    public class MockLanguageRepository : ILanguageRepository
    {
        private List<Language> _languageList;

        //constructor
        public MockLanguageRepository()
        {
            _languageList = new List<Language>()
            {
                new Language() {Id = 1, Name = "Python", Purpose="web, scripting, artificial intelligence", EventDriven=true, ObjectOriented=true},
                new Language() {Id = 2, Name = "Ruby", Purpose="Application, scripting, web", EventDriven= true, ObjectOriented = true},
                new Language() {Id = 3, Name = "Visual Basic", Purpose="Application, RAD, education", EventDriven= true, ObjectOriented = true},
                new Language() {Id = 4, Name = "Java Script", Purpose="Client-side, server-side, web", EventDriven= true, ObjectOriented = true},
                new Language() {Id = 5, Name = "Java", Purpose="web, Application, business, client-side", EventDriven= true, ObjectOriented = true},
                new Language() {Id = 6, Name = "C#", Purpose="web, Application, RAD, business, client-side", EventDriven= true, ObjectOriented = true},
                new Language() {Id = 7, Name = "C", Purpose="low-level operations", EventDriven= false, ObjectOriented = true},
                new Language() {Id = 8, Name = "Bash", Purpose="Shell, scripting", EventDriven= false, ObjectOriented = false},
                new Language() {Id = 9, Name = "J", Purpose="Data processing", EventDriven= false, ObjectOriented = false}

            };
        }

        public Language GetLanguageById(int Id)
        {
            return _languageList.FirstOrDefault(e => e.Id == Id);
        }
        public List<Language> GetLanguagesByPurpose(string Purpose)
        {
            List<Language> languages = null;
            if (Purpose == null)
            {
                return _languageList;
            }
            Purpose = Purpose.ToLower();
            languages = _languageList
                .Where(nc => nc.Purpose.ToLower()
                .Contains(Purpose)).ToList();
            return languages;
        }
        public List<Language> GetAllLanguages()
        {
            return _languageList;
        }
    }
}
