using UnityEngine;

namespace Assets.Scripts.Features.Behaviours
{
    public class ExplodeOnCollisionBehavior : MonoBehaviour
    {
        [SerializeField] private ParticleSystem m_ExplosionParticles;        
        [SerializeField] private AudioSource m_ExplosionAudio;

        private void OnTriggerEnter(Collider other)
        {
            PlayExplosion();
        }

        private void PlayExplosion()
        {
            m_ExplosionParticles.transform.parent = null;

            m_ExplosionParticles.Play();
            m_ExplosionAudio.Play();

            Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);
        }
    }
}
