### Unity学习笔记

[TOC]

#### Transform类

> 1. transform.DOScale()，这个函数是在引入命名空间DG.Tweening之后才有的方法，属于DG.Tweening的方法。

#### 基础界面知识

> 1. project界面和Asset and Packages文件夹对应----游戏资源界面
> 2. Hierarchy界面-----------------------------------------------游戏对象界面
> 3. Scene-----------------------------------------------------------操作界面
> 4. game------------------------------------------------------------游戏预览界面
> 5. 三角--------------------------------------------------------------运行游戏

#### 快捷键 or 界面知识

> 1. 聚焦---------选中物体，按F键（focus）
>
> 2. 对齐（顶点吸附）---------选中物体,按v,定位定点，拖拽到对齐的物体上，松开v
>
> 3. reset------右键transform出现reset
>
> 4. center/pivot------切换坐标的位置
>
> 5. global/local-------切换坐标为世界坐标 or 本地坐标
>
> 6. 预览游戏/逐帧播放/暂停
>
>    ![image-20220628214731027](typora-user-images\image-20220628214731027.png)
>
> -  视图--------persp/ISO------点击可以切换视图
>
>   ![image-20220628215050686](typora-user-images\image-20220628215050686.png)
>
> - Scene ------一个关卡----里面存放游戏对象
>
> - 游戏对象GameObject
>
>   > 游戏对象为一个容器，容器用于装组件Component
>   >
>   > Transform组件-------物体的坐标
>   >
>   > Mesh Filter组件------网格过滤器，获取物体的形状信息
>   >
>   > Mesh Renderer------网格渲染器，显示物体的颜色等信息
>
> - 游戏对象的合并---打组
>
>   > - 操作将其他物体拖拽到某一个物体下面，将这个物体作为父物体，剩余的都当作子物体
>   >
>   > - 更好的方式-----创建一个empty物体，将其他的物体放在这个empty物体下（将子物体全部reset之后再进行调整）

#### Material

> 材质：颜色，
>
> shader着色器
>
> texture:附加到物体表面的贴图
>
> - 给一个物体添加材质
>
>   >- 创建Material
>   >
>   >- 给Material选择颜色
>   >
>   >- 将Material拖拽给物体对象的Mesh Renderer出的Material出的element
>   >
>   >![image-20220628224450181](typora-user-images\image-20220628224450181.png)
>
> - 给一个物体贴图
>
>   > 将图片拖拽到物体上，拖拽的过程自动生成material,并将这个material付给Mesh Renderer
>
> - 渲染模式
>
>   > Opaque默认---不透明
>   >
>   > Cutout-----------将透明通道去掉，只留下边框
>   >
>   > Transpant------透明的，看得见（同时在颜色处修改透明度）
>   >
>   > Fade--------------淡入淡出（可以看不见）
>
> - material实质就是一个shader的实例，shader一段嵌入到管程中的渲染程序
>
> - **shader是类，material是具体的对象**，选择的shader不同是，material的具体细节也不同

#### Unity和Lua的交互

