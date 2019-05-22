using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    bool beltTouched = true;

    Rigidbody2D package;
    public GameObject packageDestroyed;


    void Start()
    {
        package = GetComponent<Rigidbody2D>();
    }


    void LateUpdate()
    {
        if(beltTouched)
        {
            package.velocity = Vector3.right * 1.5f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals("Belt"))
        {
            beltTouched = true;
        }
        else if (collision.collider.tag.Equals("Floor"))
        {
            Util.shatterSound = true;
            //Miss Logic
            GameObject temp = Instantiate(packageDestroyed, transform.position, Quaternion.identity);
            Destroy(temp, 1f);
            Destroy(gameObject);
        }
        else if (collision.collider.tag.Equals("Player"))
        {
            //Catch Logic
            Destroy(gameObject);
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals("Belt"))
        {
            beltTouched = false;
        }
    }

}
