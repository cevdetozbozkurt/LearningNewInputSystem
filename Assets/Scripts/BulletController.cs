using System;
using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            gm.Score++;
        }
    }

    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * transform.up, Space.World);    
    }


}
