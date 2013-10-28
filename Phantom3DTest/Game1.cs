using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Phantom;

namespace Phantom3DTest
{
    public class Game1 : PhantomGame
    {
        public Game1()
            :base(550, 400, "Phantom 3D Test")
        {
        }

        public override void SetupGraphics()
        {
            base.SetupGraphics();
            this.graphics.IsFullScreen = false;
            XnaGame.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }
    }
}
