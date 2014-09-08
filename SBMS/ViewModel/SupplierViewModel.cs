﻿using EkushApp.ShellService.MVVM;
using SBMS.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SupplierViewModel : ViewModelBase
    {
        public string Tag { get { return "Supplier"; } }
        #region Constructor(s)
        [ImportingConstructor]
        public SupplierViewModel(ISupplierView view)
        {
            View = view;
            View.ViewModel = this;
        }
        #endregion

        #region ViewModelBase
        public override void OnLoad()
        {
        }

        public override void OnClosing()
        {
            this.Dispose();
        }
        #endregion
    }
}
