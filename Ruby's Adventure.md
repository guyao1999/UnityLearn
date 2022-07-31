### Ruby's Adventure

[TOC]

#### 官方链接

> https://learn.u3d.cn/tutorial/unity-ruby-adventure

#### Tips

> 1. Unity无法直接使用png格式的图片，导入之后，Unity会自动将其转换为sprite格式
>
> 2. Time.deltaTime   这个变量是按秒为单位，完成上一帧所用的时间
>
>    > - 当电脑的刷新频率为50帧/s时，则Time.deltaTime=0.02
>    > - 当电脑的刷新频率为25帧/s时，则Time.deltaTime=0.04
>    >
>    > 1. 50帧/s时,每帧走0.1f\*horizontal*0.02 个单位
>    > 2. 25帧/s时,每帧走0.1f\*horizontal*0.04个单位
>    >
>    > - 0.1f\*horizontal*0.02 * 50= 0.1horizontal
>    > - 0.1f\*horizontal*0.04 * 25=0.1horizontal
>    >
>    > - 所以使用Time.deltaTime实现了平滑过渡，防止了不同的电脑的刷新频率不一样带来的表现效果不一样

#### Grid

> 定义：网格
>
> tips:
>
> > 在Insperator中Scale表示一个格子的大小
> >
> > ![image-20220702215419644](typora-user-images\image-20220702215419644.png)

#### TileMap

> 定义：放置tile的地图，方便对地图进行编辑
>
> 创建：
>
> > Grid--->TileMap
> >
> > tips:方便进行地图的编辑，在编辑时只需要将tile进行填充就可以实现地图的编辑

#### Tile palette

> 定义：网格调色板，用于放置Tile瓦片，方便对地图进行填充
>
> 使用:
>
> > 在palette上放置不同的tile
> >
> > 打开palette之后，选择画笔，然后就可以直接将tile添加到tilemap上，实现地图的绘制
>
> tips:
>
> > pallette类似画画时用的画板
> >
> > tile类似颜料
> >
> > tilemap类似于带格子的画布

#### Tile

> 定义：瓦片，一种特殊的精灵，可用作地图绘制
>
> tips:
>
> > Tile中的pixels per Unit表示将tile填充到Girp中时，一个格子填充几个像素
> >
> > ![image-20220702215542233](typora-user-images\image-20220702215542233.png)

#### Tile集

> 定义：通常一个一个的导入tile和对单个tile进行管理很麻烦，因此将tile做成了一个集合，称作瓦片集
>
> 使用：
>
> > 在Inspector中将single改成mutil就告诉了unity这是一个瓦片集不是单个的瓦片
> >
> > <img src="typora-user-images\image-20220702220155953.png" alt="image-20220702220155953" style="zoom:67%;" />
>
> Tile集的切分:
>
> > 选中瓦片集 点击右侧的Sprite Editor进行瓦片 or 精灵的切分
> >
> > ![image-20220702220955745](typora-user-images\image-20220702220955745.png)
> >
> > 弹出sprite Editor窗口
> >
> > 选择slice切分  

#### Order in Layer 调整图层

> Order in Layer的值用来调整Render绘制图像时的顺序，值小的处于底层，先绘制
>
> ![](typora-user-images\image-20220702230633244.png)

#### 更改图像设置,自动绘制精灵和物体

> 方法：
>
> > Edit---->Project Settings---->Transparency Sort Mode
> >
> > 修改为Custom Axis表示使用按照自定义的轴向来进行图形的渲染
> >
> > 修改x=0, y=1,z=0；表示在y轴上基于精灵的基础上来进行图像的绘制
>
> 效果：
>
> > 当精灵在物体的前面时，显示的是精灵
> >
> > 当精灵在物体的后面是，显示的是物体
> >
> > ![image-20220703104818310](typora-user-images\image-20220703104818310.png)

#### 修改精灵的坐标轴的轴心

