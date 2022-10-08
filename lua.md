### lua 笔记

[TOC]

#### 语法

> 1. 全局变量不需要声明
> 2. 没有赋值的全局变量为nil
> 3. 给一个变量赋值为nil表示删除这个变量

#### 数据类型

> **定义：**
>
> > 1. nil表示无效的数据类型
> > 2. number表示双精度的浮点数
> > 3. function表示函数
> > 4. userdata表示任意存放在变量中的c数据结构？？
> > 5. thread表示一个线程
> > 6. table Lua中的表==关联数组？？  类似于数组
>
> **应用：**
>
> > 1. 对全局变量和table中的变量，赋值为nil表示删除这个数
> >
> >    ```lua
> >    tab1 = { key1 = "val1", key2 = "val2", "val3" }
> >    for k, v in pairs(tab1) do
> >        print(k .. " - " .. v)
> >    end
> >
> >    --------------------------------输出---------------------------------------------
> >    1 - val3
> >    key1 - val1
> >    key2 - val2
> >
> >    ---------------------------------------------------------------------------------
> >    tab1 = { key1 = "val1", key2 = "val2", "val3" }
> >    for k, v in pairs(tab1) do
> >        print(k .. " - " .. v)
> >    end
> >
> >    tab1.key1 = nil -- delete key1
> >    for k, v in pairs(tab1) do
> >        print(k .. " - " .. v)
> >    end
> >
> >    --------------------------------输出---------------------------------------------
> >    1 - val3
> >    key2 - val2
> >    ```
> >
> > 1. nil本身为一个string类型，比较时使用""来进行比较
> >
> > 2. nil 和false都为false, 其他的都为true包括0
> >
> > 3. ```lua 
> >    -------使用""来表示字符串
> >    -------使用[[]]来表示一块字符串
> >                                           
> >    html = [[
> >    <html>
> >    <head></head>
> >    <body>
> >        <a href="http://www.runoob.com/">菜鸟教程</a>
> >    </body>
> >    </html>
> >    ]]
> >    print(html)
> >                                           
> >    --------------------------------输出-------------------------------------
> >    <head></head>
> >    <body>
> >        <a href="http://www.runoob.com/">菜鸟教程</a>
> >    </body>
> >    </html>
> >    ```
> >
> > 1. 使用..来进行字符串的连接
> >
> >    ```lua
> >    print("a" .. 'b')
> >    --------------------------------输出-------------------------------------
> >    ab
> >
> >    print(157 .. 428)
> >    --------------------------------输出-------------------------------------
> >    157428
> >    ```
> >
> > 1. 使用 # 来计算字符串的长度，放在字符串前面
> >
> >    ```lua
> >    len = "www.runoob.com"
> >    print(#len)
> >    --------------------------------输出-------------------------------------
> >    14
> >    
> >    print(#"www.runoob.com")
> >    -------------------------------输出-------------------------------------
> >    14
> >
> > 1. table相关
> >
> >    > - 使用构造表达式{}来创建table
> >    >
> >    >   ```lua
> >    >   -- 创建一个空的 table
> >    >   local tbl1 = {}
> >    >    
> >    >   -- 直接初始表
> >    >   local tbl2 = {"apple", "pear", "orange", "grape"}
> >    >   ```
> >    >
> >    > - table为关联数组，**索引可以是数字和字符串**
> >    >
> >    >   ```lua
> >    >   -- table_test.lua 脚本文件
> >    >   a = {}                     --创建一个新的table a 
> >    >   a["key"] = "value"         --给索引为key的位置赋值为value       key---value
> >    >   key = 10                   --创建一个变量key，值为10
> >    >   a[key] = 22                a[10]=22                     
> >    >   a[key] = a[key] + 11       a[10]=33
> >    >   for k, v in pairs(a) do    --此时a中存在两个元素
> >    >       print(k .. " : " .. v)  
> >    >   end
> >    >   -------------------------------输出-----------------------------------
> >    >   key：value
> >    >   10:33
> >    >   ```
> >    >
> >    > - lua中table的默认下标为1,在创建table时，如果没有指定索引，则自动使用数字作为索引
> >    >
> >    >   ```lua
> >    >   -- table_test2.lua 脚本文件
> >    >   local tbl = {"apple", "pear", "orange", "grape"}
> >    >   for key, val in pairs(tbl) do
> >    >       print("Key", key)   -- 一种新的输出方式
> >    >   end
> >    >   -------------------------------输出-----------------------------------
> >    >   key 1
> >    >   key 2
> >    >   key 3
> >    >   key 4
> >    >   ```
> >    >
> >    > - table没有固定大小，添加新的元素之后自动增加
> >    >
> >    >   ```lua
> >    >   -- table_test3.lua 脚本文件
> >    >   a3 = {}
> >    >   for i = 1, 10 do   --循环10次对table a3进行赋值
> >    >       a3[i] = i
> >    >   end
> >    >   a3["key"] = "val"  --在a3中添加一个元素
> >    >   print(a3["key"])   --打印a3["key"]这个元素
> >    >   print(a3["none"])  --打印一个不存在的元素
> >    >   -------------------------------输出-----------------------------------
> >    >   val
> >    >   nil
> >    >   ```
> >
> > 1. function函数
> >
> >    > -  lua中function可以看作一个变量，可以进行赋值
> >    >
> >    > ```lua
> >    > -- function_test.lua 脚本文件
> >    > function factorial1(n)   --创建一个函数。求阶乘
> >    >     if n == 0 then
> >    >         return 1
> >    >     else
> >    >         return n * factorial1(n - 1)
> >    >     end      --else的end处
> >    > end
> >    > print(factorial1(5))   --计算5!
> >    > factorial2 = factorial1  --进行函数的赋值，lua中进行变量之间的赋值时不需要声明变量类型
> >    > print(factorial2(5))    --计算5!
> >    > -------------------------------输出-----------------------------------
> >    > 120
> >    > 120
> >    > ```
> >    >
> >    > - 将function写为匿名函数时，可以将其作为参数在函数中传递
> >    >
> >    > ```lua
> >    > -- function_test2.lua 脚本文件
> >    > function testFun(tab,fun)
> >    >         for k ,v in pairs(tab) do   --先调用再声明
> >    >                 print(fun(k,v));
> >    >         end
> >    > end
> >    > 
> >    > 
> >    > tab={key1="val1",key2="val2"};   --以这种方式进行表的创建and初始化
> >    > testFun(tab,
> >    > function(key,val)               --在这里说明fun为一个匿名函数，且给出他的定义        
> >    >         return key.."="..val;
> >    > end
> >    > );
> >    > -------------------------------输出-----------------------------------
> >    > key1=val1
> >    > key2=val2
> >    > ```
> >
> > 1. 线程
> >
> >    > lua中的线程为协同线程，和普通线程的区别在于一次只能运行一个协同线程， 而普通的线程一次可以运行多个。
> >    >
> >    > 协同线程只能被挂起，没有处于等待的状态
> >
> > 1. userdata自定义数据
> >
> >    > 为用户定义的结构体 or 指针

#### 变量

> 分类：全局变量、局部变量、**表中的域**
>
> ```lua
> -- test.lua 文件脚本
> a = 5               -- 全局变量
> local b = 5         -- 局部变量
> 
> function joke()
>     c = 5           -- 全局变量
>     local d = 6     -- 局部变量
> end                 --进行函数的创建
> 
> joke()              --创建一个函数，同时函数中的数据也被创建出来
> print(c,d)          --> 5 nil    --d局部变量，只在joke函数中有效，所以进行
> 
> do                  --使用 do  end来标志一个域
>     local a = 6     -- 局部变量
>     b = 6           -- 对 上面的局部变量重新赋值
>     print(a,b);     --> 6 6      打印的是域内的数据
> end
> 
> print(a,b)      --> 5 6
> ```

> 赋值，可以在一行代码中对多个数据进行赋值
>
> ```lua
> a, b = 10, 2*x       <-->       a=10; b=2*x
> ```
>
> 赋值规则，lua先将右边的值全部计算好之后再进行赋值
>
> ```lua
> x, y = y, x                     -- swap 'x' for 'y'
> a[i], a[j] = a[j], a[i]         -- swap 'a[i]' for 'a[j]'
> --实现了值的交换  swap
> ```
>
> 在一行代码中进行多个值的赋值时，如果两边的数据个数不一样，采用以下的方式来进行补充或截断
>
> ```lua
> a. 变量个数 > 值的个数            -- 按变量个数补足nil
> b. 变量个数 < 值的个数            -- 多余的值会被忽略
> 
> -------------------------------实例-----------------------------------
> a, b, c = 0, 1
> print(a,b,c)             --> 0   1   nil      --从左边开始进行对齐
>  
> a, b = a+1, b+1, b+2     -- value of b+2 is ignored
> print(a,b)               --> 1   2
>  
> a, b, c = 0
> print(a,b,c)             --> 0   nil   nil
> 
> -------------------------------tips-----------------------------------
> a, b = f()   --可以用来获取一个函数的多个返回值
> ```
>
> - 索引
>
>   > ```lua
>   > t[i]
>   > t.i                 -- 当索引为字符串类型时的一种简化写法      -----这样的方式只能用于字符串作为索引
>   > gettable_event(t,i) -- 采用索引访问本质上是一个类似这样的函数调用   
>   > 
>   > 
>   > t={key="val1","val2"}    --val2的索引为1
>   > for k,v in pairs(t) do
>   >     print(k.."="..v)
>   > end
>   > print(t.key)  --这样的方式支持
>   > print(t.1)    --这样的方式不支持
>   > 
>   > ```

#### 循环

> while循环
>
> ```lua
> a=10
> while( a < 20 )
> do
>    print("a 的值为:", a)
>    a = a+1
> end
> ```
>
> for循环
>
> ```lua
> for var=exp1,exp2,exp3 do    --  var=exp1为初始化， 
>     <执行体>                  --  var从exp1变化到exp2, 每次的变化步为exp3,   如果不指定exp3，则默认值为1
> end  
> 
> -------------------------------实例1-----------------------------------
> for i=1,f(x) do   --f无效，所以该代码错误
>     print(i)
> end
>  
> for i=10,1,-1 do --从10变到1，每次的步长为-1
>     print(i)
> end
> --------------------------------实例2---------------------------------------
> function f(x)  
>     print("function")  
>     return x*2  
> end                    --创建一个函数，该函数返回传入的参数的2倍的值
> for i=1,f(5) do print(i)   ==  for i=1,10 do print(i)    --只输出了一次function,说明for之前的三个表达式只求一次
> end
> ```
>
> 泛型for循环
>
> > ```lua
> > --打印数组a的所有值  
> > a = {"one", "two", "three"}
> > for i, v in ipairs(a) do    --ipairs为一个迭代器函数，用于获取table中的所有元素
> >     print(i, v)
> > end 
> > --------------------------------实例---------------------------------------
> > days = {"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"}  
> > for i,v in ipairs(days) do  print(v) end  
> > 
> > -----输出
> > Sunday
> > Monday
> > Tuesday
> > Wednesday
> > Thursday
> > Friday
> > Saturday
> > ```
>
> repeat..until循环
>
> > ```lua
> > --[ 变量定义 --]
> > a = 10
> > --[ 执行循环 --]
> > repeat
> >    print("a的值为:", a)
> >    a = a + 1
> > until( a > 15 )          ---等价于do..while
> > ```

#### 流程控制

> if语句
>
> ```lua
> if(布尔表达式)
> then
>    --[ 在布尔表达式为 true 时执行的语句 --]
> end
> ```
>
> if..else语句
>
> ```lua
> if(布尔表达式)
> then
>    --[ 布尔表达式为 true 时执行该语句块 --]
> else
>    --[ 布尔表达式为 false 时执行该语句块 --]
> end
> ```
>
> if嵌套语句
>
> ```lua
> if( 布尔表达式 1)
> then
>    --[ 布尔表达式 1 为 true 时执行该语句块 --]
>    if(布尔表达式 2)
>    then
>       --[ 布尔表达式 2 为 true 时执行该语句块 --]
>    end
> end
> ```

#### 函数

> 函数的定义
>
> ```lua
> optional_function_scope function function_name( argument1, argument2, argument3..., argumentn)
>  function_body
>  return result_params_comma_separated
> end
> --optional_function_scope 
> --该参数是可选的制定函数是全局函数还是局部函数，未设置该参数默认为全局函数，如果你需要设置函数为局部函数需要使用关键字 local。
> --local局部函数，未修饰-->默认为全局函数
> 
> 
> --result_params_comma_separated
> --可以返回多个值，每个值以逗号隔开
> 
> ```
>
> 函数作为参数传递
>
> ```lua
> myprint = function(param)
> print("这是打印函数 -   ##",param,"##")
> end
> --在定于函数的同时，将函数赋值给另外一个变量
> 
> 
> function add(num1,num2,functionPrint)---第三个参数为一个函数
> result = num1 + num2
> -- 调用传递的函数参数
> functionPrint(result)
> end
> -----定义一个add函数
> 
> 
> myprint(10)  --进行函数的调用
> -- myprint 函数作为参数传递
> add(2,5,myprint)---将函数作为参数进行传递
> 
> --------------------------------输出---------------------------------------
> 这是打印函数 -  ## 10 ##
> 这是打印函数 -  ## 7 ##
> ```
>
> 函数**返回多个参数**
>
> ```lua
> s, e = string.find("www.runoob.com", "runoob") --返回runoob开始和结束的位置，返回了两个数
> -----------------------------------------------------------------------
> function maximum (a)
>  local mi = 1             -- 最大值索引     第一个参数的索引
>  local m = a[mi]          -- 最大值        第一个参数的值
>  for i,val in ipairs(a) do
>     if val > m then                     -- 如果大于这个参数
>         mi = i
>         m = val                         --修改索引和参数
>     end
>  end
>  return m, mi                          --返回最大的索引的值 and 索引，使用逗号进行分隔
> end
> 
> print(maximum({8,10,23,12,5}))
> -----输出
> 23 3
> ```
>
> 函数中的**可变参数**-----表示函数接受的参数的个数不定
>
> ```lua
> function add(...)   --定义一个函数，接受的参数的个数不定
> local s = 0  
>   for i, v in ipairs{...} do   --> {...} 表示一个由所有变长参数构成的数组  ---取这一串可变参数进行操作
>     s = s + v  
>   end  
>   return s  
> end  
> print(add(3,4,5,6,7))  --->25
> 
> -----------------------------------实例2------------------------------------
> function average(...)
>    result = 0
>    local arg={...}    --> arg 为一个表，局部变量     ### 将这一串参数赋值给变量arg
>    for i,v in ipairs(arg) do
>       result = result + v
>    end
>    print("总共传入 " .. #arg .. " 个数")
>    return result/#arg    --求得平均值
> end
> 
> print("平均值为",average(10,5,3,4,5,6))
> -----------------------------------实例3------------------------------------
> function average(...)
>    result = 0
>    local arg={...}    --将传入的参数赋值给一个数组
>    for i,v in ipairs(arg) do
>       result = result + v
>    end                 --得到数组之和
>    print("总共传入 " .. select("#",...) .. " 个数")  --直接求的...的参数个数
>    return result/select("#",...)      ----select("#",...)获取参数的个数
> end
> 
> print("平均值为",average(10,5,3,4,5,6))
> 
> -----------------------------------tips------------------------------------
> select 函数的使用
> select("#",...)    --得到整个参数的长度 or 参数的个数
> select(n,...)      --得到第n个参数开始的剩余参数
> 
> 
> function f(...)
>     a = select(3,...)  -->从第三个位置开始，变量 a 对应右边变量列表的第一个参数，得到2 3 4 5 但是，进行多个参数的赋值时，左边的参数少，所以进行截断，a就只得到了一个值
>     print (a)
>     print (select(3,...)) -->打印所有列表参数
> end
> 
> f(0,1,2,3,4,5)
> ---输出结果
> 2
> 2       3       4       5
> ```
>
> 固定参数+可变参数
>
> ```lua
> function fwrite(fmt, ...)  ---> 固定的参数fmt
>     return io.write(string.format(fmt, ...))    --string.format进行字符串格式的转化，前面为转换的目标的，后面参数为需要进行转换的参数
> end
> 
> fwrite("runoob\n")       --->fmt = "runoob", 没有变长参数。  
> fwrite("%d%d\n", 1, 2)   --->fmt = "%d%d", 变长参数为 1 和 2
> 
> -----输出
> 12
> ```

#### 运算符

> 算术运算符
>
> > ^  幂乘
> >
> > // 整除
>
> 关系运算符
>
> > ~=  不等于
>
> 逻辑运算符
>
> > and  逻辑与
> >
> > or   或
> >
> > not 非
>
> 其他运算符
>
> > ..   连接两个字符串
> >
> > \# 返回字符串的长度

#### 字符串

> 字符串的定义
>
> > ```lua
> > string1 = "Lua"          --双引号定义
> > string2 = 'runoob.com'   --单引号定义
> > string3 = [["Lua 教程"]]  --[[]]定义    这样的定义方式可以保留""
> > ```
>
> 字符串操作
>
> > ```lua
> > string.upper(argument)    --字符串全部转换为大写
> > string.lower(argument)    --字符串全部转换为小写
> > 
> > string.gsub(mainString,findString,replaceString,num)    --进行字符串的替换
> > --mainString为需要操作的字符串
> > --findString为需要被替换的部分
> > --replaceString为替换目标
> > --num为重复次数   如果没有这个参数，则全部进行替换
> > ------------------------------------实例--------------------------------------
> > string.gsub("aaaa","a","z",3);
> > zzza    3   --替换之后的结果
> > 
> > 
> > string.find (str, substr, [init, [plain]])   --字符串的查找  []中的参数表示可选，可以不进行说明
> > --str为查找的域
> > --substr为需要查找的字符串
> > --init为搜索的起始位置，默认为1
> > --plain表示是否使用正则表达式的方式进行查找
> > --返回结果为字符串的起始位置和结束位置
> > ------------------------------------实例--------------------------------------
> > string.find("Hello Lua user", "Lua", 1)   --从第一个位置开始进行查找lua的起始位置和结束位置，不适用正则表达式的方式来进行匹配
> > 7    9
> > 
> > 
> > 
> > string.reverse(arg) ---字符串反转
> > 
> > string.format("the value is:%d",4)   --字符串给格式化，将4按照int类型来进行输出
> > 
> > string.char(arg)   --整型数据转换为字符，更具ascii码来进行转换
> > 
> > 
> > 
> > string.byte(arg[,int])  --将字符转换为整型
> > ------------------------------------实例------------------------------------
> > string.byte("ABCD",4) 68   --指定转换第4个字符
> > string.byte("ABCD")   65  --不指定转换的位置，转换第一个
> > 
> > 
> > 
> > string.len(arg)  --计算字符串的长度
> > 
> > string.rep(string, n)   --将字符串重复n次作为返回值
> > 
> > 
> > string.gmatch(str, pattern)  --返回的是一个迭代器函数，每次在str中往下找一个符合pattern要求的字符串
> > ------------------------------------实例------------------------------------
> > for word in string.gmatch("Hello Lua user", "%a+") do print(word) end
> > hello      --%a表示接受一个字符，  %a+表示接受多个字母，即一个单词
> > lua
> > user
> > 
> > 
> > string.match(str, pattern, init) --寻找字符串中第一个符合pattern的子字符串，init表示开始查找的位置
> > ------------------------------------实例1------------------------------------
> > string.match("I have 2 questions for you.", "%d+ %a+")  --匹配“数字 单词”模式
> > 2 questions
> > ------------------------------------实例2------------------------------------
> > string.format("%d, %q", string.match("I have 2 questions for you.", "(%d+) (%a+)"))
> > 2 "questions"     --%q表示将其转换为字符串
> > 
> > 
> > string.sub(s, i [, j])   --字符串截取
> > --s为需要截取的字符串
> > --i为开始截取的位置
> > --j为结束截取的位置，默认为-1  截取到末尾的位置
> > ------------------------------------实例1------------------------------------
> > -- 字符串
> > local sourcestr = "prefix--runoobgoogletaobao--suffix"
> > print("\n原始字符串", string.format("%q", sourcestr))-----"prefix--runoobgoogletaobao--suffix"
> > 
> > -- 截取部分，第4个到第15个
> > local first_sub = string.sub(sourcestr, 4, 15)
> > print("\n第一次截取", string.format("%q", first_sub))-----“prefix--runoob”
> > 
> > -- 取字符串前缀，第1个到第8个
> > local second_sub = string.sub(sourcestr, 1, 8)
> > print("\n第二次截取", string.format("%q", second_sub))----“prefix--”
> > 
> > -- 截取最后10个
> > local third_sub = string.sub(sourcestr, -10)
> > print("\n第三次截取", string.format("%q", third_sub))------“ao--suffix”  截取到数10个字符
> > 
> > -- 索引越界，输出原始字符串
> > local fourth_sub = string.sub(sourcestr, -100)    
> > print("\n第四次截取", string.format("%q", fourth_sub))------越界，不进行截取操作
> > 
> > ```

#### lua 数组

> 一维数组---数组的下标从1开始
>
> > ```lua
> > ------------------------------------实例1------------------------------------
> > array = {"Lua", "Tutorial"}     
> > for i= 0, 2 do
> >    print(array[i])
> > end
> > ----输出
> > nil
> > Lua
> > Tutorial
> > ------------------------------------实例2------------------------------------
> > array = {}
> > for i= -2, 2 do
> >    array[i] = i *2      array={-2=-4,-1=-2,0=0,1=2,2=4}
> > end
> > 
> > for i = -2,2 do
> >    print(array[i])     --数组的index可以为负数
> > end
> > ```
>
> 多维数组
>
> > ```lua
> > -- 初始化数组
> > array = {}
> > for i=1,3 do
> >    array[i] = {}                         --array[1]={1,2,3};
> >       for j=1,3 do                       --array[2]={2,4,6};
> >          array[i][j] = i*j               --array[3]={3,6,9};
> >       end
> > end
> > -- 访问数组
> > for i=1,3 do
> >    for j=1,3 do
> >       print(array[i][j])
> >    end
> > end
> > ```

#### 迭代器

> 泛型for迭代器
>
> > ```lua
> > array = {"Google", "Runoob"}
> > 
> > for key,value in ipairs(array)    --迭代函数 inpairs
> > do
> >    print(key, value)
> > end
> > ----执行步骤
> > --1、执行in后面的ipairs(array)语句，返回三个值：迭代函数，状态常量、控制变量
> > --2、使用状态常量和控制变量作为参数来调用迭代函数
> > --3、将迭代函数的返回值赋值给参数列表，如果第一个值为nil则结束循环
> > --4、回到第2不再次执行迭代函数
> > ```
>
> 无状态的迭代器
>
> > ```lua
> > function square(iteratorMaxCount,currentNumber)
> >    if currentNumber<iteratorMaxCount      --iteratorMaxCount为最大迭代次数
> >    then                                   --current为当前的数字
> >       currentNumber = currentNumber+1
> >    return currentNumber, currentNumber*currentNumber     --返回这个数，以及这个数的平方
> >    end
> > end
> > 
> > for i,n in square,3,0    --square为迭代函数   3为状态常量(迭代过程中不会该表的表)   0为控制变量（迭代过程中会改变的表） 迭代3次，从0开始迭代
> > do
> >    print(i,n)
> > end
> > 
> > --------------------------------------inpairs函数的实现----------------------------------
> > array = {"Google", "Runoob"}
> > function iter (a,i)
> >     i = i + 1
> >     local v = a[i]
> >     if v then
> >         print("in function iter")   
> >         return i, v
> >     end
> > end
> > 
> > function ipairs (array)
> >     return iter, array, 0
> > end
> > 
> > for i,v in ipairs(array)  --这个迭代函数会记住函数体中变量的值，所以下次再次运行时，得到的时
> > do 
> >     print(i,v)      
> > end
> > -----输出
> > in function iter   --输出了多次的in function iter   每次for循环调用了一次iter函数，迭代函数函数体中的变量的值被保存下来了
> > 1       Google
> > in function iter
> > 2       Runoob 
> > ```
>
> 多状态的迭代器
>
> > ```lua
> > array = {"Google", "Runoob"}
> > 
> > function elementIterator (collection)   --collection为需要进行迭代的集合
> >    local index = 0                      --索引index为0
> >    local count = #collection            --得到集合中元素的个数
> >    -- 闭包函数 ？？？？？
> >    return function ()
> >       index = index + 1
> >       if index <= count                 --如果当前的下标小于等于元素的个数
> >       then
> >          --  返回迭代器的当前元素
> >          return collection[index]
> >       end
> >    end
> > end
> > 
> > for element in elementIterator(array)  --打印数组中的所有元素
> > do
> >    print(element)
> > end
> > ```

#### table表

> table的创建
>
> > ```lua
> > -- 初始化表
> > mytable = {}
> > 
> > -- 指定值
> > mytable[1]= "Lua"
> > 
> > -- 移除引用
> > mytable = nil
> > -- lua 垃圾回收会释放内存
> > 
> > alternatetable = mytable  --进行表的复制，将一个表赋值为nil之后，另外一个表依然可以进行访问
> > 
> > local table1={}
> > local table2={hello="hello"}
> > local table={[1]=table,[2]=tabl2}
> > print(table)
> > print({table}) --形成一张新的表
> > print(table and {table})
> > local flag= table and {table1} or {}
> > print(flag)
> > --00AE7190  表示这张表不为空
> > local table3={}
> > print(table3)
> > ```
>
> table的操作
>
> > ```lua 
> > table.sort (table [, comp])    --给table排序，默认使用升序的方式来进行排序
> > 
> > 
> > 
> > table.remove (table [, pos])   --移除table中pos处以及之后的元素(保留pos之前的所有元素)，默认长度为表的长度（移除最后一个）
> > -------------------------------------实例1----------------------------------
> > t1={"valu1","valu2","valu3"};
> > table.remove(t1);   --移除了最后一个元素
> > for k,v in pairs(t1)
> > do
> >  print(v)
> > end
> > 
> > 
> > 
> > table.insert (table, [pos,] value)   --在table的数组部分指定位置(pos)插入值为value的一个元素. pos参数可选, 默认为数组部分末尾.
> > 
> > 
> > table.concat (table [, sep [, start [, end]]]) --表连接
> > --链接table中start到end位置之间的元素，中间使用sep作为分隔符
> > --如果没有start和end，则默认对全表进行连接
> > --如果没有指定sep，则之间进行连接
> > 
> > ```

#### 模块和包

> module模块--一个封装好的库，里面定义好一些标准的函数以及一些常用的常数
>
> module
>
> 是由变量、函数等已知元素组成的 table，因此创建一个模块很简单，就是创建一个 table，然后把需要导出的常量、函数放入其中，最后返回这个 table 就行
>
> > ```lua
> > -- 文件名为 module.lua
> > -- 定义一个名为 module 的模块
> > module = {}
> >  
> > -- 定义一个常量
> > module.constant = "这是一个常量"
> >  
> > -- 定义一个函数
> > function module.func1()
> >     io.write("这是一个公有函数！\n")
> > end
> >  
> > local function func2()     --定义的函数为内部函数，该函数不可以通过moudle.func2来进行调用
> >     print("这是一个私有函数！")
> > end
> >  
> > function module.func3()  --定义一个新的函数func3,这样外部可以进行使用
> >     func2()
> > end
> >  
> > return module
> > ```
>
> **require函数**----用于导入一个module
>
> > ```lua
> > -- test_module.lua 文件
> > -- module 模块为上文提到到 module.lua
> > require("module")
> >  
> > print(module.constant)
> >  
> > module.func3()
> > 
> > 
> > 
> > -- test_module2.lua 文件
> > -- module 模块为上文提到到 module.lua
> > -- 别名变量 m
> > local m = require("module")  --给加载的module重新命名，方便使用
> >  
> > print(m.constant)
> >  
> > m.func3()
> > 
> > ---------------------------------tips---------------------
> > lua进行module的加载时，实际加载的是一个文件，如果要准确的找到这个文件，需要准确的添加lua path
> > ```
>
> **包**
>
> > ```lua
> > local path = "/usr/local/lua/lib/libluasocket.so"   --指定文件名  so文件为linux下的共享库文件，即efl问价，该文件为二进制文件
> > local f = loadlib(path, "luaopen_socket")           --使用loadlib函数来加载该so文件中的初始化函数luaopen_socket
> > ```

#### metatable元表  ？？？没看懂  协同程序 、文件IO

> 元表--用于实现对表的操作
>
> 相当于一个表存在另外一个表，存在的这个另外的表叫做元表
>
> > ```lua
> > setmetatable(table,metatable)   ---给table设置元表
> > mytable = {}                          -- 普通表
> > mymetatable = {}                      -- 元表
> > setmetatable(mytable,mymetatable)     -- 把 mymetatable 设为 mytable 的元表
> > 
> > -------------------等价于--------------------
> > mytable = setmetatable({},{})  --传入两张表并给第一张表设置了元表，将设置之后的元表返回给mytable
> > 
> > getmetatable(mytable)                 -- 这会返回 mymetatable返回mytable中的metatable
> > ```
>
>  **__index元方法**
>
> > 查找表中的某个键时，如果该键不存在，就查找这个表的元表中的__index键,如果\__index建包含一个表，就在这个表中查找这个属性
>
> > ```lua
> > other = { foo = 3 }    ------定义一张表other
> > > t = setmetatable({}, { __index = other })  
> > ---定义一张表t,将另外一张表设为这张表的元表；
> > ---在另外一张表中，该表包含了一个__index属性，这个__index属性为一个表
> > 
> > 
> > 
> > > t.foo         --访问t.foo时，t表没有这个属性，然后__index包含一张表，这是使用__index中包含的other表来进行foo属性的访问
> > 3
> > > t.bar      --t表没有bar这个属性，other表也没有这个属性，这时返回nil
> > 
> > 
> > -------------------------------------实例1--------------------------------------
> > mytable = setmetatable({key1 = "value1"}, {   
> >   __index = function(mytable, key)
> >     if key == "key2" then
> >       return "metatablevalue"
> >     else
> >       return nil
> >     end
> >   end
> > })
> > 
> > print(mytable.key1,mytable.key2)
> > --给mytable设置一个属性  key1="value1"
> > --给mytable设置元表，在元表中存在__index属性，__index对应的是一个方法
> > --index=function
> > -------------------
> > 查找key1时，找到了，直接输出
> > 查找key2时，没有找到，调用__index,发现__index为一个方法，执行这个方法，该方法返回metatablevalue
> > ```
> >
> >   
>
> **__newindex方法**
>
> > ```
> > 
> > ```
> >
> > 



#### 错误处理

> ```lua
> --assert函数
> local function add(a,b)
>    assert(type(a) == "number", "a 不是一个数字")    --assert首先检查第一个参数是否为true,没有问题就不做多余的操作，如果为false,则将第二个参                                                   --数作为错误信息输出 
>    assert(type(b) == "number", "b 不是一个数字")
>    return a+b
> end
> add(10)
> 
> --error函数
> error (message [, level])  --终止正在执行的函数，并返回message信息作为错误信息  level用于指出在哪个位置给出错误信息
> --Level=1[默认]：为调用error位置(文件+行号)
> --Level=2：指出哪个调用error的函数的函数
> --Level=0:不添加错误位置信息
> 
> 
> 
> ---pcall函数
> if pcall(function_name, ….) then   --pcall 使用保护模式来执行一个函数，这样可以捕获函数运行过程中所有出现的错误，最后返回true or false表示
> -- 没有错误                         --这次的函数调用的过程有没有出现错误
> else
> -- 一些错误
> end
> ----------------------------------------实例1----------------------------------------
> =pcall(function(i) print(i) end, 33)   --定义一个匿名函数，并将33作为参数传递进去
> 33                                     --在匿名函数中打印出33这个数
> true                                   --pcall函数结束，这个函数的运行没有出错，返回true
> 
> ----------------------------------------实例2----------------------------------------
> =pcall(function(i) print(i) error('error..') end, 33)  
> 33                     
> false        stdin:1: error..     --函数运行过程中出现了error表示这个function函数运行出错，所以返回的值为false
> 
> 
> 
> ---xpcall
> ----pcall得到了出现错误的位置信息，但是没有得到所有的调试信息，因为pcall返回的时候，已经消除了function函数的堆栈，所以没有保留有效的调试信息
> ----因此 出现了xpcall
> xpcall(firstFunctionName,handleFunctionName, parameter)
> --第一个function为调用的function
> --第二个function为错误处理函数
> --最后为第一个function函数的参数
> 
> 
> ----------------------------------------实例1----------------------------------------
> =xpcall(function(i) print(i) error('error..') end, function() print(debug.traceback()) end, 33)
> 33                                 --function函数中输出这个参数
> stack traceback:                   --遇到error函数，表示function函数调用失败
> stdin:1: in function <stdin:1>     --然后调用debug.traceback()函数来进行堆栈信息的打印
> [C]: in function 'error'
> stdin:1: in function <stdin:1>
> [C]: in function 'xpcall'
> stdin:1: in main chunk
> [C]: in ?
> false        nil
>                 
>  ----------------------------------------实例2----------------------------------------
> function myfunction ()
>    n = n/nil
> end
> 
> function myerrorhandler( err )
>    print( "ERROR:", err )
> end
> 
> status = xpcall( myfunction, myerrorhandler )
> print( status)
> ---输出
> ERROR:    test2.lua:2: attempt to perform arithmetic on global 'n' (a nil value)
> false
> ```

#### debug调试

> ```lua
> function myfunction ()
> print(debug.traceback("Stack trace"))   -- debug.traceback()没有message参数时，返回堆栈信息，有message时，输出message信息
> print(debug.getinfo(1))                 -- debug.getinfo() 
> print("Stack trace end")
>         return 10
> end
> myfunction ()
> print(debug.getinfo(1))
> 
> --输出
> Stack trace
> stack traceback:
>     test2.lua:2: in function 'myfunction'
>     test2.lua:8: in main chunk
>     [C]: ?
> table: 0054C6C8
> Stack trace end
> 
> --debug.getinfo() 
> --返回关于一个函数信息的表。 你可以直接提供该函数， 也可以用一个数字 f 表示该函数。 数字 f 表示运行在指定线程的调用栈对应层次上的函数： 
> --0 层表示当前函数（getinfo 自身）； 
> --1 层表示调用 getinfo 的函数 （除非是尾调用，这种情况不计入栈）；等等。 如果 f 是一个比活动函数数量还大的数字， getinfo 返回 nil
> 
> 
> 
> ----debug.setupvalue()  --设置一个变量的值
> function newCounter ()   --定义一个newCounter函数   
>   local n = 0
>   local k = 0
>   return function ()    --使用闭包来保存n的值，每次调用n的值都加1，实现计数器的方法
>     k = n
>     n = n + 1
>     return n
>     end
> end
> 
> counter = newCounter ()
> print(counter())      ---1
> print(counter())      ---2
> 
> local i = 1
> 
> repeat   -- 
>   name, val = debug.getupvalue(counter, i)    ---返回counter函数的第1个upvalue的名字和值，
>   if name then
>     print ("index", i, name, "=", val)       ---index 1 k = 1
>         if(name == "n") then
>                 debug.setupvalue (counter,2,10)
>         end
>     i = i + 1
>   end -- if
> until not name  --当name为false时退出循环
> 
> print(counter())
> ----输出
> 1
> 2
> index    1    k    =    1
> index    2    n    =    2
> 11
> ---getupvalue (f, up)
> --此函数返回函数 f 的第 up 个上值的名字和值。 如果该函数没有那个上值，返回 nil 。
> --以 '(' （开括号）打头的变量名表示没有名字的变量 （去除了调试信息的代码块）。
> ```
>
> 

#### 垃圾回收  ？暂时不看

#### 面向对象

> **使用table来描述类的属性**--table为引用类型
>
> **使用function来描述方法**
>
> **table+function==类(面向对象)**
>
> > ```lua
> > Account = {balance = 0}           --使用表Account来存放属性
> > function Account.withdraw (v)     --使用函数Account.withdraw函数来操作Account中的属性    这里Account就变成了一个对象
> >     Account.balance = Account.balance - v
> > end
> > ```
>
> **类的定义**
>
> > ```lua
> > -----------------------------定义1-----------------------------------
> > person={name="feitan",age=23}
> > person.eat=function()                 --使用匿名函数赋值的方式来定义函数
> >     print(person.name.." are eating")
> > end
> > person.eat()
> > -----------------------------定义2-----------------------------------
> > person={name="feitan",age=23}
> > function person.eat()                
> >     print(person.name.." are eating")         --使用直接定义的方式来定义函数
> > end
> > person.eat()
> > -----------------------------定义3-----------------------------------
> > person={name="feitan",age=23,eat=function()print("feitan are eating") end}   --function也是一种数据类型
> > person.eat()
> > 
> > 
> > ----------------------------存在的问题-----------------------------
> > --问题1：上述方法实现的是一个对象，而不是一个方法，这样需要对person需要重复定义
> > --问题2：
> > person={name="feitan",age=23}
> > person.eat=function()                 
> >     print(person.name.." are eating")
> > end
> > person.eat()
> > a=person
> > person=nil
> > a.eat()    --会出现报错，因为在function中，使用的是person来访问这个属性
> > 
> > 
> > 
> > ------------------------问题2的解决方案1-----------------------
> > person={name="feitan",age=23}
> > person.eat=function(self)                 
> >     print(self.name.." are eating")
> > end
> > person.eat(person)
> > a=person
> > person=nil
> > a.eat(a)     --在进行函数的调用时，将自身作为变量进行从传递，这样调用不会出错-----调用起来比较麻烦
> > 
> > -----------------------问题2的解决方法2-----------------------
> > person={name="feitan",age=23}
> > function person:eat()                   
> >     print(self.name.." are eating")
> > end
> > person:eat()
> > a=person
> > a:eat()
> > --使用:来进行函数的定义时，可以直接在内部使用self，不需要进行参数的传递  --self为调用者
> > 
> > --通过:来进行调用，self可以自动赋值、
> > --通过.来进行调用，self需要手动赋值，必须通过第一个参数来进行赋值
> > 
> > 
> > ---------------------------问题1的解决方法---------------------------
> > Person={name="feitan",age=23}           --定义Person原型
> > function Person:eat()                   
> >     print(self.name.." are eating")
> > end
> > function Person:new()
> >     t={}                --创建一个新的空表
> >     setmetatable(t,{__index=self})  --设置t的元表，t的元表为一个空表{}   
> >                                     --调用一个属性时，如果t中不存在,那么会在__index所指定的table中查找
> >     return t            --t为我们构造出来的对象，将t返回即可
> > end
> > person1=Person:new()    --进程对象的构建
> > print(person1.name)
> > person2=Person:new()    --person1、person2中的元表的__index属性指向的也是Person
> > 
> > person1.name="feitan2"   --这时新设置的属性会添加到person1中，它和元表中的name属性同时存在，只是访问的时候只访问这个属性
> > ```
> >
> > ```lua
> > Person={name="feitan",age=23}          
> > function Person:eat()                   
> >     print(self.name.." are eating")
> > end
> > function Person:new(o)    --o为一个传入的表，
> >     t=o or {}             --当o表存在时，将o表赋值给t表，   
> >     setmetatable(t,{__index=self})    --在t表的基础上再加上元表的属性
> >     return t            
> > end
> > person1=Person:new({weight=65})  --####在元表的基础上，实现属性的添加
> > person2=Person:new(nil)          --####直接得到一个元表
> > print(person1.weight)
> > ```
> >
> > 
> >
> > ```lua
> > -- 元类
> > Rectangle = {area = 0, length = 0, breadth = 0}    --定义了一个Rectangle类，存在三个属性
> > 
> > -- 派生类的方法 new
> > function Rectangle:new (o,length,breadth)
> > t = o or {}
> >     
> > setmetatable(t, self)    --将self设置为t的元表
> > self.__index = self      --将t的元表的__index属性设置为self,实现__index属性为一个表      
> > --等价于setmetatable(t,{__index=self})
> >     
> > self.length = length or 0        --初始化属性
> > self.breadth = breadth or 0      --初始化属性
> > self.area = length*breadth;      --初始化属性                                                                                                                                                                                                                                                                                                                                  
> > return t
> > end
> > 
> > -- 派生类的方法 printArea
> > function Rectangle:printArea ()
> > print("矩形面积为 ",self.area)
> > end
> > ```
> >
> > ```lua
> > -- 元类
> > Shape = {area = 0}
> > 
> > -- 基础类方法 new
> > function Shape:new (o,side)
> >   t = o or {}            --创建一张表
> >   setmetatable(t, self)  --给这张表设置元表
> >   self.__index = self    --将元表的__index属性设置为一张表
> >   side = side or 0       --带参数的构造函数
> >   self.area = side*side; --初始化
> >   return t
> > end
> > 
> > -- 基础类方法 printArea
> > function Shape:printArea ()    --使用：来定义函数
> >   print("面积为 ",self.area)    --之间之后sefl来访问这个对象的area属性
> > end
> > 
> > -- 创建对象
> > myshape = Shape:new(nil,10)   --创建一个实例
> > 
> > myshape:printArea()           --进行函数的调用
> > ```
>
> **继承**
>
> > ```lua
> > -- Meta class
> > Shape = {area = 0}               --初始化基础类
> > -- 基础类方法 new
> > function Shape:new (o,side)      --定义构造函数
> >   local t = o or {}
> >   setmetatable(t, self)          --设置元表 
> >   self.__index = self            --设置元表的__index属性为一张表
> >   side = side or 0
> >   self.area = side*side;         --初始化面积，面积=边长*边长
> >   return t
> > end
> > -- 基础类方法 printArea
> > function Shape:printArea ()     --定义输出方法
> >   print("面积为 ",self.area)
> > end
> > ------上面 完成了Shape类的定义
> > 
> > Square = Shape:new()
> > -- Derived class method new
> > function Square:new (o,side)
> >   o = o or Shape:new(o,side)
> >   setmetatable(o, self)
> >   self.__index = self
> >   return o
> > end
> > ```
> >
> > ```lua
> > -- Meta class
> > Shape = {area = 0}
> > -- 基础类方法 new
> > function Shape:new (o,side)    ---基础类的构造函数，只有一个area属性
> >   o = o or {}
> >   setmetatable(o, self)
> >   self.__index = self
> >   side = side or 0
> >   self.area = side*side;
> >   return o
> > end
> > -- 基础类方法 printArea        --基础类的输出方法，输出面积
> > function Shape:printArea ()
> >   print("面积为 ",self.area)
> > end
> > 
> > -- 创建对象
> > myshape = Shape:new(nil,10)    --使用基础类的构造函数来创建对象
> > myshape:printArea()            --使用基础了的输出函数来输出对象的属性
> > 
> > 
> > 
> > 
> > 
> > Square = Shape:new()             ---####继承
> > -- 派生类方法 new
> > function Square:new (o,side)    --派生类对构造函数进行重写
> >   t = o or Shape:new(o,side)
> >   setmetatable(t, self)
> >   self.__index = self
> >   return t
> > end
> > 
> > -- 派生类方法 printArea
> > function Square:printArea ()    --派生类对输出函数进行重写
> >   print("正方形面积为 ",self.area)
> > end
> > 
> > -- 创建对象
> > mysquare = Square:new(nil,10)   --使用派生类的构造函数来创建对象
> > mysquare:printArea()            --使用派生类的输出方法来进行属性的输出
> > 
> > Rectangle = Shape:new()         --####继承
> > -- 派生类方法 new
> > function Rectangle:new (o,length,breadth)     --派生类重写构造函数
> >   o = o or Shape:new(o)
> >   setmetatable(o, self)
> >   self.__index = self
> >   self.area = length * breadth
> >   return o
> > end
> > 
> > -- 派生类方法 printArea
> > function Rectangle:printArea ()           --派生类重写输出函数
> >   print("矩形面积为 ",self.area)
> > end
> > 
> > -- 创建对象
> > myrectangle = Rectangle:new(nil,10,20)     --使用派生类的构造函数来创建对象
> > myrectangle:printArea()                    --使用派生类的输出函数来输出属性
> > ```
> >
> > ```lua
> > Person ={name="feitan",age=22}               --基础类  Person
> > function Person:info()
> >     print("name="..self.name)
> >     print(self.name.." age is "..self.age)
> > end
> > function Person:new(o)
> >     local t=0 or {}
> >     setmetatable(t,self)
> >     self.__index=self
> >     return t
> > end
> > 
> > Student = Person:new()              
> > 
> > 
> > ```

#### class类的实现

>```lua
>-- 声明一个 lua class
>-- className 是类名
>-- super 为父类
>local function class(className, super)
>-- 构建类
>local clazz = { __cname = className, super = super }
>if super then
>-- 设置类的元表，此类中没有的，可以查找父类是否含有
>setmetatable(clazz, { __index = super })   --将父类设置为自己的元表
>end
>-- new 方法创建类对象
>clazz.new = function(...)
>-- 构造一个对象
>   local instance = {}
>-- 设置对象的元表为当前类，这样，对象就可以调用当前类生命的方法了
>  setmetatable(instance, { __index = clazz })
>  if clazz.ctor then
>    clazz.ctor(instance, ...)
>  end
>  return instance
>end
>return clazz
>end
>--------------------------------------------------------------------------------------
>--构造feitan类，feitan类继承于people类
>Feitan=class(feitan,people) --经过class函数之后 Feitan有了clazz的所有参数
>----
>--结果Feitan=clazz
>clazz={_cname="feitan",super=super}
>clazz.__index=super
>clazz.new() = function
>
>a=Feitan.new()
>-----结果
>a=instance
>instance={}
>instance.__index=clazz
>instance.new()
>--
>--访问a.h属性是，instance中本身没有，访问clazz.h属性。
>--所以实现了访问a.h时访问的是Feitan这个类中定义的属性
>--如果instance中没有这个属性，就访问instance.__index即clazz这个属性，但是clazz中本身没有，所以访问的是clazz.__index即super这个参数的属性。所
>--以访问到了super类中的属性，
>--总结：
>--从子类进行调用，如果子类中有这个属性就访问子类中的这个属性如果子类中没有这个属性，那么访问的就是基类中的这个属性。
>--如果子类中没有这个属性，基类中有这个属性。从子类访问这个属性的话，访问的就是基类的属性
>--如果子类中没有这个属性，基类中有这个属性。从基类访问这个属性的话，访问的还是基类的属性
>--如果子类中有这个属性，基类中有这个属性，
>    
>    
>------------------------------------------
>local class = require("app.window.activity.ActivityRepairMission")
>local content = class.new(self.groupContent.gameObject,{id=id,tupe=type},self)
>--在new方法中，ctor方法通过.调用的方式来进行调用
>--content={}
>--content.__index=ActivityRepairMission
>--ActivityRepairMission.__index=ActivityContent
>--ActivityContent.__index=BaseComponent
>
>--在ActivityRepairMission  ActivityContent  BaseComponent中
>--self为同一个，就是content参数
>```
>

#### loadfile require  import 

> loadfile ----加载的是lua文件
>
> require --- 加载的module模块，不加载文件
>
> ```lua
> local table1={
> ["1"]={1,141,20,"hello",1},
> ["10"]={10，142，30，“world",3},
> ["11"]={11，145，40，“test",4}
> }
> 
> print(table1)
> ```
>

#### os.time()

> https://www.lua.org/pil/22.1.html
>
> 1、不传入参数时，返回一个number,这个number表示当前时间距离 `1970年1月1日0点0秒` 经过的秒数。不同时区的计算机获得的时间不同。例如格林威治时间`西三区`的电脑,传入参数`1970年1月1日0点0秒`时，得到的秒数为18000秒。北京时间为`东八区`传入参数得到的时间为-28800秒。
>
> 2、使用table传入参数，返回一个number,这个number表示table中的时间距离`1970年1月1日0点0秒`经过的秒数
>
> ```lua
> print(os.time())   --打印的是当前时间
> print(os.time{year=1970, month=1, day=1, hour=0, sec=1})  
> print(os.time{year=1970, month=1, day=1})--前三个参数必须指定  后面的参数如果不指定就默认为12点
> --14400   12*60*60+（-8*60*60）=14400  北京时间为东八区
> 
> print(os.time{year=1970, month=1, day=1, hour=8})   -- 快8个小时  
> --输出0
> --北京时间8点时， 格林威治时间为0点
> --即北京时间的起点为8点
> print(os.time{year=1970, month=1, day=1, hour=0})
> -- （-28800）
> ```
>
> 3、`xyd.getServerTime()=xyd.Global.serverDeltaTime+os.tiem()`
>
> 4、`xyd.Global.serverDeltaTime` 后端返回的时间，应该是根据时区计算所得

#### os.date()

> ```lua
> temp = os.date("*t", 906000490)
> --{year = 1998, month = 9, day = 16, yday = 259, wday = 4,
> --hour = 23, min = 48, sec = 10, isdst = false
> 
> --返回的时间和时区相关
> local tb=os.date("*t", 0)  --0表示起点，北京时间的起点为8点
> print(tb.year)
> print(tb.month)
> print(tb.day)
> print(tb.hour)
> print(tb.min)
> --1970
> --1
> --1
> --8   --比世界时间快8个小时
> --0
> 
> --返回的时间和时区没有关系
> local tb=os.date("!*t", 0)
> print(tb.year)
> print(tb.month)
> print(tb.day)
> print(tb.hour)
> print(tb.min)
> --1970
> --1
> --1
> --0
> --0
> ```
>
> 1、第一个参数*t表示我们需要的数据类型，这里表示需要table类型，第二个参数为需要转换的秒数。
>
> 2、`temp = os.date("*t", 0)`返回当前时区的起点时间，北京时间的起点时间为8点