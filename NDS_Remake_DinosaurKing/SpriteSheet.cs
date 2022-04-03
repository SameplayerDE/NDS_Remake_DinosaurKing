using System.Collections.Generic;

namespace NDS_Remake_DinosaurKing
{
    public abstract class SpriteSheet
    {
        public List<SpriteSheetSection> Sections;

        public int Count => Sections.Count;
        public int MaxIndex => Count - 1;

        public SpriteSheetSection Get(int index)
        {
            return Sections[index];
        }
    }
}