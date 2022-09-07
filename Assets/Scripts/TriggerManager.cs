using System;
using UnityEngine;
public class TriggerManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
        }
        
    }
}
