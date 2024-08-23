using MeonMark.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeonMark.ViewModels
{
    public class TodoItemDetailsViewModel : BaseViewModel
    {
        public TodoItemDetailsViewModel( ITodoItemRepository repository )
        {
            _repository = repository;
        }

        private readonly ITodoItemRepository _repository;
    }
}
