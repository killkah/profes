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

    void Start()
    {
        //Invoke("CreateEnemy", 0.05f);
        CreateEnemy();
    }
    public void CreateEnemy()
    {
        Color[] colors = { Color.red, Color.yellow, Color.gray, Color.black, Color.blue, Color.cyan, Color.green };
        gameObjects = GameObject.FindGameObjectsWithTag("EnemySet");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        int count = enemyCount.value + 1;
        for (int i = 0; i < count; i++)
        {
            GameObject newEnemy = Instantiate(enemySetPrefab, enemySetParent.transform);
            InputField name = newEnemy.GetComponentInChildren<InputField>();
            Image colorEnemy = newEnemy.GetComponentInChildren<Button>().gameObject.GetComponent<Image>();
            name.text = "Противник " + (i + 1);
            colorEnemy.color = colors[i];
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(enemySetParent.GetComponent<RectTransform>());   
    }
}
