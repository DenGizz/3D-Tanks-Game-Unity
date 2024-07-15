using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Features.Behaviours
{
    public class DealSplashDamageOnCollisionBehavior : MonoBehaviour
    {
        public LayerMask m_TankMask;                        
        public float m_MaxDamage = 100f;                   
        public float m_ExplosionForce = 1000f; 
        public float m_ExplosionRadius = 5f; 

        private void OnTriggerEnter(Collider other)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

                if (!targetRigidbody)
                    continue;

                targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
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
            float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
            float damage = relativeDistance * m_MaxDamage;
            damage = Mathf.Max(0f, damage);

            return damage;
        }
    }
}
