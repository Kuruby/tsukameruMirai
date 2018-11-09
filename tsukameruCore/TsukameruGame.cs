using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeUI;
using yumeTakusan.ContentManagment;
using yumeTakusan.Camera;

namespace tsukameruCore
{
    public class TsukameruGame : Game
    {
        protected GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        protected ContentStorageManager content;

        public TsukameruGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        Camera camera = new Camera(CameraViewType.Sidescroller);

        protected override void Initialize()
        {
            base.Initialize();
        }

        

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            content.LoadAllContent();
            InitializeAfterContentLoad();
        }

        protected void InitializeAfterContentLoad()
        {

        }

        //RootNode testUi;

        protected override void UnloadContent() { }


        protected override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MediumAquamarine);

            base.Draw(gameTime);
        }
    }
}
