using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NDS_Remake_DinosaurKing.Graphics
{
    public class TextureCollection
    {
        public Texture2D Texture2D;
        public List<Rectangle> Sections;
        public List<Texture2D> Textures;

        public TextureCollection()
        {
            Sections = new List<Rectangle>();
            Textures = new List<Texture2D>();
        }

        public Texture2D Get(int index)
        {
            if (index >= 0 && index < Textures.Count)
            {
                return Textures[index];
            }
            throw new IndexOutOfRangeException();
        }
        
        public Texture2D GetSafe(int index)
        {
            index = Math.Clamp(index, 0, Textures.Count - 1);
            return Textures[index];
        }
        
        public Texture2D GetWrapped(int index)
        {
            index = HxMath.Wrap(index, 0, Textures.Count - 1);
            return Textures[index];
        }
        
        public void Process(GraphicsDevice graphicsDevice, Texture2D texture2D = null)
        {
            if (texture2D == null && Texture2D == null)
            {
                throw new NullReferenceException();
            }
            var texture = texture2D ?? Texture2D;
           
            foreach (var section in Sections)
            {
                var croppedTexture = new Texture2D(graphicsDevice, section.Width, section.Height);
                var data = new Color[section.Width * section.Height];
                texture.GetData(0, section, data, 0, section.Width * section.Height);
                croppedTexture.SetData(data);
                Textures.Add(croppedTexture);
                data = null;
                GC.Collect();
            }
        }
        
        public void SProcess(GraphicsDevice graphicsDevice, Texture2D texture2D = null)
        {
            if (texture2D == null && Texture2D == null)
            {
                throw new NullReferenceException();
            }
            var texture = texture2D ?? Texture2D;
            
            var completeData = new Color[texture.Width * texture.Height];
            texture.GetData(0, texture.Bounds, completeData, 0, texture.Width * texture.Height);
            foreach (var section in Sections)
            {
                var croppedTexture = new Texture2D(graphicsDevice, section.Width, section.Height);
                var data = new Color[section.Width * section.Height];
                for (var y = 0; y < section.Height; y++)
                {
                    Array.Copy(completeData, section.X + texture.Width * (section.Y + y), data, section.Width * y, section.Width);
                }
                croppedTexture.SetData(data);
                Textures.Add(croppedTexture);
                data = null;
                GC.Collect();
            }
            //Sections.Clear();
            completeData = null;
            GC.Collect();
        }
        
    }
}