### NGUI

[TOC]

#### 链接

> http://www.tasharen.com/forum/index.php?topic=6754.0（简介地址）
>
> http://tasharen.com/ngui/docs/class_u_i_rect.html（详细方法介绍地址）

#### UIRoot

> https://blog.actorsfit.com/a?ID=01000-6907dd82-2ffa-4c68-9500-4d28ddcaf91e
>
> Scalling Style  缩放模式：
>
> > Flexible表示自适应方式。UI的大小会变，像素不变。在不同的设备上，高度会在MinimumHeight和MaximumHeright两个值之间进行自适应。**所以会进行scale的缩放**，保持清晰度。
> >
> > ConStrained表示进行大小的限制

#### UIRect

> 1. UIRect为一个抽象类，UI Widget 和Panel的父类，不直接作为脚本添加到组件之上
> 2. 在UIRect中定义了4个锚点(AnchorPoint)，用于将组件和target保持相对的位置
> 3. 子类：UI Widget，UIPanel
> 4. ![image-20220727100237512](C:\Users\feitan\AppData\Roaming\Typora\typora-user-images\image-20220727100237512.png)

#### UIWidget

> 1. 继承于UIRect
> 2. 只是一个可以展示在游戏场景中的矩形，并且**运行时看不到**
> 3. 不能添加背景或其他任何东西，只能调整大小和深度等信息，**一般用来存放其他component**
> 4. 移动时会自动对齐最近的component,如果不想自动对齐，移动的时候按住ctrl
> 5. 将鼠标放在原点外可以旋转component,如果不想角度的自动对齐，旋转的时候按住ctrl
> 6. 给gameObject添加一个Box Collider组件时，UIWidget下将出现Collider  auto-adjust to match选项，自动调整碰撞检测区域
> 7. 右键gameObjecty--->select,将会展示层级由高到低的所有的可选的UIWidget
> 8. 子类：UILabel, UISprite, UITexture, UI2DSprite

#### UIPanel

> 1. UIPanel用于**管理下面的所有widget**，用于**创建一个实际的渲染调用**，就像Renderer一样
> 2. UIPanel的层级将会影响下面的所有的widget的层级，其层级的权重比下面widget的层级的权重要大得多
> 3. 通常情况下，一个window要有一个UIPanel,并且这个UIPanel不共享同一个层级。如果共享同一个层级，那么为了保持渲染顺序，渲染调将会被频繁切换，导致更多的渲染调用
> 4. Alpha参数用于调节下面所有的widget的透明度
> 5. Noramal参数，当UI被光照影响时，勾选上这个参数
> 6. Cull参数，如果想要创建一个可以滑动的Panel，并且这个Panel下有很多的几何体，就勾选上Cull参数，这样在进行滑动时，可以减少绘画的矩形数量
> 7. Static参数，勾选上Static参数将高数NGUI这个Panel下的widget不会移动，NGUI就不会检查位置的修改
> 8. Show Draw Calls按钮，这个按钮将展示进行渲染调用的具体信息。
> 9. **Clipping参数，调整裁剪效果**，例如Soft Clip可以使得裁剪时panel的边缘是渐变的，不是直接裁剪。实现原理为调整边缘的Alpha值----**配合UIScrollView一起使用时一定要设置裁剪**
> 10. Render Q参数，用来调整渲染队列，Explicit用来指定一个确定的渲染队列

#### UILabel

> 1. 用来展示文字的组件
>
> 2. Material，指定用于绘制文字的材料
>
> 3. Font Size,调整字体大小
>
> 4. Modifier,调整单词为全大写或全小写
>
> 5. Overflow，用于指定文字超出可以战死的区域时的展示方式
>
>    > Shrink Content:自动缩小字体以适应文本框的大小，同时需要勾选上keep crisp
>    >
>    > Clamp Content:如果超出，就全部裁剪掉，即不显示
>    >
>    > Resize Freely:根据字体的大小来调整文本框的大小
>    >
>    > Resize Height:自动调整文本框的的高度，宽度不改变
>
> 6. Alignment,调整对齐方式
>
> 7. Gradient，调整字体的上部和下部的颜色
>
> 8. Effect,调整字体的阴影效果
>
>    > 下面的参数用来调整阴影效果的距离
>
> 9. Max Lines,指定最多展示几行，如果不做限制，设置为0

#### UISprite

