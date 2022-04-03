using Microsoft.Xna.Framework;

namespace NDS_Remake_DinosaurKing
{
    public static class HxTime
    {
        private static float _deltaF = 0f;
        public static float DeltaF => _deltaF;
        
        public static void Update(GameTime gameTime)
        {
            _deltaF = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}