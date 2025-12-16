using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePlacement : MonoBehaviour
{
    [SerializeField] bool eyePick;
    [SerializeField] GameObject textOnScreen;
    [SerializeField] GameObject fulleye;
    [SerializeField] GameObject fadeIn;
    public AudioSource audioSource_win;

    void Update()
    {
        if (eyePick == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (EyeInventory.leftEyeCollected && EyeInventory.rightEyeCollected)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    fulleye.SetActive(true);
                    StartCoroutine(Eyepieces());
                }
            }
        }
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(1);
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }

    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 5)
        {
            if (EyeInventory.leftEyeCollected && EyeInventory.rightEyeCollected)
            {
                eyePick = true;
                UIController.actionText = "Both eyes pulse with a cold presence...\nThe ritual is ready to be completed";
                UIController.commandText = "[P] Place";
                UIController.uiActive = true;
            }
            else
            {
                eyePick = false;
                UIController.actionText = "The altar rejects you...\nBoth eyes must be returned before it will awaken";
                UIController.commandText = "";
                UIController.uiActive = true;
            }
        }
    }

    void OnMouseExit()
    {
        eyePick = false;
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }

    IEnumerator Eyepieces()
    {
        fadeIn.SetActive(true);
        if (audioSource_win != null)
            audioSource_win.Play();
        yield return new WaitForSeconds(2);
        fadeIn.SetActive(false);
    }
}
