using MeonMark.Models;
using MeonMark.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeonMark.Repositories.Implementation
{
    public class TodoItemSQLiteRepository : SQLiteRepository<TodoItem>, ITodoItemRepository
    {

    }
}
