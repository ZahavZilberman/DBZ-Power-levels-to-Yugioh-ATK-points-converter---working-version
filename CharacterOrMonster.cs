using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DBZ_Power_levels_to_Yugioh_ATK_points_converter___working_version
{
    public class CharacterOrMonster
    {
        public double ATKPoints { get; set; }
        public double DEFPoints { get; set; }
        public string Name { get; set; }
        public double PowerLevel { get; set; }
        public bool IsTheStrongestCharacterInHisDeck { get; set; }
        public bool IsTheWeakestCharacterInHisDeck { get; set; }
        public Deck TheDeckThisGuyBelongsTo { get; set; }

        public CharacterOrMonster()
        {
            ATKPoints = 0.1;
            DEFPoints = 0.1;
            Name = "";
            PowerLevel = 0;
            IsTheStrongestCharacterInHisDeck = false;
            IsTheWeakestCharacterInHisDeck = false;
        }

    }
}
