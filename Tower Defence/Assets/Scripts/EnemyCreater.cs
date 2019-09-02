using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    public static int RemainEnemy = 0;
    public Wave[] waves;
    public Transform start;
    public float waveInterval = 3;
    private Coroutine co;

    // Start is called before the first frame update
    void Start()
    {
       co = StartCoroutine(EnemyCreate());
    }

    // Update is called once per frame
    public void Stop()
    {
        StopCoroutine(co);
    }

    IEnumerator EnemyCreate()
    {
        foreach (Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, start.position, Quaternion.identity);
                RemainEnemy++;
                if (i!=wave.count-1)
                {
                    yield return new WaitForSeconds(wave.interval);
                }
            }
            while (RemainEnemy>0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveInterval);
        }
        GameManager.instance.Win();
        
    }
}
