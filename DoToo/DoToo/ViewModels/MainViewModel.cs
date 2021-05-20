using DoToo.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoToo.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly TodoItemRepository _repository;
        public MainViewModel(TodoItemRepository repository)
        {
            _repository = repository;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            
        }
    }
}
