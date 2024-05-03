using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject impactEffect;
    [SerializeField] private Rigidbody Rb;
    [SerializeField] private LayerMask groundMask;

    void Start()
    {
        Rb.velocity = transform.forward * speed;
        Destroy(this.gameObject, 4);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            GameObject pe =  Instantiate(impactEffect, transform.position, Quaternion.identity);
            pe.SetActive(true);
            Destroy(pe, 1);
            Destroy(this.gameObject);

            Debug.Log("Hit");
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            if(hit.transform.gameObject.layer == groundMask)
            {
                GameObject pe =  Instantiate(impactEffect, hit.point, Quaternion.identity);
                pe.SetActive(true);
                Destroy(pe, 1);
                Destroy(this.gameObject);
            }
        }
    }
}
