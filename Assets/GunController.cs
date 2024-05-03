using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunBarrel;
    public GameObject projectile;
    //public float projectileSpeed = 10;
    public Light muzzleFlashLight; // Reference to the point light for muzzle flash
    public AudioSource gunsfx;
    public AudioClip sfxclip;

    void Start()
    {
        // Ensure that the muzzle flash light is initially disabled
        muzzleFlashLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for shooting
        {
            ShootBullet();
            PlayMuzzleFlash();
        }
    }

void ShootBullet()
    {
        // Calculate the position slightly in front of the gun barrel along its forward direction
        Vector3 spawnPosition = gunBarrel.position + gunBarrel.forward * 0.5f; // Adjust the multiplier as needed
        Vector3 direction = transform.forward;

        // Instantiate the bullet trail at the adjusted position and rotation of the gun barrel
        var bullet = Instantiate(projectile, spawnPosition, gunBarrel.rotation);
        bullet.SetActive(true);
        //bullet.GetComponent<Rigidbody>().velocity = gunBarrel.forward * projectileSpeed;

        ScreenShake.instance.ShakeScreen();
        gunsfx.PlayOneShot(sfxclip);
    }
    
    void PlayMuzzleFlash()
    {
        muzzleFlashLight.enabled = true; // Enable the point light for muzzle flash
        Invoke("TurnOffMuzzleFlash", 0.1f); // Turn off the muzzle flash after a short delay
    }

    void TurnOffMuzzleFlash()
    {
        muzzleFlashLight.enabled = false; // Disable the point light for muzzle flash
    }
}
