using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phantom.Core;
using Microsoft.Xna.Framework.Graphics;
using Phantom;
using Microsoft.Xna.Framework;

namespace Phantom3DTest.ThreeD
{
    public class Origin : Component
    {
        private Layer3D layer;
        private BasicEffect effect;

        private VertexPositionColor[] vertices;

        public Origin( float scale )
        {
            this.effect = new BasicEffect(PhantomGame.Game.GraphicsDevice);
            vertices = new VertexPositionColor[6];
            vertices[0] = new VertexPositionColor(Vector3.Zero, Color.Red);
            vertices[1] = new VertexPositionColor(Vector3.UnitX * scale, Color.Red);
            vertices[2] = new VertexPositionColor(Vector3.Zero, Color.Green);
            vertices[3] = new VertexPositionColor(Vector3.UnitY * scale, Color.Green);
            vertices[4] = new VertexPositionColor(Vector3.Zero, Color.Blue);
            vertices[5] = new VertexPositionColor(Vector3.UnitZ * scale, Color.Blue);
        }

        public override void OnAdd(Component parent)
        {
            base.OnAdd(parent);
            this.layer = parent as Layer3D;
            if (this.layer == null)
                throw new Exception("Origin object must be added to a Layer3D instance!");
        }

        public override void Render(Phantom.Graphics.RenderInfo info)
        {
            this.effect.View = this.layer.Camera.View;
            this.effect.Projection = this.layer.Camera.Projection;
            this.effect.VertexColorEnabled = true;

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                layer.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices, 0, 3);
            }
            base.Render(info);
        }
    }
}
