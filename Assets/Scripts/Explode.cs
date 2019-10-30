using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D collider)
    {
        var rigidBody = collider.GetComponent<Rigidbody2D>();

        if (rigidBody == null) return;

        if (rigidBody.velocity.magnitude < 1f)
        {
            var entity = Instantiate(explosion);
            entity.transform.parent = gameObject.transform;
            Destroy(gameObject);
        }
    }
}
