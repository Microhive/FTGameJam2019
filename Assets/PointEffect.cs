using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEffect : MonoBehaviour
{
    public int pointWillGive = 20;

    public void AddPoint()
    {
        if(Points.Instace() != null)
            Points.Instace().AddPoints(pointWillGive);
    }

    private void OnDestroy()
    {
        AddPoint();

        bool gameOverScreenAppear = true;
        foreach(TerrestialObject terrestial in FindObjectsOfType<TerrestialObject>())
        {
            if (terrestial.type == TerrestialType.Ship)
            { 
                gameOverScreenAppear = false;
                break;
            }
        }

        if(gameOverScreenAppear == true)
        {
            GameObject.FindGameObjectWithTag("Game Over").SetActive(true);
        }
    }

}
