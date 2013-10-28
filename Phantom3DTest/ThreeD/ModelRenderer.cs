using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phantom.Core;
using Microsoft.Xna.Framework.Graphics;
using Phantom;
using Microsoft.Xna.Framework;
using Phantom.Graphics;

namespace Phantom3DTest.ThreeD
{
    public class ModelRenderer : Component
    {
        private Model model;
        private Layer3D layer;

        private Vector3 position;
        public Vector3 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
                ResetWorld();
            }
        }

        private Vector3 rotation;
        public Vector3 Rotation
        {
            get
            {
                return this.rotation;
            }
            set
            {
                this.rotation = value;
                ResetWorld();
            }
        }

        private float scale;
        public float Scale
        {
            get
            {
                return this.scale;
            }
            set
            {
                this.scale = value;
                ResetWorld();
            }
        }

        private Matrix world;

        public ModelRenderer(Model model, Vector3 position, Vector3 rotation, float scale = 1f)
        {
            this.model = model;
            this.Position = position;
            this.Rotation = rotation;
            this.Scale = scale;
        }

        public ModelRenderer(string assetName, Vector3 position, Vector3 rotation, float scale = 1f)
            : this(PhantomGame.Game.Content.Load<Model>(assetName), position, rotation, scale)
        {
        }

        public override void OnAdd(Component parent)
        {
            base.OnAdd(parent);
            this.layer = parent as Layer3D;
            if (this.layer == null)
                throw new Exception("ModelRenderer object must be added to a Layer3D instance!");
        }

        private void ResetWorld()
        {
            this.world = Matrix.CreateRotationX(this.rotation.X) * Matrix.CreateRotationY(this.rotation.Y) * Matrix.CreateRotationZ(this.rotation.Z) * Matrix.CreateScale(this.scale) * Matrix.CreateTranslation(this.position);
        }

        public override void Render(RenderInfo info)
        {
            Matrix[] transforms = new Matrix[this.model.Bones.Count];
            this.model.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in this.model.Meshes)
            {

                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] * world;
                    effect.View = this.layer.Camera.View;
                    effect.Projection = this.layer.Camera.Projection;
                }

                mesh.Draw();
            }
            base.Render(info);
        }
    }
}
