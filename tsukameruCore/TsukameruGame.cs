using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeUI;
using yumeTakusan.contentManagment;

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

        ContentManager content = new ContentManager();

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentManager.LoadAllContent(Content);

        }

        protected override void UnloadContent() { }


        protected override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {


            base.Draw(gameTime);
        }
    }
}
