
namespace timeFairy
{
    /// <summary>
    /// 委托来构造回调函数，在子窗口关闭时传值给父窗口
    /// </summary>
    public class DelegateClass
    {
        public delegate void delegateTime(double m,Thing thing);
        public delegate void delegateThing(Thing thing);
    }
}
