using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPref;
    [SerializeField] private float spawnTime = 4f;
    [SerializeField] private GameObject enemies;
    private Vector3 _spawnPoint;
    private void Start()
    {
        StartCoroutine(EnemySpawnTime());
    }

    
    private IEnumerator EnemySpawnTime()
    {
        while (true)
        {
            //if (GameManager.Score % 5 == 0) spawnTime -= .2f;
            _spawnPoint = new Vector3(Random.Range(0, 7.6f),Random.Range(0, 4.3f),0f);
            Instantiate(enemyPref, _spawnPoint, Quaternion.identity, enemies.transform);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
