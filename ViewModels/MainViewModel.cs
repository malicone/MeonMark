using MeonMark.Models;
using MeonMark.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeonMark.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel( ITodoItemRepository todoItemRepository )
        {
            _todoItemRepository = todoItemRepository;
            Task.Run( async () => await LoadDataAsync() );
        }

        public async Task LoadDataAsync()
        {
            await Task.Delay(10);
        }

        private readonly ITodoItemRepository _todoItemRepository;
    }
}
