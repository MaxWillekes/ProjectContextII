using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : ObjectScript, IInteraction
{
    public void ObjectInteraction()
    {
        transform.parent = LevelManager.Instance.player.transform;
        AdjustRigidbodyForPickup();
        LevelManager.Instance.player.GetComponent<PlayerInteraction>().playerIsInteracting = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EggBasket")
        {
            LevelManager.Instance.ui.eggsFound++;
            LevelManager.Instance.ui.UpdateToDo();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "EggBasket")
        {
            LevelManager.Instance.ui.GetComponent<UserInterfaceManager>().eggsFound--;
            LevelManager.Instance.ui.GetComponent<UserInterfaceManager>().UpdateToDo();
        }
    }
}
