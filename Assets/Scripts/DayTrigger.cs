using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTrigger : MonoBehaviour
{
    public bool IsTriggered
    {
        get;
        private set;
    }

    private void OnTriggerEnter(Collider other)
    {
        IsTriggered = true;
        Debug.Log("istriggered");
    }

}
