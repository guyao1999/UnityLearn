using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 public class RubyController : MonoBehaviour
 {
     // Start is called before the first frame updat
     public int maxHealth=5;
     public float speed=3.0f;
     int currentHealth;

     public float timeInvicible = 2.0f;  //无敌时间
     bool isInvincible;                  //是否无敌
     float invicibleTimer;               //无敌计时器

     Animator animator;
     Vector2 lookDirection= new Vector2(1,0);   //存放ruby观看的方向 Look X   or  Look Y

     //添加health属性，不是函数
     public int health { get { return currentHealth; }}  //使用函数来获取到私有变量

     private Rigidbody2D rigidbody2d;
     float horizontal;
     float vertical;


     public GameObject  projectilePrefab;     //一个CogBullet的预制体

     void Start()   //只在游戏开始时执行一次
     {
         //QualitySettings.vSyncCount = 0;     //   
         //Application.targetFrameRate = 10;   //设置帧率为   10帧/s   默认为60帧/s
         currentHealth=maxHealth;                       //初始化声明值
         rigidbody2d = GetComponent<Rigidbody2D>();  //得到这个游戏对象的rigidbod

         animator=GetComponent<Animator>();
     }
     // Update is called once per frame
     void Update()    //每帧执行一次   只进行数据的收集
     {        
         //Vector2 position =transform.position;         //得到游戏对象的位    
         //Vector2 position = rigidbody2d.position;         //得到刚体的位置
         horizontal = Input.GetAxis("Horizontal");    //获取到Horizontal的值，当按下a时，值为负数，当按下d时，值为正数   取值范围为[-1,1]
         vertical=Input.GetAxis("Vertical");

         if(isInvincible){
            invicibleTimer-=Time.deltaTime;
            if(invicibleTimer<0)
            {
                isInvincible=false;
            }
         }


        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))  //x不等于0  或 y不等于0 ---->ruby在移动
        {
            lookDirection.Set(move.x, move.y);  //设置方向
            lookDirection.Normalize();          //将值修改为1 或-1这样的数(用来存放方向)
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);  //设置动画controller组件中的方向
        animator.SetFloat("Speed", move.magnitude);    //move向量的长度


         //transform.position = position;         
         //rigidbody2d.MovePosition(position);    //将刚体移动到新的位置  


        if(Input.GetKeyDown(KeyCode.C))   //按c键，投射飞镖
        {
            Launch();
        }


        //对话系统（射线投射）
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Raycast 射线投射
            //起点、方向、射线距离、碰撞检测的图层
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)  //返回检测到的NPC
            {
                 Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();  //获取到NPC的控制脚本
                if (character != null)
                {
                    Debug.Log("character not null");
                    character.DisplayDialog();
                }  
            }
        }
     }
     void FixedUpdate()                          //FixedUpate用于定期更新，保持物理计算稳定
     {
         //Debug.Log("call FixedUpdate");
         Vector2 position = rigidbody2d.position;
         position.x = position.x + speed* horizontal * Time.deltaTime;
         position.y = position.y + speed* vertical * Time.deltaTime;
         rigidbody2d.MovePosition(position);
     }
     
     public void ChangeHealth(int amount)   //让其他脚本调用时也可以访问
     {
        if(amount<0)  //伤害减一
        {
            if(isInvincible)
               return;
            isInvincible=true;               //修改处于无敌状态  
            invicibleTimer=timeInvicible;    //初始化无敌时间

            animator.SetTrigger("Hit");     //播放被伤害的动画
        }
         currentHealth = Mathf.Clamp(currentHealth+amount,0,maxHealth); //钳制函数，使得修改后的值不会小于第一个数，不会大于第二个数

        

         UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);  //修改Ui
        //  Debug.Log(currentHealth+"/"+maxHealth);
     }

     void Launch()
     {
        //Instantiate第一个参数是一个对象，在第二个参数的位置处创建一个副本，第三个参数是旋转。
       GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);  //在场景中实例化这个对象
       Projectile projectile = projectileObject.GetComponent<Projectile>();            //得到这个对象的脚本                                            
       projectile.Launch(lookDirection, 300);                                    //调用脚本中的函数

       animator.SetTrigger("Launch");   //设置触发器，播放动画
     }



     
     
}