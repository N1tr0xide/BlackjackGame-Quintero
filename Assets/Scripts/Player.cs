using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Text _handValueText;
    
    public List<Card> Hand = new List<Card>();
    public int HandValue { get; set; }

    protected void GetRandomCard(List<Card> deck, Transform parentUI)
    {
        int randomIndex = Random.Range(0, deck.Count - 1);
        Card cardDrawn = deck[randomIndex];

        Hand.Add(cardDrawn);
        HandValue += CheckCardValue(cardDrawn);
        deck.Remove(cardDrawn);
        
        _cardPrefab.GetComponent<Image>().sprite = cardDrawn.sprite;
        Instantiate(_cardPrefab, parentUI);
    }
    
    protected void GetFaceDownRandomCard(GameManager manager, Transform parentUI, out GameObject cardGameObject, out Sprite drawnCard)
    {
        int randomIndex = Random.Range(0, manager.Deck.Count - 1);
        Card cardDrawn = manager.Deck[randomIndex];
        drawnCard = cardDrawn.sprite;
        
        Hand.Add(cardDrawn);
        HandValue += CheckCardValue(cardDrawn);
        manager.Deck.Remove(cardDrawn);
        
        _cardPrefab.GetComponent<Image>().sprite = manager.CardCover;
        GameObject card = Instantiate(_cardPrefab, parentUI);
        cardGameObject = card;
    }

    protected void UpdateHandValueUI()
    {
        _handValueText.text = "Hand Value " + "\n" + HandValue; 
    }
    
    private int CheckCardValue(Card card)
    {
        if (card.value != 0) return card.value;
        
        return (HandValue + 11 > 21)? 1 : 11;
    }
}