> 方法：
>
> > 添加物体时，物体的轴心默认为物体的中间
> >
> > ![image-20220703105519508](typora-user-images\image-20220703105519508.png)
> >
> > 如果轴心为Bottom则当物体的位置为0,0,0时，物体的底部在0,0,0这个位置
> >
> > 如果轴心为center则当物体的位置为0,0,0时，物体的中间在0,0,0这个位置
> >
> > tips:虽然修改了轴心，但是在点击物体时，物体上用于定位的坐标轴的位置不变
> >
> > ![image-20220703110302450](typora-user-images\image-20220703110302450.png)
> >
> > 
> >
> > 上述方式存在的问题：
> >
> > 问题1：只能将轴心修改在一些特定的位置，为了实现可以将轴心修改为任意位置，这时候需要使用Sprite Editor
> >
> > 图中的小蓝点位置就是轴心，可以修改到任意位置
> >
> > ![image-20220703110741478](typora-user-images\image-20220703110741478.png)
> >
> > 问题2：只能修改单个精灵的轴心，无法更改tile集的轴心
> >
> > 使用上述方法可以修改tile集的轴心
> >
> > ![image-20220703111008058](typora-user-images\image-20220703111008058.png)

#### 物理系统---**Rigidbody**

> 定义：对物体进行推力，摩檫力，重力等的模拟需要进行复制的计算，Unity将该功能进行了统一。为了实现物理量的模拟，Unity提供了Rigidbody组件来进行模拟。Rigidbody用来给物体添加一系列的物理量。不使用重力时，将Gravity Scal设置为0。
>
> tips:
>
> > 如图，Grivity Scale为加粗字体，旁边有蓝色的线，这表示我们进行的修改是随Scene中的物体进行的修改,而不是在预制体上进行的修改，后续再次添加ruby时，Gravity Scale的值依然为1。
> >
> > ![image-20220703115305131](typora-user-images\image-20220703115305131.png)
>
>  将更改应用到预制体上：
>
> > 1. 选中ruby之后，右边的Overrides下拉会展示当前的对象和预制体的区别。
> > 2. 点击Apply All表示将更改同步到预制体上，下次通过预制体添加ruby时，添加的ruby的Gravity Scale为0
> > 3. ![image-20220703115930950](typora-user-images\image-20220703115930950.png)

#### 物理系统---碰撞检测 Box Collider 2D

> 定义：用于进行物体之间的碰撞检测
>
> 使用：
>
> > 给ruby添加Box Collider 2D组件之后，ruby周围会出现一个框，这个框时碰撞检测时的检测范围。
> >
> > ![image-20220703120513608](typora-user-images\image-20220703120513608.png)
>
> 解决碰撞时物体旋转问题：
>
> > 旋转原因：在碰撞的时候两个box的角碰撞到了就会导致反弹方向不水平，因此出现了旋转现象
> >
> > 解决办法：进入预制体模式，Ridigbody组件，将constrains下的**Freeze Rotation**-----表示进行限制，冻结旋转
> >
> > ![image-20220703121511642](typora-user-images\image-20220703121511642.png)
>
> 解决抖动问题：
>
> > 抖动原因：
> >
> > > 游戏场景和物理系统为两个系统，在物理系统中，只有需要进行碰撞检测的物体。碰撞检测的逻辑是计算两个物体是否重合，如果出现重合，就将其中的一个物体的碰撞框移出去，然后到游戏场景更新物体的新位置。但是由于帧的存在，导致在游戏场景两个物体出现了重合之后，物理系统再检测到两个物体的重合，因此需要将其移出去。这就导致了抖动的出现。
> > >
> > > 总结：物理系统在游戏对象进入箱子之后再将其移出去，就导致了抖动。
> >
> > 解决办法：
> >
> > > 使用刚体来移动游戏角色的位置，而不是移动游戏角色本身
> > >
> > > - 在使用游戏角色的位置来进行移动时，不进行检测，会将游戏角色移动到箱子内部，然后碰撞系统检测到碰撞再将游戏角色移动出来，就出现了抖动
> > >
> > > - 使用刚体的位置来进行移动时，在移动的过程中会进行碰撞的检测，如果出现了碰撞
>
> 调整碰撞的检测范围:
>
> > 进入预制体视图，找到Box Collider ，点击Edit Collider，将碰撞检测的框修改为如图所示，这样可以使得ruby可以走到箱子的后面
> >
> > ![image-20220703153138953](typora-user-images\image-20220703153138953.png)
>
> 给tile添加碰撞检测：
>
> > 先给tileMap添加**Tilemap Collider 2D**碰撞检测组件，这时所有的tileMap都被标记为进行碰撞检测
> >
> > 在project中选中所有不需要进行碰撞检测的tile，将collider type修改为none
> >
> > ![image-20220703154408504](typora-user-images\image-20220703154408504.png)
>
> 优化碰撞检测，将场景中的碰撞体合并:
>
> > 首先给TileMap添加Composite Collider 2D组件，该组件用于将碰撞合成为一个
> >
> > 添加Composite Collider 2D组件之后，会自动添加要给Rigidbody 2D组件，因为Composite Collider 2D组件需要Rigibody 2D组件才能运行
> >
> > 勾选Tilemap Collider 2D组件的Used By Compostite，表示这个碰撞体被合成到Composite Collider 2D中
> >
> > 将Rigidbody 2D 组件的Body Type修改为Static；表示刚体不能运动
> >
> > ![image-20220703155321835](typora-user-images\image-20220703155321835.png)

