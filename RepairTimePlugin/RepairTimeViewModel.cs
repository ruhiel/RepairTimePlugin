using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;
using Livet;
using Livet.EventListeners;
using MetroTrilithon.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairTimePlugin
{
    public class RepairTimeViewModel : ViewModel
    {
        #region FirstFleet 変更通知プロパティ
        private Ship[] _Ship;
        public Ship[] FirstFleet
        {
            get { return _Ship;}
            set
            {
                if (this._Ship != value)
                {
                    this._Ship = value;
                    this.RaisePropertyChanged();
                }
            }
        }
        #endregion
        public RepairTimeViewModel()
        {
            KanColleClient.Current.Homeport.Organization
                .Subscribe(nameof(Organization.Fleets), this.InitializeFleets)
                .AddTo(this);

            this.InitializeFleets();
        }
        public void InitializeFleets()
        {
            FirstFleet = KanColleClient.Current.Homeport.Organization.Fleets.Values.First().Ships;

            this.CompositeDisposable.Add(new PropertyChangedEventListener(KanColleClient.Current.Homeport.Organization)
            {
                {
                    () => KanColleClient.Current.Homeport.Organization.Ships,
                    (_, __) => { DispatcherHelper.UIDispatcher.Invoke(this.UpdateView); }
                }
            });
        }

        private void UpdateView()
        {
            if (!KanColleClient.Current.IsStarted) return;

            FirstFleet = KanColleClient.Current.Homeport.Organization.Fleets.Values.First().Ships;
        }

    }
}
