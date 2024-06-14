using System;
using UnityEngine;

public class Tank
{
    public Color PlayerColor { get; private set; }                                                  
    public int PlayerNumber { get; private set; }
    public GameObject GameObjectInstance { get; set; }         


    private TankMoveControllerBehaviour m_Movement;                        // Reference to tank's movement script, used to disable and enable control.
    private TankShootingControlelrBehaviour m_Shooting;                        // Reference to tank's shooting script, used to disable and enable control.
    private GameObject m_CanvasGameObject;                  // Used to disable the world space UI during the Starting and Ending phases of each round.

    public void Setup(GameObject tankInstance, Color color, int playerNumber)
    {
        PlayerColor = color;
        PlayerNumber = playerNumber;
        GameObjectInstance = tankInstance;

        // Get references to the components.
        m_Movement = GameObjectInstance.GetComponent<TankMoveControllerBehaviour>();
        m_Shooting = GameObjectInstance.GetComponent<TankShootingControlelrBehaviour>();
        m_CanvasGameObject = GameObjectInstance.GetComponentInChildren<Canvas>().gameObject;

        // Set the player numbers to be consistent across the scripts.
        m_Movement.m_PlayerNumber = PlayerNumber;
        m_Shooting.m_PlayerNumber = PlayerNumber;

        // Get all of the renderers of the tank.
        MeshRenderer[] renderers = GameObjectInstance.GetComponentsInChildren<MeshRenderer>();

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
}