#### 世界交互1

> 脚本：
>
> > 在脚本中声明为public的变量将会被公开，在Inspector可以直接进行修改
> >
> > ![image-20220703163559502](typora-user-images\image-20220703163559502.png)
> >
> > **Update()函数用于每帧更新，可以准时得到输入数据**
> >
> > **FixedUpdate()函数用于固定更新，保证物理量的计算稳定**
>
> 触发器：
>
> > 添加一个ColletialeHeath，
> >
> > 添加Box Collider 2D然后勾选Is Trigger，将碰撞检测修改为触发器
> >
> > 这时ruby碰到这个ColletialeHeath时，碰撞系统会记录此碰撞，但是此时没有函数进行处理，所以游戏对象对碰撞没有反应，这时在这个上面添加脚本，就可以控制ruby生命值
> >
> > ![image-20220703164157796](typora-user-images\image-20220703164157796.png)

#### 世界交互2----添加伤害区域和敌人

> 步骤：
>
> > 1. 添加Damageable精灵到游戏场景中
> >
> > 2. 给该精灵添加脚本来修改ruby的生命值
> >
> > 3. 将OnTriggerEnter2D修改为OnTriggerStay2D，以实现ruby呆在Damge区域时持续受到伤害，而不是只在进去的那个时候受到伤害
>
> 问题1：
>
> > ruby进去DamageZone区域不动时不会受到伤害
> >
> > 原因:刚体不动时，物理系统不会计算刚体之间的碰撞，进入sleep状态
> >
> > 解决方法：将ruby的Rigidbody的Sleep Mode修改为Never Sleep
> >
> > ![image-20220703195910606](typora-user-images\image-20220703195910606.png)
>
> 问题2：
>
> > ruby在DamageZone中时，很快就会失去了所有的生命值
> >
> > 解决办法：添加无敌时间，处于无敌时间时，不修改生命值
>
> 添加伤害：
>
> > **OnTriggerEnter2D**  使用触发器，第一次碰撞时进行调用
> >
> > **OnTriggerStay2D**   使用触发器，呆在区域内时进行调用
> >
> > **OnCollisionEnter2D**  使用碰撞检测，发生碰撞时进行调用
> >
> > 
> >
> > ```c#
> >  void OnCollisionEnter2D(Collision2D other)    //Collision2D  和 Collider2D的不同
> >  {
> >      RubyController player = other.gameObject.GetComponent<RubyController>();  //这里多了一个gameObject对象来进行调用
> > 
> >      if (player != null)
> >      {
> >          player.ChangeHealth(-1);
> >      }
> >  }
> > ```
> >
> > **Collider2D**可以直接调用GetComponent函数
> >
> > **Collidsion2D** 没有GetComponent函数，但是存在一系列的碰撞信息，可以使用gameObject来间接调用

#### Sprite Renderer(精灵渲染器)

