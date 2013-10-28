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
using Phantom.Core;
using Phantom3DTest.ThreeD;

namespace Phantom3DTest
{
    public class Game1 : PhantomGame
    {
        private ModelRenderer mr;
        private float timer;
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
            GameState gs = new GameState();
            Layer3D l = new Layer3D();
            l.AddComponent(this.mr = new ModelRenderer("suzanne", Vector3.Zero, Vector3.Zero, 2));
            gs.AddComponent(l);
            PushState(gs);
        }

        public override void Update(float elapsed)
        {
            mr.Rotation = mr.Rotation + Vector3.UnitY * elapsed;
            this.timer += elapsed;
            if (this.timer > 4.5f)
            {
                mr.Rotation = mr.Rotation + Vector3.UnitZ * MathHelper.TwoPi * elapsed * 2;
                if (this.timer > 5f)
                {
                    mr.Rotation = new Vector3(mr.Rotation.X, mr.Rotation.Y, 0);
                    this.timer = (float)PhantomGame.Randy.NextDouble();
                }
            }
            base.Update(elapsed);
        }
    }
}
