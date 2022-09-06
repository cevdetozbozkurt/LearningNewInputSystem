using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    void Start()
    {
        
    }

    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * transform.up, Space.World);    
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
