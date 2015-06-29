/*


    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear

    简介：测试MAF，这段代码用来定义宿主段的视图类，该类的所有方法和属性需与协定类一致。

 */

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



namespace HostSideView
{

    public interface HostSideView
    {
        string Say();
    }
}

