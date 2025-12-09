using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}