/*


    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear

*   简介：测试MAF，这段代码是定义插件端的视图类，该视图类的方法和属性必须与协定一致。

 */

using System.AddIn.Pipeline;

namespace AddinSideView
{
    [AddInBase()]
    public interface AddinSideView
    {
        string Say();
    }
}

