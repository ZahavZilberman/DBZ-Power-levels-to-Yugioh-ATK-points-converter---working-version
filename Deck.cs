using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBZ_Power_levels_to_Yugioh_ATK_points_converter___working_version
{
    public class Deck
    {

        #region Properties
        public List<CharacterOrMonster> CharacterList { get; set; }
        public int NumberOfMonstersStoredInIt { get; set; }
        public CharacterOrMonster TheMonsterWithTheHighestPowerLevel { get; set; }
        public CharacterOrMonster TheMonsterWithTheLowestPowerLevel { get; set; }
        public double TheHighestAllowedATKPoints { get; set; }
        public double TheLowestAllowedATKPoints { get; set; }
        public double ThePowerLevelGapBetweenTheStrongestAndWeakest { get; set; }
        public double ThePowerConvertorBetweenPowerLevelToATKPoints { get; set; }
        public string DeckName { get; set; }
        public int DeckNumberInOrder { get; set; }
        #endregion

        #region Ctor
        public Deck()
        {
            DeckNumberInOrder = 0;
            CharacterList = new List<CharacterOrMonster>();
            TheMonsterWithTheHighestPowerLevel = new CharacterOrMonster();
            TheMonsterWithTheLowestPowerLevel = new CharacterOrMonster();
            NumberOfMonstersStoredInIt = 0;
            TheHighestAllowedATKPoints = 0;
            TheLowestAllowedATKPoints = 0;

            CharacterList.Add(TheMonsterWithTheLowestPowerLevel);
            CharacterList.Add(TheMonsterWithTheHighestPowerLevel);
            DeckName = "";
        }
        #endregion

        #region Updating the properties from the deck's XML file infromation
        public void ReadDeckXMLFile(string DeckDocPath)
        {
            if (DeckDocPath == null)
            {
                throw new Exception("WTF?");
            }
            XDocument DeckDoc = new XDocument(XDocument.Load(DeckDocPath));
            XElement root = DeckDoc.Root;
            XElement DeckNameElement = root.Element("DeckName");
            XElement MonstersListElement = root.Element("CharacterList");
            IEnumerable<XElement> MonstersList = MonstersListElement.Elements("Monster");
            foreach (XElement monster in MonstersList)
            {
                if (monster.Element("TheMonsterWithTheLowestPowerLevel") != null)
                {
                    XElement MonsterElement = monster.Element("TheMonsterWithTheLowestPowerLevel");
                    this.TheMonsterWithTheLowestPowerLevel.Name = MonsterElement.Element("Name").Value;
                    this.TheMonsterWithTheLowestPowerLevel.PowerLevel = double.Parse(MonsterElement.Element("PowerLevel").Value);
                    this.TheMonsterWithTheLowestPowerLevel.ATKPoints = double.Parse(MonsterElement.Element("ATKPoints").Value);
                    this.TheMonsterWithTheLowestPowerLevel.DEFPoints = double.Parse(MonsterElement.Element("DEFPoints").Value);
                    this.TheMonsterWithTheLowestPowerLevel.IsTheStrongestCharacterInHisDeck = false;
                    this.TheMonsterWithTheLowestPowerLevel.IsTheWeakestCharacterInHisDeck = true;

                    this.TheMonsterWithTheLowestPowerLevel.TheDeckThisGuyBelongsTo = new Deck();
                    this.TheMonsterWithTheLowestPowerLevel.TheDeckThisGuyBelongsTo.DeckName = MonsterElement.Element("TheDeckThisGuyBelongsTo").Value;
                }
                else if (monster.Element("TheMonsterWithTheHighestPowerLevel") != null)
                {
                    XElement MonsterElement = monster.Element("TheMonsterWithTheHighestPowerLevel");
                    this.TheMonsterWithTheHighestPowerLevel.Name = MonsterElement.Element("Name").Value;
                    this.TheMonsterWithTheHighestPowerLevel.PowerLevel = double.Parse(MonsterElement.Element("PowerLevel").Value);
                    this.TheMonsterWithTheHighestPowerLevel.ATKPoints = double.Parse(MonsterElement.Element("ATKPoints").Value);
                    this.TheMonsterWithTheHighestPowerLevel.DEFPoints = double.Parse(MonsterElement.Element("DEFPoints").Value);
                    this.TheMonsterWithTheHighestPowerLevel.IsTheStrongestCharacterInHisDeck = true;
                    this.TheMonsterWithTheHighestPowerLevel.IsTheWeakestCharacterInHisDeck = false;

                    this.TheMonsterWithTheHighestPowerLevel.TheDeckThisGuyBelongsTo = new Deck();
                    this.TheMonsterWithTheHighestPowerLevel.TheDeckThisGuyBelongsTo.DeckName = MonsterElement.Element("TheDeckThisGuyBelongsTo").Value;
                }
                else
                {
                    CharacterOrMonster AnotherMonster = new CharacterOrMonster();
                    AnotherMonster.Name = monster.Element("Name").Value;
                    AnotherMonster.PowerLevel = double.Parse(monster.Element("PowerLevel").Value);
                    AnotherMonster.ATKPoints = double.Parse(monster.Element("ATKPoints").Value);
                    AnotherMonster.DEFPoints = double.Parse(monster.Element("DEFPoints").Value);
                    AnotherMonster.IsTheStrongestCharacterInHisDeck = false;
                    AnotherMonster.IsTheWeakestCharacterInHisDeck = false;
                    AnotherMonster.TheDeckThisGuyBelongsTo = new Deck();
                    AnotherMonster.TheDeckThisGuyBelongsTo.DeckName = monster.Element("TheDeckThisGuyBelongsTo").Value;
                    CharacterList.Add(AnotherMonster);
                }
            }

            this.TheHighestAllowedATKPoints = double.Parse(root.Element("TheHighestAllowedATKPoints").Value);
            this.TheLowestAllowedATKPoints = double.Parse(root.Element("TheLowestAllowedATKPoints").Value);
            this.ThePowerLevelGapBetweenTheStrongestAndWeakest = double.Parse(root.Element("ThePowerLevelGapBetweenTheStrongestAndWeakest").Value);
            this.ThePowerConvertorBetweenPowerLevelToATKPoints = double.Parse(root.Element("ThePowerConvertorBetweenPowerLevelToATKPoints").Value);
            this.DeckName = DeckNameElement.Value;
        }

        #endregion
        // push test
    }
}
