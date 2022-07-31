using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHealthBar : MonoBehaviour
{


    //单例模式的实现
    public static UIHealthBar instance { get; private set; }   //定义了一个UIHealthBar类型的属性  instance 并给这个属性设置了get 和set方法，并且将该属性实例化为this

    public Image mask;
    float originalSize;

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;  //获取mask的宽度
    }

    void Awake()   //注意大写，否则不被调用
    {
        instance =this;
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize*value);
    }
    //当游戏开始时，
    //创建了一个HealthBar1游戏对象，并给这个游戏对象创建了该脚本0，可以通过该脚本就获取到游戏对象的值，修改游戏对象HealthBar1的值
    //如果，又创建了一个HealthBar游戏对象，那么instance被第二个游戏对象覆盖，这时通过HealthBar.instance来访问修改HealthBar时，两个HealthBar同时改变
}
