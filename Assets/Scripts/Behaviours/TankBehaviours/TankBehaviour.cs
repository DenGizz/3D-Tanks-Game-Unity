using Assets.Scripts.Tank;
using System;
using UnityEngine;

public class TankBehaviour : MonoBehaviour, ITank
{
    public Color PlayerColor { get; private set; }                                                  
    public int PlayerNumber { get; private set; }

    public bool IsAlive => m_Health.IsAlive;

    public Vector3 Position => transform.position;

    private TankMoveControllerBehaviour m_Movement;                        // Reference to tank's movement script, used to disable and enable control.
    private TankShootingControlelrBehaviour m_Shooting;                        // Reference to tank's shooting script, used to disable and enable control.
   private DamagableBehaviour m_Health;                        // Reference to tank's health script, used to disable and enable control.
    private GameObject m_CanvasGameObject;                  // Used to disable the world space UI during the Starting and Ending phases of each round.

    public void Setup(Color color, int playerNumber)
    {
        PlayerColor = color;
        PlayerNumber = playerNumber;

        // Get references to the components.
        m_Movement = GetComponent<TankMoveControllerBehaviour>();
        m_Shooting = GetComponent<TankShootingControlelrBehaviour>();
        m_Health = GetComponent<DamagableBehaviour>();
        m_CanvasGameObject = GetComponentInChildren<Canvas>().gameObject;

        // Set the player numbers to be consistent across the scripts.
        m_Movement.m_PlayerNumber = PlayerNumber;
        m_Shooting.m_PlayerNumber = PlayerNumber;

        // Get all of the renderers of the tank.
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        // Go through all the renderers...
        for (int i = 0; i < renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            renderers[i].material.color = PlayerColor;
        }
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
}