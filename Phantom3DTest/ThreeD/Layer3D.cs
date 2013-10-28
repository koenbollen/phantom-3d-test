using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phantom.Core;
using Phantom;
using Microsoft.Xna.Framework.Graphics;
using Phantom.Graphics;
using Microsoft.Xna.Framework;

namespace Phantom3DTest.ThreeD
{
    public class Layer3D : Component
    {
        public Camera3D Camera { get; protected set; }

        public GraphicsDevice GraphicsDevice { get; protected set; }
        private Model model;

        public Layer3D()
        {
            this.AddComponent(new Camera3D());
#if DEBUG
            this.AddComponent(new Origin(5));
#endif
        }

        public override void OnAdd(Component parent)
        {
            this.GraphicsDevice = PhantomGame.Game.GraphicsDevice;

            this.model = PhantomGame.Game.Content.Load<Model>("suzanne");

            base.OnAdd(parent);
        }

        protected override void OnComponentAdded(Component child)
        {
            base.OnComponentAdded(child);
            if (child is Camera3D)
                this.Camera = (Camera3D)child;
        }

    }
}
