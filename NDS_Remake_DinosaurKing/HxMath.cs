namespace NDS_Remake_DinosaurKing
{
    public static class HxMath
    {
        public static int Wrap(int a, int min, int max)
        {
            while (true)
            {
                int result;
                if (a > max)
                {
                    var diff = a - max;
                    diff -= 1;
                    result = min + diff;
                }
                else if (a < min)
                {
                    var diff = min - a;
                    diff -= 1;
                    result = max - diff;
                }
                else
                {
                    result = a;
                    return result;
                }
                a = result;
            }
        }
    }
}