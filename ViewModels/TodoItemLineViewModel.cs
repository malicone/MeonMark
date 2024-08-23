using CommunityToolkit.Mvvm.ComponentModel;
using MeonMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeonMark.ViewModels
{
    public partial class TodoItemLineViewModel : BaseViewModel
    {
        public TodoItemLineViewModel( TodoItem item )
        {
            Item = item;
        }

        public event EventHandler? ItemStatusChanged;

        [ObservableProperty]
        TodoItem? item;

        public string StatusText => Item?.Completed == true ? "Reactivate" : "Completed";
    }
}
