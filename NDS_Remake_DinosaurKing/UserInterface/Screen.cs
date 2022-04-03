using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NDS_Remake_DinosaurKing.Data;

namespace NDS_Remake_DinosaurKing.UserInterface
{
    public abstract class Screen
    {

        // ReSharper disable once HeapView.ObjectAllocation.Evident
        private readonly List<UserInterfaceElement> _elements = new List<UserInterfaceElement>();
        
        public Color BackgroundColorTop = Color.Transparent;
        public Color BackgroundColorBottom = Color.Transparent;
        public Texture2D BackgroundImageTop = null;
        public Texture2D BackgroundImageBottom = null;
        public Color BackgroundImageTintTop = Color.Transparent;
        public Color BackgroundImageTintBottom = Color.Transparent;

        public void Add(UserInterfaceElement element)
        {
            //_elements.Add(element);
        }

        public virtual void Update(float delta)
        {
            foreach (var element in _elements)
            {
                element.Update(delta);
            }
        }
        
        public virtual void Draw(SpriteBatch spriteBatch, float delta)
        {
            spriteBatch.Draw(AssetHandler.Get("p_w"), new Rectangle(0, 0, 256, 192), BackgroundColorTop);
            spriteBatch.Draw(AssetHandler.Get("p_w"), new Rectangle(0, 192, 256, 192), BackgroundColorBottom);
            foreach (var element in _elements)
            {
                element.Draw(spriteBatch, delta);
            }
        }
    }
}