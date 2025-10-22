using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 move = Vector3.zero;
    Rigidbody2D myRigid;
    SpriteRenderer mySr;

    bool isJump = false;
    bool isDead = false;

    float speed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        mySr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                move = Vector3.right;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                move = Vector3.left;
            }
            else
            {
                move = Vector3.zero;
            }

            if(Input.GetKeyDown(KeyCode.Space)&& isJump == false)
            {
                move = Vector3.up;
                myRigid.AddForce(Vector3.up * 300.0f);
                isJump = true;
            }
            transform.Translate(move * speed * Time.deltaTime);
        }
        
    }
}
