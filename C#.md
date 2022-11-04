### C#

[TOC]



#### delegate、event 、Action 和EventHandler之间的关系

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

#### Action

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
> 