> 1. UISprite需要使用图集的方式指定显示的内容
>
> 2. Edit用来编辑选中的图集和精灵
>
> 3. Type:用来选择精灵的填充方式
>
>    > Simple：不进行多余的操作
>    >
>    > Sliced:切分为9片来进行填充
>    >
>    > Tiled:精灵用作tile，重复进行填充
>    >
>    > Filled:填满
>    >
>    > Advanced：高级方式，可以自定义各边的填充方式
>
> 4. snap恢复UI原来的大小

#### UITable

> 1. 用来快速排列widget
>
> 2. Columns,控制一行展示多少个
>
> 3. Direction,调整排列的方向
>
> 4. Sorting,用来调整进行排序的方式
>
>    > 默认：按照创建的方式来进行排列
>    >
>    > Alphabetic:更具字母表来进行排列
>
> 5. Hide Inactive,调整子物体中没有激活的是否显示
>
> 6. padding,调整两个物体之间的间距
>
> 7. Pivot,调整这个table的轴心
>
> 8. Cell Alignment ?????

#### UIGrid

> 1. 用来快速排列widget
>
> 2. Arrangement,用来指定填充方式，水平或垂直填充
>
> 3. Cell Width，Cell Height指定两个item轴心之间的距离
>
> 4. Column Limit,表示列的限制
>
> 5. Pivot，调整这个Grid的轴心
>
> 6. Sorting，排序方式
>
> 7. UIGrid和UITable之间的区别
>
>    > UITable指定padding---------UIGrid指定的是两个item之间的距离
>    >
>    > UIGrid两个item之间的距离是固定的-----------UItabel两个item之间的距离是自动调整的（item不一样大的情况下，效果不同）

#### UIScrollView+UIDragScrollView

> 1. 和UIPanel一起用，UIScrollViwm的大小就是UIPanel的大小
>
> 2. 不能指定大小，大小由子组件的范围确定
>
> 3. Content Origin：指定滑动框从哪里弹出
>
> 4. Movement: 指定滑动的方向
>
> 5. Scroll Whel Factor: 指定通过鼠标滚轮来滑动的滑动速度
>
> 6. Momentum Amount: 指定松开时滑动的距离
>
> 7. Scroll Bars
>
>    > 控制滑动列表快速滑动
>    >
>    > show Condition 一般选择Only If Needed,只有在需要的时候才进行滑动拖拽条的展示（前提和UIProgressBar一起使用）
>
> 8. 创建一个滑动列表的方法
>
>    > 在一个组件1上添加UIPanel和UIScrollView，UIScrollView会自适应UIPanel的大小，该大小就是内容的范围（记得勾选UIPanel的裁剪方式）
>    >
>    > 在UIPanel所在的组件1下或者同级别，创建一个新的组件2，在这个组件2上添加BoxCollider,用于滑动时的检测，再添加上UIDragScrollView实现拖拽效果，同时为了控制碰撞检测的范围的大小，添加上一个UIWidget，勾选auto-adjust to match，让碰撞检测范围和UIWIdget的大小同步
>    >
>    > 总结：
>    >
>    > > 滑动列表=视图组件1 +拖拽组件2  
>    > >
>    > > **视图组件1=UIPanel+UIScrollView**
>    > >
>    > > **拖拽组件2=UIWidget+BoxCollider+UIDragScrollView**  
>    >
>    > tips:每一个需要进行拖拽的子组件都需要添加上UIDrag ScrollView
>
> 9. UIDragScrollVIew 用来指定哪个UIScrollView是可以拖拽的，和UIScrollView一起使用

#### UIWrapContent

> 让ScrollView下的展示内容为无限大，在ScrollView下使用
>
> 使用方法：将原来应该是UITable或者UIGird的地方替代为UIWrapContent就行
>
> itemHeight：其子对象的两个item轴心之间的距离

#### UIButtonScale

> 控制按钮被按下是的缩放效果
>
> Tween Target:动画目标
>
> Hover:鼠标悬浮在上面时的大小
>
> Pressed:按下之后的大小
>
> 会调用TweenScale这个脚本来实现动画

#### UITexture

> 1. 用来显示图片，这种方法不需要创建图集
>
> 2. 一个UITexture会调用一个DrawCall来进行图像的绘制，所以一般用来存放背景图等大图
>
> 3. 继承关系:
>
>    ![image-20220727111823764](C:\Users\feitan\AppData\Roaming\Typora\typora-user-images\image-20220727111823764.png)

#### UILayout

