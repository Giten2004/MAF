/*

    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear
    简介：测试MAF，这段代码用来定义宿主端的适配器类。该类实现宿主端的
    视图类并组合协定。

 */



using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



using System.AddIn.Pipeline;

namespace HostSideAdapter
{

    [HostAdapter()]
    public class HostSideAdapter : HostSideView.HostSideView
    {
        private IContract.IMyContract _contract;
        
        //这行代码重要
        private System.AddIn.Pipeline.ContractHandle _handle;

        public HostSideAdapter(IContract.IMyContract contract)
        {
            this._contract = contract;

            this._handle = new ContractHandle(contract);
        }

        public string Say()
        {
            return this._contract.Say();
        }
    }

}


