using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] int m_index;
    [SerializeField] Transform m_targetPos;

    public void StartSpawn()
    {
        StartCoroutine(EnemySpawn());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    IEnumerator EnemySpawn()
    {
        EnemySpawnSystem enemySpawnSystem = EnemySpawnSystem.Instance;

        while (!TransportSystem.Instance.IsClear)
        {
            while (EnemySystem.Instance.Enemys[m_index] != null) yield return null;

            float errorRange = Random.Range(-enemySpawnSystem.SpawnDelayErrorRange, enemySpawnSystem.SpawnDelayErrorRange);
            float spawnDelay = enemySpawnSystem.SpawnDelay + errorRange;
            yield return new WaitForSeconds(spawnDelay);

            GameObject enemy = Instantiate(enemySpawnSystem.SpawnEnemy);
            enemy.transform.position = transform.position;
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
            enemy.GetComponent<EnemyMoveState>().TargetPos = m_targetPos;
            EnemySystem.Instance.Enemys[m_index] = enemy.GetComponent<HPController>();
        }
    }
}
