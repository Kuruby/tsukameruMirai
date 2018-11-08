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

        ContentStorageManager content = new ContentStorageManager();

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            content.LoadAllContent(Content);
            InitializeAfterContentLoad();
        }

        protected void InitializeAfterContentLoad()
        {

        }

        RootNode testUi;

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
