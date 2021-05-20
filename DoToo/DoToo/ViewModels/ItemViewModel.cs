using DoToo.Repositories;

namespace DoToo.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private readonly TodoItemRepository _repository;
        public ItemViewModel(TodoItemRepository repository) => _repository = repository;

    }
}
