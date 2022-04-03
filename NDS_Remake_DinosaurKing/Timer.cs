namespace NDS_Remake_DinosaurKing
{
    public class Timer
    {
        public float Duration;
        public float Waited;
        public bool Finished;

        public void Update(float delta)
        {
            if (Waited < Duration)
            {
                Waited += delta * 1000;
            }
            else
            {
                Finished = true;
            }
        }

        public void Reset()
        {
            Waited = 0;
            Finished = false;
        }
    }
}