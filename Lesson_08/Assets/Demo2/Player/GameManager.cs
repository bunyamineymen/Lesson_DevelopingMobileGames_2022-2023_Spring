using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton

    public static GameManager instance;

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


    private GameState gameState = GameState.MainMenu;

    public ParticleSystem particleSystem;

    public bool IsSessionPlaying => gameState == GameState.SessionIsPlaying;



    #region Callback

    private void OnGameStateChange(GameState _gameState)
    {
        gameState = _gameState;

        if (gameState == GameState.MainMenu)
        {
            particleSystem.Play();
        }
    }

    #endregion

}

public enum GameState
{
    SessionIsPlaying,
    MainMenu
}
