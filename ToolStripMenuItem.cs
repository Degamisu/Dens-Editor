
namespace Dens_Editor
{
    internal class ToolStripMenuItem
    {
        internal object DropDownItems;
        private string v;

        public ToolStripMenuItem(string v)
        {
            this.v = v;
        }

        public Action<object, EventArgs> Click { get; internal set; }
    }
}