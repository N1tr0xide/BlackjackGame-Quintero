using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Object cardPrefab;

    public List<Card> hand = new List<Card>();
    public int handvalue = 0;

    public void GetRandomCard(List<Card> deck, Transform UIparent)
    {
        int randomIndex = Random.Range(0, deck.Count - 1);
        Card cardDrawn = deck[randomIndex];

        hand.Add(cardDrawn);
        handvalue += CheckCardValue(cardDrawn);
        deck.Remove(cardDrawn);
        
        (cardPrefab as GameObject).GetComponent<Image>().sprite = cardDrawn.sprite;
        GameObject.Instantiate(cardPrefab, UIparent);
    }

    private int CheckCardValue(Card card)
    {
        if(card.value == 0)
        {
            if(handvalue + 11 > 21)
            {
                return 1;
            }

            return 11;
        }

        return card.value;
    }
}
