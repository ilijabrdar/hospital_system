using System;
using System.Windows.Forms;



namespace upravnikKT2
{
    class MyTabControl : TabControl
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Tab | Keys.Control) ||
                e.KeyData == (Keys.PageDown | Keys.Control))
            {
                // Don't allow tabbing beyond last page
                if (this.SelectedIndex == this.TabCount - 1) return;
            }
            base.OnKeyDown(e);
        }
    }
}