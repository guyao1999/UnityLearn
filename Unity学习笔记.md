### Unity学习笔记

[TOC]

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
>    ![image-20220628214731027](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220628214731027.png)
>
> -  视图--------persp/ISO------点击可以切换视图
>
>   ![image-20220628215050686](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220628215050686.png)
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
>   >![image-20220628224450181](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220628224450181.png)
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
> > ![image-20220630212643097](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220630212643097.png)
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
> >   ![image-20220702160222318](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702160222318.png)
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
> > ![image-20220702161332990](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702161332990.png)
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
> > ![image-20220702161747922](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702161747922.png)
>
> **创建依赖 以及打包之后的关系**
>
> > 给player添加一个test脚本
> >
> > 在test脚本中添加要给GameObject  go属性
> >
> > 将player1添加到这个属性上  ------此时player依赖于player1
> >
> > ![image-20220702165532448](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702165532448.png)
> >
> > 进行AssetBundle打包之后，可以在player的mainfest文件中看到它依赖于player1
> >
> > ![image-20220702165701254](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702165701254.png)
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

#### Ruby's Adventure

> - Unity无法直接使用png格式的图片，导入之后，Unity会自动将其转换为sprite格式
>
> - Time.deltaTime   这个变量是按秒为单位，完成上一帧所用的时间
>
>   > - 当电脑的刷新频率为50帧/s时，则Time.deltaTime=0.02
>   > - 当电脑的刷新频率为25帧/s时，则Time.deltaTime=0.04
>   >
>   > 1. 50帧/s时,每帧走0.1f\*horizontal*0.02 个单位
>   > 2. 25帧/s时,每帧走0.1f\*horizontal*0.04个单位
>   >
>   > - 0.1f\*horizontal*0.02 * 50= 0.1horizontal
>   > - 0.1f\*horizontal*0.04 * 25=0.1horizontal
>   >
>   > - 所以使用Time.deltaTime实现了平滑过渡，防止了不同的电脑的刷新频率不一样带来的表现效果不一样
>
> - Grid--->TileMap
>
>   > 网格 瓦片地图
>   >
>   > 方便进行地图的编辑，在编辑时只需要将tile进行填充就可以实现地图的编辑
>
> - Tile palette 
>
>   > 网格调色板，用于放置Tile瓦片，方便对地图进行填充
>   >
>   > 在palette上放置不同的tile
>   >
>   > 打开plette之后，选择画笔，然后就可以直接将tile添加到tilemap上，实现地图的绘制
>   >
>   > > pallette类似画画时用的画板
>   > >
>   > > tile类似颜料
>   > >
>   > > tilemap类似于带格子的画布
>
> - Girp
>
>   > 在Insperator中Scale表示一个格子的大小
>   >
>   > ![image-20220702215419644](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702215419644.png)
>
> - Tile
>
>   >  Tile中的pixels per Unit表示将tile填充到Girp中时，一个格子填充几个像素
>   >
>   > ![image-20220702215542233](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702215542233.png)
>
> - Tile集  or 瓦片集
>
>   > 通常一个一个的导入tile和对单个tile进行管理很麻烦，因此将tile做成了一个集合，称作瓦片集
>   >
>   > 在Inspector中将single改成mutil就告诉了unity这是一个瓦片集不是单个的瓦片
>   >
>   > ![image-20220702220155953](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702220155953.png)
>
> - Tile集的切分
>
>   >  选中瓦片集 点击右侧的Sprite Editor进行瓦片 or 精灵的切分
>   >
>   > ![image-20220702220955745](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702220955745.png)
>   >
>   > 弹出sprite Editor窗口
>   >
>   > 选择slice切分  
>   >
>   > type选择Grid By Cell Count ，按照网格的数量来进行切分
>   >
>   > 行&列,输入3,3，表示将该精灵切分为3*3的格式，总共得到9个精灵
>   >
>   >  ![image-20220702221131669](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702221131669.png)
>
> - Order in Layer 调整图层
>
>   > Order in Layer的值用来调整Render绘制图像时的顺序
>   >
>   > 值小的处于底层，先绘制
>   >
>   >![](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220702230633244.png)
>
> - 更改图像设置
>
>   > Edit---->Project Settings---->Transparency Sort Mode
>   >
>   > 修改为Custom Axis表示使用按照自定义的轴向来进行图形的渲染
>   >
>   > 修改x=0, y=1,z=0；表示在y轴上基于精灵的基础上来进行图像的绘制
>   >
>   > 效果
>   >
>   > > 当精灵在物体的前面时，显示的是精灵
>   > >
>   > > 当精灵在物体的后面是，显示的是物体
>   >
>   > ![image-20220703104818310](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703104818310.png)
>
> - 修改精灵的坐标轴的轴心
>
>   > 添加物体时，物体的轴心默认为物体的中间
>   >
>   > ![image-20220703105519508](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703105519508.png)
>   >
>   > 如果轴心为Bottom则当物体的位置为0,0,0时，物体的底部在0,0,0这个位置
>   >
>   > 如果轴心为center则当物体的位置为0,0,0时，物体的中间在0,0,0这个位置
>   >
>   > tips:虽然修改了轴心，但是在点击物体时，物体上用于定位的坐标轴的位置不变
>   >
>   > ![image-20220703110302450](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703110302450.png)
>   >
>   >  
>   >
>   > 上述方式存在的问题：
>   >
>   > 问题1：只能将轴心修改在一些特定的位置，为了实现可以将轴心修改为任意位置，这时候需要使用Sprite Editor
>   >
>   > 图中的小蓝点位置就是轴心，可以修改到任意位置
>   >
>   > ![image-20220703110741478](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703110741478.png)
>   >
>   > 问题2：只能修改单个精灵的轴心，无法更改tile集的轴心
>   >
>   > 使用上述方法可以修改tile集的轴心
>   >
>   > ![image-20220703111008058](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703111008058.png)
>
> - 物理系统
>
>   > **Rigidbody:**
>   >
>   > 对物体进行推力，摩檫力，重力等的模拟需要进行复制的计算，Unity将该功能进行了统一。为了实现物理量的模拟，Unity提供了Rigidbody组件来进行模拟
>   >
>   > Rigidbody用来给物体添加一系列的物理量
>   >
>   > 不使用重力时，将Gravity Scal设置为0
>   >
>   > **tips:**
>   >
>   > > 如图，Grivity Scale为加粗字体，旁边有蓝色的线，这表示我们进行的修改是随Scene中的物体进行的修改,而不是在预制体上进行的修改，后续再次添加ruby时，Gravity Scale的值依然为1
>   >
>   > ![image-20220703115305131](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703115305131.png)
>   >
>   >  **将更改应用到预制体上：**
>   >
>   > > 选中ruby之后，右边的Overrides下拉会展示当前的对象和预制体的区别，
>   > >
>   > > 点击Apply All表示将更改同步到预制体上，下次通过预制体添加ruby时，添加的ruby的Gravity Scale为0
>   >
>   > ![image-20220703115930950](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703115930950.png)
>   >
>   > **碰撞检测 Box Collider 2D:**
>   >
>   > 给ruby添加Box Collider 2D组件之后，ruby周围会出现一个框，这个框时碰撞检测时的检测范围
>   >
>   > ![image-20220703120513608](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703120513608.png)
>   >
>   > **解决旋转问题：**
>   >
>   > 旋转触发的原因：在碰撞的时候两个box的角碰撞到了就会导致反弹方向不水平，因此出现了旋转现象
>   >
>   > 解决办法：进入预制体模式，Ridigbody组件，将constrains下的Freeze Rotation
>   >
>   > 表示进行限制，冻结旋转
>   >
>   > ![image-20220703121511642](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703121511642.png)
>   >
>   > **解决抖动问题：**
>   >
>   > 抖动原因：
>   >
>   > > 游戏场景和物理系统为两个系统，在物理系统中，只有需要进行碰撞检测的物体。碰撞检测的逻辑是计算两个物体是否重合，如果出现重合，就将其中的一个物体的碰撞框移出去，然后到游戏场景更新物体的新位置。但是由于帧的存在，导致在游戏场景两个物体出现了重合之后，物理系统再检测到两个物体的重合，因此需要将其移出去。这就导致了抖动的出现。
>   > >
>   > > 总结：物理系统在游戏对象进入箱子之后再将其移出去，就导致了抖动。
>   >
>   > 解决办法：
>   >
>   > > 使用刚体来移动游戏角色的位置，而不是移动游戏角色本身
>   > >
>   > > - 在使用游戏角色的位置来进行移动时，不进行检测，会将游戏角色移动到箱子内部，然后碰撞系统检测到碰撞再将游戏角色移动出来，就出现了抖动
>   > >
>   > > - 使用刚体的位置来进行移动时，在移动的过程中会进行碰撞的检测，如果出现了碰撞就不进行移动了，所有没有抖动。
>   >
>   > **调整碰撞的检测范围:**
>   >
>   > > 进入预制体视图，找到Box Collider ，点击Edit Collider，将碰撞检测的框修改为如图所示，这样可以使得ruby可以走到箱子的后面
>   > >
>   > > ![image-20220703153138953](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703153138953.png)
>   >
>   > **给tile添加碰撞检测：**
>   >
>   > > 先给tileMap添加**Tilemap Collider 2D**碰撞检测组件，这时所有的tileMap都被标记为进行碰撞检测
>   > >
>   > > 在project中选中所有不需要进行碰撞检测的tile，将collider type修改为none
>   > >
>   > > ![image-20220703154408504](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703154408504.png)
>   >
>   > **优化碰撞检测，将场景中的碰撞体合并:**
>   >
>   > > 首先给TileMap添加Composite Collider 2D组件，该组件用于将碰撞合成为一个
>   > >
>   > > 添加Composite Collider 2D组件之后，会自动添加要给Rigidbody 2D组件，因为Composite Collider 2D组件需要Rigibody 2D组件才能运行
>   > >
>   > > 勾选Tilemap Collider 2D组件的Used By Compostite，表示这个碰撞体被合成到Composite Collider 2D中
>   > >
>   > > 将Rigidbody 2D 组件的Body Type修改为Static；表示刚体不能运动
>   > >
>   > > ![image-20220703155321835](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703155321835.png)
>
> - 世界交互1----添加生命值
>
>   > **脚本：**
>   >
>   > 在脚本中声明为public的变量将会被公开，在Inspector可以至今进行修改
>   >
>   > ![image-20220703163559502](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703163559502.png)
>   >
>   > **Update()函数用于每帧更新，可以准时得到输入数据**
>   >
>   > **FixedUpdate()函数用于固定更新，保证物理量的计算稳定**
>   >
>   > **触发器：**
>   >
>   > 添加一个ColletialeHeath，
>   >
>   > 添加Box Collider 2D然后勾选Is Trigger，将碰撞检测修改为触发器
>   >
>   > 这时ruby碰到这个ColletialeHeath时，碰撞系统会记录此碰撞，但是此时没有函数进行处理，所以游戏对象对碰撞没有反应
>   >
>   > ![image-20220703164157796](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703164157796.png)
>
> - 世界交互2-----添加伤害区域和敌人
>
>   > 添加Damageable精灵到游戏场景中
>   >
>   > 给该精灵添加脚本来修改ruby的生命值
>   >
>   > 将OnTriggerEnter2D修改为OnTriggerStay2D，以实现ruby呆在Damge区域时持续受到伤害，而不是只在进去的那个时候受到伤害
>   >
>   > **Q1:**
>   >
>   > > ruby进去DamageZone区域不动时不会受到伤害
>   > >
>   > > 原因:刚体不动时，物理系统不会计算刚体之间的碰撞，进入sleep状态
>   > >
>   > > 解决方法：将ruby的Rigidbody的Sleep Mode修改为Never Sleep
>   > >
>   > > ![image-20220703195910606](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703195910606.png)
>   >
>   > **Q2:**
>   >
>   > > ruby在DamageZone中时，很快就会失去了所有的生命值
>   > >
>   > > 解决办法：添加无敌时间，处于无敌时间时，不修改生命值
>
> - 精灵渲染器
>
>   > **Tips:T键可以调出矩形工具，实现对游戏场景中的精灵的范围进行调整**
>   >
>   > 为了在对精灵进行拉伸时比例不变，而是使用相同的内容进行平铺，
>   >
>   > 选中精灵，将Draw Mode修改为Tiled
>   >
>   > 将Tile Mode修改为 Adaptive
>   >
>   > 如果出现警告，就将**project**中的该精灵的Mesh Type修改为Full Rect
>   >
>   > ![image-20220703201737686](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703201737686.png)
>   >
>   > ![image-20220703201932644](C:\Users\HP\AppData\Roaming\Typora\typora-user-images\image-20220703201932644.png)
>
> - 敌人
>
>   > 让其左右运动或上下运动
>
> - 添加伤害
>
>   > **OnTriggerEnter2D**  使用触发器，第一次碰撞时进行调用
>   >
>   > **OnTriggerStay2D**   使用触发器，呆在区域内时进行调用
>   >
>   >  **OnCollisionEnter2D**  使用碰撞检测，发生碰撞时进行调用
>   >
>   > ```c#
>   > 
>   >     void OnCollisionEnter2D(Collision2D other)    //Collision2D  和 Collider2D的不同
>   >     {
>   >         RubyController player = other.gameObject.GetComponent<RubyController>();  //这里多了一个gameObject对象来进行调用
>   > 
>   >         if (player != null)
>   >         {
>   >             player.ChangeHealth(-1);
>   >         }
>   >     }
>   > ```
>   >
>   > **Collider2D**可以直接调用GetComponent函数
>   >
>   > **Collidsion2D** 没有GetComponent函数，但是存在一系列的碰撞信息，可以使用gameObject来间接调用
>
> - 动画 Animator
>
>   > 给机器人添加Animator组件

