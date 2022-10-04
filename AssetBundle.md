### AssetBundle学习

[TOC]

[参考手册](https://docs.unity3d.com/cn/current/Manual/AssetBundles-Workflow.html)

[官方教程](https://learn.unity.com/tutorial/introduction-to-assetbundles#)

[github参考链接](https://github.com/XINCGer/Unity3DTraining/tree/master/HotUpdate)

#### Introduction

AssetBundle用来存储和游戏的主体功能分离的游戏资源的东西。以便于在运行时进行资源加载和资源卸载。这使得用户可以只下载他们需要的模块，减少对网络和系统资源的占用。例如，一个VR自动驾驶软件中，用户可以测试没一辆车的性能，但是开始时app中不会包含所有车的相关资源，如果包含的所有的资源，这个app将会特别的大。而AssetBundle使得用户只需要下载他们需要测试的，且当前的平台可以处理的相关车辆资源即可，不用将所有的资源都下载下来。

#### Advantages of AssetBundels

AssetBundle可以在发版之后进行更新或添加内容。这其中可能包含了可以下载的内容；限时促销事件；和节日相关的主题等等。AssetBundle还可以实现自动更新和项目之间资源的互用。例如，在交流app中，你可能存放了你的品牌的logo或者介绍视频作为一个online assetBundle。当你的品牌改变的时候，你只需要在你的服务器上更新相关的assetBundle就可以。那些通过远程 assetBundle来加载这些资源的app就会加载展示更新之后的内容，而不需要更新整个app。加载这些资源的app可以预先编程来检查这些在线assetBundle的改变，然后将本地的存放的资源更新为最新的就可以。

#### Variants

 AssetBundle可以进一步分为几种类型。一个变量是一个和assetBundle存放在一起的选项或者子类。如果你有一个assetBundle叫做"Vehicles",你应该就有一个car的变体，一个truck的变体。如果你将一个assetBundle赋值给了一个变体，那么你必须将那个bundle下的所有asset分配给一个变体。在

举例说明使用变体来协助assetBundle的组织。假设，我们正在给一个多人控制的视频游戏创建一个教程。下面的表展示了中的一些图像将用来提示玩家按下哪个键。控制面板的排版在现代操作台上和常见，但是按钮上的标签因平台的不同而不同。在这个案例中，尽管标签的不同，TopActionButton在不同的版本的游戏的中，都实现了同一个操作。在我们的代码中，对于直接使用图像操作的平台，我们加载Universal Variant这个button,但在运行的时候，我们需要根据不同的系统来加载包含了button的variant或者键盘图形。

![image-20221003210402615](C:\Users\27236\AppData\Roaming\Typora\typora-user-images\image-20221003210402615.png)

或者，假设说我们在打包一些带有密钥的图片在不同的平台训练用户。consoleA和consoleB可以分别代表windows和macOS,TopActionButton就类似于 cmdCtrl。

#### Creating An AssetBundle

现在，创建assetBundle的唯一方式就是通过脚本来实现。下面的脚本将这以功能在unity Editor中实现了。在BuildAssetBundles()中有三个参数：AssetBunde创建的文件夹、非标准模式下的打包选项BuildAssetBundleOption、assetBundle的目标打包平台。

1、首先在Asset文件夹下创建一个叫做Editor的文件夹

2、在Editor文件夹内，创建一个叫做CreateAssetBundles的c#脚本

3、双击CreateAssetBundles脚本标记这个脚本

4、将脚本中编辑以下内容

```c#
using UnityEditor;
using UnityEngine;
using System.IO;

public class CreateAssetBundles
{
	[MenuItem("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles()
	{
  	string assetBundleDirectory = "Assets/StreamingAssets";
  	if (!Directory.Exists(Application.streamingAssetsPath))
  	{
    	Directory.CreateDirectory(assetBundleDirectory);
  	}
  	BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
	}
}
```

5、保存脚本推出之后，将会在编辑器的上方Asset下的选项中多一个Build AssetBundles的选项。

#### 创建AssetBundles时的参数

1、在开始build  AssetBundle之前，AssetBundle存放的文件夹必须存在

2、BuildAssetBundleeOptions的参数是可选的，如果不进行指定的话默认为none,其他的的参数如下

> - BuildAssetBundleOptions.None             没有指定操作
>
> - BuildAssetBundleOptions.DryRunBuild   这个没有正在的执行build操作，而是跑了一遍这个过程，用来进行错误的检测
> - BuildAssetBundleOptions.StrictMode   如果在build的过程中出现了错误，就停止
> - BuildAssetBundleOptions.UncompressedAssetBundle  进行build操作，但是不将AssetBundle压缩。这使得AssetBundle在build和loade的时候更快，但是也消耗更多的硬盘空间。这对于在开发中加快迭代（访问）速度，但是一般最终进行发版build时，不选用这个选项

#### 目标平台选项

因为不同平台对于AssetBundles的格式要求不一样，所以在对AssetBundle进行build的时候，需要选中打包的目标平台。

> EditorUserBuildSettings.activeBuildTarget   使用你的Build Settings中定义的平台
>
> BuildTarget.Android             安卓平台
>
> BuildTarget.IOS                      IOS平台
>
> BuildTarget.StandaloneLinux               32位的linux平台
>
> BuildTarget.StandaloneLinux64           64位的linux平台
>
> BuildTarget.StandalonOsx                    64为的macOS平台
>
> BuildTarge.StandalonWindows            32位的windows平台
>
> BuildTarge.StandalonWindows64        64位的windows平台
>
> BuildTarge.WebGL                                  
>
> BuildTarget.WASPlayer

#### Create a Simple AssetBundle

1、创建一个新的gameObject 叫做"BundledSpriteObject"、

2、给这个gameObject添加一个Sprite Renderer组件

3、在Assets文件夹下创建一个新的文件夹叫做"BundleAssets"

4、在Assets文件夹下创建一个新的文件夹叫做”StreamingAssets“

5、在BundledAssets文件下，创建一个文件夹叫做”testbundle“

6、将BundledSpriteObject拖拽到testbundle文件夹下，并删除Hierarchy目录下的BundledSpriteObject

7、选中BundledSpriteObject这个预制体，在inspector界面查看

8、找到下面的AssetBundle面板，选择new,输出"testbundle";将创建一个叫做testbundle的AssetBundle,并将BundledSpriteObject这个预制体赋给了这个testbundle

![image-20221004150414182](C:\Users\27236\AppData\Roaming\Typora\typora-user-images\image-20221004150414182.png)

9、前面的一个参数表示将这个BundledSpriteObject非配给哪个AssetBundle,后面的参数表示这个BundledSpriteObject的变体名(variant name)

10、从编辑器面板选中Asset,点击最下面的Build AssetBundles(运行我们之前写的脚本)，这一步执行之后将在StreamingAssets文佳夹下生成我们build出来的AssetBundle

![image-20221004151016122](C:\Users\27236\AppData\Roaming\Typora\typora-user-images\image-20221004151016122.png)

#### Loading a locally stored AssetBundle

假设上面的过程没有出现错误，那么我们现在可以从本地库中加载我们已经存放好的AssetBundle。为了验证我们的加载方法，我们直接在Start函数中进行加载。但是，在工业生产中，我们只在需要用到这个资源的时候才加载这些AssetBundle。

1、将主相机的位置设置为0,0

2、创建一个新的空的gameObejct叫做"Loader"

3、创建一个c#脚本叫做BundledObjectLoader,并将这个脚本添加到这个gameObjec上

4、双击刚刚创建的脚本进行编辑

5、删除update方法

6、脚本里面添加替换为以下代码

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BundleObjectLoader : MonoBehaviour
{

    public string assetName = "BundledSpriteObject";
    public string bundleName = "testbundle";

    void Start()
    {
        //得到一个AssetBundle
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if (localAssetBundle == null) {
	        Debug.LogError("Failed to load AssetBundle!");
	        return;
        }
        
        //从AssetBundle中加载到这个GameObject
        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);  

        //实例化这个GameObject
        Instantiate(asset);
        localAssetBundle.Unload(false);
        
    }
}

```

7、运行项目，将会自动将我们上面的的预制体添加到游戏场景中

![image-20221004153124653](C:\Users\27236\AppData\Roaming\Typora\typora-user-images\image-20221004153124653.png)

8、上述代码中，AssetBundle.LoaFromFile使用的是同步(synchronous)的方式来进行加载，这意味着，在AssetBundle没有被玩家加载完之前，他是不会返回的。这对于我们示例中的这样小的资源来说是没有问题的，但是当资源足够大的时候，比如自动驾驶或者建筑预览程序或者3A大作中，我们就会看到帧率的下降，这是不允许的。

#### 异步方式加载AssetBundle

1、将我们上面的加载脚本修改为以下的方式

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class BundledObjectLoaderAsync : MonoBehaviour
{
    public string assetName = "BundledSpriteObject";
    public string bundleName = "testbundle";
    
    IEnumerator Start()
    {
        //异步加载得到AssetBundle
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;

        if (localAssetBundle == null) {
	        Debug.LogError(“Failed to load AssetBundle!”);
	        yield break;
        }
        
        //异步加载得到AssetBundle中的gameObject
        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;

        GameObject prefab = assetRequest.asset as GameObject;
        Instantiate(prefab);

        localAssetBundle.Unload(false);
    }
}

```

3、协程使得代码可以在多个帧上之间执行，由于完成花费时间过长的初始化过程。

#### 从web端加载AssetBundle

 从web端加载AssetBundle和从本地加载是差不多的，假设我们将我们的AssetBundle资源存放在了web服务器上的assetbundles文件夹下。

1、创建如下的加载脚本

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
public class BundleWebLoader : MonoBehaviour
{
    //这个URL给出的资源需要是可以访问下载的
    public string bundleUrl = "http://localhost:81/StreamingAssets/testbundle";
    public string assetName = "BundledSpriteObject";
    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            if(1==0)
            {
                //2019版本之前的旧方法
                yield return web;
                //得到web端的AssetBundle
                print(Application.streamingAssetsPath);
                print(web.url+"nice");
                AssetBundle remoteAssetBundle = web.assetBundle;
                if (remoteAssetBundle == null) {
                    Debug.LogError("Failed to download AssetBundle!");
                    yield break;
                }
                //从AssetBundle中加载需要的资源成一个gameObject
                //将加载得到的gameObject实例化
                Instantiate(remoteAssetBundle.LoadAsset(assetName));
                remoteAssetBundle.Unload(false);
            }

            if (1==1)
            {
                //2022之后的版本的新的加载方法
                UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl);
                yield return www.SendWebRequest();
                if (www.result != UnityWebRequest.Result.Success) {
                    Debug.Log(www.error);
                }
                else {

                    //将www得到的内容解压为一个AssetBundle
                    AssetBundle remoteAssetBundle = DownloadHandlerAssetBundle.GetContent(www);
                    if (remoteAssetBundle == null) {
                        Debug.LogError("Failed to download AssetBundle!");
                        yield break;
                    }
                    print(remoteAssetBundle);
                    Instantiate(remoteAssetBundle.LoadAsset(assetName));
                    //true表示将所有的资源都卸载  false表示只卸载用过的资源
                    remoteAssetBundle.Unload(false);
                }
            }

        }
    }
}

