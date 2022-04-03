using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace NDS_Remake_DinosaurKing.Data
{
    public static class AssetHandler
    {
        private static Dictionary<string, Texture2D> _textures;
        private static Dictionary<string, Effect> _effects;

        static AssetHandler()
        {
            _textures = new Dictionary<string, Texture2D>();
            _effects = new Dictionary<string, Effect>();
        }

        private static void Add(string key, Texture2D texture2D)
        {
            _textures.Add(key, texture2D);
        }

        private static void Add(string key, Effect effect)
        {
            _effects.Add(key, effect);
        }

        public static void LoadAssets(ContentManager contentManager)
        {
            Add("p_w", HxGraphics.Graphics.Instance.GenerateTexture2D(1, 1, Color.White));
            Add("d_w", HxGraphics.Graphics.Instance.GenerateTexture2D(256, 192, Color.White));
            Add("c_w", HxGraphics.Graphics.Instance.GenerateTexture2D(256, 384, Color.White));
            
            Add("splash_top", contentManager.Load<Texture2D>("Splash_Top"));
            Add("splash_bottom", contentManager.Load<Texture2D>("Splash_Bottom"));
            Add("title_top", contentManager.Load<Texture2D>("Logo"));
            Add("title_top_background", contentManager.Load<Texture2D>("Titel_Top_Background"));
            Add("title_bottom_background", contentManager.Load<Texture2D>("Titel_Bottom_Background"));
            Add("frame_complete", contentManager.Load<Texture2D>("Frame_Complete"));
        }

        public static Texture2D Get(string key)
        {
            return _textures[key];
        }
    }
}