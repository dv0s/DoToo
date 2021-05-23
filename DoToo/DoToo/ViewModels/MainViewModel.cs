using DoToo.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DoToo.Views;
using Xamarin.Forms;
using System.Linq;
using DoToo.Models;
using System.Collections.ObjectModel;

namespace DoToo.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly TodoItemRepository _repository;
        public ObservableCollection<TodoItemViewModel> Items { get; set; }
        public MainViewModel(TodoItemRepository repository)
        {
            repository.OnItemAdded += (sender, item) => Items.Add(CreateTodoItemViewModel(item));
            repository.OnItemUpdated += (sender, item) => Task.Run(async () => await LoadData());

            _repository = repository;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            var items = await _repository.GetItems();
            var itemViewModels = items.Select(i =>
            CreateTodoItemViewModel(i));
            Items = new ObservableCollection<TodoItemViewModel>
            (itemViewModels);
        }
        private TodoItemViewModel CreateTodoItemViewModel(TodoItem item)
        {
            var itemViewModel = new TodoItemViewModel(item);
            itemViewModel.ItemStatusChanged += ItemStatusChanged;
            return itemViewModel;
        }
        private void ItemStatusChanged(object sender, EventArgs e)
        {
        }


        public ICommand AddItem => new Command(async () =>
        {
            var itemView = Resolver.Resolve<ItemView>();
            await Navigation.PushAsync(itemView);
        });
    }
}
