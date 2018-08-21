using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour 
{

    [SerializeField]
    private Transform _canvas;
    [SerializeField]
    private Image _fillImage;

    public int MaxHealth = 100;
    public int CurrentHealth = 100;

    private void Update()
    {
        _canvas.LookAt(Camera.main.transform, Vector3.up);
    }

    public void GetDamage(int damage)
    {
        if(!isServer)
        {
            return;
        }
    }
}
 