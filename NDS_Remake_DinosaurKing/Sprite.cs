using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NDS_Remake_DinosaurKing
{
    public abstract class Sprite : Entity, IDraw
    {
        public Texture2D Texture2D = null;
        public SpriteSheet SpriteSheet = null;
        public int Index = 0;
        public Color Tint = Color.White;

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Texture2D == null)
            {
                return;
            }

            if (SpriteSheet == null)
            {
                spriteBatch.Draw(Texture2D, Position, Tint);
            }
            else
            {
                spriteBatch.Draw(
                    Texture2D,
                    Position,
                    SpriteSheet.Get(Index).ToRectangle(),
                    Tint,
                    0f,
                    Vector2.Zero, //new Vector2(SpriteSheet.Get(Index).Width / 2, SpriteSheet.Get(Index).Height / 2),
                    1f,
                    SpriteEffects.None,
                    0f
                );
            }
        }
    }

    public interface IDraw
    {
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}