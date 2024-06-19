using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorValidateSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int MyFind(List<Color> colors, Color color)
    {
        for(int i = 0; i < colors.Count; i++)
        {
            if (colors[i] == color)
            {
                return i;
            }
        }
        return -1;
    }
    public void ValidateColors()
    {
        List<Color> colors = new List<Color>() { Color.red, Color.yellow, Color.gray, Color.black, Color.blue, Color.cyan, Color.green };
        Color color = gameObject.GetComponent<Image>().color;
        print(MyFind(colors, color));
        
        
    }
}
