using Microsoft.Xna.Framework;

namespace NDS_Remake_DinosaurKing
{
    public struct SpriteSheetSection
    {
        public int X, Y, Width, Height;

        public SpriteSheetSection(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }
        
    }
}