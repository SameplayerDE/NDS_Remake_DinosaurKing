using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NDS_Remake_DinosaurKing.Data;

namespace NDS_Remake_DinosaurKing.UserInterface.Screens
{
    public class SaveSelectionScreen : Screen
    {
        public Image Image0;
        public Image Image1;
        
        public Image Image2;


        public SaveSelectionScreen()
        {

        }

        public override void Update(float delta)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, float delta)
        {
            base.Draw(spriteBatch, delta);
            Image0.Draw(spriteBatch, delta);
            Image1.Draw(spriteBatch, delta);
            Image2.Draw(spriteBatch, delta);
        }

        private void Reset()
        {
            
        }
        
        public static Screen Create()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new SaveSelectionScreen
            {
                BackgroundColorTop = Color.White,
                BackgroundColorBottom = Color.White,
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                Image0 = new Image
                {
                    Texture2D = AssetHandler.Get("title_top_background")
                },
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                Image1 = new Image
                {
                    Texture2D = AssetHandler.Get("title_top")
                }, // ReSharper disable once HeapView.ObjectAllocation.Evident
                Image2 = new Image
                {
                    Texture2D = AssetHandler.Get("title_bottom_background"),
                    Alpha = 0f,
                    Position = new Vector2(0, 192)
                }
            };
            return result;
        }
    }
}