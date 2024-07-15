using Assets.Scripts.Domain;
using Assets.Scripts.Features.InputSources;
using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Behaviours.TankBehaviours
{
    public class TankShootingControlelrBehaviour : MonoBehaviour, IInputReader
    {
        [SerializeField] private Transform _fireTransform;
        [SerializeField] private Slider _aimSlider;

        [SerializeField] private AudioClip _chargeAudioClip;
        [SerializeField] private AudioClip _fireAudioClip;
        [SerializeField] private float m_MinLaunchForce = 15f;       
        [SerializeField] private float m_MaxLaunchForce = 30f; 
        [SerializeField] private float m_MaxChargeTime = 0.75f;

        private float _currentLaunchForce;         // The force that will be given to the shell when the fire button is released.
        private float _chargeSpeed;                // How fast the launch force increases, based on the max charge time.
        private bool _isFired;                       // Whether or not the shell has been launched with this button press.

        private IShellFactory _shellFactory;
        private IInputSource _inputSource;
        private AudioSource _audioSource;

        [Inject]
        public void Construct(IShellFactory shellFactory)
        {
            _shellFactory = shellFactory;
        }

        private void OnEnable()
        {
            // When the tank is turned on, reset the launch force and the UI
            _currentLaunchForce = m_MinLaunchForce;
            _aimSlider.value = m_MinLaunchForce;
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start ()
        {
            // The rate that the launch force charges up is the range of possible forces by the max charge time.
            _chargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
        }

        private void Update ()
        {
            // The slider should have a default value of the minimum launch force.
            _aimSlider.value = m_MinLaunchForce;

            // If the max force has been exceeded and the shell hasn't yet been launched...
            if (_currentLaunchForce >= m_MaxLaunchForce && !_isFired)
            {
                // ... use the max force and launch the shell.
                _currentLaunchForce = m_MaxLaunchForce;
                Fire ();
            }
            // Otherwise, if the fire button has just started being pressed...
            else if (_inputSource.GetFireButtonDown)
            {
                // ... reset the fired flag and reset the launch force.
                _isFired = false;
                _currentLaunchForce = m_MinLaunchForce;

                // Change the clip to the charging clip and start it playing.
                _audioSource.clip = _chargeAudioClip;
                _audioSource.Play ();
            }
            // Otherwise, if the fire button is being held and the shell hasn't been launched yet...
            else if (_inputSource.GetFireButton && !_isFired)
            {
                // Increment the launch force and update the slider.
                _currentLaunchForce += _chargeSpeed * Time.deltaTime;

                _aimSlider.value = _currentLaunchForce;
            }
            // Otherwise, if the fire button is released and the shell hasn't been launched yet...
            else if (_inputSource.GetFireButtonUp && !_isFired)
            {
                // ... launch the shell.
                Fire ();
            }
        }

        public void SetInputSource(IInputSource inputSource)
        {
            _inputSource = inputSource;
        }


        private void Fire ()
        {
            // Set the fired flag so only Fire is only called once.
            _isFired = true;


            IShell shell = _shellFactory.CreateShell(_fireTransform.position, _fireTransform.rotation);
            shell.Lunch(_fireTransform.forward, _currentLaunchForce);

            // Change the clip to the firing clip and play it.
            _audioSource.clip = _fireAudioClip;
            _audioSource.Play ();

            // Reset the launch force.  This is a precaution in case of missing button events.
            _currentLaunchForce = m_MinLaunchForce;
        }
    }
}