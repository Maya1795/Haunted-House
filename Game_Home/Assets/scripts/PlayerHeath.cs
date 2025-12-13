using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
   
    void Start()
    {
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}