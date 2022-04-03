using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NDS_Remake_DinosaurKing.UserInterface;
using NDS_Remake_DinosaurKing.UserInterface.Screens;

namespace NDS_Remake_DinosaurKing.Data
{
    public static class ScreenHandler
    {
        private static Stack<Screen> _screenStack;
        private static Dictionary<string, Screen> _screens;
        private static Queue<ScreenHandlerRequest> _requests;

        static ScreenHandler()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _screenStack = new Stack<Screen>();
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _screens = new Dictionary<string, Screen>();
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _requests = new Queue<ScreenHandlerRequest>();
        }

        public static void PrepareScreens()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _screens.Add("splash", SplashScreen.Create());
        }

        public static Screen Get(string key)
        {
            return _screens[key];
        }

        public static void RequestPush(string key)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _requests.Enqueue(new ScreenHandlerRequest(ScreenHandlerRequestType.Push, key));
        }

        public static void RequestPush(Screen screen)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _requests.Enqueue(new ScreenHandlerRequest(ScreenHandlerRequestType.Push, screen));
        }

        public static void RequestPop(string message = "")
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _requests.Enqueue(new ScreenHandlerRequest(ScreenHandlerRequestType.Pop));
#if DEBUG
            Console.WriteLine(string.IsNullOrEmpty(message) ? "Requested POP" : $"Requested POP: {message}");
#endif
        }

        public static void ProcessRequests()
        {
            while (_requests.TryDequeue(out var request))
            {
                switch (request.RequestType)
                {
                    case ScreenHandlerRequestType.Pop:
                        Pop();
                        break;
                    case ScreenHandlerRequestType.Push:
                        if (string.IsNullOrEmpty(request.Key))
                        {
                            if (request.Screen != null)
                            {
                                Push(request.Screen);
                            }

                            break;
                        }

                        Push(request.Key);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Push(string key)
        {
            _screenStack.Push(Get(key));
        }

        public static void Push(Screen screen)
        {
            _screenStack.Push(screen);
        }

        public static void Pop()
        {
            if (_screenStack.Count > 0)
            {
                _screenStack.Pop();
            }
        }

        public static void Update(GameTime gameTime)
        {
            ProcessRequests();
            if (_screenStack.Count <= 0) return;
            _screenStack.Peek().Update(HxTime.DeltaF);
        }

        public static void Draw(SpriteBatch spriteBatch, float delta)
        {
            if (_screenStack.Count <= 0) return;
            foreach (var screen in _screenStack)
            {
                screen.Draw(spriteBatch, delta);
            }
        }
    }
}