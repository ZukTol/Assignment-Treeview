namespace assignment_treeview.ViewModels
{
	using System.Collections.ObjectModel;


	public class CategoryViewModel : ViewModelBase
	{
		private string _name;
		private ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();

		public string Name
		{
			get { return _name; }
			set { SetValue(ref _name, value); }
		}

		public int Id { get; set; }

		public ObservableCollection<ItemViewModel> Items { get { return _items; } }
	}


	public class ItemViewModel : ViewModelBase
	{
		private string _name;

		public string Name
		{
			get { return _name; }
			set { SetValue(ref _name, value); }
		}

		public int Id { get; set; }
	}
}
