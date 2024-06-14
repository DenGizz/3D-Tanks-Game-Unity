using Assets.Scripts.Infrasctucture;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Ui;
using Assets.Scripts.UI;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    public GameObject m_TankPrefab;             // Reference to the prefab the players will control.

    private int m_RoundNumber;                  // Which round the game is currently on.
    private WaitForSeconds m_StartWait;         // Used to have a delay whilst the round starts.
    private WaitForSeconds m_EndWait;           // Used to have a delay whilst the round or game ends.
    private Tank m_RoundWinner;          // Reference to the winner of the current round.  Used to make an announcement of who won.
    private Tank m_GameWinner;           // Reference to the winner of the game.  Used to make an announcement of who won.

    private ITankFactory _tankFactory;
    private ITanksProvider _tanksProvider;
    private IUiFactory _uiFactory;
    private IUiProvider _uiProvider;
    private ICameraControlProvider _cameraControlProvider;
    private ILevelSpawnPointsProvider _levelSpawnPointsProvider;
    private ICoroutineRunner _coroutineRunner;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(ITankFactory tankFactory, ITanksProvider tanksProvider,
        IUiFactory uiFactory, IUiProvider uiProvider, 
        ICameraControlProvider cameraControlProvider, 
        ILevelSpawnPointsProvider levelSpawnPointsProvider, 
        ICoroutineRunner coroutineRunner, IStaticDataService staticDataService)
    {
        _tankFactory = tankFactory;
        _tanksProvider = tanksProvider;
        _uiFactory = uiFactory;
        _uiProvider = uiProvider;
        _cameraControlProvider = cameraControlProvider;
        _levelSpawnPointsProvider = levelSpawnPointsProvider;
        _coroutineRunner = coroutineRunner;
        _staticDataService = staticDataService;
    }


    private void Start()
    {
        // Create the delays so they only have to be made once.
        m_StartWait = new WaitForSeconds (_staticDataService.BattleSessionConfig.StartDelay);
        m_EndWait = new WaitForSeconds (_staticDataService.BattleSessionConfig.EndDelay);

        _uiProvider.MessagesUi = _uiFactory.CreateMessagesUi();
        _cameraControlProvider.Initialize();
        _levelSpawnPointsProvider.Initialize();
        _coroutineRunner.Initialize();


        SpawnAllTanks();
        SetCameraTargets();

        // Once the tanks have been created and the camera is using them as targets, start the game.
        _coroutineRunner.StartCoroutine(GameLoop ());
    }


    private void SpawnAllTanks()
    {
        Tank tank1 = _tankFactory.CreateTank(_levelSpawnPointsProvider.SpawnPoints.ElementAt(1), Color.blue, 1);
        Tank tank2 = _tankFactory.CreateTank(_levelSpawnPointsProvider.SpawnPoints.ElementAt(0), Color.red, 2);

        _tanksProvider.AddTank(tank1);
        _tanksProvider.AddTank(tank2);
    }


    private void SetCameraTargets()
    {
        _cameraControlProvider.CameraControl.m_Targets = _tanksProvider.Tanks.Select(t => t.GameObjectInstance.transform).ToArray();
    }


    // This is called from start and will run each phase of the game one after another.
    private IEnumerator GameLoop ()
    {
        // Start off by running the 'RoundStarting' coroutine but don't return until it's finished.
        yield return _coroutineRunner.StartCoroutine(RoundStarting ());

        // Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
        yield return _coroutineRunner.StartCoroutine(RoundPlaying());

        // Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
        yield return _coroutineRunner.StartCoroutine (RoundEnding());

        // This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
        if (m_GameWinner != null)
        {
            // If there is a game winner, restart the level.
            Application.LoadLevel (Application.loadedLevel);
        }
        else
        {
            // If there isn't a winner yet, restart this coroutine so the loop continues.
            // Note that this coroutine doesn't yield.  This means that the current version of the GameLoop will end.
            _coroutineRunner.StartCoroutine (GameLoop ());
        }
    }


    private IEnumerator RoundStarting ()
    {
        // As soon as the round starts reset the tanks and make sure they can't move.
        ResetAllTanks ();
        DisableTankControl ();

        // Snap the camera's zoom and position to something appropriate for the reset tanks.
        _cameraControlProvider.CameraControl.SetStartPositionAndSize ();

        // Increment the round number and display text showing the players what round it is.
        m_RoundNumber++;
        _uiProvider.MessagesUi.Text = "ROUND " + m_RoundNumber;

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return m_StartWait;
    }


    private IEnumerator RoundPlaying ()
    {
        // As soon as the round begins playing let the players control the tanks.
        EnableTankControl ();

        // Clear the text from the screen.
        _uiProvider.MessagesUi.Text = string.Empty;

        // While there is not one tank left...
        while (!OneTankLeft())
        {
            // ... return on the next frame.
            yield return null;
        }
    }


    private IEnumerator RoundEnding ()
    {
        // Stop tanks from moving.
        DisableTankControl ();

        // Clear the winner from the previous round.
        m_RoundWinner = null;

        // See if there is a winner now the round is over.
        m_RoundWinner = GetRoundWinner ();

        // If there is a winner, increment their score.
        if (m_RoundWinner != null)
            m_RoundWinner.m_Wins++;

        // Now the winner's score has been incremented, see if someone has one the game.
        m_GameWinner = GetGameWinner ();

        // Get a message based on the scores and whether or not there is a game winner and display it.
        string message = EndMessage ();
        _uiProvider.MessagesUi.Text = message;

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return m_EndWait;
    }


    // This is used to check if there is one or fewer tanks remaining and thus the round should end.
    private bool OneTankLeft()
    {
        return _tanksProvider.Tanks.Count(t => t.GameObjectInstance.activeSelf) <= 1;
    }


    // This function is to find out if there is a winner of the round.
    // This function is called with the assumption that 1 or fewer tanks are currently active.
    private Tank GetRoundWinner()
    {
        return  _tanksProvider.Tanks.FirstOrDefault(t => t.GameObjectInstance.activeSelf);
    }


    // This function is to find out if there is a winner of the game.
    private Tank GetGameWinner()
    {
        return _tanksProvider.Tanks.FirstOrDefault(t => t.m_Wins == _staticDataService.BattleSessionConfig.NumRoundsToWin);
    }


    // Returns a string message to display at the end of each round.
    private string EndMessage()
    {
        // By default when a round ends there are no winners so the default end message is a draw.
        string message = "DRAW!";

        // If there is a winner then change the message to reflect that.
        if (m_RoundWinner != null)
            message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

        // Add some line breaks after the initial message.
        message += "\n\n\n\n";

        foreach (Tank tank in _tanksProvider.Tanks)
            message += tank.m_ColoredPlayerText + ": " + tank.m_Wins + " WINS\n";

        // If there is a game winner, change the entire message to reflect that.
        if (m_GameWinner != null)
            message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

        return message;
    }


    // This function is used to turn all the tanks back on and reset their positions and properties.
    private void ResetAllTanks()
    {
        foreach (Tank tank in _tanksProvider.Tanks)
            tank.Reset();
    }


    private void EnableTankControl()
    {
        foreach (Tank tank in _tanksProvider.Tanks)
            tank.EnableControl();
    }


    private void DisableTankControl()
    {
        foreach (Tank tank in _tanksProvider.Tanks)
            tank.DisableControl();
    }
}