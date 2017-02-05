namespace assignment_treeview.ViewModels
{
	using System;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Linq;
	using System.Windows;
	using System.Windows.Data;
	using System.Windows.Input;


	public class MainWindowViewModel : ViewModelBase
	{
		private const int MaxCategoriesCount = 500;
		readonly Random _catRandom = new Random();

		public ObservableCollection<CategoryViewModel> Categories { get; } = new ObservableCollection<CategoryViewModel>();
		public ICommand LoadCmd => new DelegateCommand(DoLoad);
		public ICommand ExitCmd => new DelegateCommand(() => Application.Current.Shutdown());

		private ICollectionView _categoriesCollection;

		public MainWindowViewModel()
		{
			SetupCategoriesCollection();
		}

		public ICollectionView CategoriesCollection
		{
			get { return _categoriesCollection; }
			set { SetValue(ref _categoriesCollection, value); }
		}

		void SetupCategoriesCollection()
		{
			var collection = new ListCollectionView(Categories);
			collection.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Ascending));

			CategoriesCollection = collection;
		}

		private void DoLoad()
		{
			var newCatCount = NewCategoriesCount();

			if (Categories.Count + newCatCount > MaxCategoriesCount)
				newCatCount = MaxCategoriesCount - Categories.Count;

			for (var i = 0; i < newCatCount; i++)
			{
				var id = NewValidCategoryName();
				var newCategory = new CategoryViewModel { Name = "Category" + id.ToString(), Id = id };

				Categories.Add(newCategory);
			}

			foreach (var category in Categories)
			{
				category.Items.Clear();
				var newItemsCount = NewItemsCount();
				for (var i = 0; i < newItemsCount; i++)
				{
					var id = NewValidItemId(category.Items);
					var newItem = new ItemViewModel { Name = "Item" + id.ToString(), Id = id };
					category.Items.Add(newItem);
				}
			}
		}

		private int NewCategoriesCount()
		{
			return _catRandom.Next(25, 51);
		}

		private int NewCategoryId()
		{
			return _catRandom.Next(1, 1000);
		}

		private int NewValidCategoryName()
		{
			var ids = Categories.Select(c => c.Id).ToList();
			var newId = NewCategoryId();
			while (ids.Contains(newId))
			{
				newId = NewCategoryId();
			}
			return newId;
		}

		private int NewItemsCount()
		{
			return _catRandom.Next(3, 11);
		}

		private int NewItemId()
		{
			return _catRandom.Next(1, 31);
		}

		private int NewValidItemId(ObservableCollection<ItemViewModel> items)
		{
			var ids = items.Select(c => c.Id).ToList();
			var newId = NewItemId();
			while (ids.Contains(newId))
			{
				newId = NewItemId();
			}
			return newId;
		}
	}
}
