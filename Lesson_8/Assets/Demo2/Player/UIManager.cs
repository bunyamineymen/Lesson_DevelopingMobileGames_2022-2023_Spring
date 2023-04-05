using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region Singleton

    public static UIManager instance;

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    #region Monobehaviour

    private void Awake()
    {
        Singleton();
    }

    private void OnEnable()
    {
        DelegateStore.GameStateChange += OnGameStateChange;
    }



    private void OnDisable()
    {
        DelegateStore.GameStateChange -= OnGameStateChange;
    }

    #endregion

    public GameObject BtnPlayGame;


    public void PlayGame()
    {
        DelegateStore.GameStateChange?.Invoke(GameState.SessionIsPlaying);
    }

    #region Callback

    private void OnGameStateChange(GameState _gameState)
    {
        if (_gameState == GameState.SessionIsPlaying)
        {
            BtnPlayGame.SetActive(false);
        }
        else if (_gameState == GameState.MainMenu)
        {
            BtnPlayGame.SetActive(true);
        }

    }

    #endregion
}
