namespace AR_Map_Viewer.Class
{
    enum eLocationType
    {
        City, Inn, Tavern, Bank, Shop, Smith, Special, Healer, Guild, Combat
    }

    class Player
    {
        public int Heading { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        #region Unused
        public int Z { get; set; } // Always 0 in the City, 1 for Dungeon Level 1, 2 for Dungeon Level 2, etc.

        public int Xprevious { get; set; }
        public int Yprevious { get; set; }
        public int Zprevious { get; set; }

        public decimal Xpartial { get; set; }
        public decimal Ypartial { get; set; }

        public decimal XpartialPrevious { get; set; }
        public decimal YpartialPrevious { get; set; }

        public eLocationType LocationType  { get; set; }
        public eLocationType LocationTypePrevious  { get; set; }

        public byte WalkingSpeed { get; set; } // 0 - 36

        public byte SlotNumber { get; set; } // For Save 0-8 or FF for temporary
        #endregion
    }
}