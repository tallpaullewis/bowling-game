using System;

namespace BowlingGame.Languages
{
    public class EnGB : Language
    {
        public override string ERROR_CharacterSequence
        {
            get
            {
                return "Invalid characters in sequence";
            }
        }

        public override string ERROR_GameFormat
        {
            get
            {
                return "Invalid game format";
            }
        }

        public override string ERROR_GameLength
        {
            get
            {
                return "Invalid game length";
            }
        }

        public override string MENU_AllPresets
        {
            get
            {
                return "All Presets";
            }
        }

        public override string MENU_Back
        {
            get
            {
                return "Back";
            }
        }

        public override string MENU_Continue
        {
            get
            {
                return "Press any key to continue";
            }
        }

        public override string MENU_EnterScorecard
        {
            get
            {
                return "Enter Scorecard";
            }
        }

        public override string MENU_EnterScorecardNumber
        {
            get
            {
                return "Enter Scorecard Number";
            }
        }

        public override string MENU_Language
        {
            get
            {
                return "Select Language";
            }
        }

        public override string MENU_UsePresets
        {
            get
            {
                return "Use Preset";
            }
        }

        public override string TITLE
        {
            get
            {
                return "English";
            }
        }
    }
}
