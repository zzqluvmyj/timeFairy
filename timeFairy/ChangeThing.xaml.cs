﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace timeFairy
{
    /// <summary>
    /// ChangeThing.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeThing : Window
    {
        private Thing thing;
        public DelegateClass.delegateThing CallBackThing;
        public ChangeThing()
        {
            InitializeComponent();
            thing = new Thing();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            thing.Name = name.Text;
            thing.Kind = kind.Text;
            thing.Priority = priority.Text;
            thing.StartTime = Convert.ToDateTime(starttime.Text);
            thing.Etc = etc.Text;
            thing.EndTime= Convert.ToDateTime(endtime.Text);

            CallBackThing(thing);
            Close();
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
