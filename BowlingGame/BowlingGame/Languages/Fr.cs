using System;

namespace BowlingGame.Languages
{
    /// Using Google Translate
    public class Fr : Language
    {
        public override string ERROR_CharacterSequence
        {
            get
            {
                return "Caractères non valides dans la séquence";
            }
        }

        public override string ERROR_GameFormat
        {
            get
            {
                return "Format de jeu non valide";
            }
        }

        public override string ERROR_GameLength
        {
            get
            {
                return "Invalid durée de jeu";
            }
        }

        public override string MENU_AllPresets
        {
            get
            {
                return "Tous les préréglages";
            }
        }

        public override string MENU_Back
        {
            get
            {
                return "Arrière";
            }
        }

        public override string MENU_Continue
        {
            get
            {
                return "Appuyez sur n'importe quelle touche pour continuer";
            }
        }

        public override string MENU_EnterScorecard
        {
            get
            {
                return "Entrez Scorecard";
            }
        }

        public override string MENU_EnterScorecardNumber
        {
            get
            {
                return "Entrez le numéro de tableau de bord";
            }
        }

        public override string MENU_Language
        {
            get
            {
                return "Choisir la langue";
            }
        }

        public override string MENU_UsePresets
        {
            get
            {
                return "Utiliser Preset";
            }
        }

        public override string TITLE
        {
            get
            {
                return "French";
            }
        }
    }
}
