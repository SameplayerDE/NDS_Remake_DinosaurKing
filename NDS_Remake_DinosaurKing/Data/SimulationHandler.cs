using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NDS_Remake_DinosaurKing.Humans;

namespace NDS_Remake_DinosaurKing.Data
{
    public static class SimulationHandler
    {
        public static SimulationArea SimulationArea;
        private static Dictionary<string, SimulationArea> _areas;

        public static void Update(GameTime gameTime)
        {
            if (SimulationArea == null)
            {
                return;
            }

            foreach (var entity in SimulationArea.Entities)
            {
                if (entity is IUpdate updateable)
                {
                    updateable.Update(gameTime, SimulationArea);
                }
            }
        }
        
    }
}