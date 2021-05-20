using DoToo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoToo.ViewModels
{
    public class TodoItemViewModel : ViewModel
    {
        public TodoItemViewModel(TodoItem item) => Item = item;
        public event EventHandler ItemStatusChanged;
        public TodoItem Item { get; private set; }
        public string Status => Item.Completed ? "Racativate" : "Completed";

    }
}
