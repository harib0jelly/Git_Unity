using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 move = Vector3.zero;
    Rigidbody2D myRigid;
    Animator myAnim;
    SpriteRenderer mySr;

    bool isJump = false;
    bool isDead = false;

    float speed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
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
                myAnim.SetBool("run", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                move = Vector3.left;
                myAnim.SetBool("run", true);
            }
            else
            {
                move = Vector3.zero;
                myAnim.SetBool("run", false);
            }

            if(Input.GetKeyDown(KeyCode.Space)&& isJump == false)
            {
                move = Vector3.up;
                myRigid.AddForce(Vector3.up * 300.0f);
                myAnim.SetBool("jump", true);
                isJump = true;
            }
            transform.Translate(move * speed * Time.deltaTime);
        }
        
    }
}
