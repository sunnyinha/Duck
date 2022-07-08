using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 3;
    public float jumpForce = 50;
    public float timeBeforeNextJump = 1.0f;
    private float canJump = 0f;
    Animator anim;
    Rigidbody rb;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(move());
    }

    void Update()
    {
        ControllPlayer();
    }

    IEnumerator move()
    {
        float moveHorizontal = Random.Range(-10.0f, 10.0f);
        float moveVertical = Random.Range(-10.0f, 10.0f);

        Vector3 movement =  new Vector3(moveHorizontal, 0.0f, moveVertical);

        //if(//moveHorizontal >10 || moveVertical <10)
        //{
        //    anim.SetInteger("Walk", 0);
        //}

        //else{ 
        
        anim.SetInteger("Walk", 1);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime*3);
        transform.position = Vector3.Lerp(transform.position, movement, Time.deltaTime*3);
        //while float 점점 증가시켜서 1까지 움직이면 구현 가능
        //베르 -> 로딩창 구현하기
        //}


        yield return new WaitForSeconds(5.0F);
        
        StartCoroutine(move());
    }

    void ControllPlayer()
    {
        

        //if (Input.GetButtonDown("Jump") && Time.time > canJump)
        //{
        //        rb.AddForce(0, jumpForce, 0);
        //        canJump = Time.time + timeBeforeNextJump;
        //        anim.SetTrigger("jump");
        //}
    }
}