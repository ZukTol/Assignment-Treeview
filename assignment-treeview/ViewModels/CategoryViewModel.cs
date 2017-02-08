namespace assignment_treeview.ViewModels
{
	using System.Collections.ObjectModel;
	using System.Linq;


	public class CategoryViewModel : ViewModelBase
	{
		private string _name;
		private ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();
		private int _matchFilter;

		public string Name
		{
			get { return _name; }
			set { SetValue(ref _name, value); }
		}

		public int MatchFilter
		{
			get { return _matchFilter; }
			set { SetValue(ref _matchFilter, value); }
		}

		public int Id { get; set; }

		public ObservableCollection<ItemViewModel> Items { get { return _items; } set { SetValue(ref _items, value); } }

		public CategoryViewModel Clone()
		{
			var res = new CategoryViewModel { Name = Name, Id = Id };
			foreach (var result in Items.Select(i => i.Clone()))
			{
				res.Items.Add(result);
			}
			return res;
		}

		#region Object overrides
		protected bool Equals(CategoryViewModel other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CategoryViewModel)obj);
		}

		public override int GetHashCode()
		{
			return Id;
		}
		#endregion Object overrides
	}


	public class ItemViewModel : ViewModelBase
	{
		private string _name;
		private int _matchFilter;

		public string Name
		{
			get { return _name; }
			set { SetValue(ref _name, value); }
		}

		public int Id { get; set; }

		public int MatchFilter
		{
			get { return _matchFilter; }
			set { SetValue(ref _matchFilter, value); }
		}

		public ItemViewModel Clone()
		{
			return new ItemViewModel {Name = Name, Id = Id};
		}

		#region Object overrides
		protected bool Equals(ItemViewModel other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ItemViewModel)obj);
		}

		public override int GetHashCode()
		{
			return Id;
		}
		#endregion Object overrides
	}
}
