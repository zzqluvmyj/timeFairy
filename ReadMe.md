# 时间精灵

## 1.概述

“时间精灵”是一个使用WPF开发的一个事件待办记录桌面应用程序，具体如下：

> 使用WPF技术开发，其中使用了数据绑定，资源绑定，动画，触发器，接口，类，事件处理，委托，异步事件，数据实例化，异常处理等。

> 主界面为时钟，可打开菜单窗口，内含待办添加，待办编辑，待办删除，待办记录，记录查看，记录可视化等功能，并且提供了自动的文件读取和保存功能。

> 该程序能够帮助使用者养成好的时间管理习惯，并且能够记录相对应的事件的实际情况，通过多样化的记录可视化方式来了解自己的日常时间安排情况，让使用者能够加强自己的日程安排管理能力。

> 该程序可处理一定程度的异常情况，有一定的健壮性。

## 2.类设计

(1) **MainWindow.xaml.cs**

​				时钟后台类，用于对前台所画的UI界面的时钟指针和用于显示日期和时间的Label进行操作，以便让时钟可以显示即时日期和时间。

​      主要逻辑代码如下：

 private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)

​         {

​            //UI异步更新

​             this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>

​             {

​                 //秒针转动,秒针绕一圈360度，共60秒，所以1秒转动6度

​                 secondPointer.Angle = DateTime.Now.Second* 6;

​                 //分针转动,分针绕一圈360度，共60分，所以1分转动6度

​                 minutePointer.Angle = DateTime.Now.Minute* 6;

​                 //时针转动,时针绕一圈360度，共12时，所以1时转动30度。

​                 //另外同一个小时内，随着分钟数的变化(绕一圈60分钟），时针也在缓慢变化（转动30度，30/60=0.5)

​                 hourPointer.Angle = (DateTime.Now.Hour* 30)+ (DateTime.Now.Minute* 0.5);

​                 //更新时间值

​                 this.mytime.Content = DateTime.Now.ToString("HH:mm");

​                 this.mydate.Content = DateTime.Now.ToString("d");

​             }));

​         }

并且对应于前台界面的两个Button，有两个事件，分别用于打开菜单窗口和退出应用程序。

(2) **MenuWindow.xaml.cs**

菜单界面后台类，包含事件，记录，绘图三大功能块。

该类中首先声明了ViewModel viewModel = new ViewModel();作为从文件中读到的数据集合的存储区域。

开始初始化界面后，该类将读入事件集和记录集到viewModel中，以便显示到界面上。

由于每次打开点击菜单都会新建窗口，为了解决这个问题，为了在用户关闭窗口时自动保存内容到文件，重写了OnClosing（）函数。

该类中的后台方法有：Edit_Click(),Remove_Click(),Record_Click(),Draw_Click(),DrawMonth(),DrawDay()等，分别用于编辑待办项，移除待办项，记录待办项，该月情况图，该日情况图等，其他主要是一些为了协助这些函数的功能而增加的函数。

以上方法中很多都添加了一些错误处理机制。

(3) **AddThing.xaml.cs**

添加待办事件窗口的后台类，主要作用是将新生成的Thing的对象thing通过委托函数传值给MenuWindow.xaml.cs，以便添加新的事件。

(4) **ChangeThing.xaml.cs**

改变选中的待办事件的后台类，主要作用是将选中的项进行修改，该类通过DataContext接收到选中项，并且通过该类修改该值来改变选中项，在MenuWindow.xaml.cs中保存有选中项的深拷贝，以便在使用者撤销操作的时候恢复原有值。

(5) **DelegateClass.cs**

委托函数类，声明了两个委托函数，分别用于AddThing.xaml.cs返回thing和用于Recorder.xaml.cs返回记录的时间。

(6) **DrawPre.cs**

绘图准备类，用于将记录列表转换为可供画图模块调用的列表，主要包含了ClearUp(),getLabel(),GetShapes()等，分别用于清空列表，得到图例，得到扇形等。

(7) **FileMethod.cs**

文件操作类，里面都是用于读取文件和保存文件的函数，采用的二进制序列化和反序列化来保存文件和读出文件。

(8) **Note.cs**

记录类，该类的每个实例都对应着一个记录，因为要保存该类，所以添加[Serializable]，并且为了在绑定后能够动态的更新该值，实现了该类的InotifyPropertyChanged接口。每当对象的Properties改变时，通过Notify()函数来通知.Net的后台托管来更新值。其中因为在实现接口时新加的属性PropertyChanged不可被实例化，所以加这个标志来避免被实例化，防止出错。

(9) **PieChart.cs**

饼图的绘制类。

(10) **RingPart.cs**

圆环的绘制类。

(11) **Recorder.x****aml.****cs**

用于记录窗口的后台类，是一个提供了开始，暂停，结束，完成，返回功能的计时器。

(12) **Sector****P****art.cs**

扇形的绘制类。

(13) **Thing.cs**

事件类，该类的每个实例都对应着一个事件，因为要保存该类，所以添加[Serializable]，并且为了在绑定后能够动态的更新该值，实现了该类的InotifyPropertyChanged接口。每当对象的Properties改变时，通过Notify()函数来通知.Net的后台托管来更新值。也实现了Icloneable接口，声明了通过文件序列化而实现的深拷贝方法DeepClono()。其中因为在实现接口时新加的属性PropertyChanged不可被实例化，所以加这个标志来避免被实例化，防止出错。

​			**（1****4****）ViewModel.cs**

该类有两个ObservableCollection列表，如下所示：

private ObservableCollection<Thing> thingsList;

private ObservableCollection<Note> notesList;

保存着从文件中提出来得事件列表和记录列表。

该类实现了InotifyPropertyChanged接口，以便在整个列表变化的时候能够通知后台将整个列表的值加以自动更新。

## 3.现有bug

- 不能画超过180度的扇形。原因：画扇形的类我是copy别人的，不想去看了，反正不是我的锅，暂时也没改的动力。
- 相同事件的不同记录的判断标准是事件的名称，本来是事件的id和名称，后来出了bug，于是改为了由事件的名称判定多个记录是否是同一事件。暂时没有解决的该问题的动力

