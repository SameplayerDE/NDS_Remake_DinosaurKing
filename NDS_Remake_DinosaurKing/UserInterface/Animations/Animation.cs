namespace NDS_Remake_DinosaurKing.UserInterface.Animations
{
    public abstract class Animation
    {
        public UserInterfaceElement Element;
        public abstract void Update(float delta);
    }
}