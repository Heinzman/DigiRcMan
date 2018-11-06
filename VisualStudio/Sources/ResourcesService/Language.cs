namespace Elreg.ResourcesService
{
    public class Language
    {
        public Language(LanguageType languageType, string displayName)
        {
            LanguageType = languageType;
            DisplayName = displayName;
        }

        public LanguageType LanguageType { get; set; }
        public string DisplayName { get; set; }
    }
}
