using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private int points = 0;
    Text pointsText;

    public GameObject player;
    public GameObject gameOverScreen;

    public static Points Instace()
    {
        return instace;
    }

    private static Points instace;

    // Start is called before the first frame update
    void Start()
    {
        if(instace == null)
        {
            instace = this;
            pointsText = GetComponent<Text>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddPoints(int point)
    {
        points += point;
        pointsText.text = "Points: " + points;

        if(points <= -50)
        {
            Camera.main.gameObject.transform.SetParent(null);
            Camera.main.backgroundColor = Color.red;
            Destroy(player);
            gameOverScreen.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        if(instace == this)
        {
            instace = null;
        }
    }
}
