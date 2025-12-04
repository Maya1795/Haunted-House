using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePlacement : MonoBehaviour
{
    [SerializeField] bool eyePick;
    [SerializeField] GameObject textOnScreen;
    [SerializeField] GameObject fulleye;
    [SerializeField] GameObject fadeIn;

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
                UIController.actionText = "Place Eyes Pieces";
                UIController.commandText = "[P] Place";
                UIController.uiActive = true;
            }
            else
            {
                eyePick = false;
                UIController.actionText = "You still need an eye piece!";
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
        yield return new WaitForSeconds(2);
        fadeIn.SetActive(false);
    }
}
