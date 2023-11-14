using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb2;
    [Header("速度相關控制")]
    public float speed;
    public float jumpForce;
    [Header("按鍵設定")]
    public KeyCode jumpKey= KeyCode.Space;
    
    void Start()
    {
        rb2=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()                    //在物理運動時可用
    {
        Movement();
    }
    void Update(){ 

        
        if(Input.GetKeyDown(jumpKey)){
            
            rb2.velocity=new Vector2(rb2.velocity.x,jumpForce);
            
        }
    }


    void Movement(){
        
        float horizontalMove = Input.GetAxis("Horizontal");//沒有Raw版本的會取-1 ~ 1 間的值(包含浮點數)
        float facedircetion=Input.GetAxisRaw("Horizontal"); //有Raw版本的只會取得 -1 0 1 這三個值而已
        if(horizontalMove!=0){
           rb2.velocity=new Vector2(horizontalMove*speed *Time.deltaTime,rb2.velocity.y);

            
        }
        if(facedircetion!=0){                                   //設定角色的面朝向，因為Scale.X=-1時是反方向
            transform.localScale= new Vector3(facedircetion,1,1);
        }

        
    }
}
