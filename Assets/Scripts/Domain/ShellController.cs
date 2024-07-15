using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class ShellController : IShell
    {
        public Vector3 Position
        {
            get => _transform.position;
            set => _transform.position = value;
        }

        public Quaternion Rotation
        {
            get => _transform.rotation; 
            set => _transform.rotation = value;
        }


        private readonly GameObject _gameObject;
        private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;

        public ShellController(GameObject gameObject)
        {
            _gameObject = gameObject;
            _transform = gameObject.transform;
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }
        public void Lunch(Vector3 direction, float force)
        {
            _rigidbody.velocity = force * direction;
        }
    }
}