> 内容1：
>
> > 为了在对精灵进行拉伸时比例不变，而是使用相同的内容进行平铺，
> >
> > 选中精灵，将Draw Mode修改为Tiled
> >
> > 将Tile Mode修改为 Adaptive，自适应的模式
> >
> > 如果出现警告，就将**project**中的该精灵的Mesh Type修改为Full Rect
> >
> > ![image-20220703201737686](typora-user-images\image-20220703201737686.png)
> >
> > ![image-20220703201932644](typora-user-images\image-20220703201932644.png)
>
> tips:
>
> > T键可以调出矩形工具，实现对游戏场景中的精灵的范围进行调整

#### Animator动画

> 添加动画组件：
>
> > 给机器人添加Animator组件
> >
> > 在Animator文件夹下，右键create Aninator Contorller来**创建Robot**,将Robot添加到enemy的controller属性中
> >
> > controller用于控制动画的播放
> >
> > ![image-20220709210845177](typora-user-images\image-20220709210845177.png)
>
> 制作动画：
>
> >  选择 **Window > Animation > Animation** 来打开 **Animation 窗口**
> >
> > 同时打开Robot的预制体模式
> >
> > 在打开的窗口中出现创建动Animation的按钮
> >
> > 
> >
> > 窗口介绍：**左侧**用于动画化属性,**右侧**的时间轴显示每个属性的关键帧
> >
> > ![image-20220709214744034](typora-user-images\image-20220709214744034.png)
> >
> > create an Animation Clip，创建动画片段
> >
> > 选中目标图片拖拽到窗口中
> >
> > ![image-20220709220750705](typora-user-images\image-20220709220750705.png)
> >
> > samples=60表示每秒运行60帧，即每张图片只停留60秒
> >
> > 修改帧数，将samples修改为4，表示一秒内播放4帧，将后面的播放时间修改为1秒，表示这4张照片在1秒内播放完，所以结果就是1秒播放图片，一张图片停留1/4秒（得到向左走的动画）
> >
> > ![image-20220709221855586](typora-user-images\image-20220709221855586.png)
>
> 创建向右走的动画：
>
> > 在创建完向左走的动画轴，点击左上角的RobotLeft-->Creat New Clip..来创建
> >
> > 添加4个向左走的图片
> >
> > 单击 **Add Property**，然后单击 **Sprite Renderer** 旁边的三角形，再单击 **Flip X** 旁边的 + 图标：
> >
> > ![image-20220709222730917](typora-user-images\image-20220709222730917.png)
> >
> > 在帧 **0** 和帧 **4** 上的时候，选中**属性名称**旁的**切换开关**，即可将属性设置为 true，这样 **Flip** 在整个动画中将保持选中状态：
> >
> > ![image-20220709223300233](typora-user-images\image-20220709223300233.png)
> >
> > 和Flip在一条线上出现的小菱形表示这个值选中了Flip,播放时将进行翻转
>
> 构建controller----使用Aninator Contorller控制Aniantor clip的播放:
>
> > 步骤：
> >
> > > 打开 **Animator 窗口**（菜单：**Windows > Animation > Animator**）。  **注意：**确保在 **Project 文件夹**中选择了**机器人预制件**或 **Robot Animator**
> > >
> > > 窗口介绍：
> > >
> > > > part1:
> > > >
> > > > 窗口左边是 **Layers** 和 **Parameters**，右侧是**动画状态机 (Animation State Machine)**
> > > >
> > > > Layers用于3D动画
> > > >
> > > > **Parameters** 由我们的脚本用来向 **Controller** 提供信息
> > > >
> > > > part2:
> > > >
> > > > 右边是动画状态机，用来构建动画之间的变化方式（可以使用简单的方式blend tree来实现）
> > > >
> > > > ![image-20220710164036899](typora-user-images\image-20220710164036899.png)
> > >
> > > 创建blend tree
> > >
> > > > 删除动画状态图中的所有状态
> > > >
> > > > 然后再创建blend tree
> > > >
> > > > ![image-20220710164739157](typora-user-images\image-20220710164739157.png)
> > >
> > > 添加Move X和Move Y两个参数，该参数用于控制动画的播放
> > >
> > > 添加4个motion，并设置其位置，用于放置4段动画
> > >
> > > 中间红点的位置由两个参数Move X和Move Y给出
> > >
> > > ![image-20220710170128120](typora-user-images\image-20220710170128120.png)
> > >
> > > 控制Blend Tree中两个参数Move X和Move Y的值变化是，红点的值也会进行变化
> > >
> > > Blend Tree会选择离红点最近的动画片段来进行播放，从而达到通过参数来控制动画播放的目的
> > >
> > > ![image-20220710170448011](typora-user-images\image-20220710170448011.png)
> > >
> > > 给每个Motion添加动画之后，可以通过移动红点到周围的点上去，在下面看到Blend Tree选着播放的动画
> > >
> > > ![image-20220710171807926](typora-user-images\image-20220710171807926.png)
>
> 将Enemy Controller中的参数发送到Aninator Contorller
>
> > 功能：实现将通过用户的输入参数来控制播放的动画
> >
> > 在Enemy Controller脚本中获取到animator这个component
> >
> > 然后设置这个component的Move X和Move Y值
>
> 给ruby添加动画
>
> > Moving表示奔跑状态，Idle表示站立状态，hit表示被击中
> >
> > 点击ruby的动画控制脚本，两个动画之间的箭头表示动画的过度过度方式
> >
> > 点击箭头可以查看“过渡”的详细设置
> >
> > Has Exit Time默认为没有选中的状态，这表示？？
> >
> > 底下的conditions表示动画进行过渡的条件，当速度小于0.1时，进行动画的过渡
> >
> > ![image-20220710175234756](typora-user-images\image-20220710175234756.png)
>
> **总结：**
>
> > 给需要添加动画的对象添加Animator组件
> >
> > 然后创建Animator Controller脚本，并将该脚本放置在Animator上
> >
> > 使用Window-->Animation-->Animation来创建动画
> >
> > 打开Animatior Controller的编辑界面，使用Blender Tree或动画状态机来控制动画之间的转变
> >
> > 编写ruby controller脚本，在脚本中获取到用户的输入，将输入传送到Animator组件的参数中

