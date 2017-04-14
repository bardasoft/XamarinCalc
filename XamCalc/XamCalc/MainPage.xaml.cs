using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamCalc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new CalcViewModel();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(button==null)return;

            var key = button.Text;

            var vm = this.BindingContext as CalcViewModel;
            vm?.KeyCommand.Execute(key);
        }
    }
}
