using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab_circle;
    public GameObject EnemyPrefab_square;
    public GameObject EnemyPrefab_triangle;
    private GameObject[] GeneratedEnemy = new GameObject[3];

    private float generationRate = 5f;
    private float rateDiscount = 0.95f;
    private Vector3 generatePosition;

    public GameObject[] SpawnEffect = new GameObject[3];
    private GameObject effect;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        GeneratedEnemy[0] = EnemyPrefab_circle;
        GeneratedEnemy[1] = EnemyPrefab_square;
        GeneratedEnemy[2] = EnemyPrefab_triangle;

        generatePosition = new Vector3(Random.Range(-6.5f, 6.5f), Random.Range(-4.5f, 4.5f), 0);
        StartCoroutine(enemyGnerate());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator enemyGnerate()
    {
        while (true)
        {
            index = Random.Range(0, 3);
            effect = GameObject.Instantiate(SpawnEffect[index], generatePosition, Quaternion.identity);
            Destroy(effect,1f);
            yield return new WaitForSeconds(1f);
            GameObject.Instantiate(GeneratedEnemy[index], generatePosition, Quaternion.identity);
            generatePosition = new Vector3(Random.Range(-6.5f, 6.5f), Random.Range(-4.5f, 4.5f), 0);
            yield return new WaitForSeconds(generationRate);
            generationRate = generationRate * rateDiscount;
        }

    }

}
