using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NDS_Remake_DinosaurKing.Data;
using NDS_Remake_DinosaurKing.UserInterface.Screens;

namespace NDS_Remake_DinosaurKing
{
    public class DinosaurKing : Game
    {

        public static DinosaurKing Instance;
        
        public readonly string Version = "0.0.0";
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;

        private int _scale = 2;
        
        public DinosaurKing()
        {
            Content.RootDirectory = "Content";
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            _graphicsDeviceManager.PreferredBackBufferWidth = 256 * _scale;
            _graphicsDeviceManager.PreferredBackBufferHeight = 192 * 2 * _scale;
            _graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;
            TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 60L);
            IsFixedTimeStep = true;
            _graphicsDeviceManager.ApplyChanges();

            Instance = this;
            
            HxGraphics.Graphics.Instance.SetGraphicsDeviceManager(_graphicsDeviceManager);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            AssetHandler.LoadAssets(Content);

            ScreenHandler.Push(SplashScreen.Create());

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            HxTime.Update(gameTime);
            InputHandler.Update(gameTime);
            ScreenHandler.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Matrix.CreateScale(_scale));
            ScreenHandler.Draw(_spriteBatch, HxTime.DeltaF);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}