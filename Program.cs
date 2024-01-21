// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Reflection;
using System.Security;
using System.Xml.Linq;
namespace DBZ_Power_levels_to_Yugioh_ATK_points_converter___working_version
{
    public class Program()
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < double.MaxValue; i++)
            {
                #region Main Meun

                Console.Clear();
                Console.WriteLine("\x1b[3J");

                List<Deck> AllDecksWithAllMonsters = new List<Deck>();
                AllDecksWithAllMonsters = GettingAllDecks();
                Console.WriteLine("Welcome to the dbz power levels to yugioh converter.");
                Console.WriteLine("This calculator receives the general properties of a DBZ deck");
                Console.WriteLine("And after that, it can calculate the ATK points of every character sepreatly.");
                Console.WriteLine("The calculator will have to recieve some variables from you that you need to know their number, and than calculate the rest.");
                Console.WriteLine();
                Console.WriteLine("now, please decide what you want to do with it now. Do you want to:");
                Console.WriteLine();
                Console.WriteLine("1. Give the general details of an entire deck?");
                Console.WriteLine();
                Console.WriteLine("2.Calculate the specific ATK points of a DBZ character in a deck that you've already entered her general required variables to calculate?");
                Console.WriteLine();
                Console.WriteLine("3. Calculate the DEF points of a DBZ character whose ATK points was already calculated?");
                Console.WriteLine();
                Console.WriteLine("4. View details of decks and characters whose information was already calculated (inclduing star rating)?");
                // Console.WriteLine("\x1b[3J"); is the code that solves the "the console won't clear anything" problem

                Deck deck = new Deck();
                CharacterOrMonster CreatedMonster = new CharacterOrMonster();
                string choiceWhatToDoNow = Console.ReadLine();
                while (choiceWhatToDoNow != "3" && choiceWhatToDoNow != "2" && choiceWhatToDoNow != "1" && choiceWhatToDoNow != "4")
                {
                    Console.WriteLine();
                    Console.WriteLine("That's not a choice. Write either 1, 2 or 3, without any blank spaces, and than press enter");
                    choiceWhatToDoNow = Console.ReadLine();
                }

                #endregion

                #region Taking the user to his choice of conversation

                if (choiceWhatToDoNow == "1")
                {
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    AllDecksWithAllMonsters = CalculatingGeneralDeckDetails(AllDecksWithAllMonsters);
                }

                else if (choiceWhatToDoNow == "2")
                {
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    CreatedMonster = CalculatingSpecificCharacterATKPoints(AllDecksWithAllMonsters);
                }
                else if (choiceWhatToDoNow == "3")
                {
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    AllDecksWithAllMonsters = CalculatingSpecificCharacterDEFPoints(AllDecksWithAllMonsters);
                }
                else if (choiceWhatToDoNow == "4")
                {
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    ShowingAllInfo(AllDecksWithAllMonsters);
                }

                #endregion
            }

            static List<Deck> CalculatingGeneralDeckDetails(List<Deck> ExistingDecks)
            {
                Deck deck = new Deck();
                Console.Clear();
                Console.WriteLine("\x1b[3J");

                #region The variables the user gives

                Console.WriteLine("Enter the power level of the weakest character in the deck:");
                Console.WriteLine("Or m/M to return to the main meun.");
                Console.WriteLine();
                string WeakestPowerLevel = Console.ReadLine();
                if (WeakestPowerLevel.ToLower() == "m")
                {
                    return ExistingDecks;
                }
                while (!double.TryParse(WeakestPowerLevel, out double d))
                {
                    Console.WriteLine("That's not a number. Power level is a number. Try writing the power level again:");
                    Console.WriteLine("Or m/M to return to the main meun.");
                    WeakestPowerLevel = Console.ReadLine();
                    if (WeakestPowerLevel.ToLower() == "m")
                    {
                        return ExistingDecks;
                    }
                }
                double ThePowerNumberOfTheWeakestGuy = double.Parse(WeakestPowerLevel);
                Console.WriteLine();
                Console.WriteLine("Enter the power level of the strongest character in the deck:");
                Console.WriteLine("Or m/M to return to the main meun.");
                string StrongestPowerLevel = Console.ReadLine();
                if (StrongestPowerLevel.ToLower() == "m")
                {
                    return ExistingDecks;
                }
                while (!double.TryParse(StrongestPowerLevel, out double d))
                {
                    Console.WriteLine("That's not a number. Power level is a number. Try writing the power level again:");
                    StrongestPowerLevel = Console.ReadLine();
                    if (StrongestPowerLevel.ToLower() == "m")
                    {
                        return ExistingDecks;
                    }
                }
                double ThePowerNumberOfTheStrongestGuy = double.Parse(StrongestPowerLevel);
                bool isTheStrongestPowerAboveTheWeakestOne = ThePowerNumberOfTheStrongestGuy > ThePowerNumberOfTheWeakestGuy;
                while (isTheStrongestPowerAboveTheWeakestOne == false)
                {
                    Console.WriteLine("This number is not above the weakest guy one! the number must be higher! Input the right number:");
                    Console.WriteLine();
                    StrongestPowerLevel = Console.ReadLine();
                    if (StrongestPowerLevel.ToLower() == "m")
                    {
                        return ExistingDecks;
                    }
                    while (!double.TryParse(StrongestPowerLevel, out double d))
                    {
                        Console.WriteLine("That's not a number. Power level is a number. Try writing the power level again:");
                        StrongestPowerLevel = Console.ReadLine();
                        if (StrongestPowerLevel.ToLower() == "m")
                        {
                            return ExistingDecks;
                        }
                    }
                    ThePowerNumberOfTheStrongestGuy = double.Parse(StrongestPowerLevel);
                    isTheStrongestPowerAboveTheWeakestOne = ThePowerNumberOfTheStrongestGuy > ThePowerNumberOfTheWeakestGuy;
                }
                Console.WriteLine();
                Console.WriteLine("What is the highest ATK points you want in the deck?");
                Console.WriteLine();
                string HighestATKValue = Console.ReadLine();
                if (HighestATKValue.ToLower() == "m")
                {
                    return ExistingDecks;
                }
                while (!double.TryParse(HighestATKValue, out double d))
                {
                    Console.WriteLine("That's not a number. ATK points are a number. Try writing the ATK points again:");
                    HighestATKValue = Console.ReadLine();
                    if (HighestATKValue.ToLower() == "m")
                    {
                        return ExistingDecks;
                    }
                }
                double HighestAttackNumber = double.Parse(HighestATKValue);
                while (HighestAttackNumber <= 0)
                {
                    Console.WriteLine("It can't be this low! At least above 0! Try again:");
                    Console.WriteLine();
                    HighestATKValue = Console.ReadLine();
                    if (HighestATKValue.ToLower() == "m")
                    {
                        return ExistingDecks;
                    }
                    while (!double.TryParse(HighestATKValue, out double d))
                    {
                        Console.WriteLine("That's not a number. ATK points are a number. Try writing the ATK points again:");
                        HighestATKValue = Console.ReadLine();
                        if (HighestATKValue.ToLower() == "m")
                        {
                            return ExistingDecks;
                        }
                    }
                    HighestAttackNumber = double.Parse(HighestATKValue);
                }

                Console.WriteLine();
                Console.WriteLine("Now, what is the lowest ATK points the weakest character will have?");
                Console.WriteLine();
                string LowestATKValue = Console.ReadLine();
                if (LowestATKValue.ToLower() == "m")
                {
                    return ExistingDecks;
                }
                while (!double.TryParse(LowestATKValue, out double d))
                {
                    Console.WriteLine("That's not a number. ATK points are a number. Try writing the ATK points again:");
                    LowestATKValue = Console.ReadLine();
                    if (LowestATKValue.ToLower() == "m")
                    {
                        return ExistingDecks;
                    }
                }
                double LowestAttackNumber = double.Parse(LowestATKValue);
                while (LowestAttackNumber < 0)
                {
                    Console.WriteLine("It can't be this low! At least 0! Try again:");
                    Console.WriteLine();
                    LowestATKValue = Console.ReadLine();
                    if (LowestATKValue.ToLower() == "m")
                    {
                        return ExistingDecks;
                    }
                    while (!double.TryParse(LowestATKValue, out double d))
                    {
                        Console.WriteLine("That's not a number. ATK points are a number. Try writing the ATK points again:");
                        LowestATKValue = Console.ReadLine();
                        if (LowestATKValue.ToLower() == "m")
                        {
                            return ExistingDecks;
                        }
                    }
                    LowestAttackNumber = double.Parse(LowestATKValue);
                }

                Console.WriteLine();
                Console.WriteLine("Now give the deck a name, and you're done:");
                string TheDeckName = Console.ReadLine();
                if (TheDeckName.ToLower() == "m")
                {
                    return ExistingDecks;
                }
                Console.WriteLine();

                foreach (Deck CheckedDeck in ExistingDecks)
                {
                    if (CheckedDeck.DeckName == TheDeckName)
                    {
                        while (CheckedDeck.DeckName == TheDeckName)
                        {
                            Console.WriteLine("There's already a deck under the same name. Please give it another name that doesn't exist in the converter's database.");
                            Console.WriteLine();
                            TheDeckName = Console.ReadLine();
                            if (TheDeckName.ToLower() == "m")
                            {
                                return ExistingDecks;
                            }
                        }
                    }
                }

                deck.DeckName = TheDeckName;

                deck.TheHighestAllowedATKPoints = HighestAttackNumber;
                deck.TheLowestAllowedATKPoints = LowestAttackNumber;

                #endregion

                #region The variables that the calculator calculates without help

                deck.TheMonsterWithTheLowestPowerLevel.PowerLevel = ThePowerNumberOfTheWeakestGuy;
                deck.TheMonsterWithTheHighestPowerLevel.PowerLevel = ThePowerNumberOfTheStrongestGuy;

                deck.ThePowerLevelGapBetweenTheStrongestAndWeakest = (deck.TheMonsterWithTheHighestPowerLevel.PowerLevel) / deck.TheMonsterWithTheLowestPowerLevel.PowerLevel;
                deck.ThePowerConvertorBetweenPowerLevelToATKPoints = 1 / (Math.Log(deck.ThePowerLevelGapBetweenTheStrongestAndWeakest) / Math.Log(deck.TheHighestAllowedATKPoints - deck.TheLowestAllowedATKPoints));

                deck.TheMonsterWithTheLowestPowerLevel.IsTheWeakestCharacterInHisDeck = true;
                deck.TheMonsterWithTheLowestPowerLevel.IsTheStrongestCharacterInHisDeck = false;
                deck.TheMonsterWithTheLowestPowerLevel.ATKPoints = LowestAttackNumber;
                deck.TheMonsterWithTheLowestPowerLevel.TheDeckThisGuyBelongsTo = new Deck();
                deck.TheMonsterWithTheLowestPowerLevel.TheDeckThisGuyBelongsTo = deck;

                deck.TheMonsterWithTheHighestPowerLevel.IsTheWeakestCharacterInHisDeck = false;
                deck.TheMonsterWithTheHighestPowerLevel.IsTheStrongestCharacterInHisDeck = true;
                deck.TheMonsterWithTheHighestPowerLevel.ATKPoints = HighestAttackNumber;
                deck.TheMonsterWithTheHighestPowerLevel.TheDeckThisGuyBelongsTo = new Deck();
                deck.TheMonsterWithTheHighestPowerLevel.TheDeckThisGuyBelongsTo = deck;

                ExistingDecks.Add(deck);
                WritingDeckToXMLFile(deck);

                Console.WriteLine();
                Console.WriteLine("All the variables required for the deck have been established. Now the deck data can be saved and used to convert its monster's power levels to ATK points.");
                Console.WriteLine();
                Console.WriteLine("enter anything to go back to the main meun.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                return ExistingDecks;

                #endregion
            }

            static CharacterOrMonster CalculatingSpecificCharacterATKPoints(List<Deck> AllDecks)
            {
                #region User inputs required information to calculate

                CharacterOrMonster CurrentCharacter = new CharacterOrMonster();
                Deck TheMonstersDeck = new Deck();

                Console.WriteLine("The following is a list of all decks in the converter's database. Enter the number of the deck your monster will belong to:");
                Console.WriteLine();
                List<int> allDeckNumbers = new List<int>();
                int deckNum = 1;
                foreach (Deck deck in AllDecks)
                {
                    Console.WriteLine($"{deckNum}. {deck.DeckName}");
                    Console.WriteLine();
                    allDeckNumbers.Add(deckNum);
                    deckNum++;
                }

                string ChoosenDeck = Console.ReadLine();
                if (ChoosenDeck.ToLower() == "m")
                {
                    return CurrentCharacter;
                }
                bool HasTheConverterFoundAMatchBetweenTheChoosenNameAndExistingDeckName = false;
                while (!int.TryParse(ChoosenDeck, out int d))
                {
                    Console.WriteLine($@"That's not a deck number. Enter the number that appears right before your deck name:");
                    ChoosenDeck = Console.ReadLine();
                    if (ChoosenDeck.ToLower() == "m")
                    {
                        return CurrentCharacter;
                    }
                }
                int ChoosenDeckNumber = int.Parse(ChoosenDeck);
                while (ChoosenDeckNumber > (allDeckNumbers.Count) || ChoosenDeckNumber < 1)
                {
                    Console.WriteLine("This number doesn't match the number of any deck. Try again:");
                    ChoosenDeck = Console.ReadLine();
                    if (ChoosenDeck.ToLower() == "m")
                    {
                        return CurrentCharacter;
                    }
                    while (!int.TryParse(ChoosenDeck, out int d))
                    {
                        Console.WriteLine($@"That's not a deck number. Enter the number that appears right before your deck name:");
                        ChoosenDeck = Console.ReadLine();
                        if (ChoosenDeck.ToLower() == "m")
                        {
                            return CurrentCharacter;
                        }
                    }
                    ChoosenDeckNumber = int.Parse(ChoosenDeck);
                }

                for (int i = 1; i <= AllDecks.Count; i++)
                {
                    if (ChoosenDeckNumber == i)
                    {
                        TheMonstersDeck = AllDecks.ElementAt(i - 1);
                        HasTheConverterFoundAMatchBetweenTheChoosenNameAndExistingDeckName = true;
                    }
                }
                /*
                while (!HasTheConverterFoundAMatchBetweenTheChoosenNameAndExistingDeckName)
                {
                    Console.WriteLine("This number doesn't match any deck's name. Try entering another name:");
                    Console.WriteLine();
                    ChoosenDeck = Console.ReadLine().ToLower();
                    foreach (Deck deck in AllDecks)
                    {
                        if (deck.DeckName.ToLower() == ChoosenDeck)
                        {
                            HasTheConverterFoundAMatchBetweenTheChoosenNameAndExistingDeckName = true;
                            TheMonstersDeck = deck;
                        }
                    }
                }
                */
                CurrentCharacter.TheDeckThisGuyBelongsTo = new Deck();
                CurrentCharacter.TheDeckThisGuyBelongsTo = TheMonstersDeck;
                Console.WriteLine("What is the character's name (card name)?");
                Console.WriteLine();
                string NameForIt = Console.ReadLine();
                if (NameForIt.ToLower() == "m")
                {
                    return CurrentCharacter;
                }
                Console.WriteLine();

                for (int i = 0; i < TheMonstersDeck.CharacterList.Count; i++)
                {
                    if (TheMonstersDeck.CharacterList.ElementAt(i).Name == NameForIt)
                    {
                        while (TheMonstersDeck.CharacterList.ElementAt(i).Name == NameForIt)
                        {
                            Console.WriteLine("There's already a monster with this name. You can't edit exisitng monsters at the time. Try another name:");
                            Console.WriteLine();
                            NameForIt = Console.ReadLine();
                            if (NameForIt.ToLower() == "m")
                            {
                                return CurrentCharacter;
                            }
                        }

                    }
                }

                CurrentCharacter.Name = NameForIt;

                Console.WriteLine("What is his power level?");
                Console.WriteLine();
                string PowerLevelValue = Console.ReadLine();
                if (PowerLevelValue.ToLower() == "m")
                {
                    return CurrentCharacter;
                }

                while (!double.TryParse(PowerLevelValue, out double d))
                {
                    Console.WriteLine("That's not a number. Power levels are numbers. Try again:");
                    PowerLevelValue = Console.ReadLine();
                    if (PowerLevelValue.ToLower() == "m")
                    {
                        return CurrentCharacter;
                    }
                }

                double PowerLevel = double.Parse(PowerLevelValue);
                while (PowerLevel <= 0 || PowerLevel <= TheMonstersDeck.TheMonsterWithTheLowestPowerLevel.PowerLevel || PowerLevel >= TheMonstersDeck.TheMonsterWithTheHighestPowerLevel.PowerLevel)
                {
                    Console.WriteLine($"The number is too low or too high. Make sure it's not below 0, not below the weakest monster in this deck, and not above the strongest monster in this deck. For techinal limiations, you also cannot have more than 1 monster with the minimum or maximum power level. Try again:");
                    Console.WriteLine();
                    PowerLevelValue = Console.ReadLine();
                    if (PowerLevelValue.ToLower() == "m")
                    {
                        return CurrentCharacter;
                    }
                    while (!double.TryParse(PowerLevelValue, out double d))
                    {
                        Console.WriteLine("That's not a number. Power levels are numbers. Try writing the power level again:");
                        PowerLevelValue = Console.ReadLine();
                        if (PowerLevelValue.ToLower() == "m")
                        {
                            return CurrentCharacter;
                        }
                    }
                    PowerLevel = double.Parse(PowerLevelValue);
                }

                CurrentCharacter.Name = NameForIt;
                CurrentCharacter.PowerLevel = PowerLevel;
                CurrentCharacter.IsTheWeakestCharacterInHisDeck = false;
                CurrentCharacter.IsTheStrongestCharacterInHisDeck = false;

                #endregion

                #region Now to calculate and show the ATK points...

                double GapBetweenThisMonsterAndWeakestMonsterInPowerLevel = CurrentCharacter.PowerLevel / TheMonstersDeck.TheMonsterWithTheLowestPowerLevel.PowerLevel;
                double GapConvertedToATKExponent = Math.Pow(GapBetweenThisMonsterAndWeakestMonsterInPowerLevel, TheMonstersDeck.ThePowerConvertorBetweenPowerLevelToATKPoints);
                double LogDifferenceBetweenCurrentMonsterAndStrongestMonster = Math.Log(TheMonstersDeck.TheHighestAllowedATKPoints - TheMonstersDeck.TheLowestAllowedATKPoints) / Math.Log(GapConvertedToATKExponent);
                double TheAttackPointsGap = Math.Round((TheMonstersDeck.TheHighestAllowedATKPoints - TheMonstersDeck.TheLowestAllowedATKPoints) / LogDifferenceBetweenCurrentMonsterAndStrongestMonster);
                double TheActualAttackPoints = TheAttackPointsGap + TheMonstersDeck.TheLowestAllowedATKPoints;
                CurrentCharacter.ATKPoints = TheActualAttackPoints;
                CurrentCharacter.TheDeckThisGuyBelongsTo = TheMonstersDeck;

                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine($"The ATK points of {NameForIt} (rounded) should be: {TheActualAttackPoints}");
                Console.WriteLine();
                Console.WriteLine("You can now view this monster's details by viewing its deck details.");
                Console.WriteLine("Enter anything to return to the main meun.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                TheMonstersDeck.CharacterList.Add(CurrentCharacter);
                TheMonstersDeck.NumberOfMonstersStoredInIt = TheMonstersDeck.NumberOfMonstersStoredInIt + 1;
                UpdateDeckWithNewMonster(TheMonstersDeck, CurrentCharacter);


                return CurrentCharacter;

                #endregion

            }

            #region Showing whatever information the user may wanna know..

            static void ShowingAllInfo(List<Deck> AllDecksToShow)
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");

                CharacterOrMonster CurrentCharacter = new CharacterOrMonster();
                Deck TheMonstersDeck = new Deck();

                Console.WriteLine("The following is a list of all decks in the converter's database. Enter the number of the deck your monster will belong to:");
                Console.WriteLine("or enter m/M (not case sensitive) to go back to the main meun:");
                Console.WriteLine();
                int DeckNumber = 1;
                List<int> deckNumbers = new List<int>();
                foreach (Deck deck in AllDecksToShow)
                {
                    Console.WriteLine($"{DeckNumber}.{deck.DeckName}");
                    Console.WriteLine();
                    deckNumbers.Add(DeckNumber);
                    DeckNumber++;
                }

                string ChoosenDeck = Console.ReadLine().ToLower();
                if (ChoosenDeck.ToLower() == "m")
                {
                    return;
                }
                bool HasTheConverterFoundAMatchBetweenTheChoosenNameAndExistingDeckName = false;

                while (!int.TryParse(ChoosenDeck, out int d))
                {
                    Console.WriteLine("That's not even a number. Enter the number of the deck you wanna view its information:");
                    Console.WriteLine();
                    ChoosenDeck = Console.ReadLine();
                    if (ChoosenDeck.ToLower() == "m")
                    {
                        return;
                    }
                }
                int ChoosenDeckNumber = int.Parse(ChoosenDeck);
                while (ChoosenDeckNumber < 1 || ChoosenDeckNumber > deckNumbers.Count)
                {
                    Console.WriteLine("This number does not belong to any deck. Enter again:");
                    Console.WriteLine();
                    ChoosenDeck = Console.ReadLine();
                    if (ChoosenDeck.ToLower() == "m")
                    {
                        return;
                    }
                    while (!int.TryParse(ChoosenDeck, out int d))
                    {
                        Console.WriteLine("That's not even a number. Enter the number of the deck you wanna view its information:");
                        Console.WriteLine();
                        ChoosenDeck = Console.ReadLine();
                        if (ChoosenDeck.ToLower() == "m")
                        {
                            return;
                        }
                    }
                    ChoosenDeckNumber = int.Parse(ChoosenDeck);
                }
                while (!HasTheConverterFoundAMatchBetweenTheChoosenNameAndExistingDeckName)
                {
                    for (int i = 1; i <= deckNumbers.Count; i++)
                    {
                        if (deckNumbers.ElementAt(i - 1) == ChoosenDeckNumber)
                        {
                            TheMonstersDeck = AllDecksToShow.ElementAt(ChoosenDeckNumber - 1);
                            HasTheConverterFoundAMatchBetweenTheChoosenNameAndExistingDeckName = true;
                        }
                    }
                }

                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine($@"The following are the general details of the deck named {TheMonstersDeck.DeckName}.");
                Console.WriteLine();
                Console.WriteLine("To view the details of its monsters, enter c/C (either lower or upper case)");
                Console.WriteLine("To go back to the main meun, enter M/m");
                Console.WriteLine();
                Console.WriteLine(@$"This deck named {TheMonstersDeck.DeckName}, contains: {TheMonstersDeck.CharacterList.Count - 2} monsters.");
                Console.WriteLine();
                Console.WriteLine($@"The highest ATK points allowed for this deck is: {TheMonstersDeck.TheHighestAllowedATKPoints}, and the lowest allowed are {TheMonstersDeck.TheLowestAllowedATKPoints}.");
                Console.WriteLine();
                Console.WriteLine($@"The strongest DBZ monster here has a power level of {TheMonstersDeck.TheMonsterWithTheHighestPowerLevel.PowerLevel}, and the weakest's power level is {TheMonstersDeck.TheMonsterWithTheLowestPowerLevel.PowerLevel}.");
                Console.WriteLine();
                Console.WriteLine("In addition, here's the list of stars in this deck depending on the ATK points:");
                for (int star = 1; star <= 12; star++)
                {
                    double GapBetweenEachStar = (TheMonstersDeck.TheHighestAllowedATKPoints - TheMonstersDeck.TheLowestAllowedATKPoints) / 12;
                    Console.WriteLine();
                    double currentStarMinimum = Math.Round(TheMonstersDeck.TheLowestAllowedATKPoints + (star - 1) * GapBetweenEachStar);
                    double currentStarMaximum = Math.Round(TheMonstersDeck.TheLowestAllowedATKPoints + (star) * GapBetweenEachStar);

                    Console.WriteLine($@"{star} star: between {currentStarMinimum} to {currentStarMaximum}");
                }
                Console.WriteLine();
                string firstChoice = Console.ReadLine();
                while (firstChoice.ToLower() != "c" && firstChoice.ToLower() != "m")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter either m or c - nothing else. Enter again:");
                    Console.WriteLine();
                    firstChoice = Console.ReadLine();
                }

                if (firstChoice.ToLower() == "c")
                {
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");

                    Console.WriteLine(@$"The following is a list of all characters/monsters in that already exist in the deck named {TheMonstersDeck.DeckName}.");
                    Console.WriteLine($@"The DEF points of the monsters will appear as uncalculated, expect for monsters whose DEF points were calculated via this converter and are not equal to the same monster's ATK points.");
                    Console.WriteLine();

                    foreach (CharacterOrMonster monster in TheMonstersDeck.CharacterList)
                    {
                        if (monster.Name != "Weakest" && monster.Name != "Strongest")
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{monster.Name}:");
                            Console.WriteLine();
                            Console.WriteLine($@"{monster.Name}'s Power Level: {monster.PowerLevel}");
                            Console.WriteLine();
                            Console.WriteLine($@"{monster.Name}'s ATK points: {monster.ATKPoints}");
                            Console.WriteLine();
                            if (monster.DEFPoints == 0 || monster.DEFPoints == 0.1 || monster.DEFPoints == monster.ATKPoints)
                            {
                                Console.WriteLine($@"{monster.Name}'s DEF Points: Uncalculated");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine($@"{monster.Name}'s DEF Points: {monster.DEFPoints}");
                                Console.WriteLine();
                            }
                            Console.WriteLine($@"the stars of this monster should be (not always accratue): {Math.Round(12 / (TheMonstersDeck.TheHighestAllowedATKPoints / monster.ATKPoints))}");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("Enter anything to return to selecting deck to view its details.");
                    Console.ReadLine();
                    ShowingAllInfo(AllDecksToShow);
                }
                if (firstChoice.ToLower() == "m")
                {
                    return;
                }
            }

            #endregion

            #region Calculating DEF points

            static List<Deck> CalculatingSpecificCharacterDEFPoints(List<Deck> AllDecks)
            {
                CharacterOrMonster CurrentCharacter = new CharacterOrMonster();

                Console.Clear();
                Console.WriteLine("\x1b[3J");

                #region Choosing the deck to edit

                Deck TheMonstersDeck = new Deck();

                Console.WriteLine("The following is a list of all decks in the converter's database. Enter the number of the deck your monster will belong to:");
                Console.WriteLine();
                List<int> allDeckNumbers = new List<int>();
                int deckNum = 1;
                foreach (Deck deck in AllDecks)
                {
                    Console.WriteLine($"{deckNum}. {deck.DeckName}");
                    Console.WriteLine();
                    allDeckNumbers.Add(deckNum);
                    deckNum++;
                }

                string ChoosenDeck = Console.ReadLine();
                if (ChoosenDeck.ToLower() == "m")
                {
                    return AllDecks;
                }

                bool HasTheConverterFoundAMatchBetweenTheChoosenNameAndExistingDeckName = false;
                while (!int.TryParse(ChoosenDeck, out int d))
                {
                    Console.WriteLine($@"That's not a deck number. Enter the number that appears right before your deck name:");
                    ChoosenDeck = Console.ReadLine();
                    if (ChoosenDeck.ToLower() == "m")
                    {
                        return AllDecks;
                    }
                }
                int ChoosenDeckNumber = int.Parse(ChoosenDeck);
                while (ChoosenDeckNumber > (allDeckNumbers.Count) || ChoosenDeckNumber < 1)
                {
                    Console.WriteLine("This number doesn't match the number of any deck. Try again:");
                    ChoosenDeck = Console.ReadLine();
                    if (ChoosenDeck.ToLower() == "m")
                    {
                        return AllDecks;
                    }
                    while (!int.TryParse(ChoosenDeck, out int d))
                    {
                        Console.WriteLine($@"That's not a deck number. Enter the number that appears right before your deck name:");
                        ChoosenDeck = Console.ReadLine();
                        if (ChoosenDeck.ToLower() == "m")
                        {
                            return AllDecks;
                        }
                    }
                    ChoosenDeckNumber = int.Parse(ChoosenDeck);
                }

                for (int i = 1; i <= AllDecks.Count; i++)
                {
                    if (ChoosenDeckNumber == i)
                    {
                        TheMonstersDeck = AllDecks.ElementAt(i - 1);
                        HasTheConverterFoundAMatchBetweenTheChoosenNameAndExistingDeckName = true;
                    }
                }



                #endregion

                bool DoesTheUserWantsToApplyTheGapToAllCharacters = false;
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                Console.WriteLine("Now, decide if you want the gap between ATK/DEF you're going to input:");
                Console.WriteLine("1. only apply for one character?");
                Console.WriteLine("2. or apply for the entire deck?");
                Console.WriteLine("enter eihter 1 or 2.");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "m")
                {
                    return AllDecks;
                }
                while (!int.TryParse(answer, out int d))
                {
                    Console.WriteLine($@"That's not either of those options. Choose either 1 (for applying your gap for one character) or 2(apply it for all characters in the deck {TheMonstersDeck.DeckName}");
                    answer = Console.ReadLine();
                    if (answer.ToLower() == "m")
                    {
                        return AllDecks;
                    }
                }
                int answerNumber = int.Parse(answer);
                while (answerNumber != 1 && answerNumber != 2)
                {
                    Console.WriteLine();
                    Console.WriteLine($@"That's not either of those options. Choose either 1 (for applying your gap for one character) or 2(apply it for all characters in the deck {TheMonstersDeck.DeckName}");
                    answer = Console.ReadLine();
                    if (answer.ToLower() == "m")
                    {
                        return AllDecks;
                    }

                    while (!int.TryParse(answer, out int d))
                    {
                        Console.WriteLine();
                        Console.WriteLine($@"That's not either of those options. Choose either 1 (for applying your gap for one character) or 2(apply it for all characters in the deck {TheMonstersDeck.DeckName}");
                        answer = Console.ReadLine();
                        if (answer.ToLower() == "m")
                        {
                            return AllDecks;
                        }
                    }
                    answerNumber = int.Parse(answer);
                }
                if (answerNumber == 1)
                {
                    #region Choosing the existing monster to update its DEF points

                    CurrentCharacter = new CharacterOrMonster();
                    CurrentCharacter.TheDeckThisGuyBelongsTo = new Deck();
                    CurrentCharacter.TheDeckThisGuyBelongsTo = TheMonstersDeck;
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");

                    Console.WriteLine(@$"The following is a list of all characters/monsters in that already exist in the deck named {TheMonstersDeck.DeckName}. Enter the name of the one you want to edit its DEF points):");
                    Console.WriteLine();
                    int MonsterNumber = 1;
                    foreach (CharacterOrMonster monster in TheMonstersDeck.CharacterList)
                    {
                        Console.WriteLine($"{MonsterNumber}.{monster.Name}");
                        Console.WriteLine();
                        MonsterNumber++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("So, what is the character's name (card name)?");
                    Console.WriteLine();
                    string NameForIt = Console.ReadLine();
                    if (NameForIt.ToLower() == "m")
                    {
                        return AllDecks;
                    }
                    Console.WriteLine();
                    bool HasTheMonsterBeenFound = false;
                    for (int i = 0; i < TheMonstersDeck.CharacterList.Count; i++)
                    {
                        if (TheMonstersDeck.CharacterList.ElementAt(i).Name.ToLower() == NameForIt.ToLower())
                        {
                            HasTheMonsterBeenFound = true;
                        }
                    }
                    while (!HasTheMonsterBeenFound)
                    {
                        Console.WriteLine();
                        Console.WriteLine("This monster does not exist in this deck. Try another name:");
                        Console.WriteLine();
                        NameForIt = Console.ReadLine();
                        if (NameForIt.ToLower() == "m")
                        {
                            return AllDecks;
                        }
                        for (int i = 0; i < TheMonstersDeck.CharacterList.Count; i++)
                        {
                            if (TheMonstersDeck.CharacterList.ElementAt(i).Name.ToLower() == NameForIt.ToLower())
                            {
                                HasTheMonsterBeenFound = true;
                            }
                        }
                        Console.WriteLine();
                    }
                    CurrentCharacter.Name = NameForIt;

                    foreach (CharacterOrMonster monster in TheMonstersDeck.CharacterList)
                    {
                        if (monster.Name == CurrentCharacter.Name)
                        {
                            CurrentCharacter = monster;
                        }
                    }

                    #endregion
                }
                else if (answerNumber == 2)
                {
                    DoesTheUserWantsToApplyTheGapToAllCharacters = true;
                }

                #region Entering the gap

                Console.Clear();
                Console.WriteLine("\x1b[3J");

                if (!DoesTheUserWantsToApplyTheGapToAllCharacters)
                {
                    Console.WriteLine(@$"Enter the gap (in multiplier power level terms) between the character {CurrentCharacter.Name} power level to the power it takes to one-shot (and kill) it.");
                }
                else if (DoesTheUserWantsToApplyTheGapToAllCharacters)
                {
                    Console.WriteLine(@$"Enter the gap (in multiplier power level terms) between all characters in the deck {TheMonstersDeck.DeckName} between their power level to the power it takes to one-shot (and kill) them.");
                }
                Console.WriteLine($@"How to do it: If it takes a power x1.5 strongest to kill the character/s, write 1.5. If x2, than write 2, etc.");
                Console.WriteLine();
                Console.WriteLine($@"(character/s means either a single character, or characters if you apply this to all monsters in the deck {TheMonstersDeck.DeckName}.");
                Console.WriteLine();
                Console.WriteLine($@"The character/s can't be killed with a power level not higher than his own. That's exgrated.");
                Console.WriteLine($@"It's true was rated at 1500 while the special beam cannon that killed him was stated to be below that, but offical and stated numbers often make zero sense,");
                Console.WriteLine($@"And raditz was likely only at 1000-1200 since he was slightly weakend by Gohan's attack. Possbily below 1000 if nerfing him to how strong he is actually shown to be.");
                Console.WriteLine();
                Console.WriteLine("So always put a number above 1:");
                Console.WriteLine();
                string gap = Console.ReadLine();
                if (gap.ToLower() == "m")
                {
                    return AllDecks;
                }
                while (!double.TryParse(gap, out double d))
                {
                    Console.WriteLine("That's not a number. Try writing the gap again:");
                    gap = Console.ReadLine();
                    if (gap.ToLower() == "m")
                    {
                        return AllDecks;
                    }
                }
                while (double.Parse(gap) <= 1)
                {
                    Console.WriteLine(@"The character can't be killed with a power level not higher than his own. That's exgrated.");
                    Console.WriteLine(@"It's true was rated at 1500 while the special beam cannon that killed him was stated to be below that, but offical and stated numbers often make zero sense,");
                    Console.WriteLine(@"And raditz was likely only at 1000-1200 since he was slightly weakend by Gohan's attack. Possbily below 1000 if nerfing him to how strong he is actually shown to be.");
                    Console.WriteLine();
                    Console.WriteLine("Now enter a number above 1:");
                    Console.WriteLine();
                    gap = Console.ReadLine();
                    if (gap.ToLower() == "m")
                    {
                        return AllDecks;
                    }
                    while (!double.TryParse(gap, out double d))
                    {
                        Console.WriteLine("That's not a number. Try writing the gap again:");
                        gap = Console.ReadLine();
                        if (gap.ToLower() == "m")
                        {
                            return AllDecks;
                        }
                    }
                }

                double TheGap = double.Parse(gap);

                #endregion

                #region Calculating the DEF points of this monster

                double convertingNumber = TheMonstersDeck.ThePowerConvertorBetweenPowerLevelToATKPoints;
                double YugiohDEFGap = Math.Pow(TheGap, convertingNumber);
                double LogGap = (Math.Log(TheMonstersDeck.TheHighestAllowedATKPoints)) / Math.Log(YugiohDEFGap);
                double DEFBonus = Math.Round(TheMonstersDeck.TheHighestAllowedATKPoints / LogGap);
                double DEFBonusForEveryOne = DEFBonus;

                #endregion

                #region Updating the DEF points on local variables

                AllDecks.Remove(TheMonstersDeck);
                if (!DoesTheUserWantsToApplyTheGapToAllCharacters)
                {
                    TheMonstersDeck.CharacterList.Find(x => x == CurrentCharacter).DEFPoints = CurrentCharacter.ATKPoints + DEFBonus; ;
                    CurrentCharacter.DEFPoints = CurrentCharacter.ATKPoints + DEFBonus;
                }
                else if (DoesTheUserWantsToApplyTheGapToAllCharacters)
                {
                    foreach (CharacterOrMonster monster in TheMonstersDeck.CharacterList)
                    {
                        monster.DEFPoints = monster.ATKPoints + DEFBonusForEveryOne;
                    }
                }

                AllDecks.Add(TheMonstersDeck);

                #endregion

                #region Updating the DEF points in the deck xml file

                if (!DoesTheUserWantsToApplyTheGapToAllCharacters)
                {
                    UpdatingDEFPoints(TheMonstersDeck, CurrentCharacter);
                }
                else if (DoesTheUserWantsToApplyTheGapToAllCharacters)
                {
                    UpdatingDEFPoints(TheMonstersDeck);
                }

                #endregion

                #region Showing the result to the user

                Console.Clear();
                Console.WriteLine("\x1b[3J");
                if (!DoesTheUserWantsToApplyTheGapToAllCharacters)
                {
                    Console.WriteLine($@"{CurrentCharacter.Name} DEF points should be: {CurrentCharacter.ATKPoints + DEFBonus}.");
                }
                else if (DoesTheUserWantsToApplyTheGapToAllCharacters)
                {
                    Console.WriteLine($@"All of the monsters in the deck named {TheMonstersDeck.DeckName}'s DEF points are {DEFBonus} higher than their Attack points.");
                }
                Console.WriteLine(@$"And it's saved in the database.");
                Console.WriteLine("Enter anything to go back to the main meun.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\x1b[3J");

                return AllDecks;

                #endregion
            }

            #endregion

            #region Preparing all the deck and monsters objects pre-software start

            static List<Deck> GettingAllDecks()
            {
                List<Deck> AllDecks = new List<Deck>();
                List<string> DecksPathes = new List<string>();
                XDocument NavigatorDocument = new XDocument(XDocument.Load(@"YugiohDBZConverter\DecksNavigator.xml"));
                XElement NavigatorRoot = NavigatorDocument.Root;
                IEnumerable<XElement> AllDecksElements = NavigatorRoot.Elements("Deck");
                foreach (XElement DeckElement in AllDecksElements)
                {
                    XElement DocDeckPath = new XElement(DeckElement.Element("Path"));
                    DecksPathes.Add(DocDeckPath.Value);
                }
                foreach (string path in DecksPathes)
                {
                    Deck deck = new Deck();
                    deck.ReadDeckXMLFile(path);
                    AllDecks.Add(deck);
                }
                return AllDecks;
            }

            #endregion

            #region Writing to files - I have no choice

            static void WritingDeckToXMLFile(Deck deck)
            {

                #region Writing a new deck file
                List<string> whatToWriteToXML = new List<string>();
                whatToWriteToXML.Add("<Deck>");
                whatToWriteToXML.Add($@"<DeckName>{deck.DeckName}</DeckName>");
                whatToWriteToXML.Add(@$"<TheHighestAllowedATKPoints>{deck.TheHighestAllowedATKPoints}</TheHighestAllowedATKPoints>");
                whatToWriteToXML.Add(@$"<TheLowestAllowedATKPoints>{deck.TheLowestAllowedATKPoints}</TheLowestAllowedATKPoints>");
                whatToWriteToXML.Add(@$"<ThePowerLevelGapBetweenTheStrongestAndWeakest>{deck.ThePowerLevelGapBetweenTheStrongestAndWeakest}</ThePowerLevelGapBetweenTheStrongestAndWeakest>");
                whatToWriteToXML.Add(@$"<ThePowerConvertorBetweenPowerLevelToATKPoints>{deck.ThePowerConvertorBetweenPowerLevelToATKPoints}</ThePowerConvertorBetweenPowerLevelToATKPoints>");
                whatToWriteToXML.Add(@$"<CharacterList>");
                whatToWriteToXML.Add(@$"<Monster>");
                whatToWriteToXML.Add(@$"<TheMonsterWithTheLowestPowerLevel>");

                whatToWriteToXML.Add(@$"<ATKPoints>{deck.TheLowestAllowedATKPoints}</ATKPoints>");
                whatToWriteToXML.Add(@$"<DEFPoints>{deck.TheLowestAllowedATKPoints}</DEFPoints>");
                whatToWriteToXML.Add(@$"<Name>Weakest</Name>");
                whatToWriteToXML.Add(@$"<PowerLevel>{deck.TheMonsterWithTheLowestPowerLevel.PowerLevel}</PowerLevel>");
                whatToWriteToXML.Add(@$"<IsTheStrongestCharacterInHisDeck>False</IsTheStrongestCharacterInHisDeck>");
                whatToWriteToXML.Add(@$"<IsTheWeakestCharacterInHisDeck>True</IsTheWeakestCharacterInHisDeck>");
                whatToWriteToXML.Add(@$"<TheDeckThisGuyBelongsTo>{deck.DeckName}</TheDeckThisGuyBelongsTo>");
                whatToWriteToXML.Add(@$"</TheMonsterWithTheLowestPowerLevel>");
                whatToWriteToXML.Add(@$"</Monster>");

                whatToWriteToXML.Add("<Monster>");
                whatToWriteToXML.Add("<TheMonsterWithTheHighestPowerLevel>");
                whatToWriteToXML.Add(@$"<ATKPoints>{deck.TheHighestAllowedATKPoints}</ATKPoints>");
                whatToWriteToXML.Add(@$"<DEFPoints>{deck.TheHighestAllowedATKPoints}</DEFPoints>");
                whatToWriteToXML.Add(@$"<Name>Strongest</Name>");
                whatToWriteToXML.Add(@$"<PowerLevel>{deck.TheMonsterWithTheHighestPowerLevel.PowerLevel}</PowerLevel>");
                whatToWriteToXML.Add(@$"<IsTheStrongestCharacterInHisDeck>True</IsTheStrongestCharacterInHisDeck>");
                whatToWriteToXML.Add(@$"<IsTheWeakestCharacterInHisDeck>False</IsTheWeakestCharacterInHisDeck>");
                whatToWriteToXML.Add(@$"<TheDeckThisGuyBelongsTo>{deck.DeckName}</TheDeckThisGuyBelongsTo>");
                whatToWriteToXML.Add(@$"</TheMonsterWithTheHighestPowerLevel>");
                whatToWriteToXML.Add(@$"</Monster>");
                whatToWriteToXML.Add(@$"</CharacterList>");
                whatToWriteToXML.Add(@$"</Deck>");
                File.WriteAllLines($@"YugiohDBZConverter\{deck.DeckName}.xml", whatToWriteToXML);

                #endregion

                #region Updating the deck navigator

                XDocument theDoc = new XDocument(XDocument.Load($@"YugiohDBZConverter\{deck.DeckName}.xml"));

                XDocument DeckNavigatorToEdit = new XDocument(XDocument.Load(@"YugiohDBZConverter\DecksNavigator.xml"));
                XElement root = DeckNavigatorToEdit.Root;
                IEnumerable<XElement> Decks = root.Elements("Deck");

                XElement path = new XElement(XName.Get("Path"));
                path.SetValue($@"YugiohDBZConverter\{deck.DeckName}.xml");

                XElement DeckElement = new XElement(XName.Get("Deck"));
                DeckElement.Add(path);

                List<XElement> DecksInList = Decks.ToList();
                DecksInList.Add(DeckElement);

                root.RemoveNodes();
                root.Add(DecksInList);

                DeckNavigatorToEdit.RemoveNodes();
                DeckNavigatorToEdit.Add(root);

                File.Delete($@"YugiohDBZConverter\DecksNavigator.xml");
                DeckNavigatorToEdit.Save($@"YugiohDBZConverter\DecksNavigator.xml");

                #endregion
            }


            #endregion

            #region Updating a deck when a new monster is added to it

            static void UpdateDeckWithNewMonster(Deck deck, CharacterOrMonster monster)
            {
                // next time use the startgey of creating a list of strings - it is way easier than what you did here

                /* Example code of editing an xml file:
                 * XDocument gameNavigatorToEdit = new XDocument(XDocument.Load(@"DepositInvestingGame\GamesNavigator.xml"));
                        XElement root = gameNavigatorToEdit.Root;
                        IEnumerable<XElement> games = root.Elements("Game");

                        XElement path = new XElement(XName.Get("Path"));
                        path.SetValue($@"DepositInvestingGame\Games\{gameName}.xml");

                        XElement game = new XElement(XName.Get("Game"));
                        game.Add(path);

                        List<XElement> gamesInList = games.ToList();
                        gamesInList.Add(game);

                        root.RemoveNodes();
                        root.Add(gamesInList);

                        gameNavigatorToEdit.RemoveNodes();
                        gameNavigatorToEdit.Add(root);

                        File.Delete(@"DepositInvestingGame\GamesNavigator.xml");
                        gameNavigatorToEdit.Save(@"DepositInvestingGame\GamesNavigator.xml");
                */
                XDocument DeckFileToEdit = new XDocument(XDocument.Load($@"YugiohDBZConverter\{deck.DeckName}.xml"));
                XElement root = DeckFileToEdit.Root;

                IEnumerable<XElement> RootOtherElements = root.Elements();
                List<XElement> RootElementsList = RootOtherElements.ToList();

                XElement MonstersListElement = root.Element($@"CharacterList");


                IEnumerable<XElement> MonstersList = MonstersListElement.Elements($@"Monster");
                XElement MonsterElement = new XElement(XName.Get("Monster"));

                // Than you use the .add function to all the other elements to their parent element (monsterelement)
                XElement ATKPointsElement = new XElement(XName.Get($@"ATKPoints"));
                XElement DEFPointsElement = new XElement(XName.Get($@"DEFPoints"));
                XElement NameElement = new XElement(XName.Get($@"Name"));
                XElement PowerLevelElement = new XElement(XName.Get($@"PowerLevel"));
                XElement IsTheStrongestCharacterInHisDeckElement = new XElement(XName.Get(@"IsTheStrongestCharacterInHisDeck"));
                XElement IsWeakestCharacterInHisDeckElement = new XElement(XName.Get("IsTheWeakestCharacterInHisDeck"));
                XElement TheDeckThisGuyBelongsToElement = new XElement(XName.Get(@$"TheDeckThisGuyBelongsTo"));

                ATKPointsElement.SetValue($@"{monster.ATKPoints}");
                DEFPointsElement.SetValue($@"{monster.ATKPoints}");
                NameElement.SetValue($@"{monster.Name}");
                PowerLevelElement.SetValue($@"{monster.PowerLevel}");
                IsTheStrongestCharacterInHisDeckElement.SetValue($@"False");
                IsWeakestCharacterInHisDeckElement.SetValue($@"False");
                TheDeckThisGuyBelongsToElement.SetValue($@"{deck.DeckName}");

                MonsterElement.Add(ATKPointsElement);
                MonsterElement.Add(DEFPointsElement);
                MonsterElement.Add(NameElement);
                MonsterElement.Add(PowerLevelElement);
                MonsterElement.Add(IsTheStrongestCharacterInHisDeckElement);
                MonsterElement.Add(IsWeakestCharacterInHisDeckElement);
                MonsterElement.Add(TheDeckThisGuyBelongsToElement);

                List<XElement> MonstersActualList = MonstersList.ToList();
                MonstersActualList.Add(MonsterElement);

                RootElementsList.Remove(MonstersListElement);
                //XElement AnotherMonsterRoot = new XElement(XName.Get(@""));

                XElement NewCharacterList = new XElement(XName.Get($@"CharacterList"));
                NewCharacterList.Add(MonstersActualList);
                RootElementsList.Add(NewCharacterList);

                root.RemoveNodes();
                root.Add(RootElementsList);

                DeckFileToEdit.RemoveNodes();
                DeckFileToEdit.Add(root);

                File.Delete($@"YugiohDBZConverter\{deck.DeckName}.xml");
                DeckFileToEdit.Save($@"YugiohDBZConverter\{deck.DeckName}.xml");

                //XElement DeckElement

                /* Here's a template the string list to add to the xml file:
                 *<Monster>
                  <TheMonsterWithTheHighestPowerLevel>
                    <ATKPoints></ATKPoints>
                    <DEFPoints></DEFPoints>
                    <Name></Name>
                    <PowerLevel></PowerLevel>
                    <IsTheStrongestCharacterInHisDeck>False</IsTheStrongestCharacterInHisDeck>
                    <IsTheWeakestCharacterInHisDeck>False</IsTheWeakestCharacterInHisDeck>
                    <TheDeckThisGuyBelongsTo>{deck.DeckName}</TheDeckThisGuyBelongsTo>
                  </TheMonsterWithTheHighestPowerLevel>
                </Monster>
                And below this tree node:
                </CharacterList>
                </Deck>
                */

            }

            #endregion

            #region Updating a deck when an existing's monster DEF is set

            static void UpdatingDEFPoints(Deck deck, CharacterOrMonster monster = null)
            {
                XDocument DeckFileToEdit = new XDocument(XDocument.Load($@"YugiohDBZConverter\{deck.DeckName}.xml"));
                XElement root = DeckFileToEdit.Root;
                XElement MonstersListElement = root.Element($@"CharacterList");
                IEnumerable<XElement> MonstersList = MonstersListElement.Elements($@"Monster");
                List<XElement> ActualMonstersList = MonstersList.ToList();
                foreach (XElement monsterElement in ActualMonstersList)
                {
                    XElement ItsName;
                    if (monsterElement.Element(@"TheMonsterWithTheLowestPowerLevel") != null)
                    {
                        ItsName = monsterElement.Element(@"TheMonsterWithTheLowestPowerLevel").Element("Name");
                    }
                    else if (monsterElement.Element(@"TheMonsterWithTheHighestPowerLevel") != null)
                    {
                        ItsName = monsterElement.Element(@"TheMonsterWithTheHighestPowerLevel").Element("Name");
                    }
                    else
                    {
                        ItsName = monsterElement.Element("Name");
                    }
                    if (monster != null)
                    {
                        if (ItsName.Value.ToLower() == monster.Name.ToLower())
                        {
                            monsterElement.Element("DEFPoints").Value = monster.DEFPoints.ToString();
                        }
                    }
                }
                IEnumerable<XElement> RootOtherElements = root.Elements();

                List<string> LetsTryWithAStringList = new List<string>();
                LetsTryWithAStringList.Add(@$"<Deck>");
                LetsTryWithAStringList.Add(@$"<DeckName>{deck.DeckName}</DeckName>");
                LetsTryWithAStringList.Add(@$"<TheHighestAllowedATKPoints>{deck.TheHighestAllowedATKPoints}</TheHighestAllowedATKPoints>");
                LetsTryWithAStringList.Add(@$"<TheLowestAllowedATKPoints>{deck.TheLowestAllowedATKPoints}</TheLowestAllowedATKPoints>");
                LetsTryWithAStringList.Add(@$"<ThePowerLevelGapBetweenTheStrongestAndWeakest>{deck.ThePowerLevelGapBetweenTheStrongestAndWeakest}</ThePowerLevelGapBetweenTheStrongestAndWeakest>");
                LetsTryWithAStringList.Add(@$"<ThePowerConvertorBetweenPowerLevelToATKPoints>{deck.ThePowerConvertorBetweenPowerLevelToATKPoints}</ThePowerConvertorBetweenPowerLevelToATKPoints>");
                LetsTryWithAStringList.Add($@"<CharacterList>");
                foreach (CharacterOrMonster character in deck.CharacterList)
                {
                    LetsTryWithAStringList.Add("<Monster>");
                    if (character.IsTheWeakestCharacterInHisDeck)
                    {
                        LetsTryWithAStringList.Add("<TheMonsterWithTheLowestPowerLevel>");
                    }
                    if (character.IsTheStrongestCharacterInHisDeck)
                    {
                        LetsTryWithAStringList.Add("<TheMonsterWithTheHighestPowerLevel>");
                    }
                    LetsTryWithAStringList.Add(@$"<ATKPoints>{character.ATKPoints}</ATKPoints>");
                    LetsTryWithAStringList.Add(@$"<DEFPoints>{character.DEFPoints}</DEFPoints>");

                    if (character.IsTheWeakestCharacterInHisDeck)
                    {
                        LetsTryWithAStringList.Add("<Name>Weakest</Name>");
                    }
                    else if (character.IsTheStrongestCharacterInHisDeck)
                    {
                        LetsTryWithAStringList.Add("<Name>Strongest</Name>");
                    }
                    else
                    {
                        LetsTryWithAStringList.Add(@$"<Name>{character.Name}</Name>");
                    }
                    LetsTryWithAStringList.Add(@$"<PowerLevel>{character.PowerLevel}</PowerLevel>");

                    if (character.IsTheWeakestCharacterInHisDeck)
                    {
                        LetsTryWithAStringList.Add("<IsTheStrongestCharacterInHisDeck>False</IsTheStrongestCharacterInHisDeck>");
                        LetsTryWithAStringList.Add("<IsTheWeakestCharacterInHisDeck>True</IsTheWeakestCharacterInHisDeck>");
                    }
                    else if (character.IsTheStrongestCharacterInHisDeck)
                    {
                        LetsTryWithAStringList.Add("<IsTheStrongestCharacterInHisDeck>True</IsTheStrongestCharacterInHisDeck>");
                        LetsTryWithAStringList.Add("<IsTheWeakestCharacterInHisDeck>False</IsTheWeakestCharacterInHisDeck>");
                    }
                    else
                    {
                        LetsTryWithAStringList.Add("<IsTheStrongestCharacterInHisDeck>False</IsTheStrongestCharacterInHisDeck>");
                        LetsTryWithAStringList.Add("<IsTheWeakestCharacterInHisDeck>False</IsTheWeakestCharacterInHisDeck>");
                    }

                    LetsTryWithAStringList.Add(@$"<TheDeckThisGuyBelongsTo>{character.TheDeckThisGuyBelongsTo}</TheDeckThisGuyBelongsTo>");

                    if (character.IsTheWeakestCharacterInHisDeck)
                    {
                        LetsTryWithAStringList.Add("</TheMonsterWithTheLowestPowerLevel>");
                    }
                    else if (character.IsTheStrongestCharacterInHisDeck)
                    {
                        LetsTryWithAStringList.Add("</TheMonsterWithTheHighestPowerLevel>");
                    }
                    else
                    {

                    }
                    LetsTryWithAStringList.Add("</Monster>");
                }

                LetsTryWithAStringList.Add("</CharacterList>");
                LetsTryWithAStringList.Add(@$"</Deck>");
                File.Delete($@"YugiohDBZConverter\{deck.DeckName}.xml");
                File.WriteAllLines($@"YugiohDBZConverter\{deck.DeckName}.xml", LetsTryWithAStringList);
            }

            #endregion

            #region Checking numbers to avoid double code

            static double CheckingNumbers(string AskingForInputMessage, List<double> AlloweedIntegers, string? NonNumberErrorMessage = null, string? UserInput = null, string? NonAllowedNumbersErrorMessage = null, double MaximumAllowedNumber = double.NaN, double MinimumAllowedNumber = double.NaN)
            {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine(AskingForInputMessage);

                UserInput = Console.ReadLine();

                if (UserInput.ToLower() == "m")
                {
                    return double.MaxValue;
                }

                bool IsTheInputANumber = false;
                bool IsTheInputRelevant = false;

                while (!double.TryParse(UserInput, out double d))
                {
                    Console.WriteLine();
                    if (NonNumberErrorMessage == null)
                    {
                        Console.WriteLine("That's not even a number. Input a number out of the number appearing on the screen:");
                    }
                    else
                    {
                        Console.WriteLine(NonNumberErrorMessage);
                    }
                    Console.WriteLine();
                    UserInput = Console.ReadLine();
                    if (UserInput.ToLower() == "m")
                    {
                        return double.MaxValue;
                    }
                }
                IsTheInputANumber = true;
                double UserNumber = double.Parse(UserInput);

                if (AlloweedIntegers.Count > 0)
                {
                    foreach (double OptionalNumber in AlloweedIntegers)
                    {
                        if (OptionalNumber == UserNumber)
                        {
                            IsTheInputRelevant = true;
                        }
                    }

                    while (!IsTheInputRelevant)
                    {

                        Console.WriteLine();
                        if (NonAllowedNumbersErrorMessage == null)
                        {
                            Console.WriteLine("This number isn't among the choices you have. Enter one of the numbers that appear on the screen to choose from:");
                        }
                        else
                        {
                            Console.WriteLine(NonAllowedNumbersErrorMessage);
                        }
                        UserInput = Console.ReadLine();

                        while (!double.TryParse(UserInput, out double d))
                        {
                            if (NonAllowedNumbersErrorMessage == null)
                            {
                                Console.WriteLine("That's not even a number. Input a number out of the number appearing on the screen:");
                            }
                            else
                            {
                                Console.WriteLine(NonAllowedNumbersErrorMessage);
                            }
                            Console.WriteLine();
                            UserInput = Console.ReadLine();
                            if (UserInput.ToLower() == "m")
                            {
                                return double.MaxValue;
                            }
                        }
                        UserNumber = double.Parse(UserInput);

                        foreach (double OptionalNumber in AlloweedIntegers)
                        {
                            if (OptionalNumber == UserNumber)
                            {
                                IsTheInputRelevant = true;
                            }
                        }
                    }
                }

                if (MaximumAllowedNumber != double.NaN)
                {
                    while (UserNumber > MaximumAllowedNumber)
                    {
                        Console.WriteLine("This number is higher than the maximum number allowed. Enter a lower number:");
                        Console.WriteLine();
                        UserInput = Console.ReadLine();
                        while (!double.TryParse(UserInput, out double d))
                        {
                            Console.WriteLine();
                            if (NonNumberErrorMessage == null)
                            {
                                Console.WriteLine("That's not even a number. Input a number out of the number appearing on the screen:");
                            }
                            else
                            {
                                Console.WriteLine(NonNumberErrorMessage);
                            }
                            Console.WriteLine();
                            UserInput = Console.ReadLine();
                            if (UserInput.ToLower() == "m")
                            {
                                return double.MaxValue;
                            }
                        }

                    }

                }

                if (MinimumAllowedNumber != double.NaN)
                {
                    while (UserNumber < MinimumAllowedNumber)
                    {
                        Console.WriteLine();
                        Console.WriteLine($@"This number is lower than the minimum number you can enter, which is {MinimumAllowedNumber}. Enter a higher number:");
                        UserInput = Console.ReadLine();

                        while (!double.TryParse(UserInput, out double d))
                        {
                            Console.WriteLine();
                            if (NonNumberErrorMessage == null)
                            {
                                Console.WriteLine("That's not even a number. Input a number out of the number appearing on the screen:");
                            }
                            else
                            {
                                Console.WriteLine(NonNumberErrorMessage);
                            }
                            Console.WriteLine();
                            UserInput = Console.ReadLine();
                            if (UserInput.ToLower() == "m")
                            {
                                return double.MaxValue;
                            }
                        }
                    }
                }


                return double.Parse(UserInput);

            }

            #endregion

            #region Checking words to avoid double code

            static string CheckingWords(string AskingForInputMessage, List<string> AllowedWords, List<string> NotAllowedWords, string? UserInput = null, string? InvalidInputMessage = null, string? NotAllowedWordMessage = null)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(AskingForInputMessage);
                UserInput = Console.ReadLine();

                if (UserInput.ToLower() == "m")
                {
                    return "m";
                }

                bool IsTheInputRelevant = false;
                bool IsTheInputNotUnAllowed = false;
                bool AreAllWordsAllowedByDefault = false;



                while (!IsTheInputRelevant)
                {
                    if (AllowedWords.Count > 0)
                    {
                        foreach (string AllowedWord in AllowedWords)
                        {
                            if (AllowedWord.ToLower() == UserInput.ToLower())
                            {
                                IsTheInputRelevant = true;
                            }
                        }
                    }
                    else if (AllowedWords.Count == 0)
                    {
                        AreAllWordsAllowedByDefault = true;
                        IsTheInputRelevant = true;
                    }
                    if (NotAllowedWords.Count > 0)
                    {
                        foreach (string NotAllowedWord in NotAllowedWords)
                        {
                            if (NotAllowedWord.ToLower() == UserInput.ToLower())
                            {
                                while (NotAllowedWord.ToLower() == UserInput.ToLower())
                                {
                                    if (NotAllowedWordMessage != null)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(NotAllowedWordMessage);
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("This input isn't allowed. Enter an allowed word:");
                                    }
                                    UserInput = Console.ReadLine();
                                    if (UserInput.ToLower() == "m")
                                    {
                                        return "m";
                                    }
                                }

                            }
                        }
                    }
                    IsTheInputNotUnAllowed = true;
                }
                if (IsTheInputRelevant && IsTheInputNotUnAllowed)
                {
                    return UserInput;
                }
                throw new Exception("The code should not be able to reach this line..");
            }

            #endregion
        }
    }
}