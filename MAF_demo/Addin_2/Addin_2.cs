/*
    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear
*/

using System.AddIn;

namespace Addin_2
{
    [AddIn("SuperBomb", Description = "This is a bigger bomb"
        , Publisher = "SuperWorker", Version = "1.0.0.0")]
    public class Addin_2 : AddinSideView.AddinSideView
    {
        public string Say()
        {
            return "B--O--M--B";
        }
    }
}