using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanPlayer : Player
{
    private GameManager gameManager;
    [SerializeField] GameObject playerHandGameObject;
    [SerializeField] Text handValueText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        HitButton();
        HitButton();
    }

    public void HitButton()
    {
        if (!gameManager.IsPlayerTurn) return;
            
        GetRandomCard(gameManager.Deck, playerHandGameObject.transform);
        UpdateHandValueUI(handvalue);
        CheckState();
    }

    private void UpdateHandValueUI(int handValue)
    {
        handValueText.text = "Hand Value " + "\n" + handvalue; 
    }

    private void CheckState()
    {
        if(handvalue > 21)
        {
            print("Busted!");
            gameManager.EndPlayerTurn();
        }

        if(hand.Count >= 5)
        {
            print("all cards drawn");
            gameManager.EndPlayerTurn();
        }
    }
}
