using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectScript : MonoBehaviour
{
    public bool interactable;

    public void InteractWithObject(RaycastHit hit)
    {
        if ( interactable ) {
            Interact();
        }
    }

    private bool playerHoldingObject = false;

    public void Interact()
    {
        Debug.Log("Got to the Interact void");

        Debug.LogError(FindObjectOfType<MonoBehaviour>().GetType().IsSubclassOf(typeof(ObjectScript)));

        //if (gameObject.GetComponent<>.GetType().IsSubclassOf(typeof(ObjectScript)))
        if (FindObjectOfType<WaterSystem>().GetType().IsSubclassOf(typeof(ObjectScript)))
        {
            LevelManager.Instance.player.GetComponent<PlayerInteraction>().interactingGameobject = transform.gameObject;
        }
    }

    public void StopInteract()
    {
        Debug.Log("Got to the StopInteract void");
        if (transform.name == "Seeds" || transform.name == "Egg")
        {
            transform.parent = null;
            AdjustRigidbodyForPickup();
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