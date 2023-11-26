using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Eagle : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb2;
    [Header("速度設定")]
    public float speed;
    [Header("邊界設定")]
    public Transform upPoint;
    public Transform downPoint;
    bool isUp=false;
    float upY,downY;
    void Start()
    {
        rb2=GetComponent<Rigidbody2D>();
        upY=upPoint.position.y;
        downY=downPoint.position.y;

        Destroy(upPoint.gameObject);
        Destroy(downPoint.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement(){

        if(isUp==false)
        {
            rb2.velocity=new Vector2(rb2.velocity.x,-speed);
            if(transform.position.y<downY)
            {
                isUp=true;
            }
        }
        else if(isUp==true)
        {
            rb2.velocity=new Vector2(rb2.velocity.x,speed);
            if(transform.position.y>upY)
            {
                isUp=false;
            }
        }


    }
}
