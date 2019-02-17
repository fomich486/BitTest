using UnityEngine;
using System.Collections;
using BitMedia.TestProject.Gameplay.CharacterBehaviour;
using BitMedia.TestProject.Service;

namespace BitMedia.TestProject.Gameplay.ProjectileBehavoiur
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        private float _lifeTime = 7f;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            StartCoroutine(DestroyCoroutine());
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void StartProjectileInertia(Vector3 direction, float force)
        {
            direction = direction.normalized;
            _rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }
        private void OnCollisionEnter(Collision collision)
        {
            Character character = collision.transform.GetComponent<Character>();
            if (character != null)
            {
                InteractWithCharecter(character);
                UI.Instance.AddPoints(character.Points);
                Die();
            }
        }
        //TODO: Should i make Projectile class and this metode abstract?
        protected virtual void InteractWithCharecter(Character character)
        {
            print("Charecter hited");
            return;
        }
        private void Die()
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
        private IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSecondsRealtime(_lifeTime);
            Die();
        }
    }
}
