using GameDevProject_2021.GameObjects.Actors;
using GameDevProject_2021.Collision;
using GameDevProject_2021.Model.Input;
using GameDevProject_2021.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GameDevProject_2021
{
    public class Game1 : Game
    {
        #region Var and Prop

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D texture;

        private Texture2D blokTexture;
        private Rectangle blok;//klasse van maken en hier gewoon texture van maken en in klasse collideRectangle

        private CollisionManager collisionManager;

        private Hero deer;

        #endregion
        #region Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        #endregion
        #region Methods
        protected override void Initialize()
        {
            collisionManager = new CollisionManager();

            base.Initialize();
            InitializeGameObject(); //hier of in loadcontent zoals in video?
        }
        protected override void LoadContent()
        {
            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();//Niet zeker waar dit moet

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("HeroSquirrel");
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            blokTexture.SetData(new[] { Color.White });
        }

        private void InitializeGameObject()
        {
            deer = new Hero(texture, new KeyBoardReader());
            blok = new Rectangle(150, 450, 30, 30);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //test collision
            if (!collisionManager.CollisionCheck(blok, deer.CollisionRectangle))
            {
                Debug.WriteLine("aaaaaaa");
            }

            deer.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            deer.Draw(_spriteBatch);

            //tijdelijke blok
            _spriteBatch.Draw(blokTexture, blok, Color.Red);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion








        //public void ChangeInput(IInputReader inputReader)
        //{
        //    inputReader = inputReader;
        //}
        //Om input te veranderen in options bvb
    }
}
