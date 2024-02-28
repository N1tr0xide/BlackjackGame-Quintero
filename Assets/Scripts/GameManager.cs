using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CardDeck CardDeck;
    [SerializeField] private List<Card> deck;

    public Sprite cardCover { get; private set; }
    public List<Card> Deck { get {  return deck; } }
    public bool IsPlayerTurn { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        deck = CardDeck.Deck.ToList();
        cardCover = CardDeck.CardCover;
        IsPlayerTurn = true;
    }

    public void EndPlayerTurn()
    {
        IsPlayerTurn = false;
        //run rest of computers turn
    }
}
