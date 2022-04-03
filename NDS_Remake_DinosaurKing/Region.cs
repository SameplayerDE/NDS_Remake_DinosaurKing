using System.Collections.Generic;

namespace NDS_Remake_DinosaurKing
{
    public class Region
    {
        // ReSharper disable once CollectionNeverQueried.Local
        private readonly List<Entity> _entities;

        public Region()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _entities = new List<Entity>();
        }

        public void Add(Entity entity)
        {
            _entities.Add(entity);
        }
        
        public void Remove(Entity entity)
        {
            _entities.Remove(entity);
        }
    }
}