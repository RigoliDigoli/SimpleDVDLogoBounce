using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace SimpleDVDLogoBounce
{
    public class Game1 : Game
    {
        // Logo variables
        Texture2D logoTexture;
        Vector2 logoPosition;
        float logoSpeed;
        float logoSpeedX;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            logoPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);

            logoSpeed = 75f;
            logoSpeedX = 75f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            logoTexture = Content.Load<Texture2D>("logo");
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            logoPosition.Y -= logoSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            logoPosition.X -= logoSpeedX * (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (logoPosition.X > _graphics.PreferredBackBufferWidth - logoTexture.Width / 2)
            {
                logoSpeedX *= -1;
            }
            else if (logoPosition.X < logoTexture.Width / 2)
            {
                logoSpeedX *= -1;
            }

            if (logoPosition.Y > _graphics.PreferredBackBufferHeight - logoTexture.Height / 2)
            {
                // bottom boundary
                logoSpeed *= -1;

            }
            else if (logoPosition.Y < logoTexture.Height / 2)
            {
                // top boundary
                logoSpeed *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                logoTexture,
                logoPosition,
                null,
                Color.White,
                0f,
                new Vector2(logoTexture.Width / 2, logoTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
                );
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}