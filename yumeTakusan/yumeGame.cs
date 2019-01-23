using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.ContentManagment;
using yumeTakusan.YumeCamera;
using yumeTakusan.GameObjects;
using yumeTakusan.yumeUI;
using yumeTakusan;

namespace yumeTakusan
{
    /// <summary>
    /// Default game type for yumeTakusan
    /// </summary>
    public class YumeGame : Game
    {
        /// <summary>
        /// Graphics device
        /// </summary>
        protected GraphicsDeviceManager graphics;
        /// <summary>
        /// Default spritebatch for the game
        /// </summary>
        SpriteBatch spriteBatch;

        /// <summary>
        /// Content storage manager for the game
        /// </summary>
        protected ContentStorageManager content;

        /// <summary>
        /// Creates game
        /// </summary>
        public YumeGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// UI for testing stuff
        /// </summary>
        RootNode testUI;

        /// <summary>
        /// Game's main camera
        /// </summary>
        protected Camera camera = new Camera(CameraViewType.Sidescroller);

        /// <summary>
        /// Zero-indexed window bounds
        /// </summary>
        protected Rectangle windowBounds;

        /// <summary>
        /// Zero-indexed window bounds
        /// </summary>
        Rectangle WindowBounds => windowBounds;

        /// <summary>
        /// Update the window rectangle
        /// </summary>
        /// <param name="sender">object sending request</param>
        /// <param name="e">arguments</param>
        void UpdateWindowRectangle(object sender, EventArgs e)
        {
            windowBounds = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            Window.ClientSizeChanged += UpdateWindowRectangle;
            base.Initialize();
        }

        /// <summary>
        /// Loads all content using the content manager
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            content.LoadAllContent();
            InitializeAfterContentLoad();
        }

        /// <summary>
        /// player for testing
        /// </summary>
        Player p;

        //performs initialization once the content is loaded
        protected void InitializeAfterContentLoad()
        {
            testUI = (RootNode)content.GetContent<RootNode>("ui");
            Texture2D pixel = (Texture2D)content.GetContent<Texture2D>("pixel");
            ElementNode.pixel = pixel;
            RootNode.pixel = pixel;
            p = new Player((Texture2D)content.GetContent<Texture2D>("char"), Rectangle.Empty);
        }

        /// <summary>
        /// Unloads content
        /// </summary>
        protected override void UnloadContent() { }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        protected override void Update(GameTime gameTime)
        {
            p.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MediumAquamarine);
            testUI.Draw(gameTime, spriteBatch);
            spriteBatch.Begin();
            p.Draw(spriteBatch, new Camera(CameraViewType.Isometric), gameTime, 0f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
