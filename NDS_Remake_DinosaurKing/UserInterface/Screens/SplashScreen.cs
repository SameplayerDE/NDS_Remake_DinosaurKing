using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NDS_Remake_DinosaurKing.Data;

namespace NDS_Remake_DinosaurKing.UserInterface.Screens
{
    public class SplashScreen : Screen
    {
        public Image Image0;
        public Image Image1;
        public Timer FadeIn;
        public Timer FadeOut;
        public Timer Stay;
        public Timer Start;
        public Timer End;

        public SplashScreen()
        {
            FadeIn = new Timer() { Duration = 1000 };
            FadeOut = new Timer() { Duration = 1000 };
            Stay = new Timer() { Duration = 4000 };
            Start = new Timer() { Duration = 1000 };
            End = new Timer() { Duration = 1000 };
            InputHandler.Disable();
        }

        public override void Update(float delta)
        {
            if (Start.Finished)
            {
                if (FadeIn.Finished)
                {
                    if (Stay.Finished)
                    {
                        if (!FadeOut.Finished)
                        {
                            Image0.Alpha -= 1000f / FadeOut.Duration * delta;
                            Image1.Alpha -= 1000f / FadeOut.Duration * delta;
                        }
                        else
                        {
                            if (End.Finished)
                            {
                                Reset();
                                ScreenHandler.RequestPop();
                                ScreenHandler.RequestPush(TitleScreen.Create());
                            }
                            End.Update(delta);
                        }
                        FadeOut.Update(delta);
                    }

                    Stay.Update(delta);
                }
                else
                {
                    Image0.Alpha += 1000f / FadeIn.Duration * delta;
                    Image1.Alpha += 1000f / FadeIn.Duration * delta;
                }

                FadeIn.Update(delta);
            }
            Start.Update(delta);
        }

        public override void Draw(SpriteBatch spriteBatch, float delta)
        {
            base.Draw(spriteBatch, delta);
            Image0.Draw(spriteBatch, delta);
            Image1.Draw(spriteBatch, delta);
        }

        private void Reset()
        {
            Image0.Alpha = 0f;
            Image1.Alpha = 0f;
            FadeIn.Reset();
            FadeOut.Reset();
            Stay.Reset();
        }
        
        public static Screen Create()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new SplashScreen
            {
                BackgroundColorTop = Color.White,
                BackgroundColorBottom = Color.White,
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                Image0 = new Image
                {
                    Texture2D = AssetHandler.Get("splash_top"),
                    Alpha = 0f
                },
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                Image1 = new Image
                {
                    Texture2D = AssetHandler.Get("splash_bottom"),
                    Alpha = 0f,
                    Position = new Vector2(0, 192)
                }
            };
            return result;
        }
    }
}