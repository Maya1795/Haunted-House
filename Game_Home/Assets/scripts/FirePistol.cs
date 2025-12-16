using UnityEngine;
using System.Collections;

public class FirePistol : MonoBehaviour
{
    public GameObject muzzleFlashPrefab;
    public GameObject bulletPrefab; // <-- This is your flying bullet (e.g., 45ACP_Projectile)
    public AudioClip gunShotSound;
    public float timeBetweenShots = 0.5f;

    private AudioSource audioPlayer;
    private bool canShoot = true;
    private Transform player;

    void Start()
    {
        audioPlayer = gameObject.AddComponent<AudioSource>();
        audioPlayer.playOnAwake = false;
        player = transform; // Assumes this script is on the gun/hand that faces forward
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

        // --- Muzzle Flash ---
        if (muzzleFlashPrefab != null)
        {
            Vector3 muzzlePos = player.position + player.forward * 1f;
            GameObject flash = Instantiate(muzzleFlashPrefab, muzzlePos, player.rotation);
            flash.transform.localScale = Vector3.one * 3f;
            Destroy(flash, 0.2f);
        }

        // --- Gunshot Sound ---
        if (gunShotSound != null)
        {
            audioPlayer.PlayOneShot(gunShotSound);
        }

        // --- Shoot the Bullet ---
        if (bulletPrefab != null)
        {
            Vector3 spawnPosition = player.position + player.forward * 1f;
            Instantiate(bulletPrefab, spawnPosition, player.rotation);
        }

        StartCoroutine(ResetGunCooldown());
    }

    IEnumerator ResetGunCooldown()
    {
        float timer = timeBetweenShots;
        while (timer > 0f)
        {
            timer -= Time.unscaledDeltaTime; // Respects Time.timeScale = 0 (e.g., during pause/win)
            yield return null;
        }
        canShoot = true;
    }
}