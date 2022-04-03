using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NDS_Remake_DinosaurKing.UserInterface.Animations;

namespace NDS_Remake_DinosaurKing.UserInterface
{
    public abstract class UserInterfaceElement
    {
        // ReSharper disable once HeapView.ObjectAllocation.Evident
        private readonly List<Animation> _animations = new List<Animation>();
        public Color Tint = Color.White;
        public float Alpha = 1f;
        public float Rotation = 0f;
        public Vector2 Scale = Vector2.One;
        public Vector2 Origin = Vector2.Zero;
        public Vector2 Position = Vector2.Zero;
        public Rectangle InteractionArea = Rectangle.Empty;
        public bool IsVisible = true;

        public void Add(Animation animation)
        {
            animation.Element = this;
            _animations.Add(animation);
        }
        
        public virtual void Update(float delta)
        {
            foreach (var animation in _animations)
            {
                animation.Update(delta);
            }
        }
        
        public virtual void Draw(SpriteBatch spriteBatch, float delta)
        {
            
        }
    }
}