﻿using EkushApp.ShellService.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SBMS.View
{
    /// <summary>
    /// Interaction logic for BbCircularOperationView.xaml
    /// </summary>
    /// 
    [Export(typeof(IBbCircularOperationView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class BbCircularOperationView : UserControlBase, IBbCircularOperationView
    {
        public BbCircularOperationView()
        {
            InitializeComponent();
        }
    }
    public interface IBbCircularOperationView : IView { }
}
