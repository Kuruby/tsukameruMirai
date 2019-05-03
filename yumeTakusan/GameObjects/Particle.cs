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
    public class Particle : GameProp, Interfaces.IDrawable
    {
        public Particle(Vector2 Location = default, int TimeToLive = 500) : base(Location)
        {
            timeToLive = TimeToLive;
            drawComponent = new DrawComponent(this);
        }

        static Random rand = new Random();
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
        private static Dictionary<string, Texture2D> particleTextures = new Dictionary<string, Texture2D>();


        /// <summary>
        /// Performs drawing for the particle
        /// </summary>
        DrawComponent drawComponent;

        /// <summary>
        /// Time for the particle to live, in milliseconds
        /// </summary>
        int timeToLive;

        /// <summary>
        /// Whether the particle is to be disposed
        /// </summary>
        bool disposed = false;
        public SpriteEffects Effects { get; set; } = SpriteEffects.None;
        public Color Color { get; set; } = Color.White;

        public Texture2D Texture => null;//No particle textures yet

        /// <summary>
        /// Particle update:
        /// (maybe motion?) and disposal check
        /// </summary>
        /// <param name="gameTime"></param>
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

        public void Draw(SpriteBatch spriteBatch, Camera camera, GameTime gameTime, float layerDepth)
        {
            drawComponent.Draw(spriteBatch, camera, gameTime, layerDepth);
        }

        public static void Update(List<Particle> Particles, GameTime gameTime)
        {
            foreach (Particle particle in Particles)
            {
                particle.Update(gameTime);
            }
        }

        public static void CheckDispose(List<Particle> Particles)
        {
            List<Particle> DisposalList = new List<Particle>();
            foreach (Particle particle in Particles)
            {
                if (particle.disposed)
                {
                    DisposalList.Add(particle);
                }
            }
            foreach (Particle particle in DisposalList)
            {
                Particles.Remove(particle);
            }
        }

        public static void UpdateAndCheckDispose(List<Particle> Particles, GameTime gameTime)
        {
            List<Particle> DisposalList = new List<Particle>();
            foreach (Particle particle in Particles)
            {
                particle.Update(gameTime);
                if (particle.disposed)
                {
                    DisposalList.Add(particle);
                }
            }
            foreach (Particle particle in DisposalList)
            {
                Particles.Remove(particle);
            }
        }
    }
}
