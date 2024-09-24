using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Features.Behaviours
{
    public class DealSplashDamageOnCollisionBehavior : MonoBehaviour
    {                     
        [SerializeField] private float _maxDamage = 100f;
        [SerializeField] float _explosionForce = 1000f;
        [SerializeField] float _explosionRadius = 5f; 

        private void OnTriggerEnter(Collider other)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

                if (!targetRigidbody)
                    continue;

                targetRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
                IDamagable damagable = targetRigidbody.GetComponent<IDamagable>();

                if (damagable == null)
                    continue;

                float damage = CalculateDamage(targetRigidbody.position);
                damagable.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        private float CalculateDamage(Vector3 targetPosition)
        {
            Vector3 explosionToTarget = targetPosition - transform.position;
            float explosionDistance = explosionToTarget.magnitude;
            float relativeDistance = (_explosionRadius - explosionDistance) / _explosionRadius;
            float damage = relativeDistance * _maxDamage;
            damage = Mathf.Max(0f, damage);

            return damage;
        }
    }
}