> 1. 用来排版一个组件下的子组件
> 2. Arrangement:选择排版方式
> 3. HorizontalAlign：选择水平方向的对象方式
> 4. VerticalAlign：选择垂直方向的对齐方式
> 5. Gap:调整两个物体之间的间隔
> 6. padding Top：调整到顶部的距离（组件需要有固定的大小时才起作用，即需要添加UIWidget）
> 7. 缺点：**只能排一行或者一列**

#### UIProgressBar

> 1. 常用于制作进度条
>
> 2. ![image-20220728113718038](C:\Users\feitan\AppData\Roaming\Typora\typora-user-images\image-20220728113718038.png)
>
> 3. Forground需要添加一个UISprite，作为进度条上层，这个UISprite的大小应该为进度条最大时的大小
>
> 4. Background需要添加一个UISprite作为进度条的背景，这个UISprite的大小应该为进度条最大时的大小
>
> 5. 一般就将UIProgressBar和作为背景的UISprite放在同一个组件上
>
> 6. 当改变UIProgressBar的value值时，将会自动改变作为Forground的UISprite的宽度
>
>    tips:如果需要可交互，选择UISlider
>
> 7. Steps:表示每次调整增加的百分比
>
> 8. Thumb参数:

#### UISlider

> 1. 常用于制作**进度条+滑动条**
> 2. 继承于UIProgressBar
> 3. ![image-20220728115031083](C:\Users\feitan\AppData\Roaming\Typora\typora-user-images\image-20220728115031083.png)
> 4. Thumb:传入一个Transform组件，滑动时，可以改变这个Transform租价的位置
> 5. UISlider可以同用户进行交互，需要添加一个BoxCollider,这样**用户就可以拖动这个滑动条**
> 6. ![image-20220728131458496](C:\Users\feitan\AppData\Roaming\Typora\typora-user-images\image-20220728131458496.png)

#### Multi Row Wrap Content

> 

#### DOTween

> sequence=DG.Tweening.DOTWeen.Sequence();
>
> sequence.Insert();



### 层级之间的关系

> https://blog.csdn.net/qq_39735897/article/details/103744325
>
> https://www.jianshu.com/p/8cb79ee7d986?u_atoken=f24a5d2f-5691-42ef-8f7d-0f2e094315b7&u_asession=01xw_4oLTUMPARX0KOyUy00RFOGStDOicwyYhT5UbonAGASeY2_Qb0IjcBfk0u_D1UX0KNBwm7Lovlpxjd_P_q4JsKWYrT3W_NKPr8w6oU7K-E1oYOwxLFGytEh7-ev2e2UPWO0ljqS-0m6uUj231Ub2BkFo3NEHBv0PZUm6pbxQU&u_asig=05oEbVwSzUZF-mtwraded9EQXf4zNMr9YnJSrAldSOW3aEfKnAB0wgpu-KXtEaZjlMGhyNPFTnH8rzf0L9QJbE_WHL5hH8wUEUKsCs5WzQWpdpdiygJQsRqEtv6v9ysMVq5QWlEdU-0u1uihhRrUBuem7pDO1MWajBToXT11PLZLr9JS7q8ZD7Xtz2Ly-b0kmuyAKRFSVJkkdwVUnyHAIJzUMWjn1aaDLoRFiprnpFNwzu46tKwvEQXyCVTsObLTagU1_gr7b-5Q11Fu-gS_hPv-3h9VXwMyh6PgyDIVSG1W_aGTOGU0wa3HUfYw6ErAD2-ugCNFY0FZyNegwerOk568tiyIX3696YxknvXGuqW5o5ACRiGoAtkZY-On-o3iLymWspDxyAEEo4kbsryBKb9Q&u_aref=Rs83BbyWxub7HYLRpvLZ1KLz6II%3D
>
> Camera.Depth > SortingLayer >UGUI的Order in Layer =NGUI的Sort Order>Render Queue>NGUI的Panel的Depth
>
> 
>
> 
>
> NGUI  vs  UGUI
>
> > SortingLayer--->Sort Order---------->Render Q---------->Depth
>
> > SrotingLyaer--->Order In Layer----->
>
> 
>
> UIRoot:Default------>sort order=5----->Depth=0
>
> items:Default------>sort order=5
>
> floor:Default------->sort order=1
>
> wall:Default-------->sort order=2
>
> bg:Default--------->sort order=0------>Depth=1;
>
> Grid Scale:160
>
> 

### 其他类

#### PlayerPrefs

> 存放玩家在玩游戏时的一些偏好设置，存放在玩家的本地。存放玩家在上次进行游戏时的设置，可以PlayerPrefs得到玩家上次的偏好设置，不需要存放在后端。





