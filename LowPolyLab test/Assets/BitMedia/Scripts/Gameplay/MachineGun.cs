using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BitMedia.TestProject.Configs;
using BitMedia.TestProject.Gameplay.ProjectileBehavoiur;

namespace BitMedia.TestProject.Gameplay
{
    public class MachineGun
    {
        private Transform _muzzleTransform;
        private Queue<Projectile> _projectileQueue = new Queue<Projectile>();
        private Projectile _currentProjectile;
        private float _minImpulse = 5f;
        private float _maxImpulse = 10f;

        private void Shoot()
        {
            Projectile tempProjectile = MonoBehaviour.Instantiate(_currentProjectile, _muzzleTransform.position,Quaternion.identity);
            float _shootForce = Random.Range(_minImpulse, _maxImpulse);
            tempProjectile.StartProjectileInertia(_muzzleTransform.up, _shootForce);
        }
        public MachineGun(ShootConfig shootConfig)
        {
            _muzzleTransform = shootConfig.MuzzleTransform;
            foreach (Projectile p in shootConfig.ProjectileList)
            {
                _projectileQueue.Enqueue(p);
            }
            ChangeProjectile();
            _minImpulse = shootConfig.MinImpulse;
            _maxImpulse = shootConfig.MaxImpulse;
            shootConfig.ShootButton.onClick.AddListener(Shoot);
            shootConfig.ChangeProjectileButton.onClick.AddListener(ChangeProjectile);
        }

        private void ChangeProjectile()
        {
            Projectile proj = _projectileQueue.Dequeue();
            _currentProjectile = proj;
            _projectileQueue.Enqueue(proj);
        }

    }
}
