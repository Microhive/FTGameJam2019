using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PartialFollow : MonoBehaviour
{
    public GameObject partialFollowWhat;
    [Range(0,1)]
    public float howMuch = 0.5f;

    private SpriteRenderer spriteRenderer;
    new private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(partialFollowWhat != null)
        {
            rigidbody2D.velocity = partialFollowWhat.GetComponent<Rigidbody2D>().velocity * howMuch;
        }
        else
        {
            rigidbody2D.velocity = Vector3.zero;
        }
    }
}
