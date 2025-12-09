using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    private bool isDead = false;
    private ZombieAI zombieAI;
    private GameManager gameManager;

    void Start()
    {
        zombieAI = GetComponent<ZombieAI>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void KillZombie()
    {
        if (isDead) return;
        isDead = true;

        if (zombieAI != null) zombieAI.OnDeath();

        if (gameManager != null)
        {
            gameManager.PlayerWins();
        }
    }
}
