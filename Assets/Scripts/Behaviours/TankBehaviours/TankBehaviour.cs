using Assets.Scripts.Tank;
using System;
using UnityEngine;

public class TankBehaviour : MonoBehaviour, ITank
{

    public bool IsAlive => m_Health.IsAlive;

    public Vector3 Position => transform.position;

    private TankMoveControllerBehaviour m_Movement;                        // Reference to tank's movement script, used to disable and enable control.
    private TankShootingControlelrBehaviour m_Shooting;                        // Reference to tank's shooting script, used to disable and enable control.
    private DamagableBehaviour m_Health;                        // Reference to tank's health script, used to disable and enable control.
    private GameObject m_CanvasGameObject;                  // Used to disable the world space UI during the Starting and Ending phases of each round.

    public event Action<ITank> OnDeath;

    public void Awake()
    {
        // Get references to the components.
        m_Movement = GetComponent<TankMoveControllerBehaviour>();
        m_Shooting = GetComponent<TankShootingControlelrBehaviour>();
        m_Health = GetComponent<DamagableBehaviour>();
        m_CanvasGameObject = GetComponentInChildren<Canvas>().gameObject;

        m_Health.OnDeath += OnDeathEventHandler;
    }


    // Used during the phases of the game where the player shouldn't be able to control their tank.
    public void DisableControl ()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        m_CanvasGameObject.SetActive (false);
    }


    // Used during the phases of the game where the player should be able to control their tank.
    public void EnableControl ()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        m_CanvasGameObject.SetActive (true);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void Revive()
    {
        gameObject.SetActive(true);
        m_Health.Revive();
    }

    private void OnDeathEventHandler()
    {
        OnDeath?.Invoke(this);
    }
}