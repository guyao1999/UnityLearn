using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

 public class RubyController : MonoBehaviour
 {
     // Start is called before the first frame updat
     public int maxHealth=5;
     public float speed=3.0f;
     int currentHealth;

     public float timeInvicible = 2.0f;  //无敌时间
     bool isInvincible;                  //是否无敌
     float invicibleTimer;               //无敌计时器
     

     //添加health属性，不是函数
     public int health { get { return currentHealth; }}  //使用函数来获取到私有变量

     Rigidbody2D rigidbody2d;
     float horizontal;
     float vertical;

     void Start()   //只在游戏开始时执行一次
     {
         //QualitySettings.vSyncCount = 0;     //   
         //Application.targetFrameRate = 10;   //设置帧率为   10帧/s   默认为60帧/s
         currentHealth=maxHealth;                       //初始化声明值
         rigidbody2d = GetComponent<Rigidbody2D>();  //得到这个游戏对象的rigidbod
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


         //transform.position = position;         
         //rigidbody2d.MovePosition(position);    //将刚体移动到新的位置  
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
        if(amount<0)
        {
            if(isInvincible)
               return;
            isInvincible=true;               //修改处于无敌状态  
            invicibleTimer=timeInvicible;    //初始化无敌时间
        }
         currentHealth = Mathf.Clamp(currentHealth+amount,0,maxHealth); //钳制函数，使得修改后的值不会小于第一个数，不会大于第二个数
         Debug.Log(currentHealth+"/"+maxHealth);
     }

     
     
}