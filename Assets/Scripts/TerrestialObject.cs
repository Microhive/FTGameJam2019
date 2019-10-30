using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TerrestialType
{
    Bird,
    Ship,
    Plane,
    Fish,
    Mountain
}

public class TerrestialObjectDef
{
    public float MinHeight;
    public float MaxHeight;
    public TerrestialType type;
}

public class TerrestialObject : MonoBehaviour
{
    public float MinHeight;
    public float MaxHeight;
    private float velocity;
    public float speed;
    public bool variedSpeeds = true;
    public float height;
    private float originalHeight;
    private bool isAlive = true;
    private GameObject birdRenderer;
    public float size = 20;
    public TerrestialType type;
    public bool doesFromLackofOxigen;


    // Start is called before the first frame update
    void Start()
    {
        birdRenderer = GetComponentInChildren<SpriteRenderer>().gameObject;
        originalHeight = Random.Range(MinHeight, MaxHeight);
        height = originalHeight;

        if (variedSpeeds)
        {
            speed = Random.Range(-speed, speed);
        } else
        {
            speed = Random.Range(0f, 1f) < 0.5 ? -speed : speed;
        }

        transform.Rotate(0, 0, Random.Range(0, 360));

        
        GetComponentInChildren<SpriteRenderer>().flipX = speed > 0;
    }

    // Update is called once per frame
    void Update()
    {
        //raiseHeight();
        if (birdRenderer == null)
        { 
            Destroy(gameObject);
            return;
        }

        if (isAlive)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * speed);
            birdRenderer.transform.localPosition = new Vector3(0, height, 0);
            height = Mathf.SmoothDamp(height, originalHeight, ref velocity, Time.deltaTime * size);
        } else if (birdRenderer != null)
        {
            var animator = birdRenderer.GetComponentInChildren<Animator>();

            if (animator != null)
            {
                animator.enabled = false;
            }

            birdRenderer.transform.parent = null;
            birdRenderer.AddComponent<Rigidbody2D>();
            birdRenderer.AddComponent<CircleCollider2D>();
            birdRenderer = null;
        }
    }

    public void raiseHeight()
    {
        height = Mathf.SmoothDamp(height, 20, ref velocity, Time.deltaTime * size);
    }

    public void SetAlive(bool state)
    {
        isAlive = state;
    }
}
