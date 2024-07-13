using Assets.Scripts.Tank;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float m_DampTime = 0.2f;
    [SerializeField] private float m_ScreenEdgeBuffer = 4f;
    [SerializeField] private float m_MinSize = 6.5f;

    private ITank[] _targets;
    private Camera _camera;                        
    private float _zoomSpeed;                      
    private Vector3 _moveVelocity;                 
    private Vector3 _desiredPosition;              

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }


    public void SetTargets(IEnumerable<ITank> targets)
    {
        _targets = targets.ToArray();
    }

    private void FixedUpdate()
    {
        Move();
        Zoom();
    }


    private void Move()
    {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, _desiredPosition, ref _moveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < _targets.Length; i++)
        {
            if (!_targets[i].IsAlive)
                continue;

            averagePos += _targets[i].Position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;
        _desiredPosition = averagePos;
    }


    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, requiredSize, ref _zoomSpeed, m_DampTime);
    }


    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(_desiredPosition);
        float size = 0f;

        for (int i = 0; i < _targets.Length; i++)
        {
            if (!_targets[i].IsAlive)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(_targets[i].Position);
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;
            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));
            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / _camera.aspect);
        }
        
        size += m_ScreenEdgeBuffer;
        size = Mathf.Max(size, m_MinSize);

        return size;
    }


    public void SetToStartPositionAndSize()
    {
        FindAveragePosition();
        transform.position = _desiredPosition;
        _camera.orthographicSize = FindRequiredSize();
    }
}