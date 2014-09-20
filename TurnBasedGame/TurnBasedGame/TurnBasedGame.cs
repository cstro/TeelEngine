using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TeelEngine.GameStates;
using TeelEngine;

namespace TurnBasedGame
{
    public class TurnBasedGame : Microsoft.Xna.Framework.Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private GameStateManager _gameStateManager;

        public TurnBasedGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferHeight = 900;
            _graphics.PreferredBackBufferWidth = 1600;

        }

        protected override void Initialize()
        {
            _gameStateManager = new GameStateManager();

            var gameStateDefault = new GameStateDefault("Default", _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            _gameStateManager.Add(gameStateDefault);

            _gameStateManager.Initialize();

            IsMouseVisible = true;
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
            Camera.Lens = new Rectangle(0,0,_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            _gameStateManager.LoadContent(Content);

            

        }
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            _gameStateManager.Update(gameTime);

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
