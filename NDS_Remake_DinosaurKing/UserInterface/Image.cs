using Microsoft.Xna.Framework.Graphics;

namespace NDS_Remake_DinosaurKing.UserInterface
{
    public class Image : UserInterfaceElement
    {
        public Texture2D Texture2D;

        public override void Draw(SpriteBatch spriteBatch, float delta)
        {
            if (!IsVisible) return;
            spriteBatch.Draw(
                Texture2D,
                Position.ToPoint().ToVector2(),
                null,
                Tint * Alpha,
                Rotation,
                Origin, 
                Scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}