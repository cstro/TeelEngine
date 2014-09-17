using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TeelEngine.GameStates;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using TeelEngine;
using TeelEngine.Audio;
using TeelEngine.Pathing;

namespace TurnBasedGame
{
    public class TurnBasedGame : Microsoft.Xna.Framework.Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private GameStateManager _gameStateManager;

        private AudioManager _audioManager;

        public TurnBasedGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 1280;

        }

        protected override void Initialize()
        {
            _gameStateManager = new GameStateManager();

            var gameStateDefault = new GameStateDefault("Default", _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            _gameStateManager.Add(gameStateDefault);

            _gameStateManager.Initialize();

            IsMouseVisible = true;

            // GameComponent Example - todo: delete
            _audioManager = new AudioManager(this);
            Components.Add(_audioManager);
            // End 

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
            Camera.Lens = new Rectangle(0,0,_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            _gameStateManager.LoadContent(Content);

            _audioManager.LoadContent("Sounds");
            _audioManager.LoadSoundEffect("footstep", "footsteps");

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            _gameStateManager.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Space) & !_audioManager.IsSoundEffectPlaying)
            {
                _audioManager.PlaySoundEffect("footstep");
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _gameStateManager.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);

        }
    }
}
