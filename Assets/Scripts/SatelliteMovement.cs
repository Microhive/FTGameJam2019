using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SatelliteMovement : MonoBehaviour
{
    public float moveStrength = 5;
    new Rigidbody2D rigidbody2D;

    public float maxSpeed = 10;
    public GameObject theBeam;
    public AudioSource audioSource;
    public AudioSource beamStartAudioSource;
    public AudioSource beamEndAudioSource;

    public GameObject gameOverGO;
    public GameObject explotion;
    public AudioSource mainMusic;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.touchCount > 1)
        {
            

        }*/

        if (Input.GetButtonDown("Jump"))
        {
            theBeam.SetActive(true);
            beamEndAudioSource.Stop();
            beamStartAudioSource.Play();
        }

        if (Input.GetButtonUp("Jump"))
        {
            theBeam.SetActive(false);
            beamStartAudioSource.Stop();
            beamEndAudioSource.Play();
        }
    }

    void FixedUpdate()
    {
        //if(Input.touchCount == 1)
        {
            //Touch touch = Input.GetTouch(0);
            float leftAndRight = Input.GetAxis("Horizontal");
            rigidbody2D.AddForce(transform.right * leftAndRight * moveStrength);

            if (rigidbody2D.velocity.magnitude > maxSpeed)
            {
                rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
            }

            if (leftAndRight > 0.5 || leftAndRight < -0.5)
            {
                audioSource.enabled = true;
            }
            else
            {
                audioSource.enabled = false;
            }
        }
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        Camera.main.gameObject.transform.SetParent(null);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject theObject = col.gameObject;

        TerrestialObject terrestialObject = null;
        if (col.transform.parent != null)
            if (col.transform.parent.GetComponent<TerrestialObject>() != null)
                terrestialObject = col.transform.parent.GetComponent<TerrestialObject>();

        if (terrestialObject != null)
        {
            theObject.transform.SetParent(null);
            Destroy(terrestialObject.gameObject);
            theObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnDestroy()
    {
        if (explotion != null)
            Instantiate(explotion, transform.position, Quaternion.identity);

        if (gameOverGO != null)
        {
            mainMusic.Stop();
            gameOverGO.SetActive(true);
        }
    }
}
