using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace BugsDestroyer
{
    public partial class Game1 : Game
    {
        // Variables
        private List<Texture2D> _menuImages;

        private Color _colorSectionPlayer = Color.White; 
        private Color _colorSectionGame = Color.LightGray * 0.5f;
        private Color _colorSectionDifficulty = Color.LightGray * 0.5f;

        //Timer
        private float timerMenu = 0f;
        private float timerDifficulty = 0f;

        private bool _isSectionGame = false;
        private bool _isSectionPlayer = true;
        private bool _isSectionDifficulty = false;

        private string _selectedPlayerText = "1 player";
        private bool _selectedPlayer1 = true;
        private string _selectedDifficultyText = "Normal";


        /// <summary>
        /// Récupération de touts les éléments don le menu a besoin
        /// (Alec Piette)
        /// </summary>
        protected void menuLoad()
        {
            // liste de sprite 
            _menuImages = new List<Texture2D>()
            {
                Content.Load<Texture2D>("Img/Menu/backgroundMenuTemp"),
                Content.Load<Texture2D>("Img/Menu/flecheDroite"),
                Content.Load<Texture2D>("Img/Menu/flecheGauche"),
                Content.Load<Texture2D>("Img/Menu/boutonCentre"),
                Content.Load<Texture2D>("Img/Menu/panelRouge"),
                Content.Load<Texture2D>("Img/Menu/panelBleu"),
                Content.Load<Texture2D>("Img/Menu/backgroundMenuTemp1"),
                Content.Load<Texture2D>("Img/Menu/backgroundMenuTemp2"),
            };

            _font = Content.Load<SpriteFont>("Fonts/GameBoy30");

            MenuSfx = Content.Load<SoundEffect>("Sounds/Sfx/MenuSfx");
            StartSfx = Content.Load<SoundEffect>("Sounds/Sfx/StartSfx");
        }

        /// <summary>
        /// Update du menu Principal
        /// (Alec Piette)
        /// </summary>
        /// <param name="gameTime"></param>
        protected void menuUpdate(GameTime gameTime)
        {
            timerMenu += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timerDifficulty += (float)gameTime.ElapsedGameTime.TotalSeconds;
            // modification de couleur et d'opacitiée entre la sélection de player et play
            if (_isSectionPlayer && timerMenu >= 0.3f && (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)))
            {
                MenuSfx.Play();
                _isSectionPlayer = false;
                _isSectionDifficulty = true;
                _isSectionGame = false;
                _colorSectionPlayer = Color.LightGray * 0.5f;
                _colorSectionGame = Color.LightGray * 0.5f;
                _colorSectionDifficulty = Color.White;
                timerMenu = 0f;
            }
            else if (_isSectionDifficulty && timerMenu >= 0.3f && (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down)))
            {
                MenuSfx.Play();
                _isSectionPlayer = false;
                _isSectionDifficulty = false;
                _isSectionGame = true;
                _colorSectionPlayer = Color.LightGray * 0.5f;
                _colorSectionGame = Color.White;
                _colorSectionDifficulty = Color.LightGray * 0.5f;
                timerMenu = 0f;
            }


            if (_isSectionDifficulty && timerMenu >= 0.3f && (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)))
            {
                MenuSfx.Play();
                _isSectionPlayer = true;
                _isSectionDifficulty = false;
                _isSectionGame = false;
                _colorSectionPlayer = Color.White;
                _colorSectionGame = Color.LightGray * 0.5f;
                _colorSectionDifficulty = Color.LightGray * 0.5f;
                timerMenu = 0f;
            }
            else if (_isSectionGame && timerMenu >= 0.3f && (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up)))
            {
                MenuSfx.Play();
                _isSectionPlayer = false;
                _isSectionDifficulty = true;
                _isSectionGame = false;
                _colorSectionPlayer = Color.LightGray * 0.5f;
                _colorSectionGame = Color.LightGray * 0.5f;
                _colorSectionDifficulty = Color.White;
                timerMenu = 0f;
            }


            if (_isSectionPlayer)
            {
                // Les sélections 1 player ou 2 player
                if (_selectedPlayer1 && (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D9)))
                {
                    MenuSfx.Play();
                    _selectedPlayer1 = false;
                    _selectedPlayerText = "2 players";
                }
                else if (!_selectedPlayer1 && (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.D7)))
                {
                    MenuSfx.Play();
                    _selectedPlayer1 = true;
                    _selectedPlayerText = "1 player";
                }
            }
            else if (_isSectionDifficulty)
            {
                // Les sélections de difficulté
                if (_selectedDifficultyText == "Normal" && timerDifficulty >= 0.3f && (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D9)))
                {
                    MenuSfx.Play();
                    _selectedDifficultyText = "Difficult";
                    timerDifficulty = 0f;
                    
                }
                else if (_selectedDifficultyText == "Easy" && timerDifficulty >= 0.3f && (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D9)))
                {
                    MenuSfx.Play();
                    _selectedDifficultyText = "Normal";
                    timerDifficulty = 0f;
                }
                else if (_selectedDifficultyText == "Difficult" && timerDifficulty >= 0.3f && (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.D7)))
                {
                    MenuSfx.Play();
                    _selectedDifficultyText = "Normal";
                    timerDifficulty = 0f;
                }
                else if (_selectedDifficultyText == "Normal" && timerDifficulty >= 0.3f && (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.D7)))
                {
                    MenuSfx.Play();
                    _selectedDifficultyText = "Easy";
                    timerDifficulty = 0f;
                }
            }
            else if (!_isSectionPlayer && !_isSectionDifficulty)
            {
                // lencement du jeu
                if (_isOnMenu && (Keyboard.GetState().IsKeyDown(Keys.D8)))
                {
                    Globals.multDifficulty = _selectedDifficultyText;
                    StartSfx.Play();
                    _isOnMenu = false;
                }
            }
        }

        /// <summary>
        /// Affichage du menu Principal
        /// (Alec Piette)
        /// </summary>
        protected void menuDraw()
        {
            // background
            _spriteBatch.Draw(_menuImages[6],
               new Rectangle(0, 0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height),
               new Rectangle(0, 0, _menuImages[6].Width, _menuImages[6].Height),
               Color.White);

            // Titre
            _spriteBatch.DrawString(_font, "bugs destroyer", new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 7.25f), Color.White, 0f, new Vector2(_font.MeasureString("bugs destroyer").X / 2, _font.MeasureString("bugs destroyer").Y / 2), 2f, SpriteEffects.None, 0f);

            // Choix du joueur
            if (!_selectedPlayer1)
            {
                _spriteBatch.Draw(_menuImages[2], new Vector2(_graphics.PreferredBackBufferWidth / 2 - 175, 400), null, _colorSectionPlayer, 0f, Vector2.Zero, 2.75f, SpriteEffects.None, 0f);
            }
            _spriteBatch.DrawString(_font, _selectedPlayerText, new Vector2(_graphics.PreferredBackBufferWidth / 2, 420), _colorSectionPlayer, 0f, new Vector2(_font.MeasureString(_selectedPlayerText).X / 2, _font.MeasureString(_selectedPlayerText).Y / 2), 0.75f, SpriteEffects.None, 0f);
            if (_selectedPlayer1)
            {
                _spriteBatch.Draw(_menuImages[1], new Vector2(_graphics.PreferredBackBufferWidth / 2 + 130, 400), null, _colorSectionPlayer, 0f, Vector2.Zero, 2.75f, SpriteEffects.None, 0f);
            }

            // Niveau de difficulté
            if (_selectedDifficultyText == "Normal")
            {
                _spriteBatch.Draw(_menuImages[2], new Vector2(_graphics.PreferredBackBufferWidth / 2 - 140, 500), null, _colorSectionDifficulty, 0f, Vector2.Zero, 2.75f, SpriteEffects.None, 0f);
                _spriteBatch.Draw(_menuImages[1], new Vector2(_graphics.PreferredBackBufferWidth / 2 + 90, 500), null, _colorSectionDifficulty, 0f, Vector2.Zero, 2.75f, SpriteEffects.None, 0f);
            }
            _spriteBatch.DrawString(_font, _selectedDifficultyText, new Vector2(_graphics.PreferredBackBufferWidth / 2, 520), _colorSectionDifficulty, 0f, new Vector2(_font.MeasureString(_selectedDifficultyText).X / 2, _font.MeasureString(_selectedDifficultyText).Y / 2), 0.75f, SpriteEffects.None, 0f);
            if (_selectedDifficultyText == "Difficult")
            {
                _spriteBatch.Draw(_menuImages[2], new Vector2(_graphics.PreferredBackBufferWidth / 2 - 170, 500), null, _colorSectionDifficulty, 0f, Vector2.Zero, 2.75f, SpriteEffects.None, 0f);
            }
            if (_selectedDifficultyText == "Easy")
            {
                _spriteBatch.Draw(_menuImages[1], new Vector2(_graphics.PreferredBackBufferWidth / 2 + 80, 500), null, _colorSectionDifficulty, 0f, Vector2.Zero, 2.75f, SpriteEffects.None, 0f);
            }

            // Jeux
            _spriteBatch.DrawString(_font, "Play", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 50, 620), _colorSectionGame, 0f, new Vector2(0, 0), 0.75f, SpriteEffects.None, 0f);

            //Controle
            _spriteBatch.Draw(_menuImages[3], new Vector2(_graphics.PreferredBackBufferWidth / 2 - 130, 720), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(_font, "play-pause", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 43, 700), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(_font, "quit", new Vector2(_graphics.PreferredBackBufferWidth / 2 + 90, 700), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
            if (_selectedPlayer1)
            {
                _spriteBatch.Draw(_menuImages[4], new Vector2(_graphics.PreferredBackBufferWidth / 2 - 120, 810), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
                _spriteBatch.DrawString(_font, "mouvement", new Vector2(_graphics.PreferredBackBufferWidth / 2 -145, 905), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
                _spriteBatch.DrawString(_font, "shot", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 48, 810), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
                _spriteBatch.DrawString(_font, "interact", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 10, 795), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
            }
            else
            {
                _spriteBatch.Draw(_menuImages[4], new Vector2(_graphics.PreferredBackBufferWidth / 2 - 300, 810), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
                _spriteBatch.DrawString(_font, "mouvement", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 325, 905), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
                _spriteBatch.DrawString(_font, "shot", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 225, 810), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
                _spriteBatch.DrawString(_font, "interact", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 190, 795), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);

                _spriteBatch.Draw(_menuImages[5], new Vector2(_graphics.PreferredBackBufferWidth / 2 + 70, 810), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
                _spriteBatch.DrawString(_font, "mouvement", new Vector2(_graphics.PreferredBackBufferWidth / 2 + 40, 905), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
                _spriteBatch.DrawString(_font, "shot", new Vector2(_graphics.PreferredBackBufferWidth / 2 + 145, 810), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
                _spriteBatch.DrawString(_font, "interact", new Vector2(_graphics.PreferredBackBufferWidth / 2 + 180, 795), Color.White, 0f, new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);
            }
        }

        
}
}