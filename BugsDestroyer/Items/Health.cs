using Microsoft.Xna.Framework;
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
     * Health.cs
     * Contains the display for health items
     * Version 2.0
     */
    class Health : Item
    {
        // Attributs
        private int healthPoints = 25;

        // Ctor
        public Health(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }

        // Methods
        public override void Update(GameTime gameTime, List<Item> listItems, List<Player> listPlayers)
        {
            ItemAnimation();

            for (int i = listPlayers.Count - 1; i >= 0; i--)
            {
                if (hasCollidedWithPlayer(listItems, listPlayers[i]))
                {
                    listPlayers[i].healthPoint += this.healthPoints;

                    listItems.Remove(this); // remove item
                }
            }
        }
    }
}
