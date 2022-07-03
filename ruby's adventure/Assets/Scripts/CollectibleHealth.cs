using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)   //函数名指定的，不能随便改 
    {                                         //脚本是添加在CollectibleHealth上的，所以会在碰撞产生的时候自动触发
        Debug.Log("Object that entered the trigger : " + other); 

        RubyController controller = other.GetComponent<RubyController>();  //脚本也是一个组件
        if(controller!=null){   //进行判断，防止重合的是敌人而非玩家             //获取到ruby的控制脚本                                  
            if(controller.health<controller.maxHealth)
            {
                controller.ChangeHealth(1);         
                Destroy(gameObject);          //销毁当前的游戏对象

            }                                        
        }
    }
}