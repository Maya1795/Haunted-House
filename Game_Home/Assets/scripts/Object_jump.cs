using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_jump : MonoBehaviour
{
    public GameObject cupObject;
    public GameObject sphereObject;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        sphereObject.SetActive(true);
        StartCoroutine(DeactivateSphere());
    }

    IEnumerator DeactivateSphere()
    {
        yield return new WaitForSeconds(0.5f);
        sphereObject.SetActive(false);
    }
}
