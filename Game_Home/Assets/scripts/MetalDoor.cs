using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDoor : MonoBehaviour
{

    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 5)
        {
            UIController.actionText = "This door leads deeper into the building,away from everything familiar";
            UIController.commandText = "Enter";
            UIController.uiActive = true;
        }
        else
        {
            UIController.actionText = "";
            UIController.commandText = "";
            UIController.uiActive = false;
        }
    }
    void OnMouseExit()
    {
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }
}