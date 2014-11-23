using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public class BaseObject
    {
        public Entity ID { get; private set; }
        private readonly List<Component> _components;

        public BaseObject(Entity ent)
        {
            ID = ent;
            _components = new List<Component>();
        }

        /// <summary>
        /// Adds an component to the component list
        /// </summary>
        public void AddComponent(Component component)
        {
            _components.Add(component);
            component.Initialize(this);
        }

        /// <summary>
        /// Adds various components to the component list
        /// </summary>
        public void AddMultipleComponents(List<Component> components)
        {
            _components.AddRange(components);
            foreach(Component component in components) 
            {
                component.Initialize(this);
            }
        }

        /// <summary>
        /// Removes an component from the component list
        /// </summary>
        public void RemoveComponent(Component component)
        {
            _components.Remove(component);
        }

        /// <summary>
        /// Returns the component of a specific type
        /// </summary>
        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _components.Find(c => c.ComponentType == componentType) as TComponentType;
        }

        /// <summary>
        /// Calls the Update routine of every component
        /// </summary>
        public void Update(double gameTime)
        {
            foreach (Component component in _components)
            {
                component.Update(gameTime);
            }
        }

        /// <summary>
        /// Calls the draw routine of every component
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in _components)
            {
                component.Draw(spriteBatch);
            }
        }
    }
}