#### 世界交互---发射飞弹

> 
>
> > 步骤1：
> >
> > > 给飞弹精灵添加Collision2D 组件用于碰撞的检测
> > >
> > > 给飞弹精灵添加Rigidbody组件用于施加力
> > >
> > > 编写控制脚本
> > >
> > > 将脚本挂载在飞弹精灵上
> >
> > 步骤2：
> >
> > > 在rubyController中获取用户的按键
> > >
> > > 使用Instantiate实例化一个飞弹对象
> > >
> > > 调用这个飞弹对象的Launch函数
> > >
> > > 在飞弹对象的Launch函数中给飞弹施加力
> > >
> > > 最后调用ruby的animator组件的方法来进行动画的播放
> >
> > tips:
> >
> > > 问题：
> > >
> > > > 调用**Instantiate**函数创建对象时，Unity不运行start函数，导致需要start获得对象的参数为空，导致null的引用
> > >
> > > 解决办法：
> > >
> > > > 将start函数修改为**Awake()**函数，与 **Start** 刚好相反，在创建对象时（调用 **Instantiate** 时）就会立即调用 **Awake**，因此在调用 **Launch** 之前已正确初始化 **Rigidbody2d**
> >
> > 修改图层：
> >
> > > 目的：让ruby和飞弹不能相撞
> > >
> > > 原理：不同图层中的对象不进行碰撞的检测
> > >
> > > 步骤：
> > >
> > > > 添加一个图层，给图层进行命名
> > > >
> > > > 将ruby和飞弹的默认图层进行修改
> > > >
> > > > ![image-20220711220856266](typora-user-images\image-20220711220856266.png)
> > > >
> > > > Editor--->Project Setting中找到Physics 2D下的Layer Collision Matrix
> > > >
> > > > 选中的表示进行碰撞检测的图层
> > > >
> > > > 将Character和Projectile两个图层之间的行和列的交集不进行勾选，则不进行碰撞的检测
> > > >
> > > > ![image-20220711221115678](typora-user-images\image-20220711221115678.png)
> >
> > 让飞弹消失：
> >
> > > 当飞弹距离世界坐标超过1000时，将飞弹这个对象销毁掉
> >
> > 添加动画：
> >
> > > 先使用animation创建一段修复动画
> > >
> > > 将blend tree过渡到修复动画
> > >
> > > 添加一个触发条件
> > >
> > > 点击过渡的箭头，再下面选中触发条件
> > >
> > > 在代码中设置条件
> > >
> > > ```c#
> > >  animator.SetTrigger("Fixed"); 
> > > ```
> > >
> > > ![image-20220711230904017](typora-user-images\image-20220711230904017.png)

