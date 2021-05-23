using DoToo.Models;
using DoToo.Repositories;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoToo.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private TodoItemRepository _repository;
        public TodoItem Item { get; set; }
        public ItemViewModel(TodoItemRepository repository)
        {
            _repository = repository;
            Item = new TodoItem() { Due = DateTime.Now.AddDays(1) };
        }

        public ICommand Save => new Command(async () =>
        {
            await _repository.AddOrUpdate(Item);
            await Navigation.PopAsync();
        });
    }
}
