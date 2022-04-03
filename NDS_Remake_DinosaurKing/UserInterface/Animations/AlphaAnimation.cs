using System;

namespace NDS_Remake_DinosaurKing.UserInterface.Animations
{
    
    public enum AlphaAnimationFade
    {
        FadeInLinear,
        FadeOutLinear,
        FadeInOutLinear,
        FadeInStayOutLinear
    }
    
    public class AlphaAnimation : Animation
    {
        
        public AlphaAnimationFade AlphaAnimationFade = AlphaAnimationFade.FadeInLinear;
        public int Duration => 1000;
        private bool _processing = true;

        public override void Update(float delta)
        {
            if (!_processing)
            {
                return;
            }

            switch (AlphaAnimationFade)
            {
                case AlphaAnimationFade.FadeInLinear when Element.Alpha >= 1f:
                    _processing = false;
                    return;
                case AlphaAnimationFade.FadeInLinear:
                    Element.Alpha += 1000f / Duration * delta;
                    break;
                case AlphaAnimationFade.FadeOutLinear when Element.Alpha <= 0f:
                    _processing = false;
                    return;
                case AlphaAnimationFade.FadeOutLinear:
                    Element.Alpha -= 1000f / Duration * delta;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}