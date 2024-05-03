using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRenderTest : MonoBehaviour
{
    public GameObject objectToShowHide;
    public BoxCollider triggerCollider;

    void Start()
    {
        objectToShowHide.SetActive(false); // Start with the object hidden
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToShowHide.SetActive(true); // Show the object when player with "Player" tag enters the collider
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToShowHide.SetActive(false); // Hide the object when player with "Player" tag exits the collider
        }
    }
}
