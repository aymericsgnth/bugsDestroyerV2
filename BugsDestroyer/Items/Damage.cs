using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
namespace BugsDestroyer
{
    /*
     * Thibaud Hegelbach, Aymeric Siegenthaler, Yoann Meier, Alexandre Babich
     * Health.cs
     * Contains the display for health items
     * Version 2.0
     */
    class Damage : Item
    {


        // Attributs
        public int multiplicatorDamage = 1;

        // Ctor
        public Damage(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }


        public float timerDmg = 0f;
        public bool timerDmgIsActivated = false;
        public int globalTimer;
        // Methods
        public override void Update(GameTime gameTime, List<Item> listItems, List<Player> listPlayers)
        {
            ItemAnimation();

            for (int i = listPlayers.Count - 1; i >= 0; i--)
            {
                if (hasCollidedWithPlayer(listItems, listPlayers[i]))
                {
                    listItems.Remove(this); // remove item
                    Globals.multiplicatorDmg++;
                }
            }
        }
    }
}

