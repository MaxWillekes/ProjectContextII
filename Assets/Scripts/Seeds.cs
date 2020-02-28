using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : ObjectScript, IInteraction
{
    public void ObjectInteraction()
    {
        transform.parent = LevelManager.Instance.player.transform;
        AdjustRigidbodyForPickup();
        LevelManager.Instance.player.GetComponent<PlayerInteraction>().playerIsInteracting = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Pet" && LevelManager.Instance.ui.taskSet1Progression == 0 && LevelManager.Instance.day == 1)
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
}
