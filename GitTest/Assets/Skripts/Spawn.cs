using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float speed;

    private GameObject enemy;
    private int countEnemy = 0;
    private SpriteRenderer spriteR;

    private void Update()
    {
        SpawnEnemy();
        MoveEnemy();
    }
 


    private void SpawnEnemy()
    {
        if(countEnemy == 0)
        {   
            enemy = Instantiate(enemyPrefab);
            Vector3 pos = transform.position;
            enemy.transform.position = pos;
            countEnemy++;
            spriteR = enemy.GetComponentInChildren<SpriteRenderer>();
        }
    }

    private void MoveEnemy()
    {

        Vector3 pos = enemy.transform.position;
        if (pos.x >= 12 || pos.x <= -12)
        {
            speed *= -1;
            spriteR.flipX = true;

        }
        if(pos.x<=-11) spriteR.flipX = false;
        pos.x += speed * Time.deltaTime;
        enemy.transform.position = pos;
    }
}