> - c#中运行lua代码
>
>   > ```c#
>   > //直接运行的方式，和unity没有关系
>   > using System.Collections;
>   > using System.Collections.Generic;
>   > using UnityEngine;
>   > //需要加入LuaInterface.dll和Luanet.dll两个库
>   > using LuaInterface;
>   > public class CSharpRunLuaCode
>   > {
>   >      static void Main()
>   >      {
>   >         Lua lua= new Lua(); //创建一个lua解释器
>   >         lua["vale"]=34;//定义一个lua变量
>   >         Console.WirteLine(lua["vale"]);
>   >         Console.ReadKey();
>   >      }
>   > }
>   > ```
>
> - c#中调用Lua脚本
>
>   > ```c#
>   > //直接运行的方式，和unity没有关系
>   > using System.Collections;
>   > using System.Collections.Generic;
>   > using UnityEngine;
>   > //需要加入LuaInterface.dll和Luanet.dll两个库
>   > using LuaInterface;
>   > public class Program
>   > {
>   >      static void Main()
>   >      {
>   >         Lua lua= new Lua(); //创建一个lua解释器
>   >         
>   >         lua.DoString("num=2");       //lua.DoString()执行一段lua代码
>   >         lua.DoFile("Controller.lua");//lua.DoFile()执行一段lua脚本  处于同一个目录
>   >      }
>   > }
>   > ```
>
> - c#和lua中变量类型的对应
>
>   > ```c#
>   > nil        null
>   > string     System.String
>   > number     System.Double
>   > boolean    System.Boolean
>   > table      LuaInterface.Table
>   > function   LuaTnterface.LuaFunction
>   > ```
>
> - 把c#的普通方法注册进Lua的全局方法
>
>   > ```c#
>   > /*
>   >   lua.RegisterFunction("NormalMethod",obj,obj.GetType().GetMethod("NormalMethod"));
>   >   
>   >   lua.DoString("NormalMethod");  使用的方式来进行调用
>   >   //NormalMethod   表示注册到lua中之后叫什么方法
>   >   //obj表示注册哪个对象
>   >   //obj.obj.GetType().GetMethod("NormalMethod") 哪个对象中的哪个方法 
>   >   
>   >   
>   >   //普通方法是属于一个具体的对象的，所有需要先创建对象，再使用对象来获取到方法
>   > 
>   > */
>   > using System;
>   > using LuaInterface;
>   > public class Program
>   > {
>   >      static void Main()
>   >      {
>   >         Lua lua= new Lua(); //创建一个lua解释器
>   >          
>   >         
>   >          Program p=new Program();  //定义一个对象
>   >          lua.RegisterFunction("LuaMethod"，p，p.GetType().GetMethod("CLRMethod"));
>   >          
>   >          lua.DoString("LuaMethod");
>   > 
>   >      }
>   >     
>   >    
>   >      public void CLRMethod() //c#方法
>   >      {
>   >          Console.WriteLine("haha")
>   >      }
>   > }
>   > ```
>
> - c#将静态方法注册到Lua的全局变量中
>
>   ```c#
>   /*
>     lua.RegisterFunction("StaticMethod",null,typeof(ClassName)GetMethod("NormalMethod"))
>     //StaticMethod   表示注册到lua中之后叫什么方法
>     //typeof(ClassName)GetMethod("NormalMethod")哪个类中的哪个静态方法 
>                 
>     //静态方法属于一个对象，所以第二个参数可以不要
>               
>   */
>   using System;
>   using LuaInterface;
>   public class Program
>   {
>        static void Main()
>        {
>           Lua lua= new Lua(); //创建一个lua解释器
>                        
>           lua.RegisterFunction("LuaMethod"，null，typeof(Program).GetMethod("CLRMethod"));
>                        
>            lua.DoString("LuaMethod");
>               
>        }
>       
>      
>        public static void CLRMethod() //c#方法
>        {
>            Console.WriteLine("haha")
>        }
>   }
>   ```
>
>   
>
> - Lua中使用c#中的类
>
>   > ```lua
>   > require "luanet"                      --引入luanet   luanet.dll
>   > luanet.load_assembly("System")        --加载一个dll  or 加载一个命名空间
>   > luanet.import_type("System.Int32")    --引入命名空间下的一个类
>   > 
>   > local num=Int32.Parse("32")           --调用Int32类中的一个静态方法
>   > 
>   > print(Int32)
>   > ```
>
> - Lua中访问c#的属性和方法
>
>   > ```c#
>   > using System;
>   > using LuaInterface;
>   > 
>   > namespace testLuaInterface{
>   >    class Program
>   >    {
>   >        public string name="feitan";
>   >        
>   >        public void testMethod()
>   >        {
>   >            Console.WriteLine("TestMethod");
>   >        }
>   >         
>   >    }
>   > }
>   > ```
>
>   > ```lua
>   > require "luanet"                      --引入luanet   luanet.dll
>   > luanet.load_assembly("testInterface") --加载一个dll  or 加载一个命名空间
>   > luanet.import_type("testInterface.Program")    --引入命名空间下的一个类
>   > 
>   > program1=Program()
>   > 
>   > print(program1.name)
>   > program1:TestMethod()
>   > 
>   > 
>   > --特殊情况 
>   > c#中的参数有out 关键字和  ref关键字时需要特殊处理
>   > 当c#中的方法有out关键字时，在lua中调用这个方法不需要传入参数，但是返回参数时返回两个参数
>   > 
>   > 当c#中的方法有ref关键字时，在lua中调用这个方法时需要传入参数，返回参数时返回两个，需要用两个变量来接受参数
>   > ```
>
>   
>
> - 复制tolua的Assets文件和Unity5.x文件覆盖unity项目中的文件
>
> - 编写c#脚本
>
> - 在CustomSetting中添加上述脚本名
>
> > ![image-20220630212643097](typora-user-images\image-20220630212643097.png)
>
> - 点击lua--->clear wrap file （清空旧得包文件，自动生成新得包文件）
> - 自动在Source-->Generate文件下生成了Test wrap文件，改文件为自动生成的文件，用于lua和c#之间进行交互的中间文件
>
> 
>
> - Testlua.lua ---------TestWrap.lua--------Test.cs(c#文件)
>
> - 创建main.cs文件，在其中注册虚拟机等信息，最后加载Testlua.lua文件，执行了Testlua.lua文件
>
>   
>
> - main.cs----->Testlua.lua---------TestWrap.lua--------Test.cs  
>
>   > Test.cs返回helloworld
>   >
>   > Testlua.lua直接通过local h=Test.TestPrint()得到改方法的返回值
>   >
>   > 最后main.cs再调用lua.DoFile("Testlua.lua")来执行这个lua文件
>
>   
>
> - main.cs----->Testlua.lua **实现了c#文件调用lua文件**
>
>   
>
> - main.cs---->controller.lua**实现了C#调用controller.lua文件中的代码来控制物体**
>
>   
>
> - Testlua.lua ---------TestWrap.lua--------Test.cs(c#文件) **实现了lua文件调用c#文件  TesWrap.lua为lua调用c#文件时的交互文件**
>
> 
>
> -  controller.lua----->music.lua  实现了lua函数之间的调用，这里使用的是

#### AssetsBundle

> 定义:AssetsBundle将各种资源进行合并打包，将资源打包上传到服务器之后，客户端下载之后会自动进行解压。  使用AssetsBundle方便资源的管理
>
> **打包方法：**
>
> > - 将我们的预制体创建为AssetsBundle，将名字修改为以bundle为后缀
> >
> >   ![image-20220702160222318](typora-user-images\image-20220702160222318.png)
> >
> > - 在Editor文件夹下添加脚本，用来实现资源的打包，脚本如下
> >
> >   ```c#
> >   using UnityEditor;
> >   using System.IO;
> >   
> >   public class CreateAssetBundles                //属于编辑器的扩展，不需要作为组件存在，也就不用继承自MonoBehaviour
> >   {
> >       [MenuItem("Assets/Build AssetBundles")]    //进行编辑器的修改，在Asset下面会多出一个Build AssetBundles的按钮
> >       static void BuildAllAssetBundles()
> >       {
> >           string assetBundleDirectory = "Assets/AssetBundles";  //将打包后的AssetBundles存放到这个文件下
> >           if(!Directory.Exists(assetBundleDirectory))
> >           {
> >               Directory.CreateDirectory(assetBundleDirectory);
> >           }       
> >           BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
> >       }
> >   }
> >   ```
> >
> > - 点击Assets下的Build AssetBundles按钮将会自动进行打包
>
> **AssetBundles打包之后的文件：**
>
> > AssetBundes.mainfestl文件用于管理，表示这个AssetBundles下有多少个assetBundles文件
> >
> > Name:这个assetBundles的名字
> >
> > Dependencies:表示这个assetBundles的依赖
> >
> > ![image-20220702161332990](typora-user-images\image-20220702161332990.png)
>
> > player1bundle.manifest文件详解
> >
> > CRC为这个assetBundle的校验码
> >
> > AssrtFileHash 和 TypeTreeHash为文件的版本信息
> >
> > ClassType表示这个assetBundle上面挂载了哪些类
> >
> > Assets:后面的表示这个assetBundle由哪个预制体打包而来
> >
> > Dependencies表示这个assetBundle的依赖
> >
> > ![image-20220702161747922](typora-user-images\image-20220702161747922.png)
>
> **创建依赖 以及打包之后的关系**
>
> > 给player添加一个test脚本
> >
> > 在test脚本中添加要给GameObject  go属性
> >
> > 将player1添加到这个属性上  ------此时player依赖于player1
> >
> > ![image-20220702165532448](typora-user-images\image-20220702165532448.png)
> >
> > 进行AssetBundle打包之后，可以在player的mainfest文件中看到它依赖于player1
> >
> > ![image-20220702165701254](typora-user-images\image-20220702165701254.png)
>
> **进行AssetBundel的下载**
>
> > 创建脚本AssetManager
> >
> > 创建空的物体AssetManager放在scene中，
> >
> > 将AssetManager脚本添加到空物体AssetManager上，实现启动unity时自动进行AssetManager脚本的执行
> >
> > ```c#
> > using System.Collections;
> > using System.Collections.Generic;
> > using UnityEngine;
> > 
> > public class LoadAssetBundle : MonoBehaviour
> > {
> >     public string url;
> >     public string assetName;
> >     // Start is called before the first frame update
> >     IEnumerator Start()   //使用协程来加载
> >     {
> >         WWW www = new WWW(url);  
> >         yield return www;
> >         if(www.error!=null){   //存在错误
> >             Debug.LogError("网络错误");
> >         }
> >         else{
> >             AssetBundle bundle = www.assetBundle;
> >             Object obj=bundle.LoadAsset(assetName);
> >             Instantiate(obj);       
> > 
> >             bundle.Unload(true);  //true把加载来的所有资源都卸载   false表示只卸载用过的资源
> >         }
> >         www.Dispose();
> >     }
> > }
> > 
> > ```
>
> 

#### 精灵和精灵图集

> 对一个精灵或一个图片进行绘制需要进行函数的调用，对很多个精灵进行绘制时会导致开销过大，因此可以将多个精灵进行打包，形成**精灵图集**，一个图集调用一次，这样减小开销。
>
> 



