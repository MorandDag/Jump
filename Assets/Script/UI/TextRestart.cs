using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRestart : MonoBehaviour
{
    public int points = 0;
    public int recordPoints = 0;
    public int lastPoints = 0;
    
    void Update()
    {
        Text text = GetComponent<Text>();
        text.text = "Your points: "+ '\n' +TextPoints.points.ToString() + '\n'
            +"Last points: " + '\n' + lastPoints.ToString() + '\n'
            +"Record: " + '\n' + recordPoints.ToString();
    }

    private void OnEnable()
    {
        LoadData();
        points = TextPoints.points;
        if (points > recordPoints)
            recordPoints = points;

        if (LevelGenerator.deathPlayer)
            SaveData();
    }

    public void SaveData()
    {
        
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        GameData data = SaveSystem.LoadData();

        if(data != null)
        {
            recordPoints = data.recordPoints;
            //if(!LevelGenerator.deathPlayer)
            lastPoints = data.lastPoints;
        }
    }
}
