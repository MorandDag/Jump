using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRestart : MonoBehaviour
{
    
    void Update()
    {
        Text text = GetComponent<Text>();
        text.text = "Your points: "+ '\n' +TextPoints.points.ToString();
    }
}
