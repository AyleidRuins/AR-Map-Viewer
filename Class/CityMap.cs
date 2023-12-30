using System.Collections.Generic;

namespace AR_Map_Viewer.Class
{
    class CityMap
    {
        public byte[,] location = new byte[64, 64];
        public Dictionary<int, LocationStruct> mapDescription = new Dictionary<int, LocationStruct>();

        public enum eLocationType
        {
            City, Inn, Tavern, Bank, Shop, Smith, Special, Healer, Guild, Combat
        }

        public struct LocationStruct
        {
            public string LocationDescription;
            public eLocationType LocationType;
        }

        public CityMap()
        {
            for (int N = 0; N <= 63; N++)
            {
                for (int E = 0; E <= 63; E++)
                {
                    location[E, N] = 255;
                }
            }

            location[35, 27] = 76; // Floating Gate - this is the starting point

            #region Inns - There are 7 inns in total
            mapDescription.Add(0, new LocationStruct { LocationDescription = "Green Boar Inn", LocationType = eLocationType.Inn });
            mapDescription.Add(1, new LocationStruct { LocationDescription = "Lazy Griffin Inn", LocationType = eLocationType.Inn });
            mapDescription.Add(2, new LocationStruct { LocationDescription = "Sleeping Dragon Inn", LocationType = eLocationType.Inn });
            mapDescription.Add(3, new LocationStruct { LocationDescription = "Traveller's Inn", LocationType = eLocationType.Inn });
            mapDescription.Add(4, new LocationStruct { LocationDescription = "Midnight Inn", LocationType = eLocationType.Inn });
            mapDescription.Add(5, new LocationStruct { LocationDescription = "Warrior's Retreat Inn", LocationType = eLocationType.Inn });
            mapDescription.Add(6, new LocationStruct { LocationDescription = "Royal Resort Inn", LocationType = eLocationType.Inn });
            location[9, 19] = 0;
            location[10, 19] = 0;
            location[8, 19] = 0;
            location[8, 18] = 0;

            location[33, 52] = 1;
            location[33, 51] = 1;

            location[60, 6] = 2;
            location[59, 6] = 2;

            location[31, 25] = 3;
            location[31, 24] = 3;
            location[32, 24] = 3;

            location[32, 23] = 4;
            location[33, 23] = 4;
            location[31, 23] = 4;
            location[31, 22] = 4;

            location[28, 54] = 5;

            location[31, 4] = 6;
            location[31, 3] = 6;
            #endregion

            #region Taverns - There are 14 taverns in total
            mapDescription.Add(7, new LocationStruct { LocationDescription = "Flaming Dragon Tavern", LocationType = eLocationType.Tavern });
            location[60, 2] = 7;

            mapDescription.Add(8, new LocationStruct { LocationDescription = "Misty Mountain Tavern", LocationType = eLocationType.Tavern });
            location[1, 54] = 8;

            mapDescription.Add(9, new LocationStruct { LocationDescription = "Screaming Siren Bar", LocationType = eLocationType.Tavern });
            location[44, 9] = 9;

            mapDescription.Add(10, new LocationStruct { LocationDescription = "Happy Hunter Rest Stop", LocationType = eLocationType.Tavern });
            location[7, 24] = 10;
            location[8, 24] = 10;
            location[9, 24] = 10;
            location[10, 24] = 10;

            mapDescription.Add(11, new LocationStruct { LocationDescription = "Dancing Nymph Tavern", LocationType = eLocationType.Tavern });
            location[41, 34] = 11;

            mapDescription.Add(12, new LocationStruct { LocationDescription = "The Club", LocationType = eLocationType.Tavern });
            location[33, 53] = 12;
            location[33, 54] = 12;

            mapDescription.Add(13, new LocationStruct { LocationDescription = "Black Devil Tavern", LocationType = eLocationType.Tavern });
            location[32, 19] = 13;
            location[33, 19] = 13;
            location[31, 19] = 13;
            location[31, 20] = 13;
            mapDescription.Add(14, new LocationStruct { LocationDescription = "(Lost Oasis) Tavern", LocationType = eLocationType.Tavern });
            location[20, 62] = 14;

            mapDescription.Add(15, new LocationStruct { LocationDescription = "Last Stop", LocationType = eLocationType.Tavern });
            location[52, 56] = 15;

            mapDescription.Add(16, new LocationStruct { LocationDescription = "Tail of the Dog Tavern", LocationType = eLocationType.Tavern });
            location[39, 29] = 16;
            location[39, 30] = 16;

            mapDescription.Add(17, new LocationStruct { LocationDescription = "Club Babylon", LocationType = eLocationType.Tavern });
            location[57, 33] = 17;
            mapDescription.Add(18, new LocationStruct { LocationDescription = "Lost Tears Tavern", LocationType = eLocationType.Tavern });
            location[13, 12] = 18;

            mapDescription.Add(19, new LocationStruct { LocationDescription = "Mom's Bar", LocationType = eLocationType.Tavern });
            location[5, 35] = 19;
            location[6, 35] = 19;

            mapDescription.Add(20, new LocationStruct { LocationDescription = "Lusty Lloyds Tavern", LocationType = eLocationType.Tavern });
            location[60, 30] = 20;
            location[60, 29] = 20;
            #endregion

            #region Banks - There are 3 banks in total
            mapDescription.Add(21, new LocationStruct { LocationDescription = "First City Bank", LocationType = eLocationType.Bank });
            location[30, 6] = 21;
            mapDescription.Add(22, new LocationStruct { LocationDescription = "Granite Bank", LocationType = eLocationType.Bank });
            location[38, 27] = 22;
            mapDescription.Add(23, new LocationStruct { LocationDescription = "Gram's Gold Exchange", LocationType = eLocationType.Bank });
            location[2, 61] = 23;
            #endregion

            #region Shops - There are 15 shops in total (1 more than the original game)
            mapDescription.Add(24, new LocationStruct { LocationDescription = "Smiley's Shop", LocationType = eLocationType.Shop });
            mapDescription.Add(25, new LocationStruct { LocationDescription = "Honest Trader", LocationType = eLocationType.Shop });
            mapDescription.Add(26, new LocationStruct { LocationDescription = "Adventurer's Outfitters", LocationType = eLocationType.Shop });
            mapDescription.Add(27, new LocationStruct { LocationDescription = "Warrior's Supplies", LocationType = eLocationType.Shop });
            mapDescription.Add(28, new LocationStruct { LocationDescription = "General Store", LocationType = eLocationType.Shop });
            mapDescription.Add(29, new LocationStruct { LocationDescription = "Exclusive Outfitters", LocationType = eLocationType.Shop });
            mapDescription.Add(30, new LocationStruct { LocationDescription = "Rocky's Emporium", LocationType = eLocationType.Shop });
            mapDescription.Add(31, new LocationStruct { LocationDescription = "Best Bargain Store", LocationType = eLocationType.Shop });
            mapDescription.Add(32, new LocationStruct { LocationDescription = "Special Imports Store", LocationType = eLocationType.Shop });
            mapDescription.Add(33, new LocationStruct { LocationDescription = "Betelgeuse Sales", LocationType = eLocationType.Shop });
            mapDescription.Add(34, new LocationStruct { LocationDescription = "Merchant's Grotto", LocationType = eLocationType.Shop });
            mapDescription.Add(35, new LocationStruct { LocationDescription = "Sunset Market", LocationType = eLocationType.Shop });
            mapDescription.Add(36, new LocationStruct { LocationDescription = "Pauline's Emporium", LocationType = eLocationType.Shop });
            mapDescription.Add(37, new LocationStruct { LocationDescription = "Da Place!", LocationType = eLocationType.Shop });
            mapDescription.Add(38, new LocationStruct { LocationDescription = "Trade Winds", LocationType = eLocationType.Shop });

            location[25, 15] = 24;
            location[35, 24] = 25;

            location[60, 61] = 37; // Da Place
            location[19, 5] = 38; // Trade Winds - Now added to the game :)

            location[52, 9] = 34; // Merchant's Grotto
            location[52, 8] = 34;
            location[51, 9] = 34;
            location[50, 9] = 34;
            location[50, 8] = 34;

            location[55, 18] = 28; // General Store
            location[56, 18] = 28;
            location[54, 18] = 28;
            location[53, 18] = 28;
            location[52, 18] = 28;

            location[3, 12] = 26; // Adventurers Outfitters

            location[0, 13] = 32; // Special Imports Store

            location[35, 30] = 31;

            location[46, 37] = 36; // Pauline's Emporium
            location[46, 36] = 36;
            location[47, 36] = 36; location[48, 36] = 36;

            location[26, 59] = 27;

            location[33, 56] = 35;
            location[33, 55] = 35;

            location[37, 56] = 33;
            location[38, 56] = 33;

            location[9, 37] = 30; // Rocky's Emporium
            location[8, 37] = 30; location[10, 37] = 30;
            location[7, 37] = 30; location[11, 37] = 30;
            location[7, 38] = 30; location[11, 38] = 30;
            location[7, 39] = 30; location[11, 39] = 30;
            location[8, 39] = 30; location[10, 39] = 30;
            location[8, 40] = 30; location[10, 40] = 30;

            location[21, 43] = 29; // Exclusive Outfitters
            location[20, 43] = 29; location[19, 43] = 29;
            location[22, 43] = 29;
            #endregion

            #region Smithies - There are 4 smithies in total
            mapDescription.Add(39, new LocationStruct { LocationDescription = "Sharp Weaponsmiths", LocationType = eLocationType.Smith });
            location[54, 9] = 39;
            location[54, 10] = 39;
            location[53, 10] = 39;

            mapDescription.Add(40, new LocationStruct { LocationDescription = "Occum's Weaponsmiths", LocationType = eLocationType.Smith });
            location[19, 32] = 40;

            mapDescription.Add(41, new LocationStruct { LocationDescription = "Best Armorers", LocationType = eLocationType.Smith });
            location[32, 27] = 41;

            mapDescription.Add(42, new LocationStruct { LocationDescription = "Knight's Armorers", LocationType = eLocationType.Smith });
            location[50, 35] = 42;
            #endregion

            #region Scenarios - There are 7 Scenarios in total
            mapDescription.Add(43, new LocationStruct { LocationDescription = "House of Ill Repute (QUARANTINED!)", LocationType = eLocationType.Special });
            location[42, 35] = 43; location[42, 36] = 43; location[42, 37] = 43;
            location[41, 37] = 43; location[43, 37] = 43; location[43, 36] = 43;


            mapDescription.Add(44, new LocationStruct { LocationDescription = "Armstrong Builders (Closed by Order of the Palace)", LocationType = eLocationType.Special }); // // Replacement for duplicate single tile 53 SE of the Arena. Resolves comment: Near the Arena, #53 is marked as Scenario, is not accessible and already exists elsewhere. This location replaces 'Armstrong Builders (Closed by Order of the Palace)'.
            location[25, 50] = 44; // was unreachable 53

            mapDescription.Add(45, new LocationStruct { LocationDescription = "Apollo Trainers (Closed by Order of the Palace)", LocationType = eLocationType.Special });// Resolves: Near the Arena, #54 is marked as Scenario, is not accessible and already exists elsewhere. This location replaces 'Apollo Trainers (Closed by Order of the Palace)'.
            location[26, 47] = 45; // was unreachable 54
            location[26, 46] = 45; // was unreachable 54

            #region Arena
            mapDescription.Add(46, new LocationStruct { LocationDescription = "Arena (Arena)", LocationType = eLocationType.Special });
            for (int E = 9; E <= 23; E++)
            {
                location[E, 60] = 46;
            }

            for (int E = 6; E <= 24; E++)
            {
                for (int N = 57; N <= 59; N++)
                {
                    location[E, N] = 46;
                    location[E, N - 5] = 46;
                }
            }

            for (int E = 7; E <= 24; E++)
            {
                for (int N = 55; N <= 56; N++)
                {
                    location[E, N] = 46;
                }
            }

            for (int E = 9; E <= 15; E++)
            {
                location[E, 51] = 46;
            }

            for (int E = 17; E <= 23; E++)
            {
                location[E, 51] = 46;
            }
            location[13, 50] = 46; location[14, 50] = 46; location[14, 49] = 46;
            location[18, 50] = 46; location[19, 50] = 46; location[18, 49] = 46;
            #endregion

            #region Palace
            mapDescription.Add(47, new LocationStruct { LocationDescription = "Palace (Palace)", LocationType = eLocationType.Special });
            for (int E = 54; E <= 62; E++)
            {
                for (int N = 39; N <= 46; N++)
                {
                    location[E, N] = 47;
                }
            }
            for (int E = 53; E <= 62; E++)
            {
                for (int N = 36; N <= 37; N++)
                {
                    location[E, N] = 47;
                }
            }
            location[53, 47] = 47; location[53, 46] = 47; location[53, 45] = 47;
            location[52, 46] = 47;

            location[52, 36] = 47;
            location[53, 35] = 47;

            location[62, 35] = 47;
            location[62, 38] = 47;
            location[62, 47] = 47;

            location[60, 38] = 47;
            location[61, 38] = 47;
            #endregion

            mapDescription.Add(48, new LocationStruct { LocationDescription = "Palace Gates (Palace)", LocationType = eLocationType.Special });
            location[61, 42] = 48;

            mapDescription.Add(49, new LocationStruct { LocationDescription = "Dungeon Entrance (Dungeon)", LocationType = eLocationType.Special });
            location[59, 1] = 49;
            location[50, 60] = 49;

            mapDescription.Add(50, new LocationStruct { LocationDescription = "Maximum Casino (Closed by Order of the Palace)", LocationType = eLocationType.Special });
            location[39, 36] = 50;
            location[39, 35] = 50; location[40, 35] = 50;
            location[39, 34] = 50; location[40, 34] = 50;

            mapDescription.Add(51, new LocationStruct { LocationDescription = "Davids Weapons Trainers (Closed by Order of the Palace)", LocationType = eLocationType.Special });
            location[21, 47] = 51; // was unreachable 57
            location[22, 48] = 51;
            location[22, 47] = 51;
            location[22, 46] = 51;
            location[23, 47] = 51;

            mapDescription.Add(52, new LocationStruct { LocationDescription = "Jack's Fitness Academy (Closed due to Chapter VII of the Bankruptcy Laws)", LocationType = eLocationType.Special });
            location[54, 4] = 52;

            mapDescription.Add(67, new LocationStruct { LocationDescription = "Grogs Weapons Trainers", LocationType = eLocationType.Special });
            location[60, 54] = 67; // Newly added to the game :)

            mapDescription.Add(68, new LocationStruct { LocationDescription = "Flash Weapons Trainers", LocationType = eLocationType.Special });
            location[23, 38] = 68; // Newly added to the game :)
            #endregion

            #region Healers - There are 2 healers in total
            mapDescription.Add(53, new LocationStruct { LocationDescription = "One Way Soothers", LocationType = eLocationType.Healer });
            mapDescription.Add(54, new LocationStruct { LocationDescription = "Alpha Omega Healers", LocationType = eLocationType.Healer });
            location[29, 29] = 53; location[28, 29] = 53; location[30, 29] = 53;
            location[29, 28] = 53; location[28, 28] = 53; location[30, 28] = 53;
            location[29, 27] = 53; location[28, 27] = 53; location[30, 27] = 53;

            location[4, 19] = 54; location[3, 19] = 54; location[5, 19] = 54;
            location[4, 18] = 54; location[3, 18] = 54; location[5, 18] = 54;
            location[4, 17] = 54; location[3, 17] = 54; location[5, 17] = 54;
            #endregion

            #region Guilds - There are 12 guilds in total
            mapDescription.Add(55, new LocationStruct { LocationDescription = "Thieves' Guild", LocationType = eLocationType.Guild });
            mapDescription.Add(56, new LocationStruct { LocationDescription = "Blue Wizards' Guild", LocationType = eLocationType.Guild });
            mapDescription.Add(57, new LocationStruct { LocationDescription = "Light Wizards' Guild", LocationType = eLocationType.Guild });
            mapDescription.Add(58, new LocationStruct { LocationDescription = "Green Wizards' Academy", LocationType = eLocationType.Guild });
            mapDescription.Add(59, new LocationStruct { LocationDescription = "Red Wizards' University", LocationType = eLocationType.Guild });
            mapDescription.Add(60, new LocationStruct { LocationDescription = "Dark Wizards' Guild", LocationType = eLocationType.Guild });
            mapDescription.Add(61, new LocationStruct { LocationDescription = "Star Wizards' Guild", LocationType = eLocationType.Guild });
            mapDescription.Add(62, new LocationStruct { LocationDescription = "Wizards' of Chaos", LocationType = eLocationType.Guild });
            mapDescription.Add(63, new LocationStruct { LocationDescription = "Wizards of Law", LocationType = eLocationType.Guild });
            mapDescription.Add(64, new LocationStruct { LocationDescription = "Guild of Order", LocationType = eLocationType.Guild });
            mapDescription.Add(65, new LocationStruct { LocationDescription = "Physicians' Guild", LocationType = eLocationType.Guild });
            mapDescription.Add(66, new LocationStruct { LocationDescription = "Assassins' Guild", LocationType = eLocationType.Guild });

            location[43, 34] = 55; location[44, 34] = 55; location[45, 34] = 55; location[44, 33] = 55; location[43, 35] = 55; location[44, 35] = 55; location[44, 36] = 55;
            location[18, 47] = 56;
            location[2, 4] = 57;

            location[11, 42] = 58; location[10, 42] = 58; location[12, 42] = 58; location[12, 41] = 58; location[13, 42] = 58; location[13, 43] = 58; location[13, 44] = 58;
            location[25, 44] = 58; location[25, 43] = 58; location[24, 43] = 58; location[23, 43] = 58;

            location[47, 14] = 59; location[48, 14] = 59; location[49, 14] = 59; location[49, 16] = 59; location[50, 16] = 59; location[50, 15] = 59; location[47 + 2, 14 + 1] = 59;

            location[33, 21] = 60; location[33, 20] = 60; location[33, 22] = 60;
            location[27, 11] = 61;
            location[50, 59] = 62;
            location[61, 49] = 63;
            location[57, 49] = 64;
            location[5, 14] = 65; location[32, 56] = 65; location[32, 55] = 65; // Physician's Guild
            location[55, 2] = 66; // Assassin's Guild
            #endregion

            #region Removed Location Type ?
            mapDescription.Add(69, new LocationStruct { LocationDescription = "Acrinimirils Gate", LocationType = eLocationType.Special });
            location[31, 36] = 69;

            mapDescription.Add(70, new LocationStruct { LocationDescription = "Mystery New Location Type 4", LocationType = eLocationType.Guild });
            mapDescription.Add(71, new LocationStruct { LocationDescription = "Mystery New Location Type 5", LocationType = eLocationType.Guild });
            mapDescription.Add(72, new LocationStruct { LocationDescription = "Mystery New Location Type 6", LocationType = eLocationType.Guild });
            #endregion

            #region Gates - There are 3 gates in total
            mapDescription.Add(73, new LocationStruct { LocationDescription = "Southern Gate (Wilderness)", LocationType = eLocationType.Special });
            location[35, 0] = 73;

            mapDescription.Add(74, new LocationStruct { LocationDescription = "Northern Gate (Wilderness)", LocationType = eLocationType.Special });
            location[35, 63] = 74;

            mapDescription.Add(75, new LocationStruct { LocationDescription = "Western Gate (Wilderness)", LocationType = eLocationType.Special });
            location[0, 27] = 75;
            #endregion

            mapDescription.Add(76, new LocationStruct { LocationDescription = "Floating Gate", LocationType = eLocationType.City });
        }
    }
}