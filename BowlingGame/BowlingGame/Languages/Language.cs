namespace BowlingGame.Languages
{
    public abstract class Language
    {
        public Language[] AvailableLanguages { get { return new Language[] { new EnGB(), new Fr() }; } }

        public abstract string TITLE { get; }

        public abstract string ERROR_GameLength { get; }
        public abstract string ERROR_GameFormat { get; }
        public abstract string ERROR_CharacterSequence { get; }

        public abstract string MENU_EnterScorecard { get; }
        public abstract string MENU_EnterScorecardNumber { get; }
        public abstract string MENU_UsePresets { get; }
        public abstract string MENU_AllPresets { get; }
        public abstract string MENU_Continue { get; }
        public abstract string MENU_Back { get; }
        public abstract string MENU_Language { get; }

    }
}
