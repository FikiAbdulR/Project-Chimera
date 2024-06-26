using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAiming : MonoBehaviour
{

        [SerializeField] private LayerMask groundMask;

        private Camera mainCamera;

        private void Start()
        {
            // Cache the camera, Camera.main is an expensive operation.
            mainCamera = Camera.main;
        }

        private void Update()
        {
            Aim();
        }

        private void Aim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                // Calculate the direction
                var direction = position - transform.position;
                
                // Make the transform look in the direction.
                this.gameObject.transform.forward = direction;

            }
        }

        private (bool success, Vector3 position) GetMousePosition()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
            {
                // The Raycast hit something, return with the position.
                return (success: true, position: hitInfo.point);
            }
            else
            {
                // The Raycast did not hit anything.
                return (success: false, position: Vector3.zero);
            }
        }

}