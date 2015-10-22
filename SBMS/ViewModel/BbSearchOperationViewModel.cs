﻿using EkushApp.EmbededDB;
using EkushApp.Model;
using EkushApp.ShellService.Commands;
using EkushApp.Utility.Extensions;
using SBMS.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BbSearchOperationViewModel : GenericOperationViewModel<BbCircularSearch>
    {
        #region Property(s)
        private string _searchBy;
        public string SearchBy
        {
            get { return _searchBy; }
            set
            {
                _searchBy = value;
                OnPropertyChanged(() => SearchBy);
            }
        }
        private OptimizedObservableCollection<BbSearchBy> _searchByCollection;
        public OptimizedObservableCollection<BbSearchBy> SearchByCollection
        {
            get { return _searchByCollection; }
        }
        private BbSearchBy _selectedSearchBy;
        public BbSearchBy SelectedSearchBy
        {
            get { return _selectedSearchBy; }
            set
            {
                _selectedSearchBy = value;
                OnPropertyChanged(() => SelectedSearchBy);
            }
        }
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged(() => SearchTerm);
            }
        }
        #endregion

        #region Command(s)
        public CommandHandler<object, object> SaveSearchByCommand { get; private set; }
        #endregion

        #region Constructor(s)
        [ImportingConstructor]
        public BbSearchOperationViewModel(IBbSearchOperationView view, CompositionContainer compositionContainer)
        {
            View = view;
            View.ViewModel = this;
            ShellContainer = compositionContainer;
            SaveSearchByCommand = new CommandHandler<object, object>(SaveSearchByCommandAction);
            _searchByCollection = new OptimizedObservableCollection<BbSearchBy>();
        }
        #endregion

        #region Command Handler(s)
        private async void SaveSearchByCommandAction(object obj)
        {
            await DbHandler.Instance.SaveData<BbSearchBy>(new BbSearchBy { SearchByName = SearchBy, SearchKey = SearchBy.Replace(" ", "_").ToUpper() });
            List<BbSearchBy> searchByCollection = await DbHandler.Instance.GetAllData<BbSearchBy>();
            SearchByCollection.Clear();
            SearchByCollection.AddRange(searchByCollection);
        }
        public override async void SaveCommandAction(object obj)
        {
            await DbHandler.Instance.SaveData<BbCircularSearch>(new BbCircularSearch
            {
                SearchByName = SelectedSearchBy.SearchByName,
                SearchKey = SelectedSearchBy.SearchKey,
                SearchTerm = SearchTerm,
                SearchTermKey = SearchTerm.Replace(" ", "_").ToUpper()
            });
            base.SaveCommandAction(obj);
        }
        #endregion

        #region ViewModelBase
        public override async void OnLoad()
        {
            base.OnLoad();
            List<BbSearchBy> searchByCollection = await DbHandler.Instance.GetAllData<BbSearchBy>();
            SearchByCollection.Clear();
            SearchByCollection.AddRange(searchByCollection);
        }
        #endregion
    }
}
