using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeUI;
using yumeTakusan.ContentManagment;

namespace tsukameruCore
{
    public class TsukameruGame:Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        RootNode rootNode = new RootNode();

        public TsukameruGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        ContentStorageManager content = new ContentStorageManager();

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            content.LoadAllContent(Content);

        }

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
