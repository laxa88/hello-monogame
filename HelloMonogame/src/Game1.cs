using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TextureAtlas;

namespace HelloMonogame
{
    public class Game1 : Game
    {
        private SpriteFont font;
        private SpriteFont customFont;
        private int score = 0;
        private Texture2D myTexture;
        private AnimatedSprite animatedSprite;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("MyFont");
            customFont = Content.Load<SpriteFont>("MyCustomFont");

            // single image
            myTexture = Content.Load<Texture2D>("SmileyWalk");

            // animated image
            Texture2D texture = Content.Load<Texture2D>("SmileyWalk");
            animatedSprite = new AnimatedSprite(texture, 4, 4);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (
                GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || state.IsKeyDown(Keys.Escape)
            )
            {
                Exit();
            }

            if (state.IsKeyDown(Keys.Up))
            {
                score++;
            }

            // TODO: Add your update logic here
            animatedSprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(
                font,
                "hello world 1: " + score,
                new Vector2(100, 100),
                Color.Black
            );
            _spriteBatch.DrawString(
                customFont,
                "hello world 2: " + score,
                new Vector2(100, 130),
                Color.Black
            );
            _spriteBatch.Draw(myTexture, new Rectangle(300, 150, 100, 100), Color.White);
            animatedSprite.Draw(_spriteBatch, new Vector2(200, 300));
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
