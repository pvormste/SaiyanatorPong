using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Screens
{
    public class Entities
    {
        private List<BaseObject> _entities;

        public Entities()
        {
            _entities = new List<BaseObject>();
        }

        public void AddEntity(BaseObject entity)
        {
            _entities.Add(entity);
        }

        public void AddMultipleEntities(List<BaseObject> entities)
        {
            _entities.AddRange(entities);
        }

        public void RemoveEntity(BaseObject entity)
        {
            _entities.Remove(entity);
        }

        public BaseObject FindEntity(Entity ent)
        {
            foreach(var entity in _entities)
            {
                if (entity.ID == ent)
                    return entity;
            }

            return null;
        }

        public void Update(double gameTime)
        {
            foreach(var entity in _entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var entity in _entities)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}
