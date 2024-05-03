using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    Animator animator;
    Vector2 input;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        Vector3 mousePos = Input.mousePosition;

        // Calculate the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // Check if the mouse is in the upper section
        if (mousePos.y > screenCenter.y)
        {
            Debug.Log("Mouse is in the upper section!");
            // Add your code here for actions when the mouse is in the upper section
            animator.SetFloat("InputX", input.x);
            animator.SetFloat("InputY", input.y);
        }

        // Check if the mouse is in the lower section
        if (mousePos.y < screenCenter.y)
        {
            Debug.Log("Mouse is in the lower section!");
            // Add your code here for actions when the mouse is in the lower section
            animator.SetFloat("InputX", -input.x);
            animator.SetFloat("InputY", -input.y);
        }
    }
}
