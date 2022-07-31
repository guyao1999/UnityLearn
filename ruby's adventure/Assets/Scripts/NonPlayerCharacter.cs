using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;  //从inspector界面进行添加
    float timerDisplay;
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;  //减去一个时间
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);  //时间到了，不显示
            }
        }
    }

    public void DisplayDialog()  //触碰时，显示对话
    {
        timerDisplay = displayTime;   //初始化
        dialogBox.SetActive(true);    //开始对话
    }
}
