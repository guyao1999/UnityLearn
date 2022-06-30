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

> - 复制tolua的Assets文件和Unity5.x文件覆盖unity项目中的文件
> - 编写c#脚本
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
> - main.cs----->Testlua.lua 实现了c#文件调用lua文件
>
> - Testlua.lua ---------TestWrap.lua--------Test.cs(c#文件) 实现了lua文件调用c#文件
>
>  
>
> -  main.cs---->controller.lua实现了C#调用controller.lua文件中的代码来控制物体
> - controller.lua----->music.lua  实现了lua函数之间的调用，这里使用的是
