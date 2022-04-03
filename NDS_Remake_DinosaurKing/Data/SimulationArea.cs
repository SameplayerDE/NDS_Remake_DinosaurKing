using System.Collections.Generic;
using HxTiled.Tiled;

namespace NDS_Remake_DinosaurKing.Data
{
    public class SimulationArea
    {
        public TileMap TileMap;
        public List<Entity> Entities = new List<Entity>();

        public void Add(Entity entity)
        {
            Entities.Add(entity);
        }
    }
}