#### 摄像机

> 1. 添加cinemachine包进行相机的管理
>
> 2. 添加相机到场景中
>
>    > 要开始使用 Cinemachine，你需要在顶部菜单栏上选择 **Cinemachine** **>** **Create 2D Camera**  条目，从而将 **Cinemachine 2D 摄像机**添加到**场景**中
>
> 3. 通过Cinemachie添加的相机为虚拟相机，可以通过告诉main camera复制哪个虚拟相机的参数，从而实现视角的转换
>
> 4. 通过调节虚拟相机中的len-->ortho size可以调价虚拟相机到场景的距离
>
> 5. 将ruby添加到相机的follow属性下，相机将自动跟随ruby的位置而变化
>
>    ![image-20220723151124900](typora-user-images\image-20220723151124900.png)
>
> 1. 防止相机显示游戏场景边界之外的东西
>
>    > 给虚拟相机添加一个cinemachine Confiner属性
>    >
>    > ![image-20220723155712379](typora-user-images\image-20220723155712379.png)
>    >
>    > 创建一个空的gameObject,给这个gameObject添加**Polygon Collider 2D**组件(多边形碰撞体)
>    >
>    > 将Polygon Collider 2D组件的碰撞范围调整为场景的边界
>    >
>    > 在points中将各个点的位置设置为整数（方便相机移动时进行计算）
>    >
>    > ![image-20220723155647873](typora-user-images\image-20220723155647873.png)
>    >
>    > 然后将Polygon Collider 2D组件分配给虚拟相机的Bouding Shape 2D属性
>    >
>    > 当相机碰撞到这个多边形的边界时，将不再往外移动
>    >
>    > ![image-20220723160207201](typora-user-images\image-20220723160207201.png)
>
> 1. ruby被推到了场景之外
>
>    > 原因，因为Polygon Collider 2D为一个多边形的碰撞体，ruby和该碰撞体碰撞时，会被推出去
>    >
>    > 解决办法：调整图层
>    >
>    > > 点击layer，给一个新的图层编辑为confier
>    > >
>    > > 然后将CamaeraConfiner的图层选中为confier图层
>    > >
>    > > 到project setting中，将confier和其他图层的碰撞检测都取消勾选
>    > >
>    > > ![image-20220723161054528](typora-user-images\image-20220723161054528.png)
>
> 
>
> 

#### 视觉风格--粒子



