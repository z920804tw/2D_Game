using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Frog : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb2;
    [Header("速度")]
    public float speed;
    [Header("邊界設定")]
    public Transform leftPoint;
    public Transform rightPoint;


    float leftX,rightX;

    bool faceLeft=true;
    void Start()
    {
        rb2=GetComponent<Rigidbody2D>();
        leftX=leftPoint.transform.position.x;
        rightX=rightPoint.transform.position.x;

        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(faceLeft==true)
        {
            rb2.velocity=new Vector2(-speed,rb2.velocity.y);
            if(transform.position.x<leftX)
            {
                faceLeft=false;
                transform.localScale=new Vector3(-1,1,1);
            
            }
        }
        else if(faceLeft==false)
        {
            rb2.velocity=new Vector2(speed,rb2.velocity.y);
            if(transform.position.x>rightX)
            {
                faceLeft=true;
                transform.localScale=new Vector3(1,1,1);
            }
        }
    }
}
