using System;
using HxTiled.Tiled;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NDS_Remake_DinosaurKing.Data;
using NDS_Remake_DinosaurKing.Graphics;
using NDS_Remake_DinosaurKing.Humans;
using NDS_Remake_DinosaurKing.SpriteSheets;
using TextureCollection = NDS_Remake_DinosaurKing.Graphics.TextureCollection;

namespace NDS_Remake_DinosaurKing
{
    public class d : Game
    {

        public static d Instance;
        
        public readonly string Version = "0.0.0";
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;

        private Camera2D _camera;
        
        private RenderTarget2D _top;
        private RenderTarget2D _bottom;

        private int _scale = 2;

        //TODO: Temp
        private Texture2D _texture000;
        private Texture2D _texture001;
        private Player _player;

        private TextureCollection _allPortraits;
        
        private int selection = 1;

        private SimulationArea _area;

        public d()
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

            _area = new SimulationArea();
            var tilemap = SimulationAreaLoader.LoadFromJson(@"Content\Areas\D_Lab.json");
            _area.TileMap = TileMap.FromTileMapFile(tilemap);

            SimulationHandler.SimulationArea = _area;
            
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _top = new RenderTarget2D(GraphicsDevice, 256, 192);
            _bottom = new RenderTarget2D(GraphicsDevice, 256, 192);
            
            DisplayHandler.SetGraphicsDevice(GraphicsDevice);

            DisplayHandler.Create("top", 256, 192);
            DisplayHandler.Create("bottom", 256, 192);
            
            AssetHandler.LoadAssets(Content);
            ScreenHandler.PrepareScreens();
            
            //ScreenHandler.Push("splash");
            
            _texture000 = Content.Load<Texture2D>("d_team_overworld");
            _texture001 = Content.Load<Texture2D>("africa_lab");
            
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _camera = new Camera2D();

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _player = new Player()
            {
                Texture2D = _texture000,
                SpriteSheet = selection == 0 ? MaxSpriteSheet.Instance : RexSpriteSheet.Instance
            };

            _allPortraits = new TextureCollection();
            var c = new[]
            {
                7, 7, 6, 7, 4, 4, 4, 4, 4, 7, 7, 6, 6, 6, 7, 9, 9, 9, 9, 9
            };
            for (var y = 0; y < c.Length; y++)
            {
                for (var i = 0; i < c[y]; i++)
                {
                    _allPortraits.Sections.Add(new Rectangle(128 * i, 128 * y, 128, 128));
                }
            }

            _allPortraits.SProcess(GraphicsDevice, Content.Load<Texture2D>("All"));
            
            _area.TileMap.LoadTileSets(GraphicsDevice);
            _area.Add(_player);
            
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            HxTime.Update(gameTime);
            InputHandler.Update(gameTime);
            SimulationHandler.Update(gameTime);

            //_player.Update(gameTime);
            //_camera.Position = _player.Position - new Vector2(256, 192) / 2;
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin(transformMatrix: Matrix.CreateTranslation(new Vector3(-_camera.Position, 0)));
            _spriteBatch.Draw(_texture001, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_allPortraits.GetWrapped((int)(gameTime.TotalGameTime.TotalSeconds * 4)), Vector2.Zero,
                Color.White);
            
            _area.TileMap.Draw(_spriteBatch, gameTime, Vector2.Zero);
            _player.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();
            
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Matrix.CreateScale(_scale));
            ScreenHandler.Draw(_spriteBatch, HxTime.DeltaF);
            _spriteBatch.End();
            
            /*_spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Matrix.CreateScale(_scale));
            _spriteBatch.Draw(DisplayHandler.Get("top").RenderTarget2D, Vector2.Zero, Color.White);
            _spriteBatch.Draw(DisplayHandler.Get("bottom").RenderTarget2D, new Vector2(0, 192), Color.White);
            _spriteBatch.End();*/

            base.Draw(gameTime);
        }
    }
}