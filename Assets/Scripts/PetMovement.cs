﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    float xRot;
    float startingHeigt;
    GameObject child;

    private void Start()
    {
        startingHeigt = transform.position.y;
        child = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        transform.LookAt(LevelManager.Instance.player.transform);

        float dist = Vector3.Distance(LevelManager.Instance.player.transform.position, transform.position);

        if (dist >= 3f)
        {
            child.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<CharacterController>().SimpleMove(transform.forward * 1);
        }
        else
        {
            child.GetComponent<Animator>().enabled = false;
            //Debug.Log(child.transform.GetChild(2).name);
            child.transform.GetChild(2).gameObject.transform.LookAt(Camera.main.transform, Vector3.up);
        }
            
        transform.position = new Vector3(transform.position.x, startingHeigt, transform.position.z);
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }
}