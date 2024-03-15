using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CardDeck _cardDeck;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private ComputerPlayer _computerPlayer;
    [SerializeField] private HumanPlayer _humanPlayer;
    
    public Sprite CardCover { get; private set; }
    public List<Card> Deck { get; private set; }
    public bool IsPlayerTurn { get; private set; }

    private void Awake()
    {
        Deck = _cardDeck.Deck.ToList();
        CardCover = _cardDeck.CardCover;
        IsPlayerTurn = true;
    }

    public void EndPlayerTurn()
    {
        IsPlayerTurn = false;
        _computerPlayer.ComputersTurn();
    }

    public void CompareScores()
    {
        if (_computerPlayer.HandValue > 21) _computerPlayer.HandValue = 0;
        if (_humanPlayer.HandValue > 21) _humanPlayer.HandValue = 0;
        
        if (_humanPlayer.HandValue == _computerPlayer.HandValue)
        {
            _gameOverText.text = "It's a Tie";
        }
        else if (_humanPlayer.HandValue > _computerPlayer.HandValue)
        {
            _gameOverText.text = "You Won!";
        }
        else if (_humanPlayer.HandValue < _computerPlayer.HandValue)
        {
            _gameOverText.text = "You Lose";
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
