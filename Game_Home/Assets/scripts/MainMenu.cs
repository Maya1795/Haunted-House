using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
<<<<<<< Updated upstream
    public void play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
=======
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");   // your game scene name
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // works only in editor
>>>>>>> Stashed changes
    }
}
