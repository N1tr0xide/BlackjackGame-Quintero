using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerPlayer : Player
{
    private GameManager _gameManager;
    [SerializeField] GameObject _computerHandUI;

    private GameObject _faceDownCardGameObject;
    private Sprite _faceDownCard;
    
    // Start is called before the first frame update
    void Start()
    {
        HandValue = 0;
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GetRandomCard(_gameManager.Deck, _computerHandUI.transform);
        UpdateHandValueUI();
        GetFaceDownRandomCard(_gameManager, _computerHandUI.transform, out _faceDownCardGameObject, out _faceDownCard);
    }

    public void ComputersTurn()
    {
        _faceDownCardGameObject.GetComponent<Image>().sprite = _faceDownCard;
        
        while (HandValue < 17 && Hand.Count < 5)
        {
            GetRandomCard(_gameManager.Deck, _computerHandUI.transform);
        }
        
        UpdateHandValueUI();
        _gameManager.CompareScores();
    }
}
