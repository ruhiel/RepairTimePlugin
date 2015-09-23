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
        //
        // 概要:
        //     [ツール] タブ内に表示される UI のルート要素を取得します。
        public object View => new UserControl1 { DataContext = new RepairTimeViewModel(), };
        //
        // 概要:
        //     [ツール] タブのツール一覧に表示される名前を取得します。
        public string Name => "RepairTime";

        //
        // 概要:
        //     プラグインの初期化処理を実行します。
        public void Initialize()
        {
        }
    }
}
