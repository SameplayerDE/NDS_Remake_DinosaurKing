using System;
using NDS_Remake_DinosaurKing.Data;

namespace NDS_Remake_DinosaurKing
{
    public static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var game = new DinosaurKing();
            game.Run();
        }
    }
}