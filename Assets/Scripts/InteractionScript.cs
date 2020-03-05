using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    private bool playerHoldingObject = false;

    public void Interact()
    {
        Debug.Log("Got to the Interact void");
        switch (transform.tag)
        {
            case "WaterSystem":
                if (LevelManager.Instance.ui.taskSet1Progression == 0 && LevelManager.Instance.day == 0)
                {
                    LevelManager.Instance.ui.UpdateToDo();
                }
                break;
            case "WaterTapPoint":
                LevelManager.Instance.RemoveThirst();
                break;
            case "FoodInteractionPoint":
                LevelManager.Instance.RemoveHunger();
                break;
            case "Seeds":
                transform.parent = LevelManager.Instance.player.transform;
                AdjustRigidbodyForPickup();
                LevelManager.Instance.player.GetComponent<PlayerInteraction>().playerIsInteracting = true;
                break;
            case "Egg":
                transform.parent = LevelManager.Instance.player.transform;
                AdjustRigidbodyForPickup();
                LevelManager.Instance.player.GetComponent<PlayerInteraction>().playerIsInteracting = true;
                break;
            case "ClimateControl":
                if (LevelManager.Instance.ui.taskSet1Progression == 0 && LevelManager.Instance.day == 2)
                {
                    LevelManager.Instance.ChangeLighting();
                    LevelManager.Instance.ui.UpdateToDo();
                }
                break;
        }

        LevelManager.Instance.player.GetComponent<PlayerInteraction>().interactingGameobject = transform.gameObject;
    }

    public void StopInteract()
    {
        Debug.Log("Got to the StopInteract void");
        switch (transform.tag)
        {
            case "Seeds":
                transform.parent = null;
                AdjustRigidbodyForPickup();
                break;
            case "Egg":
                transform.parent = null;
                AdjustRigidbodyForPickup();
                break;
        }

        LevelManager.Instance.player.GetComponent<PlayerInteraction>().playerIsInteracting = false;
        LevelManager.Instance.player.GetComponent<PlayerInteraction>().interactingGameobject = null;
    }

    public void AdjustRigidbodyForPickup()
    {
        GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity;
        playerHoldingObject = !playerHoldingObject;
    }

    public void Update()
    {
        if (playerHoldingObject)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}