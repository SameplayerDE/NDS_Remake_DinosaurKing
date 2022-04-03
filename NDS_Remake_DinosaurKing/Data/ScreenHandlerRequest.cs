using NDS_Remake_DinosaurKing.UserInterface;

namespace NDS_Remake_DinosaurKing.Data
{
    public class ScreenHandlerRequest : Request
    {
        public readonly ScreenHandlerRequestType RequestType;
        public readonly string Key;
        public readonly Screen Screen;

        public ScreenHandlerRequest(ScreenHandlerRequestType requestType)
        {
            RequestType = requestType;
        }
        
        public ScreenHandlerRequest(ScreenHandlerRequestType requestType, string key)
        {
            RequestType = requestType;
            Key = key;
            Screen = null;
        }
        
        public ScreenHandlerRequest(ScreenHandlerRequestType requestType, Screen screen)
        {
            RequestType = requestType;
            Screen = screen;
            Key = string.Empty;
        }
    }
}