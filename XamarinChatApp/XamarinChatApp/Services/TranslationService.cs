using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinChatApp.Services
{
    public class TranslationService
    {
        private readonly Dictionary<string, Dictionary<string, string>> _i18N =
            new Dictionary<string, Dictionary<string, string>>();

        public string CurrentLang = "FR";

        public TranslationService()
        {
            var frI18N = new Dictionary<string, string>
            {
                {"PASSWORD_INVALID", "Mot de passe invalide"},
                {"PASSWORD_INVALID", "Mot de passe invalide"},
            };
            _i18N.Add("FR", frI18N);
        }

        public string GetTranslation(string key)
        {
            return _i18N[CurrentLang].ContainsKey(key) ? _i18N[CurrentLang][key] : key;
        }
    }
}
