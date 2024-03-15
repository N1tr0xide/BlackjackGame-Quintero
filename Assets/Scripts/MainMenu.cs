using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _instructionsPanel;
    
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SetInstructionsPanelState(bool isOpening)
    {
        _instructionsPanel.SetActive(isOpening);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
