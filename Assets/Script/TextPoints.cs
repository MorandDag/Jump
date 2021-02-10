using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPoints : MonoBehaviour
{
    public static int points;

    
    void Update()
    {
        Text text = GetComponent<Text>();
        text.text = points.ToString();
    }
}
