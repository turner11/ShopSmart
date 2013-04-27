using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShopSmart.Common;

namespace ShopSmart.Client
{
    /// <summary>
    /// The GUI for client side
    /// </summary>
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            this.SetIcon();
        }

        private void SetIcon()
        {
            //System.Resources.ResourceManager resources =
            //                        new System.Resources.ResourceManager(typeof(Utils));

            //this.Icon = (Icon)resources.GetObject("Clock");
        }
    }
}
