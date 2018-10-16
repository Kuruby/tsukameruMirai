using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace tsukameruCore
{
    public class TsukameruGame:Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public TsukameruGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {


            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


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
