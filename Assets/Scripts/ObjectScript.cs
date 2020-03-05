using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public bool interactable;

    public void InteractWithObject(RaycastHit hit)
    {
        if ( interactable ) {
            hit.transform.GetComponent<InteractionScript>().Interact();
        }
        else if ( hit.transform.tag == "Bed" && LevelManager.Instance.ui.taskSet1Progression == 1 && LevelManager.Instance.day == 0 )
        {
            LevelManager.Instance.ui.UpdateToDo();
            LevelManager.Instance.ui.taskSet1Progression = 0;
        }
        else if( hit.transform.tag == "Bed" && LevelManager.Instance.ui.eggsFound == 2 && LevelManager.Instance.day == 1 )
        {
            LevelManager.Instance.ui.UpdateToDo();
        }
        else if (hit.transform.tag == "Bed" && LevelManager.Instance.ui.taskSet1Progression == 1 && LevelManager.Instance.day == 2)
        {
            LevelManager.Instance.ui.UpdateToDo();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "EggBasket" && transform.tag == "Egg")
        {
            LevelManager.Instance.ui.eggsFound++;
            LevelManager.Instance.ui.UpdateToDo();
        }

        if (other.transform.tag == "Pet" && transform.tag == "Seeds" && LevelManager.Instance.ui.taskSet1Progression == 0 && LevelManager.Instance.day == 1)
        {
            LevelManager.Instance.ui.taskSet1Progression++;
            LevelManager.Instance.ui.UpdateToDo();
            Destroy(transform.gameObject);

            if (LevelManager.Instance.player.GetComponent<PlayerInteraction>().interactingGameobject != null)
            {
                LevelManager.Instance.player.GetComponent<PlayerInteraction>().playerIsInteracting = false;
                LevelManager.Instance.player.GetComponent<PlayerInteraction>().interactingGameobject = null;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "EggBasket" && transform.tag == "Egg")
        {
            LevelManager.Instance.ui.GetComponent<UserInterfaceManager>().eggsFound--;
            LevelManager.Instance.ui.GetComponent<UserInterfaceManager>().UpdateToDo();
        }
    }
}