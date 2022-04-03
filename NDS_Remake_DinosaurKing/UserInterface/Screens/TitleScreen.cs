using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NDS_Remake_DinosaurKing.Data;

namespace NDS_Remake_DinosaurKing.UserInterface.Screens
{
    public class TitleScreen : Screen
    {
        public Image Image0;
        public Image Image1;
        
        public Image Image2;
        public Image Image3;
        
        public Timer FadeIn;
        public Timer Start;
        public Timer Switch;

        public bool Intro = true;
        public bool Pressed = false;

        public TitleScreen()
        {
            FadeIn = new Timer() { Duration = 3000 };
            Start = new Timer() { Duration = 500 };
            Switch = new Timer() { Duration = 250 };
        }

        public override void Update(float delta)
        {
            if (Start.Finished)
            {
                if (FadeIn.Finished)
                {
                    //TODO: Logo Animation
                    if (!Image1.IsVisible)
                    {
                        Image1.IsVisible = true;
                    }

                    //
                    /*if (!Intro)
                    {
                        if (Pressed)
                        {
                            if (Switch.Finished)
                            {
                                Image3.Alpha += 1000f / Switch.Duration * delta;
                                if ((int)Image3.Alpha == 1)
                                {
                                    if (InputHandler.IsA)
                                    {
                                        Pressed = false;
                                    }
                                }
                            }
                            else
                            {
                                Image2.Alpha -= 1000f / Switch.Duration * delta;
                            }

                            Switch.Update(delta);
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        if (InputHandler.IsA)
                        {
                            if (!Pressed)
                            {
                                Intro = false;
                                Pressed = true;
                            }
                            //ScreenHandler.RequestPop();
                            //ScreenHandler.RequestPush("save_selection");
                            //ScreenHandler.RequestPush(SaveSelectionScreen.Create());
                        }
                    }*/
                    if (InputHandler.IsA)
                    {
                        ScreenHandler.RequestPop();
                    }
                }
                else
                {
                    Image0.Alpha += 1000f / FadeIn.Duration * delta;
                    Image2.Alpha += 1000f / FadeIn.Duration * delta;
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
            Image2.Draw(spriteBatch, delta);
            Image3.Draw(spriteBatch, delta);
        }

        private void Reset()
        {
            Image0.Alpha = 0f;
            Image1.Alpha = 0f;
            Image2.Alpha = 0f;
            Image3.Alpha = 0f;
            FadeIn.Reset();
        }
        
        public static Screen Create()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var result = new TitleScreen
            {
                BackgroundColorTop = Color.White,
                BackgroundColorBottom = Color.White,
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                Image0 = new Image
                {
                    Texture2D = AssetHandler.Get("title_top_background"),
                    Alpha = 0f
                },
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                Image1 = new Image
                {
                    Texture2D = AssetHandler.Get("title_top"),
                    IsVisible = false
                }, // ReSharper disable once HeapView.ObjectAllocation.Evident
                Image2 = new Image
                {
                    Texture2D = AssetHandler.Get("title_bottom_background"),
                    Alpha = 0f,
                    Position = new Vector2(0, 192)
                },
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                Image3 = new Image
                {
                    Texture2D = AssetHandler.Get("frame_complete"),
                    Alpha = 0f,
                    Position = new Vector2(0, 192)
                }
            };
            return result;
        }
    }
}