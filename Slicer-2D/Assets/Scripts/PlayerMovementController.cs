using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public static bool floorTouched = true;
    Rigidbody2D rigid2D;
    Vector3 prevPos;
    public static bool ladderTouched = false;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        prevPos = transform.position;
    }


    void LateUpdate()
    {
        if(ladderTouched)
        {
            rigid2D.gravityScale = 0;
        }
        else
        {
            rigid2D.gravityScale = 1;
        }
        transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * Util.movementScaleHorizontal;
        if(floorTouched || ladderTouched)
        {
            transform.position += Vector3.up * Input.GetAxisRaw("Vertical") * Util.movementScaleVertical;
        }
        if(Vector3.Distance(transform.position,prevPos)>0.1f)
        {
            Util.moving = true;
        }
        else
        {
            Util.moving = false;
        }
        prevPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals("Floor"))
        {
            floorTouched = true;
            StartCoroutine(ChangeGravityScale(0));
        }
        else if (collision.collider.tag.Equals("Belt"))
        {
            //Game-over
        }
        else if (collision.collider.tag.Equals("Package"))
        {
            rigid2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }


    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ladder"))
        {
            ladderTouched = true;
        }
        else if (collision.collider.tag.Equals("Package"))
        {
            rigid2D.constraints = RigidbodyConstraints2D.FreezePosition;

        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals("Floor"))
        {
            floorTouched = false;
            StartCoroutine(ChangeGravityScale(1));
        }
        else if (collision.collider.tag.Equals("Ladder"))
        {
            ladderTouched = true;
        }
        else if (collision.collider.tag.Equals("Package"))
        {
            rigid2D.constraints &= ~RigidbodyConstraints2D.FreezePosition;
            rigid2D.freezeRotation = true;
        }
    }

    


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ladder"))
        {
            ladderTouched = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ladder"))
        {
            ladderTouched = false;
        }
    }

    


    

    IEnumerator ChangeGravityScale(int scale)
    {
        yield return new WaitForSeconds(1f);
        rigid2D.gravityScale = scale;
    }


}
