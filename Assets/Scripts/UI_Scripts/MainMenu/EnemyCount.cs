using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    [SerializeField] private Dropdown enemyCount;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private GameObject enemySetPrefab;
    [SerializeField] private GameObject enemySetParent;

    public void CreateEnemy()
    {
        
        gameObjects = GameObject.FindGameObjectsWithTag("EnemySet");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        int count = enemyCount.value + 1;
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemySetPrefab, enemySetParent.transform);
        }
            
    }
}
