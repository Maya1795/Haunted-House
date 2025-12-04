using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePickUp : MonoBehaviour
{
    [SerializeField] bool canPick;
    [SerializeField] GameObject textOnScreen;
    [SerializeField] GameObject tableCandle;
    [SerializeField] GameObject handCandle;
    [SerializeField] GameObject webEvent;

    void Update()
    {
        if (canPick == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                tableCandle.SetActive(false);
                handCandle.SetActive(true);
                webEvent.SetActive(true);
                this.enabled = false;
            }
        }
    }
    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 5)
        {
            canPick = true;
            UIController.actionText = "Candle";
            UIController.commandText = "[E] Pick Up";
            UIController.uiActive = true;
        }
        else
        {
            canPick = false;
            UIController.actionText = "";
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
}
