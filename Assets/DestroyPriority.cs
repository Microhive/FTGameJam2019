using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPriority : MonoBehaviour
{
    public int collisionDestroyPriority = 0;
    public GameObject explotion;

    void OnCollisionEnter2D(Collision2D col)
    {
        DestroyPriority otherDestroyPriority = col.gameObject.GetComponent<DestroyPriority>();

        if (otherDestroyPriority != null)
        {
            if (otherDestroyPriority.collisionDestroyPriority >= collisionDestroyPriority)
            {
                if (otherDestroyPriority.gameObject.CompareTag("Earth"))
                {
                    int pointToNegative = GetComponent<PointEffect>().pointWillGive;

                    if (pointToNegative > 0)
                    {
                        GetComponent<PointEffect>().pointWillGive = -pointToNegative;
                    }
                }
                if(explotion != null)
                    Instantiate(explotion,transform.position,Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    private void Update()
    {
        if(transform.position.magnitude > 20)
        {
            Destroy(gameObject);
        }
    }
}
