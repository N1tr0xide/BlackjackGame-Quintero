using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardDeck : ScriptableObject
{
    public Sprite CardCover;
    public Card[] Deck;        
}

[System.Serializable]
public struct Card
{
    public Sprite sprite;
    [Tooltip("If the card is an Ace. Leave at zero.")] public int value;
}
