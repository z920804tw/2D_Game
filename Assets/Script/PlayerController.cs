using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb2;
    [Header("速度相關控制")]
    public float speed;
    public float jumpForce;
    [Header("按鍵設定")]
    public KeyCode jumpKey= KeyCode.Space;

    [Header("動畫設定")]
    public Animator anim;
    [Header("LayerMask、Ray設定")]
    public LayerMask groundLayer;
    public float playerHeight;
    bool ground;

    int itemCollection=0;
    

    


    
    void Start()
    {
        rb2=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()                    //在物理運動時可用
    {
        Movement();
    }
    void Update(){ 
        ground=Physics2D.Raycast(transform.position,Vector2.down,playerHeight,groundLayer);    //使用Ray來偵測是否碰到groundLayer
        Debug.DrawRay(transform.position,new Vector2(0,-playerHeight),Color.red);                   //將射線顯示出來
        MyInput();
        SwitchAnim();

        

        
    }
    void MyInput(){
        if(Input.GetKeyDown(jumpKey))//跳躍功能
        {       
            if(ground==true)
            {
            rb2.velocity=new Vector2(rb2.velocity.x,jumpForce);
            anim.SetBool("jumping",true);
            }

            
        }
    }

    void Movement(){
        
        float horizontalMove = Input.GetAxis("Horizontal");//沒有Raw版本的會取-1 ~ 1 間的值(包含浮點數)
        float facedircetion=Input.GetAxisRaw("Horizontal"); //有Raw版本的只會取得 -1 0 1 這三個值而已

        rb2.velocity=new Vector2(horizontalMove*speed *Time.deltaTime,rb2.velocity.y);
        if(horizontalMove!=0)
        {
           anim.SetBool("running",true);
        }
        else
        {
            anim.SetBool("running",false);
        }

        if(facedircetion!=0)//設定角色的面朝向，因為Scale.X=-1時是反方向
        {                                   
            transform.localScale= new Vector3(facedircetion,1,1);
            
        }
        
        
        
    }

    void SwitchAnim()    //動畫控制
    {

        anim.SetBool("idle",false);
        if(anim.GetBool("jumping")==true)
        {
            if(rb2.velocity.y<0)       //當角色正在下落時
            {
                anim.SetBool("jumping",false);
                anim.SetBool("falling",true);
            }

        }
        else 
        {
            if(ground==true)
            {
            anim.SetBool("falling",false);
            anim.SetBool("idle",true);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Collection")
        {
            itemCollection+=1;
            Debug.Log(itemCollection);
            Destroy(other.gameObject);

        }
    }



    
    
}