>  **添加粒子特效**
>
> 1. 先将精灵进行切分
> 2. ![image-20220723202641203](typora-user-images\image-20220723202641203.png)
> 3. Effects-->Particle  System创建一个粒子特效，命名为SmokeEffect
> 4. 将启用SmokeEffect的Texture Sheet Animation属性
> 5. ![image-20220723203405694](typora-user-images\image-20220723203405694.png)
> 6. 将mode修改为Sprite
> 7. 在下面添加两个sprite
> 8. 将start fram修改为random between two constants
> 9. 修改下面的值为0，2
> 10. 选中Fram over time(这个框展示随着时间的改变，动画帧的变化) ，右键这条线上的点，delete key
> 11. ![image-20220723204157514](typora-user-images\image-20220723204157514.png)
>
> **修改粒子特效的表现**
>
> 1. 展开shape属性
> 2. 修改Radius为0-----表示粒子只从一个点发出
> 3. 修改Angle为5-----表示粒子向外发散的角度
> 4. ![image-20220723204920959](typora-user-images\image-20220723204920959.png)
>
> **修改粒子特效的表现时间**
>
> 1. 将start LifeLine修改为random between two constants----表示随机的在这两个时间中消失
> 2. 将start Size修改为random between two constants-----表示粒子生成时，大小为这两个数之间的随机数
> 3. 将start Speed修改为random between two constants----表示粒子生成时移动的速度大小
> 4. ![image-20220723205555260](typora-user-images\image-20220723205555260.png)
>
> **修改粒子慢慢的消失**
>
> 1. 勾选color over lifetime---控制粒子颜色随时间的变化为变化
> 2. 打开Gradient Editor
> 3. 上面两个控制粒子的透明度随时间的变化
> 4. 下面两个控制粒子的颜色随时间的变化
> 5. 选中右上的箭头，将值修改为0，表示粒子特效的透明度随时间的变化从100变为0
> 6. ![image-20220723210242408](typora-user-images\image-20220723210242408.png)
>
> **修改粒子大小为大---->小**
>
> 1. 启用size over lifetime
> 2. 将下面的值修改为1---->0的变化，表示粒子为从大到小的变化
> 3. ![image-20220723210742506](typora-user-images\image-20220723210742506.png)
> 4. 将simulation space从local修改为world-----world表示粒子在哪里生成，就在哪里开始往上消失，坐标不随enemy而改变
> 5. ![image-20220723212636798](typora-user-images\image-20220723212636798.png)
>

#### UI-血条

> 1. 添加一个canvas,添加该组件的同时，会添加要给EventSystem组件
> 2. 将Render Mode设置为Screen space -overlay 表示在场景的最上层绘制UI；Screen Space -Camera表示在相机的所在的平面绘制；World Space表示在世界空间中进行绘制，不随相机位置的改变而改变
> 3. 调整Canvas Scaler，UI Scale Mode，**Constant Size**表示以固定的大小来显示UI；**Scale With Screen Size**表示按照屏幕的大小来进行UI的缩放
> 4. ![image-20220724145852019](typora-user-images\image-20220724145852019.png)
> 5. 在Canvas下添加一个Imgae组件，给这个组件放置UI
> 6. 调整image的大小，将其放在合适的位置
> 7. Canvas的大小即为Game视图的大小，将image放置在canvas中，就会在game中相同的位置显示。
> 8. ![image-20220724151052900](typora-user-images\image-20220724151052900.png)
> 9. 途中的十字，或者向小花一样的为image的锚点，实际展示是，将使用这个位置为相对位置，然后在计算图像在视图中的显示位置。
> 10. 修改锚点，将锚点修改到左上角
> 11. ![image-20220724151731507](typora-user-images\image-20220724151731507.png)
> 12. 添加头像，在Health下创建一个新的image,然后添加头像的UI
> 13. 添加之后发现，头像自动以Health的四个角为锚点，所以当Health改变时，头像的大小也会改变
> 14. 为了让头像的大小和蓝色的圆圈一起缩放，修改锚点为蓝色圆圈的周围
> 15. ![image-20220724152751420](typora-user-images\image-20220724152751420.png)
> 16. ![image-20220724152924172](typora-user-images\image-20220724152924172.png)
> 17. 添加一个mask，并将修改其锚点为血条周围
> 18. 给mask添加一个子对象，选则stretch，**按住 Alt 键**的同时，在出现的弹出窗口中单击右下角的图标，该方法，自动将自对象和父级对象进行填充对齐，同时调整了大小和锚点的位置（时设置锚点和新图像的大小以填充其父级）
> 19. ![image-20220724154836522](typora-user-images\image-20220724154836522.png)
> 20. 给mask下的HealthBar添加图像，然后修改其锚点为mask的左上角
> 21. 给mask添加mask组件，取消选中show Mask Graphic，这时mask中白色的部分就不显示
> 22. ![image-20220724155357929](typora-user-images\image-20220724155357929.png)
> 23. 此时，调整Mask的大小，UIHealthBar于mask不重叠的部分就不会显示

#### 世界交互--对话系统

> 1. 选中三张图片，直接拖拽到场景中，将自动创建动画和gameObject
> 2. 修改动画的播放速度
> 3. 给青蛙添加碰撞检测