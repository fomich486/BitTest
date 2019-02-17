using System;
using System.Collections.Generic;
using BitMedia.TestProject.Gameplay.ProjectileBehavoiur;
using UnityEngine;
using UnityEngine.UI;

namespace BitMedia.TestProject.Configs
{
    [Serializable]
    public class ShootConfig
    {
        public Transform MuzzleTransform;
        public List <Projectile> ProjectileList;
        public float MinImpulse = 5f;
        public float MaxImpulse = 10f;
        public Button ShootButton;
        public Button ChangeProjectileButton;
    }
}
