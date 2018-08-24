using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerHealth : NetworkBehaviour 
{

    [SerializeField]
    private Transform _canvas;

    [SerializeField]
   private Image  _fillImage;

    public int MaxHealth = 100;
    [SyncVar (hook = "HealthChanged")]
    public int CurrentHealth = 100;

    private void LateUpdate()
    {
        _canvas.LookAt(Camera.main.transform, Vector3.up);
    }

    public void GetDamage(int damage)
    {
        if (!isServer)
        {
            return;
        }

        if (CurrentHealth <= 0)
        {
            return;
        }

        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            RpcRespawn();
        }
    }


    private void HealthChanged (int health)
    {
        CurrentHealth = health;

        _fillImage.fillAmount = (float)CurrentHealth / MaxHealth;
    }


    [ClientRpc]
        private void RpcRespawn()
        {
           Debug.Log("EX-Death");

        transform.position = Vector3.up * 3;

        CurrentHealth = MaxHealth;
        }

}
 