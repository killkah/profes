using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsValidate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ValidateEnemies();
    }

    int Count(List<string> strings, string el)
    {
        int c = 0;
        for (int i = 0; i < strings.Count; i++)
        {
            if (strings[i] == el)
            {
                c++;
            }
        }
        return c;
    }

    List<string> GetNames(GameObject[] enemies)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < enemies.Length; i++)
        {
            string enemyName = enemies[i].GetComponentInChildren<InputField>().text;
            result.Add(enemyName);
        }
        return result;
    }

    public void ValidateEnemies()
    {
        // Взять противников
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemySet");

        List<string> names = GetNames(enemies);

        // На каком месте повторяющийся эелемент
        for(int i = 0; i < names.Count; i++)
        {
            int count = Count(names, names[i]);
            if (count > 1)
            {
                InputField input = enemies[i].GetComponentInChildren<InputField>();
                Text text = input.GetComponentInChildren<Text>();
                text.color = Color.red;
            }
            else
            {
                InputField input = enemies[i].GetComponentInChildren<InputField>();
                Text text = input.GetComponentInChildren<Text>();
                text.color = Color.white;
            }
        }
    }

}
