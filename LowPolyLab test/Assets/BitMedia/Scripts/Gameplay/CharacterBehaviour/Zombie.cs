using System.Collections;
using UnityEngine;

namespace BitMedia.TestProject.Gameplay.CharacterBehaviour
{
    [RequireComponent(typeof(Animator))]
    public class Zombie : Character
    {
        protected override void StartMovementSetup()
        {
            _animator.applyRootMotion = false;
            _animator.SetInteger("zombieWalkIndex", 1);
        }
        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * _speedMultiplier * Time.fixedDeltaTime);
        }
    }
}

