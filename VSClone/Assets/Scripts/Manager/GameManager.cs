using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        //if (Instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //ChangeState(GameState.PlayerWalk);
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.PlayerWalk:
                break;
            case GameState.GenerateGrid:
                GridManager.instance.TurnOnTiles();
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    PlayerWalk,    //When the player is in control
    GenerateGrid,   //This is essentially base build
    SupplierMenu
}
