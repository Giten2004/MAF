/*


    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear

     简介：测试MAF，这段代码是定义协定。

 */



using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



using System.AddIn.Pipeline;

using System.AddIn.Contract;



namespace IContract
{

    [AddInContract]
    public interface IMyContract : System.AddIn.Contract.IContract
    {

        string Say();

    }

}


