using System.Collections;
using UnityEngine;

namespace BitMedia.TestProject.Gameplay.CharacterBehaviour
{
    [RequireComponent(typeof(Animator))]
    public class StopMan : Character
    {
        [SerializeField]
        private float _timeBetweenStops ;
        [SerializeField]
        private float _timeWalk ;
        private float _nextWalkTime;
        private float _nextStopTime;
        private bool _isWalking = true;
        protected override void StartMovementSetup()
        {
            base.StartMovementSetup();
            _nextStopTime = Time.time + _timeBetweenStops;
            _nextWalkTime = Mathf.Infinity;
            _isWalking = true;
            
        }
        private void FixedUpdate()
        {
            if (_isWalking)
            {
                if (Time.time > _nextStopTime)
                {
                    _isWalking = !_isWalking;
                    _animator.SetInteger("humanWalkIndex", 0);
                    _nextWalkTime = Time.time + _timeBetweenStops;
                }
            }
            else {
                if (Time.time > _nextWalkTime)
                {
                    _isWalking = !_isWalking;
                    _animator.SetInteger("humanWalkIndex", 1);
                    _nextStopTime = Time.time + _timeWalk;
                }
            }
        }
    }
}
