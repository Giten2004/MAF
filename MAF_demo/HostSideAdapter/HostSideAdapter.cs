/*

    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear
    简介：测试MAF，这段代码用来定义宿主端的适配器类。该类实现宿主端的
    视图类并组合协定。

 */


using System.AddIn.Pipeline;
using IContract;

namespace HostSideAdapter
{
    [HostAdapter]
    public class HostSideAdapter : HostSideView.HostSideView
    {
        //这行代码重要
        private ContractHandle _handle;
        private readonly IMyContract _contract;

        public HostSideAdapter(IMyContract contract)
        {
            _contract = contract;

            _handle = new ContractHandle(contract);
        }

        public string Say()
        {
            return _contract.Say();
        }
    }
}