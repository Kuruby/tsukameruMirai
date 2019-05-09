using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.BaseObjects;
using yumeTakusan.Components;
using yumeTakusan.Interfaces;
using yumeTakusan.YumeCamera;
using yumeTakusan.ContentManagment;

namespace yumeTakusan.GameObjects
{
    /// <summary>
    /// Particles are small, temporary in-game flashes of light often used to add flair to somethinga
    /// </summary>
    public class Particle : GameProp, Interfaces.IDrawable, IDisposalFlag
    {
        /// <summary>
        /// Creates a particle at a specific location
        /// </summary>
        /// <param name="Location">Where to create the particle</param>
        /// <param name="TimeToLive">how long (in ms) the particle is to exist</param>
        public Particle(Vector2 Location = default, int TimeToLive = 500) : base(Location)
        {
            timeToLive = TimeToLive;
            drawComponent = new DrawComponent(this);
        }

        /// <summary>
        /// Random for generation of particles within an area
        /// </summary>
        static readonly Random rand = new Random();

        /// <summary>
        /// Generates a particle at a random spot within a rectangle
        /// </summary>
        /// <param name="WithinRectangle">rectangle within which to generate particle</param>
        /// <param name="TimeToLive">how long (in ms) the particle is to exist</param>
        public Particle(Rectangle WithinRectangle, int TimeToLive = 500)
            : this(
                  new Vector2(rand.Next(WithinRectangle.Left, WithinRectangle.Right),
                      rand.Next(WithinRectangle.Top, WithinRectangle.Bottom)),
                  TimeToLive)
        { }

        /// <summary>
        /// grabs sprites for particles
        /// </summary>
        /// <param name="Content">content to grab particle sprites from</param>
        public static void AfterContentLoadInit(ContentStorageManager Content)
        {
            var ParticleTextures = Content.GetTaggedContentWithMetadata<Texture2D>("particle");
            foreach (Content content in ParticleTextures)
            {
                particleTextures.Add(content.Identifier, (Texture2D)content._Content);
            }
        }

        /// <summary>
        /// All particle textures
        /// </summary>
        private static readonly Dictionary<string, Texture2D> particleTextures = new Dictionary<string, Texture2D>();


        /// <summary>
        /// Performs drawing for the particle
        /// </summary>
        readonly DrawComponent drawComponent;

        /// <summary>
        /// Time for the particle to live, in milliseconds
        /// </summary>
        int timeToLive;

        /// <summary>
        /// Whether the particle is to be disposed
        /// </summary>
        public bool disposed { get; protected set; }

        /// <summary>
        /// The sprite effects to be applied (none by default)
        /// </summary>
        public SpriteEffects Effects { get; set; } = SpriteEffects.None;
        /// <summary>
        /// The colour for the particle
        /// </summary>
        public Color Color { get; set; } = Color.White;

        /// <summary>
        /// The texture for the particle
        /// </summary>
        public Texture2D Texture => null;//No particle textures yet

        /// <summary>
        /// Particle update:
        /// (maybe motion?) and disposal check
        /// </summary>
        /// <param name="gameTime">Timing parameter</param>
        public override void Update(GameTime gameTime)
        {
            //eval ttl and dispose if it's less than or equal to 0
            timeToLive -= gameTime.ElapsedGameTime.Milliseconds;
            //fade away over the last 400ms (frames at 60fps are ~16.666ms for a total of 24 frames before it dies)\
            //As this is less than the 1% fade time (28.333 frames), it disappears nicely
            //(fades to 2% total, not counting integer conv)
            if (timeToLive < 400)
            {
                Color = new Color((byte)(Color.R * .85f), (byte)(Color.G * .85f), (byte)(Color.B * .85f), (byte)(Color.A * .85f));
            }
            if (timeToLive <= 0)
            {
                disposed = true;
            }
        }

        /// <summary>
        /// Draws the particle
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="camera"></param>
        /// <param name="gameTime"></param>
        /// <param name="layerDepth"></param>
        public void Draw(SpriteBatch spriteBatch, Camera camera, GameTime gameTime, float layerDepth)
        {
            drawComponent.Draw(spriteBatch, camera, gameTime, layerDepth);
        }
    }
}
