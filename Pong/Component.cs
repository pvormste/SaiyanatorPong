using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    public abstract class Component
    {
        private BaseObject _baseObject;
        public abstract ComponentType ComponentType { get; }

        /// <summary>
        /// Initializes the component with its base object
        /// </summary>
        public virtual void Initialize(BaseObject baseObject)
        {
            this._baseObject = baseObject;
        }

        /// <summary>
        /// Returns the owner id
        /// </summary>
        public Entity GetOwnerID()
        {
            return _baseObject.ID;
        }

        /// <summary>
        /// Removes the component
        /// </summary>
        public void Remove()
        {
            _baseObject.RemoveComponent(this);
        }

        /// <summary>
        /// Gets component from base object
        /// </summary>
        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _baseObject == null ? null : _baseObject.GetComponent<TComponentType>(componentType);
        }

        /// <summary>
        /// Update and Draw routines
        /// </summary>
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
