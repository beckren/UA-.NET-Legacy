/* Copyright (c) 1996-2016, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using Opc.Ua.Gds;

namespace Opc.Ua.Gds
{
    public partial class SelectServerDialog : Form
    {
        public SelectServerDialog()
        {
            InitializeComponent();
            Icon = ConfigUtils.GetAppIcon();
        }

        public EndpointDescription ShowDialog(
            IWin32Window owner,
            ConfiguredEndpointCollection endpoints,
            LocalDiscoveryServer lds,
            GlobalDiscoveryServer gds,
            QueryServersFilter filters)
        {
            DiscoveryControl.Initialize(endpoints, lds, gds, filters);

            if (base.ShowDialog(owner) != System.Windows.Forms.DialogResult.OK)
            {
                return null;
            }

            return DiscoveryControl.SelectedEndpoint;
        }
    }
}
