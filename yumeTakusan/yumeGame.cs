using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.ContentManagment;
using yumeTakusan.YumeCamera;
using yumeTakusan.yumeUI;

namespace yumeTakusan
{
    public class yumeGame:Game
    {
        protected GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        protected ContentStorageManager content;

        public yumeGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        RootNode testUI;
        Texture2D pixel;

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
            testUI = (RootNode)content.getContent<RootNode>("ui");
            pixel = (Texture2D)content.getContent<Texture2D>("pixel");
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
