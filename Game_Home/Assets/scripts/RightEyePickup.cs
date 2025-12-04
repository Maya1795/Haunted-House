using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightEyePickup : MonoBehaviour
{
    [SerializeField] bool eyePick;
    [SerializeField] GameObject textOnScreen;
    [SerializeField] GameObject EyeOnTable;
    [SerializeField] GameObject HalfFade;
    [SerializeField] GameObject RightEyeImg;
    [SerializeField] GameObject textEye;

    void Update()
    {
        if (eyePick == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                EyeOnTable.SetActive(false);
                StartCoroutine(Eyepickedup());
            }
        }
    }
    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 5)
        {
            eyePick = true;
            UIController.actionText = "Eye";
            UIController.commandText = "[P] Pick Up";
            UIController.uiActive = true;
        }
        else
        {
            eyePick = false;
            UIController.actionText = "";
            UIController.commandText = "";
            UIController.uiActive = false;
        }
    }
    void OnMouseExit()
    {
        eyePick = false;
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }

    IEnumerator Eyepickedup()
    {
        EyeInventory.rightEyeCollected = true;
        HalfFade.SetActive(true);
        RightEyeImg.SetActive(true);
        textEye.SetActive(true);
        yield return new WaitForSeconds(1);
        HalfFade.SetActive(false);
        RightEyeImg.SetActive(false);
        textEye.SetActive(false);
    }
}
