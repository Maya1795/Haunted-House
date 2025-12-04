using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebBurn : MonoBehaviour
{
    [SerializeField] bool canPick;
    [SerializeField] GameObject textOnScreen;
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject webCam;
    [SerializeField] GameObject fadeIn;
    [SerializeField] GameObject flameObject;
    [SerializeField] GameObject webObjects;
    [SerializeField] GameObject handCandle;

    void Update()
    {
        if (canPick == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(BurnWeb());
            }
        }
    }
    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 5)
        {
            canPick = true;
            UIController.actionText = "Spider Web";
            UIController.commandText = "[E] Burn";
            UIController.uiActive = true;
        }
        else
        {
            canPick = false;
            UIController.actionText = "Find the Candle";
            UIController.commandText = "";
            UIController.uiActive = false;
        }
    }
    void OnMouseExit()
    {
        canPick = false;
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }

    IEnumerator BurnWeb()
    {
        webCam.SetActive(true);
        thePlayer.SetActive(false);
        flameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        webObjects.SetActive(false);
        flameObject.SetActive(false);
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(2);
        fadeIn.SetActive(false);
        thePlayer.SetActive(true);
        webCam.SetActive(false);
        handCandle.SetActive(false);
    }
}
