using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugsDestroyer
{
    /*
     * Thibaud Hegelbach, Aymeric Siegenthaler, Yoann Meier, Alexandre Babich
     * Object.cs
     * Contains the abstract class Object
     * Version 2.0
     */
    public abstract class Object
    {
        public Vector2 position;
        public Texture2D texture;
        public float size;

        /// <summary>
        /// Affichage d'un objet
        /// (Alec Piette)
        /// </summary>
        /// <param name="spriteBatch"></param>
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
