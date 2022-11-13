## C#

[TOC]

### delegate、event 、Action 和EventHandler之间的关系

**delegate**

> 委托的出现了是为了将函数也作为参数进行传递。可以将委托理解为函数指针
>
> 例如：
>
> ```c#
> //定义一个无返回值的，带一个int参数的委托 public delegate void myDelegate(int num);
> public delegate void myDelegate(int num);
> ```
>
> 然后使用这个委托（发布者/订阅者模式）：
>
> ```c#
> public myDelegate m_delegate;
> 
> m_delegate += MyFun;
> 
> public void MyFun(int num)
> {
>   Debug.Log("my func: " + num);
> }
> ```
>
> 但是它有一个弊端，delegate可以使用“=”将所有已经订阅的取消（也可以用+/-对订阅合并和删除，这是后话，不讲），只保留=后新的订阅，这使得之前的委托消失，只剩下最后赋值的委托起作用。
>
> ```c#
> m_delegate = MyFun1;  //MyFun订阅被取消，只有MyFun1在订阅中
> ```
>
> ```c#
> public void MyFun1(int num)
> {
>   Debug.Log("my func1: " + num);
> }
> ```
>
> 因此event出现

**event**

> [链接](https://www.tutorialsteacher.com/csharp/csharp-event)
>
> event是一种特殊的委托，他只能使用+=，-=的方式来进行赋值，不能使用=来赋值。可以实现一个多次的委托，使得一个事件完成之后出发多个函数。
>
> ```c#
> //在对myDelegate这个委托进行声明时，如果没有在前面加event关键字，按个这个委托只能接受一个函数的赋值，使用新的函数进行赋值之后，就的委托消失，只有新的委托起作用
> public delegate void myDelegate(int num);
> public event myDelegate m_event;
> 
> m_event += MyFun;
> m_event = MyFun;  //错误，
> ```
>
> 案例：
>
> 发布者类
>
> ```c#
> public delegate void Notify();  // delegate
>                     
> public class ProcessBusinessLogic
> {
>     //使用event关键字来定义一个Notify委托类型的变量。
>     //即我们在这个类中创建了一个event,这个类被称为“发布者”
>     public event Notify ProcessCompleted; // event
> 
>     
>     public void StartProcess()
>     {
>         Console.WriteLine("Process Started!");
>         // some code here..
>         OnProcessCompleted();
>     }
> 
>     protected virtual void OnProcessCompleted() //protected virtual method
>     {
>         //if ProcessCompleted is not null then call delegate
>         ProcessCompleted?.Invoke(); 
>     }
> }
> ```
>
> 订阅者类：
>
> ```c#
> class Program
> {
>     public static void Main()
>     {
>         ProcessBusinessLogic bl = new ProcessBusinessLogic();
>         
>         //对发布者中的event进行订阅
>         bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
>         bl.StartProcess();
>     }
> 
>     // event handler
>     public static void bl_ProcessCompleted()
>     {
>         Console.WriteLine("Process Completed!");
>     }
> }
> ```

**Action**

> Action可以理解为delegate的小弟。在使用delegate的过程中，我们发现，在使用之前每次都要定义一个委托然后才能使用。而Action是系统预先定义好的委托，我们不需要定义，直接拿来用就可以（直接创建）。
>
> ```c#
> //Action是系统预定义的一种委托，无返回值，参数在<>中传入
> public Action<int> m_action;
> 
> 
> ---------------------------------------------------------------------
> //这里就是直接使用Action的案例，不需要定义
> static void ConsolePrint(int i)
> {
>     Console.WriteLine(i);
> }
> 
> static void Main(string[] args)
> {
>     Action<int> printActionDel = ConsolePrint;
>     printActionDel(10);
> }
> 
> 
> //比较下delegate和Action的定义（个人理解）
> public delegate void myDelegate(int num);
> public Action<int> m_action;
> //1，Action省略了void，因为它本身就是无返回值
> //2, Action的参数在<>中定义的，delegate就是传统定义
> //3，delegate要用关键字，然后自定义一个委托名字。而Action委托名字已定。不需要delegate关键字。
> //4, Action可以接受0到16个参数
> //5, Action可以对匿名函数和lambda表达式使用
> ```

**EventHandler**

> EventHandler是Event的小弟。在上面我们使用event的过程中，我们需要手动写event对应的delegate类，而EventHandler是一个delegate类，我们可以直接使用EventHandler来代替我们写的delegate类。
>
> 案例1：不传入eventData的事件
>
> ```c#
> public class ProcessBusinessLogic
> {
>     // declaring an event using built-in EventHandler
>     //创建一个EventHandler类型的委托
>     public event EventHandler ProcessCompleted; 
> 
>     public void StartProcess()
>     {
>         Console.WriteLine("Process Started!");
>         // some code here..
>         
>         //不传入data
>         OnProcessCompleted(EventArgs.Empty); //No event data
>     }
> 
>     protected virtual void OnProcessCompleted(EventArgs e)
>     {
>         ProcessCompleted?.Invoke(this, e);
>     }
> }
> class Program
> {
>     public static void Main()
>     {
>         ProcessBusinessLogic bl = new ProcessBusinessLogic();
>         
>         //给这个事件注册函数
>         bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
>         bl.StartProcess();
>     }
> 
>     // event handler
>     public static void bl_ProcessCompleted(object sender, EventArgs e)
>     {
>         Console.WriteLine("Process Completed!");
>     }
> }
> 
> 
> ```
>
> 案例2：传入eventData的事件
>
> ```c#
> public class ProcessBusinessLogic
> {
>     // declaring an event using built-in EventHandler
>     //创建一个EventHandler类型的委托，这个委托接受一个bool类型的参数
>     public event EventHandler<bool> ProcessCompleted; 
> 
>     public void StartProcess()
>     {
>         try
>         {
>             Console.WriteLine("Process Started!");
> 			
>             // some code here..
> 
>             OnProcessCompleted(true);
>         }
>         catch(Exception ex)
>         {
>             OnProcessCompleted(false);
>         }
>     }
> 
>     protected virtual void OnProcessCompleted(bool IsSuccessful)
>     {
>         
>         //调用函数，
>         ProcessCompleted?.Invoke(this, IsSuccessful);
>     }
> }
> 
> class Program
> {
>     public static void Main()
>     {
>         ProcessBusinessLogic bl = new ProcessBusinessLogic();
>         
>         //给这个event注册处理函数
>         bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
>         bl.StartProcess();
>     }
> 
>     // event handler
>     public static void bl_ProcessCompleted(object sender, bool IsSuccessful)
>     {
>         Console.WriteLine("Process " + (IsSuccessful? "Completed Successfully": "failed"));
>     }
> }
> ```
>
> [案例3：传入多个参数的情况](https://www.tutorialsteacher.com/csharp/csharp-event)

### 拆箱和装箱

> **为什么有拆箱和装箱：**
>
> 值类型和引用类型都继承自System.Ojbect类，但是引用类型直接继承自System.Object类，而值类型继承于System.Object的子类Object.ValueType类。
>
> 即：
>
> > 值类型都继承自System.ValueType类
> >
> > 引用类型继承自System.Object类。
>
> 在两个类型之间进行转换时就设计到了**拆箱**和**装箱**
>
> 简单来说：装箱就是将**值类型**转换为**引用类型**；拆箱就是将**引用类型**转换为**值类型**。
>
> **装箱的案例：**
>
> ```c#
> int val = 100; 
> object obj = val; 
> Console.WriteLine ("对象的值 = {0}", obj); //对象的值 = 100
> ```
>
> **拆箱的案例：**
>
> ```c#
> int val = 100; 
> object obj = val; 
> int num = (int) obj;   //拆箱
> Console.WriteLine ("num: {0}", num); //num: 100
> ```
>
> 注:只有被装过箱的才能被拆箱
>
> **装箱的过程：**
>
> 1：首先从托管堆中为新生成的引用对象分配内存(大小为值类型实例大小加上一个方法表指针和一个SyncBlockIndex)。 
> 2：然后将值类型的数据拷贝到刚刚分配的内存中。 
> 3：返回托管堆中新分配对象的地址。这个地址就是一个指向对象的引用了。
>
> ![image-20221107104444057](C:\Users\feitan\AppData\Roaming\Typora\typora-user-images\image-20221107104444057.png)
>
> **拆箱过程：**
>
> 1、首先获取托管堆中属于值类型那部分字段的地址，这一步是严格意义上的拆箱。
> 2、将引用对象中的值拷贝到位于线程堆栈上的值类型实例中。
>
> ![image-20221107105001901](C:\Users\feitan\AppData\Roaming\Typora\typora-user-images\image-20221107105001901.png)
>
> 装箱拆箱案例1：
>
> ```c#
> //结构体是值类型 继承自 System.ValueTy类，当然可以继承自其它类型
> Struct A : ICloneable 
> { 
>     public Int32 x; 
> 
> 	public override String ToString() 
>     { 
> 		return String.Format(”{0}”,x); 
>     }
> 	//    
> 	public object Clone() { 
> 		return MemberwiseClone(); 
> 	} 
>     
>     public void Change(Int32 x) { 
> 		this.x = x; 
>     } 
> }
> //
> static void main() 
> { 
> 	A a; 
> 
> 
> 	a.x = 100; 
> 
> 
>     //本身有ToString，不进行装箱
> 	Console.WriteLine(a.ToString()); 
>     //本身没有有GetType()，需要进行装箱，变成Object类型，生成方发表指针，通过函数指针找到对应的函数
> 	Console.WriteLine(a.GetType()); 
> 
>     //实现了Clone方法，无需装箱
> 	A a2 = (A)a.Clone(); 
> 
>     //进行装箱，变成IClonable类型
> 	ICloneable c = a2; 
>     //无需装箱，使用装箱成IClonable是的堆上的对象的方法。
> 	Ojbect o = c.Clone(); 
> } 
> 
> ```
>
> 修改已经装箱的对象：
>
> ```c#
> 
> static void main() 
> { 
> 	A a = new A(); 
> 	a.x = 100; 
> 	Object o = a;        //装箱成o，下面，想改变o的值。 
>     ((A)o).Change(200); //改掉了吗？没改掉。 
>     //因为0拆箱成A时，得到的是新的临时的A，修改的是这个临时变量，不是原来的A
> } 
> 
> ```
>
> 如果实现同步修改：
>
> ```c#
> interface IChange { 
>     void Change(Int32 x); 
> } 
> struct A : IChange { 
> 	 
> } 
> static void main() 
> { 
> 	A a = new A(); 
> 	a.x = 100; 
> 	Object o = a;        //装箱成o，下面，想改变o的值。 
>     ((IChange)o).Change(200) //这里成功改变
>     //将o转换为IChange时，没有进行装箱，也没有进行拆箱。所以可是之间调用Change方法，于是更改的就是已经装箱的字段的值。
> } 
> ```
>
> 总结：如何使得修改装箱后的值，原来的值也改变---->使用不会拆箱的方法来进行调用。

### 抽象类和接口的区别

> 当一个类继承自一个接口时，他就必须实现这个接口所规定的方法，但是怎么实现都可以。所以接口的功能是约束继承自他的类“必须有”的功能，他约束了行为的有无，但不对如何实现行为进行限制。
>
> 抽象类的设计，是为了代码的复用。当所有的子类都有相同的行为时，可以将这些子类继承自这个抽象类，防止子类再实现这个方法，实现了代码的复用。
>
> 接口表达的是一个**“有没有”**的功能
>
> 抽象类表达的是一个**“是不是”**的功能

### 反射

#### 反射的基础概念

> 原理
>
> > 在我们自己写的对象和类中，我们知道这些对象和类定义了什么方法和属性，我们知道怎么使用这些类和方法。但是，例如我们引入了一个dll文件，我们并不知道这个dll文件中是怎么定义一个类的。这样我们就可以通过反射来知道这些对象或类的属性和方法，知道怎么使用这个对象，怎么访问这个对象的方法。
> >
> > 正常的写代码的逻辑：定义一个类，使用这个类来创建对象，使用这个对象
> >
> > 反射：通过类的字段得到这个类，再使用这个类来创建对象，使用这个对象
>
> 反射的基础介绍：
>
> ```c#
> using System;
> using System.Reflection;
> using System.Threading;
> 
> namespace Lesson20_反射
> {
>     #region 知识点三 反射的概念
>     //程序正在运行时，可以查看其它程序集或者自身的元数据。
>     //一个运行的程序查看本身或者其它程序的元数据的行为就叫做反射
> 
>     //说人话：
>     //在程序运行时，通过反射可以得到其它程序集或者自己程序集代码的各种信息
>     //类，函数，变量，对象等等，实例化它们，执行它们，操作它们
>     #endregion
> 
>     #region 知识点四 反射的作用
>     //因为反射可以在程序编译后获得信息，所以它提高了程序的拓展性和灵活性
>     //1.程序运行时得到所有元数据，包括元数据的特性
>     //2.程序运行时，实例化对象，操作对象
>     //3.程序运行时创建新对象，用这些对象执行任务
>     #endregion
> 
>     class Test
>     {
>         private int i = 1;
>         public int j = 0;
>         public string str = "123";
>         public Test()
>         {
> 
>         }
> 
>         public Test(int i)
>         {
>             this.i = i;
>         }
> 
>         public Test( int i, string str ):this(i)
>         {
>             this.str = str;
> 
>         }
> 
>         public void Speak()
>         {
>             Console.WriteLine(i);
>         }
>     }
> 
>     class Program
>     {
>         static void Main(string[] args)
>         {
>             Console.WriteLine("反射");
> 
>             //Type（类的信息类）、它是反射功能的基础！、它是访问元数据的主要方式。 使用 Type 的成员获取有关类型声明的信息
>             //1.万物之父object中的 GetType()可以获取对象的Type
>             int a = 42;
>             Type type = a.GetType();
>             Console.WriteLine(type);
>             
>             
>             //2.通过typeof关键字 传入类名 也可以得到对象的Type
>             Type type2 = typeof(int);
>             Console.WriteLine(type2);
>             
>             //3.通过类的名字 也可以获取类型
>             Type type3 = Type.GetType("System.Int32");
>             Console.WriteLine(type3);
> 
>             //可以通过Type可以得到类型所在程序集信息，会输出所在的程序集，版本
>             Console.WriteLine(type.Assembly);
>             Console.WriteLine(type2.Assembly);
>             Console.WriteLine(type3.Assembly);
> 
>             //然后得到所有公共成员、需要引用命名空间 using System.Reflection;
>             Type t = typeof(Test);
>             MemberInfo[] infos = t.GetMembers();
>             for (int i = 0; i < infos.Length; i++)
>             {
>                 Console.WriteLine(infos[i]);
>             }
>     
>             //1.获取所有构造函数
>             ConstructorInfo[] ctors = t.GetConstructors();
>             for (int i = 0; i < ctors.Length; i++)
>             {
>                 Console.WriteLine(ctors[i]);
>             }
> 
>             //2.获取其中一个构造函数 并执行
>             //得构造函数传入 Type数组 数组中内容按顺序是参数类型
>             //执行构造函数传入  object数组 表示按顺序传入的参数
>             
>             //  2-1得到无参构造
>             ConstructorInfo info = t.GetConstructor(new Type[0]);
>             //执行无参构造 无参构造 没有参数 传null
>             Test obj = info.Invoke(null) as Test;
>             Console.WriteLine(obj.j);
> 
>             //  2-2得到有参构造
>             ConstructorInfo info2 = t.GetConstructor(new Type[] { typeof(int) });
>             obj = info2.Invoke(new object[] { 2 }) as Test;
>             Console.WriteLine(obj.str);
> 
>             ConstructorInfo info3 = t.GetConstructor(new Type[] { typeof(int), typeof(string) });
>             obj = info3.Invoke(new object[] { 4, "444444" }) as Test;
>             Console.WriteLine(obj.str);
> 
>             //1.得到所有成员变量
>             FieldInfo[] fieldInfos = t.GetFields();
>             for (int i = 0; i < fieldInfos.Length; i++)
>             {
>                 Console.WriteLine(fieldInfos[i]);
>             }
>             
>             
>             //2.得到指定名称的公共成员变量，这里获取的是对象而不是值
>             FieldInfo infoJ = t.GetField("j");
>             Console.WriteLine(infoJ);
> 
>             
>             Test test = new Test();
>             test.j = 99;
>             test.str = "2222";
>             //  3-1通过反射 获取j这个对象中test的值
>             Console.WriteLine(infoJ.GetValue(test));
>             //  3-2通过反射 将j这个对象中test的值设置为100
>             infoJ.SetValue(test, 100);
>             Console.WriteLine(infoJ.GetValue(test));
> 
>             //通过Type类中的 GetMethod方法 得到类中的方法
>             //MethodInfo 是方法的反射信息
>             Type strType = typeof(string);
>             MethodInfo[] methods = strType.GetMethods();//获取String类中的所有的公共方法
>             for (int i = 0; i < methods.Length; i++)
>             {
>                 Console.WriteLine(methods[i]);
>             }
>             
>             
>             //1.如果存在方法重载 用Type数组表示参数类型
>             MethodInfo subStr = strType.GetMethod("Substring",
>                 new Type[] { typeof(int), typeof(int) });
>             
>             
>             
>             //2.调用该方法
>             //注意：如果是静态方法 Invoke中的第一个参数传null即可
>             string str = "Hello,World!";
>             //第一个参数 相当于 是哪个对象要执行这个成员方法
>             object result = subStr.Invoke(str, new object[] { 7, 5 });
>             Console.WriteLine(result);
> 
>             #endregion
> 
>             #region 其它
>             //Type;
>             //得枚举
>             //GetEnumName
>             //GetEnumNames
> 
>             //得事件
>             //GetEvent
>             //GetEvents
> 
>             //得接口
>             //GetInterface
>             //GetInterfaces
> 
>             //得属性
>             //GetProperty
>             //GetPropertys
>             //等等
>             #endregion
> 
>             #endregion
> 
>             #region Assembly
>             //程序集类
>             //主要用来加载其它程序集，加载后
>             //才能用Type来使用其它程序集中的信息
>             //如果想要使用不是自己程序集中的内容 需要先加载程序集
>             //比如 dll文件(库文件) 
>             //简单的把库文件看成一种代码仓库，它提供给使用者一些可以直接拿来用的变量、函数或类
> 
>             //三种加载程序集的函数
>             //一般用来加载在同一文件下的其它程序集
>             //Assembly asembly2 = Assembly.Load("程序集名称");
> 
>             //一般用来加载不在同一文件下的其它程序集
>             //Assembly asembly = Assembly.LoadFrom("包含程序集清单的文件的名称或路径");
>             //Assembly asembly3 = Assembly.LoadFile("要加载的文件的完全限定路径");
> 
>             //1.先加载一个指定程序集
>             Assembly asembly = Assembly.LoadFrom(@"C:\Users\MECHREVO\Desktop\CSharp进阶教学\Lesson18_练习题\bin\Debug\netcoreapp3.1\Lesson18_练习题");
>             Type[] types = asembly.GetTypes();//得到所有的类
>             for (int i = 0; i < types.Length; i++)
>             {
>                 Console.WriteLine(types[i]);
>             }
>             //得到上面所有的类的名称后，在根据类的名称去创建对象
>             //2.再加载程序集中的一个类对象 之后才能使用反射
>             //得到icon这个类，并获取到icon这个类中的成员变量
>             Type icon = asembly.GetType("Lesson18_练习题.Icon");
>             MemberInfo[] members = icon.GetMembers();//获取所有的类的成员变量
>             for (int i = 0; i < members.Length; i++)
>             {
>                 Console.WriteLine(members[i]);
>             }
>             
>             
>             //通过反射 实例化一个 icon对象
>             //首先得到枚举Type 来得到可以传入的参数
>             //枚举也算个类，
>             Type moveDir = asembly.GetType("Lesson18_练习题.E_MoveDir");
>             FieldInfo right = moveDir.GetField("Right");//得到类对象
>             //直接实例化对象
>             object iconObj = Activator.CreateInstance(icon, 10, 5, right.GetValue(null));
>             //得到对象中的方法 通过反射
>             MethodInfo move = icon.GetMethod("Move");
>             MethodInfo draw = icon.GetMethod("Draw");
>             MethodInfo clear = icon.GetMethod("Clear");
> 
>             Console.Clear();
>             while(true)
>             {
>                 Thread.Sleep(1000);
>                 clear.Invoke(iconObj, null);
>                 move.Invoke(iconObj, null);
>                 draw.Invoke(iconObj, null);
>             }
>             
> 
>             //3.类库工程创建
>             #endregion
> 
>             #region Activator
>             //用于快速实例化对象的类
>             //用于将Type对象快捷实例化为对象
>             //先得到Type
>             //然后 快速实例化一个对象
>             Type testType = typeof(Test);
>             //1.无参构造
>             Test testObj = Activator.CreateInstance(testType) as Test;
>             Console.WriteLine(testObj.str);
>             //2.有参数构造
>             testObj = Activator.CreateInstance(testType, 99) as Test;
>             Console.WriteLine(testObj.j);
> 
>             testObj = Activator.CreateInstance(testType, 55, "111222") as Test;
>             Console.WriteLine(testObj.j);
>             #endregion
> 
>             #endregion
>         }
>     }
> }
> 
> ```
>
> 总结：
>
> ```c#
> //总结
> //反射
> //在程序运行时，通过反射可以得到其他程序集或者自己的程序集代码的各种信息
> //类、函数、变量、对象等等，实例化他们，执行他们，操作他们
> 
> //关键类
> //Type
> //Assembly
> //Activator
> 
> //对于我们的意义
> //在初中级阶段 基本不会使用反射
> //所以目前对于大家来说，了解反射可以做什么就行
> //很长时间内都不会用到反射相关知识点
> 
> //为什么要学反射
> //为了之后学习Unity引擎的基本工作原理做铺垫
> //Unity引起的基本工作机制 就是建立在反射的基础上
> ```
>
> 例子2，类的反射：
>
> ```c#
> public class ReflectionSyntax
> {
>     public static void Excute()
>     {
>         
>         //得到kiba这个类，然年后再实例化一个对象
>         Type type = GetType("Syntax.Kiba");
>         Kiba kiba = (Kiba)Activator.CreateInstance(type);
>         
>         
>         Type type2 = GetType2("Syntax.Kiba");
>         Kiba kiba2 = (Kiba)Activator.CreateInstance(type2);
>     }
>     public static Type GetType(string fullName)
>     {
>         //加载Syntax命名空间所在的程序集
>         Assembly assembly = Assembly.Load("Syntax");
>         //从程序集中加载fullName指定的类
>         Type type = assembly.GetType(fullName, true, false);
>         return type;
>     }
>  
>     //这种方式只在自己所在的命名空间下解析
>     public static Type GetType2(string fullName)
>     {
>         Type t = Type.GetType(fullName);
>         return t;
>     }
> }
> public class Kiba
> {
>     public void PrintName()
>     {
>         Console.WriteLine("Kiba518");
>     }
> }
> ```
>
> 例子3：函数反射
>
> ```c#
> public static void ExcuteMethod()
> {
>     //加载命名空间，获取到类
>     Assembly assembly = Assembly.Load("Syntax");
>     Type type = assembly.GetType("Syntax.Kiba", true, false);
>     //得到Kiba这个类的PrintName这个函数
>     MethodInfo method =  type.GetMethod("PrintName");
>     object kiba = assembly.CreateInstance("Syntax.Kiba");
>     //创建一个字符串
>     object[] pmts = new object[] { "Kiba518" };
>     //进行函数的调用
>     method.Invoke(kiba, pmts);//执行方法 
> }
> public class Kiba
> {
>     public string Name { get; set; }
>     public void PrintName(string name)
>     {
>         Console.WriteLine(name);
>     }
> }
> ```
>
> 例子4：属性反射
>
> ```c#
> public static void ExcuteProperty()
> {
>     //创建一个对象，给这个对象的name属性赋值
>     Kiba kiba = new Kiba();
>     kiba.Name = "Kiba518";
>     
>     //
>     object name = ReflectionSyntax.GetPropertyValue(kiba, "Name");
>     Console.WriteLine(name);
> }
> public static object GetPropertyValue(object obj, string name)
> {
>     //获取到obj这个对象所处的类
>     //获取这个对象的name这个属性
>     //如果这个属性不为空，输出这个属性的值
>     PropertyInfo property = obj.GetType().GetProperty(name);
>     if (property != null)
>     {
>         object drv1 = property.GetValue(obj, null);
>         return drv1;
>     }
>     else
>     {
>         return null;
>     }
> }
> ```
>
> 上面的例子中，为什么我们得到了对象不直接进行属性的访问，还要使用反射的方式来访问?

#### 反射的架构应用

> 反射的架构应用
>
> ```c#
> //客户端
> public class Client
> {
>     public void ExcuteGetNameCommand()
>     {
>         Proxy proxy = new Proxy();
>         GetNameCommand cmd = new GetNameCommand();
>         ResultBase rb = proxy.ExcuteCommand(cmd);
>     }
> }
> 
> //执行命令的代理
> public class Proxy
> {
>     public ResultBase ExcuteCommand(CommandBase command)
>     {
>         var result = HandlerSwitcher.Excute(command);
>         return result as ResultBase;
>     }
> }
> 
> //处理分发器
> public class HandlerSwitcher
> {
>     private const string methodName = "Excute";//约定的方法名
>     private const string classNamePostfix = "Handler";//约定的处理Command的类的名称的后缀
>     
>     
>     //获取命名空间的名称
>     public static string GetNameSpace(CommandBase command)
>     {
>         
>         //获取到这个类所在的路径
>         Type commandType = command.GetType();//获取完全限定名
>         //将路径分割
>         string[] CommandTypeNames = commandType.ToString().Split('.');
>         string nameSpace = "";
>         
>         //去掉最后的类名，留下命名空间
>         for (int i = 0; i < CommandTypeNames.Length - 1; i++)
>         {
>             nameSpace += CommandTypeNames[i];
>             if (i < CommandTypeNames.Length - 2)
>             {
>                 nameSpace += ".";
>             }
>         }
>         //返回命名空间
>         return nameSpace;
>     }
>  
>     public static object Excute(CommandBase command)
>     {
>         string fullName = command.GetType().FullName;//完全限定名
>         string nameSpace = GetNameSpace(command);//命名空间 
>         
>         //加载命名空间所在的程序集
>         Assembly assembly = Assembly.Load(nameSpace);
>         //获取到这个command的处理类-->GetNameCommandHandler
>         Type handlerType = assembly.GetType(fullName + classNamePostfix, true, false);
>         //实例化一个处理类
>         object obj = assembly.CreateInstance(fullName + classNamePostfix);
>         //获取到excute这个方法
>         MethodInfo handleMethod = handlerType.GetMethod(methodName);//获取函数基本信息
>         object[] pmts = new object[] { command }; //传递一个参数command
>         try
>         {
>             //执行这个command的处理函数
>             return handleMethod.Invoke(obj, pmts);
>         }
>         catch (TargetInvocationException tie)
>         {
>             throw tie.InnerException;
>         }
>     }
> }
> //获取name命令的处理器
> public class GetNameCommandHandler
> {
>     public ResultBase Excute(CommandBase cmd)
>     {
>         GetNameCommand command = (GetNameCommand)cmd;
>         ResultBase result = new ResultBase();
>         result.Message = "I'm Kiba518";
>         return result;
>     }
> }
> //获取name的命令
> public class GetNameCommand: CommandBase
> { 
> }
> //命令的基类
> public class CommandBase
> {
>     public int UserId { get; set; }
>       
>     public string UserName { get; set; }
>      
>     public string ArgIP { get; set; }
> }
> //执行结果的基类
> public class ResultBase
> {
>     public string Message { get; set; }
> }
> ```
>
> 上面架构的实现逻辑：在客户端实现一个代理，用于处理继承了CommandBase的类的代理。即客户端不管传来什么样的Command.只要他继承了CommandBase，这个代理就会找到对应的处理类。并执行处理，且返回结果。
>
> 架构的结构图如下：
>
> ![image-20221109105012707](C:\Users\feitan\AppData\Roaming\Typora\typora-user-images\image-20221109105012707.png)
>
> 这个框架使用了一个原则，即“约定优于配置”，即架构会按照约定的方式进行代码的执行。后面开发的人员只需要按照这个约定来写自己的函数就好。
>
> 约定如下：
>
> 第一个是，处理Command的类必须后缀名是Command的类名+Handler结尾。
>
> 第二个是，处理Command的类中的处理函数名必须为Excute。

#### 反射与特性

> 反射在系统中另一个重要应用就是与特性的结合使用。
>
> 在一些相对复杂的系统中，难免会遇到一些场景，要讲对象中的一部分属性清空，或者要获取对象中的某些属性赋值。通常我们的实现方式就是手写，一个一个的赋值。
>
> 而利用反射并结合特性，完全可以简化这种复杂操作的代码量。
>
> ```c#
> public partial class ReflectionSyntax
> {
>     public void ExcuteKibaAttribute()
>     {
>         Kiba kiba = new Kiba();
>         kiba.ClearName = "Kiba518";
>         kiba.NoClearName = "Kiba518";
>         kiba.NormalName = "Kiba518";
>         ClearKibaAttribute(kiba);
>         Console.WriteLine(kiba.ClearName);
>         Console.WriteLine(kiba.NoClearName);
>         Console.WriteLine(kiba.NormalName);
>     }
>     public void ClearKibaAttribute(Kiba kiba)
>     {
>         //获取到所有public的属性
>         List<PropertyInfo> plist = typeof(Kiba).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).ToList();//只获取Public的属性
>         foreach (PropertyInfo pinfo in plist)
>         {
>             var attrs = pinfo.GetCustomAttributes(typeof(KibaAttribute), false);
>             
>             //将所有允许清除的属性进行清除
>             if (null != attrs && attrs.Length > 0)
>             {
>                 var des = ((KibaAttribute)attrs[0]).Description;
>                 if (des == "Clear")
>                 {
>                     pinfo.SetValue(kiba, null);
>                 }
>             }
>         }
>     }
> }
> public class Kiba
> {
>     
>     //定义这个属性可以清除
>     [KibaAttribute("Clear")]
>     public string ClearName { get; set; }
>     
>     //定义这些属性不可以清除
>     [KibaAttribute("NoClear")]
>     public string NoClearName { get; set; }
>     public string NormalName { get; set; }
>  
> }
> 
> //定义自己的属性描述符  并且这个属性描述符可以在所有的场景都可以使用
> [System.AttributeUsage(System.AttributeTargets.All)]
> public class KibaAttribute : System.Attribute
> {
>     public string Description { get; set; }
>     public KibaAttribute(string description)
>     {
>         this.Description = description;
>     }
> }
> ```
>
> 

### Monobehaviour的生命周期

> 各函数之间的执行顺序：
>
> ![5408097-dcc261ee317a816e](C:\Users\feitan\AppData\Roaming\Typora\typora-user-images\5408097-dcc261ee317a816e.png)
>
> 1. **update和FixedUpdate的区别：**
>
>    Update每帧调用，但因为机器的性能原因，帧数是波动的，所以这个函数的刷新时间是不规律的。如果在Update中添加物体匀速运动，需要乘上Time.deltatime
>     FixedUpdate固定时间调用一次，即一秒钟调用的次数是固定的，如需更改频率，可至Edit -> Project Setting -> Time中修改Fixed Timestep。如果同一次循环中出现FixedUpdate和Update那么FixedUpdate优先，但不建议这两个函数有依赖（因为update的刷新频率一直在变啊，谁知道会发生什么）
>
> 2. OnEnable和OnDisable函数都是一旦被setActive()修改，瞬间跳转执行。
>
>    ```c#
>    void Update()
>    {
>        gameObject.SetActive(true);
>        Debug.Log("Update")
>    }
>    private void OnDisable()
>    {
>        Debug.Log("On Disable")
>    }
>    //输出结果  On Disable--->Update
>    ```
>
> 3. Awake，Start, FixedUpdate, Update, LateUpdate, OnWillRenderObject, OnGUI都是项目中所有激活的component的同时运行的。
>
>    ```c#
>    //是
>    "Awake code1”
>    "Awake code2"
>        ...
>    "Update code1"
>    "Update code2"
>        
>     //而不是
>    "Awake code1”
>    "Start code1”
>    "Fixed code1”
>    ```
>
> 4. Reset函数只能在编辑器模式下可以使用。运行的时候不能进行调用

### 渲染管线

> 作用
>
> > 执行一些系列的操作获取到场景中的内容，将这些内容展示在屏幕上。包括：
> >
> > - 剔除（将不需要渲染的对象排除，例如那些在相机外面的物体）
> > - 渲染（将对象绘制成像素，放到缓冲区中）
> > - 后期处理（在像素的基础上添加光照等显示效果）
>
> 分类
>
> > 不同的渲染管线有不同的功能特性，使用了不同的方式来进行着色器的输出，所以对一个场景使用不同的渲染管线来进行渲染时，输出的效果可能不一样。所以游戏开发之前，就要确定使用什么渲染管线。
> >
> > 分类：
> >
> > - 内置渲染管线：unity默认的渲染管线，自定义的操作有限
> > - 通用渲染管线（URP）：可快速自定义且可以编程的渲染管线
> > - 高清渲染管线（HDRP）：可编程的渲染管线，可以创建出高保真的图像
> > - 自定义渲染管线：自己使用unity提过的api来实现自己的渲染管线
>
> 使用内置渲染管线
>
> > 如果你需要使用内置的渲染管线，你需要进入到项目设置中，Quality和Graphics中的Render Pipline设置为None,即告诉unity，该项目没有使用其他的渲染管线。unity你使用内置的渲染管线来进行渲染就好。
> >
> > 内置渲染管线的渲染路径：
> >
> > > 前向渲染路径：场景中的所有对象按照顺序进行渲染。如果一个对象被多光照同时照射，会同时使用多个渲染器来渲染一个对象。
> > >
> > > 延迟渲染路径：先将渲染对象添加到渲染缓冲区中，在里面存放这个对象的材质，镜面反射等这些信息。每个像素按照顺序渲染，渲染时间由像素的光源数量决定。
> > >
> > > **总结**：向前渲染路径：按照物体的顺序来进行渲染。延迟渲染路径：按照像素的顺序来进行渲染。
>
> 使用其他的渲染管线
>
> > 首先，渲染管线是一种资源，你的unity项目中需要有你想要设置的渲染管线的资源才能设置。在Graphics中可以选定你默认使用的渲染管线、同时，如果对不同的材质的渲染要求不同，可以在Quality中设置不同质量使用不同的渲染管线。
> >
> > 同时，也可以通过代码更改渲染管线的默认设置。

### 着色器

> 着色器是一个运行在图形处理单元(GPU)上的程序或程序集的名称。
>
> 顶点着色器：将左边从“对象空间”转换到“剪裁空间”，大概就是将物体的世界坐标转换为在相机中的坐标
>
> 像素着色器：提取物体上面的像素，绘制到由顶点着色器提取出来的像素点上。
>
> 计算着色器：可以进行大量的数学运算，实现光照剔除，粒子物理或体积模拟

### 光照

> 直接光照：发光源发出的光。光照强度会随着与光源距离的增大而衰减
>
> 间接光照：光在物体表面反射而形成的光照
>
> 方向光照：覆盖整个场景的平行光照，光照强度不会随着与光源的距离增加而衰减

[链接](https://mp.weixin.qq.com/s?__biz=MzkyMTM5Mjg3NQ==&mid=2247536464&idx=1&sn=b821f15617605b6b360024fa2c33aea6&source=41#wechat_redirect)