using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(LevelManager.Instance.player.transform);

        float dist = Vector3.Distance(LevelManager.Instance.player.transform.position, transform.position);

        if (dist >= 2f)
        {
            gameObject.GetComponent<CharacterController>().SimpleMove(transform.forward * 1);
        }

        transform.position = new Vector3(transform.position.x, 0.58f, transform.position.z);
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
    }
}