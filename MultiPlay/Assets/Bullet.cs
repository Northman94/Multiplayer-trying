using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [SerializeField]
    private int _damage = 30;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth health = collision.collider.GetComponent<PlayerHealth>();

        if(health)
        {
            health.GetDamage(_damage);
        }

        Destroy(gameObject);
    }

}
