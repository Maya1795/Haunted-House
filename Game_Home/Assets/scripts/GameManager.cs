using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public AudioSource audioSource_death;
    public AudioSource audioSource_win;

    private bool gameEnded = false;
    
    void Start()
    {
        if (gameOverText != null) gameOverText.gameObject.SetActive(false);
        if (winText != null) winText.gameObject.SetActive(false);
    }
    
    public void PlayerLoses()
    {
        if (gameEnded) return;
        gameEnded = true;
        
        if (gameOverText != null)
        {
            if (audioSource_death != null)
                audioSource_death.Play();
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "GAME OVER!\nZombie got you!\nPress R to Restart";
        }
        
        Time.timeScale = 0f;
    }
    
    public void PlayerWins()
    {
        if (gameEnded) return;
        gameEnded = true;
        
        if (winText != null)
        {
            if (audioSource_win != null)
                audioSource_win.Play();
            winText.gameObject.SetActive(true);
            winText.text = "YOU WIN!\nZombie eliminated!\nPress R to Restart";
        }
        
        Time.timeScale = 0f;
    }
    
    void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}