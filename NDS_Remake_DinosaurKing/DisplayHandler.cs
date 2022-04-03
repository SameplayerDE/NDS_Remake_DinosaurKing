using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace NDS_Remake_DinosaurKing
{
    public static class DisplayHandler
    {
        public static Dictionary<string, Display> Displays;
        public static GraphicsDevice GraphicsDevice;

        static DisplayHandler()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            Displays = new Dictionary<string, Display>();
        }

        public static Display Get(string key)
        {
            return Displays[key];
        }

        public static void SetGraphicsDevice(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        public static Display Create(string key, int width, int height)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new Display
            {
                Width = width,
                Height = height,
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                RenderTarget2D = new RenderTarget2D(GraphicsDevice, width, height)
            };
            Displays.Add(key, result);
            return result;
        }
        
    }
}