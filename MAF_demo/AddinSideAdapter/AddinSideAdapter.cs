/*


    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear

*   简介：测试MAF，这段代码是插件端的适配器类，它用来实现插件端视图类。
 *         并组合协定。这样就能让插件和协定解耦，如果插件有所修改就换掉
 *         该适配器类就可以了。
 */

using System.AddIn.Pipeline;


namespace AddinSideAdapter
{

    [AddInAdapter]
    public class AddinSideAdapter : ContractBase, IContract.IMyContract
    {
        private AddinSideView.AddinSideView _handler;

        public AddinSideAdapter(AddinSideView.AddinSideView handler)
        {
            this._handler = handler;
        }

        public string Say()
        {
            return this._handler.Say();
        }
    }
}


