using System.Collections;
using UnityEngine;

namespace BitMedia.TestProject.Gameplay.CharacterBehaviour
{
    [RequireComponent(typeof(Animator))]
    public class Character : MonoBehaviour
    {
        public int Points;
        [SerializeField] private float _lifetime = 15f;
        [SerializeField]
        [Range(0.1f,2f)]
        protected float _speedMultiplier;
        [SerializeField]
        private SkinnedMeshRenderer _skinMeshRenderer;
        [SerializeField]
        private Material _standartMaterial;
        protected Animator _animator;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            StartCoroutine(DestroyCoroutine());
            StartMovementSetup();
            SetSpeedMultiplier();
        }
  
        protected virtual void StartMovementSetup()
        {
            _animator.SetInteger("humanWalkIndex", 1);
        }

        private void SetSpeedMultiplier()
        {
            _animator.SetFloat("speedMultiplier", _speedMultiplier);
        }

        private IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSecondsRealtime(_lifetime);
            BackInPoolSetup();
        }

        public void BackInPoolSetup()
        {
            _skinMeshRenderer.material = _standartMaterial;
            transform.localScale = Vector3.one;
            gameObject.SetActive(false);
        }

        public void ChangeColor(Material newMaterial)
        {
            _skinMeshRenderer.material = newMaterial;
        }
    }
}
