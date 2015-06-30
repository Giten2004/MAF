/*


    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear

     简介：测试MAF，这段代码是定义协定。

 */


using System.AddIn.Pipeline;

namespace IContract
{
    [AddInContract]
    public interface IMyContract : System.AddIn.Contract.IContract
    {
        string Say();
    }
}