using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public GameObject truckReverseA;
    public GameObject truckStartA;

    AudioSource truckReverse;
    AudioSource truckStart;


    public GameObject shatterA;
    AudioSource shatter;


    bool forward = true;
    Rigidbody2D truck;
    float speed = 2f;

    void Start()
    {
        truck = GetComponent<Rigidbody2D>();
        truckReverse = truckReverseA.GetComponent<AudioSource>();
        truckStart = truckStartA.GetComponent<AudioSource>();

        shatter = shatterA.GetComponent<AudioSource>();
    }
    

    void LateUpdate()
    {
        if(Util.shatterSound)
        {
            shatter.Play();
            Util.shatterSound = false;
        }
        if (forward)
        {
            truck.velocity = Vector3.right * speed;
        }
        else
        {
            truck.velocity = Vector3.left * speed;
        }
    }
    
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Bound"))
        {
            StartCoroutine(TruckWait());
        }
    }

    IEnumerator TruckWait()
    {
        yield return new WaitForSeconds(Util.timeTruckWait);
        if(forward)
        {
            truckReverse.Play();
            forward = !forward;
        }
        else
        {
            StartCoroutine(TStart());
        }

    }

    IEnumerator TStart()
    {
        truckStart.Play();
        yield return new WaitForSeconds(1.5f);
        forward = !forward;
    }



}
