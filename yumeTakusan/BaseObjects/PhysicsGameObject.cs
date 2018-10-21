using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;

namespace yumeTakusan.BaseObjects
{
    class PhysicsGameObject : GameObject, IPhysicsObject
    {
        private float temperature;
        public float Temperature
        {
            get => temperature;
            set { temperature = value; }
        }


        private float mass;
        public float Mass
        {
            get => mass;
            set { mass = value; }
        }


        private Vector2 forceConstant;
        public Vector2 ForceConstant
        {
            get => forceConstant;
            set { forceConstant = value; }
        }
        public float ForceConstantXComponent
        {
            get => forceConstant.X;
            set { forceConstant.X = value; }
        }
        public float ForceConstantYComponent
        {
            get => forceConstant.Y;
            set { forceConstant.Y = value; }
        }

        private Vector2 force;
        public Vector2 Force
        {
            get => force;
            set { force = value; }
        }
        public float ForceXComponent
        {
            get => force.X;
            set { force.X = value; }
        }
        public float ForceYComponent
        {
            get => force.Y;
            set { force.Y = value; }
        }
    }
}
