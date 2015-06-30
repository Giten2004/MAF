/*


    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear
    简介：测试MAF，这段代码是用来定义一个插件的。这个插件可以在宿主程序
     中动态加载。

 */

using System.AddIn;

namespace Addin_1
{
    [AddIn("Helloworld", Description = "this is helloworld addin", Publisher = "GhostBear", Version = "1.0")]
    public class Addin_1 : AddinSideView.AddinSideView
    {
        public string Say()
        {
            return "Helloworld";
        }
    }
}