using UnityEngine;
using System.Collections;

public class FirePistol : MonoBehaviour
{
    public GameObject muzzleFlashPrefab;
    public AudioClip gunShotSound;
    public float timeBetweenShots = 0.5f;
    public float killRange = 1000f; 

    private AudioSource audioPlayer;
    private bool canShoot = true;
    private Transform player;

    void Start()
    {
        audioPlayer = gameObject.AddComponent<AudioSource>();
        audioPlayer.playOnAwake = false;
        player = transform; 
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canShoot = false;

        if (muzzleFlashPrefab != null)
        {
            Vector3 muzzlePos = player.position + player.forward * 1f;
            GameObject flash = Instantiate(muzzleFlashPrefab, muzzlePos, player.rotation);
            flash.transform.localScale = Vector3.one * 3f;
            Destroy(flash, 0.2f);
        }

        if (gunShotSound != null)
        {
            audioPlayer.PlayOneShot(gunShotSound);
        }

        ZombieHealth zombie = FindObjectOfType<ZombieHealth>();
        if (zombie != null)
        {
            float distance = Vector3.Distance(player.position, zombie.transform.position);
            if (distance <= killRange)
            {
                zombie.KillZombie();
            }
        }

        StartCoroutine(ResetGunCooldown());
    }

    IEnumerator ResetGunCooldown()
    {
        float timer = timeBetweenShots;
        while (timer > 0f)
        {
            timer -= Time.unscaledDeltaTime;
            yield return null;
        }
        canShoot = true;
    }
}
