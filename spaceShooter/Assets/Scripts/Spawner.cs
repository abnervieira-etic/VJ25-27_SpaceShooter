using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        
        Vector2 pivot = transform.position;

        Vector2 randomPos = new Vector2(pivot.x + Random.Range(-1.4f,3.4f), pivot.y);

        Instantiate (enemy, randomPos, Quaternion.identity);

        StartCoroutine(SpawnEnemy());

    }
}