```

note：上面这一步需要将自己本地的资源弄成web可以访问的方式，这里testbundle是一个没有文件扩展名的文件，对于这样的文件，如果不能访问的话，需要在IIS中添加这个文件类型为可以访问。没有文件扩展名的就添加`.*`这个作为文件扩展名

参考链接：[链接1](https://blog.csdn.net/huanglin529/article/details/108445109?spm=1001.2101.3001.6661.1&utm_medium=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7ECTRLIST%7ERate-1-108445109-blog-116399150.pc_relevant_multi_platform_whitelistv3&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7ECTRLIST%7ERate-1-108445109-blog-116399150.pc_relevant_multi_platform_whitelistv3&utm_relevant_index=1)   [链接2](https://stackoverflow.com/questions/19950882/iis-how-to-serve-a-file-without-extension0)  

#### Upgrading to the Unity Addressable Asset System

为了发挥好Unity的可定位资源系统的作用，最好的方法就是将项目更新以和这个系统相适应，同时更新文件结构。

1、进入Package Manager，安装Addressables包

2、选中window->Asset Mangaer ->Addressables -> Groups

3、在弹出的窗口上点击Create Addreables Settings

4、选择convert选项，这将会将项目中定义的AssetBundle移动到相对应的组（自动对我们的AssetBundle进行分组管理）

![image-20221004211456984](C:\Users\27236\AppData\Roaming\Typora\typora-user-images\image-20221004211456984.png)

#### assetBundle文件解析

**文件夹的manifest文件**

> .mainfestl文件用于管理，表示这个AssetBundles下有多少个assetBundles文件
>
> Name:这个assetBundles的名字
>
> Dependencies:表示这个assetBundles的依赖
>
> 如下图表示这个文件夹下存放了两个AssetBundle文件
>
> ![image-20220702161332990](typora-user-images\image-20220702161332990.png)

**每个AssetBundle的详细信息文件(.manifest)**

> CRC：这个文件校验码
>
> AssetFileHash  和 TypeTreeHash：为这个文件的版本信息
>
> ClassType：表示这个AssetBundle上挂载了那些类
>
> Assets：表示这个AssetBundle中包含的预制体
>
> Dependecies ：表示这个AssetBundle的依赖
>
> ![image-20221004221624891](C:\Users\27236\AppData\Roaming\Typora\typora-user-images\image-20221004221624891.png)
>
> 1、player上添加test脚本
>
> 2、给test脚本中的变量赋值player1
>
> 3、即player-->test-->palyer1
>
> 4、将player打包成AssetBundle
>
> 可以看到player的依赖中表明了plater1这个预制体
>
> ![image-20220702165701254](typora-user-images\image-20220702165701254.png)

