using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using Elreg.Exceptions;
using Elreg.Log;

namespace Elreg.ResourcesService
{
    public class LanguageManager
    {
        private readonly static LanguageManager Inst = new LanguageManager();
        private readonly ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private LanguageType _languageType = LanguageType.Undefined;
        private readonly List<Language> _languages = new List<Language>();
        private string _culture;
        private readonly Dictionary<string, Dictionary<string, string>> _languageDict = new Dictionary<string, Dictionary<string, string>>();

        public const string ReplaceString1 = "%Replace%";
        private const string GermanAcronym = "de";
        private const string EnglishAcronym = "en";

        public static event EventHandler LanguageChanged;

        private LanguageManager()
        {
            FillLanguages();
            _resourceManager = new ResourceManager("Elreg.ResourcesService.Languages.LC2010Strings", Assembly.GetExecutingAssembly());
            SetCultureInfo();
        }

        public static LanguageType LanguageType
        {
            set
            {
                if (value != Inst._languageType)
                {
                    Inst._languageType = value;
                    Inst.SetCultureInfo();
                    RaiseEventLanguageChanged();
                }
            }
        }

        public static string GetString(string resourceName)
        {
            string value = string.Empty;
            try
            {
                string resourceValue = Inst.GetValueFromXmlfile(resourceName);
                if (resourceValue == null)
                    resourceValue = Inst._resourceManager.GetString(resourceName, Inst._cultureInfo);
                if (resourceValue == null)
                    throw new LcException("Resource " + resourceName + " not found.");
                value = resourceValue.Replace("\\n", Environment.NewLine);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return value;
        }

        private string GetValueFromXmlfile(string resourceName)
        {
            string resourceValue = null;
            try
            {
                Dictionary<string, string> dictionary;
                _languageDict.TryGetValue(CultureAcronym, out dictionary);
                if (dictionary == null)
                {
                    dictionary = Retrieve(ResourcePathName);
                    _languageDict.Add(CultureAcronym, dictionary);
                }
                dictionary.TryGetValue(resourceName, out resourceValue);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return resourceValue;
        }

        protected string ResourcePathName
        {
            get
            {
                string fileName = Application.StartupPath + "\\Languages\\";
                fileName += "LC2010Strings." + _culture;
                if (!string.IsNullOrEmpty(_culture))
                    fileName += ".";
                fileName += "resx";
                return fileName;
            }
        }

        public Dictionary<string, string> Retrieve(string resxPathName)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            using (ResXResourceReader resxReader = new ResXResourceReader(resxPathName))
            {
                foreach (DictionaryEntry d in resxReader)
                    dictionary.Add(d.Key.ToString(), d.Value.ToString());
                resxReader.Close();
            }
            return dictionary;
        }

        public static List<Language> Languages
        {
            get { return Inst._languages; }
        }

        public static string CultureAcronym
        {
            get
            {
                string culture = Inst._culture;
                if (string.IsNullOrEmpty(culture))
                    culture = GermanAcronym;
                return culture;
            }
        }

        private void FillLanguages()
        {
            _languages.Add(new Language(LanguageType.German, "Deutsch"));
            _languages.Add(new Language(LanguageType.English, "English"));
        }

        private static void RaiseEventLanguageChanged()
        {
            if (LanguageChanged != null)
                LanguageChanged(Inst, null);
        }

        private void SetCultureInfo()
        {
            if (_languageType == LanguageType.English)
                _culture = EnglishAcronym;
            else
                _culture = string.Empty;
            _cultureInfo = CultureInfo.CreateSpecificCulture(_culture);
        }

        public static string LanguagePath
        {
            get { return CultureAcronym + @"\"; }
        }

    }
}
