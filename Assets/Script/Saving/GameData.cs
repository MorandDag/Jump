using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int recordPoints;
    public int lastPoints;

    public int key;
    public int coin;

    public GameData(TextRestart text)
    {
        lastPoints = text.points;
        recordPoints = text.recordPoints;
    }
}
