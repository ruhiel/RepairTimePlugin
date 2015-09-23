using Grabacr07.KanColleWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairTimePlugin
{
    public class RepairTimeInfo
    {
        //
        // 概要:
        //     耐久値を取得します。
        public LimitedValue HP { get; }

        //
        // 概要:
        //     艦娘の現在のレベルを取得します。
        public int Level { get; }

        //
        // 概要:
        //     艦娘の種類に基づく情報を取得します。
        public ShipInfo Info { get; }
        //
        // 概要:
        //     コンストラクタ
        public RepairTimeInfo(Ship ship)
        {
            HP = ship.HP;
            Level = ship.Level;
            Info = ship.Info;
        }
        //
        // 概要:
        //     修理時間の係数を取得します。
        private float Rate
        {
            get
            {
                if (Info.ShipType.Id == 8)
                {
                    // 巡洋戦艦
                    return 1.5f;
                }
                else if (Info.ShipType.Name == "潜水艦")
                {
                    return 0.5f;
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(Info.ShipType.Name, "駆逐艦|軽巡洋艦|重雷装巡洋艦|練習巡洋艦|水上機母艦|潜水空母|揚陸艦|補給艦"))
                {
                    return 1.0f;
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(Info.ShipType.Name, "重巡洋艦|航空巡洋艦|軽空母|潜水母艦"))
                {
                    return 1.5f;
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(Info.ShipType.Name, "航空戦艦|戦艦|正規空母|装甲空母|工作艦"))
                {
                    return 2.0f;
                }

                return 0.0f;
            }

        }
        //
        // 概要:
        //     修理時間を時:分:秒形式で取得します。
        public string RepairTime
        {
            get
            {
                int time = 0;
                if(Damage == 0)
                {
                    return "--:--:--";
                }

                if (Level < 12)
                {
                    time = (int)(Level * 10 * Rate * Damage) + 30;
                }
                else
                {
                    time = (int)((Level * 5 + LevelCorrect) * Rate * Damage) + 30;
                }

                return string.Format("{0:00}:{1:00}:{2:00}", (time / 60 / 60), (time / 60) % 60, time % 60);
            }
            
        }
        //
        // 概要:
        //     減少HPを取得します。
        private int Damage
        {
            get { return HP.Maximum - HP.Current; }
        }
        //
        // 概要:
        //     レベル補正を取得します。
        private int LevelCorrect
        {
            get
            {
                return (int)Math.Sqrt(Level - 11) * 10 + 50;
            }
        }
    }
}
