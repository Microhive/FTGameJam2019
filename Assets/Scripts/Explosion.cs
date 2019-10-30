using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float duration = 1f;
    private float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (elapsed >= duration)
        {
            Destroy(gameObject);
        }
        else
        {
            elapsed += Time.deltaTime;
        }
    }
}
