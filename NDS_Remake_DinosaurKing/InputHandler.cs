using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NDS_Remake_DinosaurKing
{
    public static class InputHandler
    {
        // ReSharper disable once HeapView.ObjectAllocation.Evident
       // public static InputHandler Instance { get; } = new InputHandler();

        private static KeyboardState _prevKeyboardState;
        private static KeyboardState _currKeyboardState;
        
        private static GamePadState[] _prevGamePadStates;
        private static GamePadState[] _currGamePadStates;

        private static List<Keys> _dirVert = new List<Keys>();
        private static List<Keys> _dirHor = new List<Keys>();

        public static bool IsUp;
        public static bool IsDown;
        public static bool IsLeft;
        public static bool IsRight;
        public static bool IsA;
        public static bool IsB;
        public static bool IsX;
        public static bool IsY;
        public static bool IsStart;
        public static bool IsSelect;
        public static bool IsL;
        public static bool IsR;

        private static bool _active = true;

        public static bool IsEnabled => _active;
        public static bool IsDisabled => !_active;

        static InputHandler()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _currGamePadStates = new [] { GamePad.GetState(0), GamePad.GetState(1), GamePad.GetState(2), GamePad.GetState(3) };
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _prevGamePadStates = new GamePadState[4];
        }
        
        public static void Update(GameTime gameTime)
        {
            if (IsEnabled)
            {
                UpdateDPad();
            }

            _prevKeyboardState = _currKeyboardState;
            _currKeyboardState = Keyboard.GetState();
            
            
            for (var i = 0; i < 4; i++)
            {
                _prevGamePadStates[i] = _currGamePadStates[i];
                _currGamePadStates[i] = GamePad.GetState(i);
            }

            
            IsA = _currKeyboardState.IsKeyDown(Keys.A);

        }

        public static bool IsGamePadConnected(PlayerIndex playerIndex)
        {
            return _currGamePadStates[(int)playerIndex].IsConnected;
        }
        
        private static void UpdateDPad()
        {
            UpdateDirHor();
            UpdateDirVert();
        }

        private static void UpdateDirVert()
        {
            if (_currKeyboardState.IsKeyDown(Keys.Up) && _prevKeyboardState.IsKeyUp(Keys.Up))
            {
                _dirVert.Add(Keys.Up);
            }
            else if (_currKeyboardState.IsKeyDown(Keys.Down) && _prevKeyboardState.IsKeyUp(Keys.Down))
            {
                _dirVert.Add(Keys.Down);
            }

            if (_currKeyboardState.IsKeyUp(Keys.Up))
            {
                _dirVert.Remove(Keys.Up);
            }
            if (_currKeyboardState.IsKeyUp(Keys.Down))
            {
                _dirVert.Remove(Keys.Down);
            }

            if (_dirVert.Count == 0)
            {
                ClearDirVert();
                return;
            }
            ClearDirHor(); //clears hor inputs because of vert priority
            switch (_dirVert.Last())
            {
                case Keys.Up:
                    IsDown = false;
                    IsUp = true;
                    break;
                case Keys.Down:
                    IsUp = false;
                    IsDown = true;
                    break;
                case Keys.None:
                case Keys.Back:
                case Keys.Tab:
                case Keys.Enter:
                case Keys.CapsLock:
                case Keys.Escape:
                case Keys.Space:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.End:
                case Keys.Home:
                case Keys.Left:
                case Keys.Right:
                case Keys.Select:
                case Keys.Print:
                case Keys.Execute:
                case Keys.PrintScreen:
                case Keys.Insert:
                case Keys.Delete:
                case Keys.Help:
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.A:
                case Keys.B:
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.V:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:
                case Keys.LeftWindows:
                case Keys.RightWindows:
                case Keys.Apps:
                case Keys.Sleep:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.Multiply:
                case Keys.Add:
                case Keys.Separator:
                case Keys.Subtract:
                case Keys.Decimal:
                case Keys.Divide:
                case Keys.F1:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                case Keys.F6:
                case Keys.F7:
                case Keys.F8:
                case Keys.F9:
                case Keys.F10:
                case Keys.F11:
                case Keys.F12:
                case Keys.F13:
                case Keys.F14:
                case Keys.F15:
                case Keys.F16:
                case Keys.F17:
                case Keys.F18:
                case Keys.F19:
                case Keys.F20:
                case Keys.F21:
                case Keys.F22:
                case Keys.F23:
                case Keys.F24:
                case Keys.NumLock:
                case Keys.Scroll:
                case Keys.LeftShift:
                case Keys.RightShift:
                case Keys.LeftControl:
                case Keys.RightControl:
                case Keys.LeftAlt:
                case Keys.RightAlt:
                case Keys.BrowserBack:
                case Keys.BrowserForward:
                case Keys.BrowserRefresh:
                case Keys.BrowserStop:
                case Keys.BrowserSearch:
                case Keys.BrowserFavorites:
                case Keys.BrowserHome:
                case Keys.VolumeMute:
                case Keys.VolumeDown:
                case Keys.VolumeUp:
                case Keys.MediaNextTrack:
                case Keys.MediaPreviousTrack:
                case Keys.MediaStop:
                case Keys.MediaPlayPause:
                case Keys.LaunchMail:
                case Keys.SelectMedia:
                case Keys.LaunchApplication1:
                case Keys.LaunchApplication2:
                case Keys.OemSemicolon:
                case Keys.OemPlus:
                case Keys.OemComma:
                case Keys.OemMinus:
                case Keys.OemPeriod:
                case Keys.OemQuestion:
                case Keys.OemTilde:
                case Keys.OemOpenBrackets:
                case Keys.OemPipe:
                case Keys.OemCloseBrackets:
                case Keys.OemQuotes:
                case Keys.Oem8:
                case Keys.OemBackslash:
                case Keys.ProcessKey:
                case Keys.Attn:
                case Keys.Crsel:
                case Keys.Exsel:
                case Keys.EraseEof:
                case Keys.Play:
                case Keys.Zoom:
                case Keys.Pa1:
                case Keys.OemClear:
                case Keys.ChatPadGreen:
                case Keys.ChatPadOrange:
                case Keys.Pause:
                case Keys.ImeConvert:
                case Keys.ImeNoConvert:
                case Keys.Kana:
                case Keys.Kanji:
                case Keys.OemAuto:
                case Keys.OemCopy:
                case Keys.OemEnlW:
                default:
                    break;
            }
        }
        
        private static void UpdateDirHor()
        {
            if (_currKeyboardState.IsKeyDown(Keys.Right) && _prevKeyboardState.IsKeyUp(Keys.Right))
            {
                _dirHor.Add(Keys.Right);
            }
            else if (_currKeyboardState.IsKeyDown(Keys.Left) && _prevKeyboardState.IsKeyUp(Keys.Left))
            {
                _dirHor.Add(Keys.Left);
            }

            if (_currKeyboardState.IsKeyUp(Keys.Right))
            {
                _dirHor.Remove(Keys.Right);
            }
            if (_currKeyboardState.IsKeyUp(Keys.Left))
            {
                _dirHor.Remove(Keys.Left);
            }

            if (_dirHor.Count == 0)
            {
                ClearDirHor();
                return;
            }
            switch (_dirHor.Last())
            {
                case Keys.Right:
                    IsLeft = false;
                    IsRight = true;
                    break;
                case Keys.Left:
                    IsRight = false;
                    IsLeft = true;
                    break;
                case Keys.None:
                case Keys.Back:
                case Keys.Tab:
                case Keys.Enter:
                case Keys.CapsLock:
                case Keys.Escape:
                case Keys.Space:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.End:
                case Keys.Home:
                case Keys.Up:
                case Keys.Down:
                case Keys.Select:
                case Keys.Print:
                case Keys.Execute:
                case Keys.PrintScreen:
                case Keys.Insert:
                case Keys.Delete:
                case Keys.Help:
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.A:
                case Keys.B:
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.V:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:
                case Keys.LeftWindows:
                case Keys.RightWindows:
                case Keys.Apps:
                case Keys.Sleep:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.Multiply:
                case Keys.Add:
                case Keys.Separator:
                case Keys.Subtract:
                case Keys.Decimal:
                case Keys.Divide:
                case Keys.F1:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                case Keys.F6:
                case Keys.F7:
                case Keys.F8:
                case Keys.F9:
                case Keys.F10:
                case Keys.F11:
                case Keys.F12:
                case Keys.F13:
                case Keys.F14:
                case Keys.F15:
                case Keys.F16:
                case Keys.F17:
                case Keys.F18:
                case Keys.F19:
                case Keys.F20:
                case Keys.F21:
                case Keys.F22:
                case Keys.F23:
                case Keys.F24:
                case Keys.NumLock:
                case Keys.Scroll:
                case Keys.LeftShift:
                case Keys.RightShift:
                case Keys.LeftControl:
                case Keys.RightControl:
                case Keys.LeftAlt:
                case Keys.RightAlt:
                case Keys.BrowserBack:
                case Keys.BrowserForward:
                case Keys.BrowserRefresh:
                case Keys.BrowserStop:
                case Keys.BrowserSearch:
                case Keys.BrowserFavorites:
                case Keys.BrowserHome:
                case Keys.VolumeMute:
                case Keys.VolumeDown:
                case Keys.VolumeUp:
                case Keys.MediaNextTrack:
                case Keys.MediaPreviousTrack:
                case Keys.MediaStop:
                case Keys.MediaPlayPause:
                case Keys.LaunchMail:
                case Keys.SelectMedia:
                case Keys.LaunchApplication1:
                case Keys.LaunchApplication2:
                case Keys.OemSemicolon:
                case Keys.OemPlus:
                case Keys.OemComma:
                case Keys.OemMinus:
                case Keys.OemPeriod:
                case Keys.OemQuestion:
                case Keys.OemTilde:
                case Keys.OemOpenBrackets:
                case Keys.OemPipe:
                case Keys.OemCloseBrackets:
                case Keys.OemQuotes:
                case Keys.Oem8:
                case Keys.OemBackslash:
                case Keys.ProcessKey:
                case Keys.Attn:
                case Keys.Crsel:
                case Keys.Exsel:
                case Keys.EraseEof:
                case Keys.Play:
                case Keys.Zoom:
                case Keys.Pa1:
                case Keys.OemClear:
                case Keys.ChatPadGreen:
                case Keys.ChatPadOrange:
                case Keys.Pause:
                case Keys.ImeConvert:
                case Keys.ImeNoConvert:
                case Keys.Kana:
                case Keys.Kanji:
                case Keys.OemAuto:
                case Keys.OemCopy:
                case Keys.OemEnlW:
                default:
                    break;
            }
        }

        private static void DebugDPad()
        {
            Console.WriteLine($"{{Up:{IsUp}; Down:{IsDown}; Right:{IsRight}; Left:{IsLeft}}}");
        }
        
        private static void ClearDPad()
        {
            IsUp = false;
            IsDown = false;
            IsLeft = false;
            IsRight = false;
        }
        
        private static void ClearDirHor()
        {
            IsLeft = false;
            IsRight = false;
        }
        
        private static void ClearDirVert()
        {
            IsUp = false;
            IsDown = false;
        }

        public static void Disable()
        {
            
        }
        
        public static void Enable()
        {
            
        }
        
    }
}