using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{

    //  void OnTriggerEnter2D(Collider2D other){   //Enter2D只有在进入的时候进行调用，呆在里面的时候不进行调用
    //     Debug.Log(other+" enter into DamageZone");
    //     RubyController controller = other.GetComponent<RubyController>();
    //     if(controller!=null){
    //         if(controller.health>0){
    //             controller.ChangeHealth(-1);
    //         }
    //     }
    //  }
     void OnTriggerStay2D(Collider2D other){   //Enter2D只有在进入的时候进行调用，呆在里面的时候不进行调用
        //Debug.Log(other+" enter into DamageZone");
        RubyController controller = other.GetComponent<RubyController>();
        if(controller!=null){
            controller.ChangeHealth(-1);
        }
     }

}
