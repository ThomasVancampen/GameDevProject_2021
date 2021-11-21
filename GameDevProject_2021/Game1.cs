using GameDevProject_2021.Heroes;
using GameDevProject_2021.Input;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject_2021
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D texture;

        private Hero deer;

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
            InitializeGameObject(); //hier of in loadcontent zoals in video?
        }



        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("HeroDeer");
        }

        private void InitializeGameObject()
        {
            deer = new Hero(texture, new KeyBoardReader());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            deer.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            deer.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
        //public void ChangeInput(IInputReader inputReader)
        //{
        //    inputReader = inputReader;
        //}
        //Om input te veranderen in options bvb
    }
}
