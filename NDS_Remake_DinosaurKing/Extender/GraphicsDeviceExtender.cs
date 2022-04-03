using Microsoft.Xna.Framework.Graphics;

namespace NDS_Remake_DinosaurKing.Extender
{
    public static class GraphicsDeviceExtender
    {
        public static void SetDisplay(this GraphicsDevice graphicsDevice, Display display)
        {
            graphicsDevice.SetRenderTarget(display?.RenderTarget2D);
        }
    }
}