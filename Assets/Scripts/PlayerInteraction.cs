using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool playerIsInteracting = false;

    public GameObject interactingGameobject;

    public void Interact()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (playerIsInteracting)
        {
            interactingGameobject.GetComponent<InteractionScript>().StopInteract();
            playerIsInteracting = false;
            interactingGameobject = null;
        }
        else if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Debug.Log("You clicked on the gameObject names " + hit.transform.name);

            if (!playerIsInteracting)
            {
                try
                {
                    hit.transform.GetComponent<ObjectScript>().InteractWithObject(hit);
                }
                catch
                {
                    Debug.LogWarning("Object clicked doesnt have an InteractionScript script.");
                }
            }
        }
    }
}
