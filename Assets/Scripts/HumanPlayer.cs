using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    private GameManager _gameManager;
    [SerializeField] private GameObject _playerHandUI;

    // Start is called before the first frame update
    void Start()
    {
        HandValue = 0;
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        HitButton();
        HitButton();
    }

    public void HitButton()
    {
        if (!_gameManager.IsPlayerTurn) return;
            
        GetRandomCard(_gameManager.Deck, _playerHandUI.transform);
        UpdateHandValueUI();
        CheckState();
    }

    private void CheckState()
    {
        if(HandValue > 21)
        {
            print("Busted!");
            _gameManager.EndPlayerTurn();
        }
        else if(Hand.Count >= 5)
        {
            print("all cards drawn");
            _gameManager.EndPlayerTurn();
        }
    }

    public void StayButton()
    {
        _gameManager.EndPlayerTurn();
    }
}
