using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCube_sound : MonoBehaviour
{
    public AudioSource impactfx;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 1.5f)
        {
            impactfx.Play();
        }
    }
}
