using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestKayakNancy.Properties;
using System.Diagnostics;

namespace TestKayakNancy
{
    public class ApplicationIcon : ApplicationContext
    {
        private NotifyIcon notifyIcon;

        public ApplicationIcon()
        {
            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.Icon = Resource.favicon;
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);

            var menu = new ContextMenuStrip();
            var openMenu = menu.Items.Add("Open");
            openMenu.Click += new EventHandler(openMenu_Click);
            var closeMenu = menu.Items.Add("Close");
            closeMenu.Click += new EventHandler(closeMenu_Click);

            this.notifyIcon.ContextMenuStrip = menu;
        }

        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("http://localhost:8445");
        }

        void closeMenu_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        void openMenu_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost:8445");
        }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            base.OnMainFormClosed(sender, e);
        }
    }
}
