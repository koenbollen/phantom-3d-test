using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phantom.Core;
using Microsoft.Xna.Framework;
using Phantom;

namespace Phantom3DTest.ThreeD
{
    public class Camera3D : Component
    {
        public Matrix View { get; protected set; }
        public Matrix Projection { get; protected set; }

        private float timer;

        public Camera3D()
        {
            View = Matrix.CreateLookAt(new Vector3(2, 5, 10), Vector3.Zero, Vector3.Up);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, PhantomGame.Game.GraphicsDevice.Viewport.AspectRatio, 1.0f, 1000.0f);
        }

        public override void Update(float elapsed)
        {
            this.timer += elapsed;
            View = Matrix.CreateLookAt(new Vector3(2, 5 + ((float)Math.Sin(this.timer*.2f)*5), 10), Vector3.Zero, Vector3.Up);
            base.Update(elapsed);
        }
    }
}
