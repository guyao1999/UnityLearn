using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

//mycode
using LuaInterface;       //命名空间

public class Main : MonoBehaviour
{
    private LuaState lua=null;
    private LuaFunction LuaFunc=null;

    // Start is called before the first frame update
    void Start()
    {
        new LuaResLoader();         //自定义加载器加载文件
        lua = new LuaState();       //初始化lua虚拟机
        lua.Start();                //开启虚拟机
        LuaBinder.Bind(lua);        //向lua虚拟机注册work类
        //ua.DoFile("Testlua.lua");   //打开lua脚本
        lua.DoFile("Controller.lua");   //打开lua脚本

        CallFunc("Controller.Start");

    }

    // Update is called once per frame  每帧调用一次
    void Update()
    {
         CallFunc("Controller.Update");   
    }
    
    void CallFunc(string func)
    {
        LuaFunc=lua.GetFunction(func);   //根据lua的函数名找到这个lua函数
        LuaFunc.Call();                  //执行这个lua函数

    }
}
