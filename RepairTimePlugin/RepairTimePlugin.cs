using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using Livet;
using MetroTrilithon.Lifetime;
using MetroTrilithon.Mvvm;
using Nekoxy;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairTimePlugin
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("Title", "入渠時間プラグイン")]
    [ExportMetadata("Description", "入渠時間プラグイン")]
    [ExportMetadata("Version", "1.0.0")]
    [ExportMetadata("Author", "@ruhiel_murrue")]
    [ExportMetadata("Guid", "8081BAEE-DD53-40CD-9C14-1FE2F098E58D")]
    [Export(typeof(ITool))]
    public class RepairTimePlugin : NotificationObject, IPlugin, ITool
    {
        public object View => new UserControl1 { DataContext = new RepairTimeViewModel(), };
        public string Name => "RepairTimePlugin";

        /*
        */
        public void Initialize()
        {
        }
    }
}
