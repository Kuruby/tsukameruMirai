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
using yumeTakusan.Interaction;
using yumeTakusan.Input.Patching;
using yumeTakusan.Components.Controllers;
using yumeTakusan.Components;

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
        protected ContentStorageManager ContentStore;

        protected MasterInput masterInput = new MasterInput();

        /// <summary>
        /// Creates game
        /// </summary>
        public YumeGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
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
        public Rectangle WindowBounds { get; protected set; }

        /// <summary>
        /// Update the window rectangle
        /// </summary>
        /// <param name="sender">object sending request</param>
        /// <param name="e">arguments</param>
        void UpdateWindowRectangle(object sender, EventArgs e)
        {
            WindowBounds = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            RenderTargetManager.windowDimensions = WindowBounds;
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            Window.ClientSizeChanged += UpdateWindowRectangle;
            UpdateWindowRectangle(this, null);
            IsMouseVisible = true;
            RenderTargetManager.Initialize(GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// Loads all content using the content manager
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentStore.LoadAllContent();
            InitializeAfterContentLoad();
        }


        /// <summary>
        /// All Characters in the game currently
        /// </summary>
        protected List<Character> Characters = new List<Character>();

        /// <summary>
        /// Interactthingy for testing
        /// </summary>
        InteractThingy interactThingy;

        protected List<Particle> Particles = new List<Particle>();



        /// <summary>
        /// performs initialization once the content is loaded
        /// </summary>
        protected void InitializeAfterContentLoad()
        {
            testUI = (RootNode)ContentStore.GetContent("ui");
            Texture2D pixel = (Texture2D)ContentStore.GetContent("pixel");
            ElementNode.pixel = pixel;
            RootNode.pixel = pixel;
            Particle.AfterContentLoadInit(ContentStore);
            Characters.Add(new Character((Texture2D)ContentStore.GetContent("char"), Rectangle.Empty, new DesktopInputController(masterInput)));
            interactThingy = new InteractThingy((Texture2D)ContentStore.GetContent("pixel"), masterInput);
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

            if (IsActive || false /*should be like Settings.InactivePlay*/)
            {
                masterInput.Update(true);
                StaticDisposalComponent.UpdateAndCheckDispose(Particles, gameTime);
                StaticDisposalComponent.UpdateAndCheckDispose(Characters, gameTime);
            }
            else
            {
                masterInput.Update(false);
                //do whatever necessary to STOP stuff, including time!
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MediumAquamarine);
            testUI.Draw(spriteBatch);
            interactThingy.Draw(spriteBatch);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);
            foreach (Character character in Characters)
            {
                character.Draw(spriteBatch, camera, gameTime, 0.1f);
            }
            foreach (Particle particle in Particles)
            {
                particle.Draw(spriteBatch, camera, gameTime, .1f);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
