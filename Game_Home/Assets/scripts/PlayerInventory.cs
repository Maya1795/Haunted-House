using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static bool hasCandle = false;

    public static void PickUpCandle()
    {
        hasCandle = true;
    }

    public static void RemoveCandle()
    {
        hasCandle = false;
    }
}