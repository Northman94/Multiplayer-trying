using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    float speedMove = 5f;
    [SerializeField]
    float speedRotate = 60f;

  


    private void Start() // Окраска своего в зеленый, а врага в красный.
    {
        if (isLocalPlayer)
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.material.color = Color.green;
            }
        }
        else
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.material.color = Color.red;
            }
        }
     }




    void Update()
    {
        // NetworkBehaviour
        if (!isLocalPlayer)
        {
            return; // в такой способ не сможем управлять чужим игроком.
        }


        // Movement
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");

        if (vert != 0)
        {
            transform.Translate(Vector3.right * vert * speedMove * Time.deltaTime);
        }

        if (horiz != 0)
        {
            transform.Rotate(Vector3.up * horiz * speedRotate * Time.deltaTime);
        }


        // Fire()
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }
  




    public void Fire( )
    {
        var bullet = Instantiate(_bulletPrefab, _firePoint.position,  _firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10f;

        Destroy(bullet, 2f);
    }

}