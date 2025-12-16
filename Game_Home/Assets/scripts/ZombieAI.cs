using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 2f;
    public float attackRange = 2f;
    public int attackDamage = 20;
    public float levelTolerance = 1f;

    private Transform player;
    private Animator anim;
    private bool isDead = false;
    private float nextAttackTime;
    private float attackCooldown = 1f;
    private float levelY;

    private GameManager gameManager;

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        levelY = transform.position.y;
        nextAttackTime = Time.time + attackCooldown;
    }

    void Update()
    {
        if (isDead || player == null) return;

        // Lock Y to starting floor
        Vector3 pos = transform.position;
        pos.y = levelY;
        transform.position = pos;

        // Only act if player is on same floor
        if (Mathf.Abs(player.position.y - levelY) > levelTolerance)
        {
            anim.CrossFade("idle", 0.2f);
            return;
        }

        // Move toward player
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // ignore vertical
        float distance = direction.magnitude;

        if (distance > attackRange)
        {
            Vector3 moveDir = direction.normalized;
            transform.position += moveDir * speed * Time.deltaTime;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            anim.CrossFade("Walk", 0.2f);
        }
        else
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        anim.CrossFade("Attack", 0.1f);

        if (Time.time >= nextAttackTime)
        {
            PlayerHealth ph = player.GetComponent<PlayerHealth>();
            if (ph != null) ph.TakeDamage(attackDamage);

            if (gameManager != null)
            {
                gameManager.PlayerLoses();
            }

            nextAttackTime = Time.time + attackCooldown;
        }
    }

    public void OnDeath()
    {
        if (isDead) return;
        isDead = true;
        anim.CrossFade("Die", 0.1f);
        enabled = false;
    }
}
