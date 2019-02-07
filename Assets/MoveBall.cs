using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public AudioSource blip;
    public AudioSource blop;

    private Vector3 ballStartPosition;
    private Rigidbody2D rb;
    private float force = 800;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ballStartPosition = this.transform.position;
        ResetBall();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "backwall")
            blop.Play();
        else
            blip.Play();
        //ResetBall();
    }

    public void ResetBall()
    {
        this.transform.position = ballStartPosition;
        rb.velocity = Vector3.zero;
        // gets a unit vector for random starting direction for the ball
        Vector3 dir = new Vector3(Random.Range(100, 300), Random.Range(-100, 100), 0).normalized;
        rb.AddForce(dir * force);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ResetBall();
        }
    }
}
