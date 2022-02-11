namespace SystemInfo;

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;
using NAudio.CoreAudioApi;
public partial class Form1 : Form
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Form1()
    {
        //各コントロール初期化
        InitializeComponent();

        //タイマーイベント作成
        Timer timer = new Timer(this.components);
        timer.Tick += new EventHandler(Timer_Tick);
        timer.Interval = 5000;  //ミリ秒
        timer.Enabled = true;
 
        //日本の祝日取得
        Dictionary<DateTime, string> dicHoliday = HolidayUtil();
        //カレンダー設定／表示
        SetCalendar(dicHoliday);

        //ボリューム取得
        MMDevice device;
        MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
        device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        this.lblVolValue.Text = string.Format("{0:0} ", device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        this.sbHVol.Value = (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        DevEnum.Dispose();
        device.Dispose();
    }

    /// <summary>
    /// フォームダブルクリックイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form_DoubleClick(object sender, EventArgs e) {
        //ダブルクリックする度に画面をずらす
        if (this.Top != 0) {
            this.Top = 0;
            this.Left = 0;
        } else {
            this.Top = -1;
            this.Left = -1631;
        }
    }

    /// <summary>
    /// タイマーイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Timer_Tick(object? sender, EventArgs e) {
        //日付、時間を更新
        this.lblDate.Text = DateTime.Now.ToShortDateString();
        this.lblTime.Text = DateTime.Now.ToShortTimeString();
    
        //AC電源の状態取得
        PowerLineStatus pls = SystemInformation.PowerStatus.PowerLineStatus;
        if (pls == PowerLineStatus.Offline) {
            this.lblBattery.Text = " BATT ";
        } else if (pls == PowerLineStatus.Online) {
            this.lblBattery.Text = " AC   ";
        } else {
            this.lblBattery.Text = " xxxx ";
        }
        float blp = SystemInformation.PowerStatus.BatteryLifePercent;       //バッテリー残量（割合）
        int blr = SystemInformation.PowerStatus.BatteryLifeRemaining / 60;  //バッテリー残量（時間）
        this.lblBatteryValue.Text = string.Format("{0:0.0} %   {1} 分 ", blp * 100, blr);

        //CPU使用率取得
        var searcher = new ManagementObjectSearcher("select LoadPercentage from CIM_Processor");
        foreach (var obj in searcher.Get()) {
            int cpuUse = 0;
            try {
                cpuUse = int.Parse((obj["LoadPercentage"]).ToString());
            } catch {}
            this.lblCpuValue.Text = string.Format("{0} % ", cpuUse);
        }

        //メモリ使用率取得
        ManagementClass mc = new ManagementClass("Win32_OperatingSystem");
        ManagementObjectCollection moc = mc.GetInstances();
        foreach (ManagementObject mo in moc) {
            float totalMemory = 0;
            float freeMemory = 0;
            try {
                freeMemory= float.Parse(mo["FreePhysicalMemory"].ToString()) / 1024 / 1024;
                totalMemory = float.Parse(mo["TotalVisibleMemorySize"].ToString()) / 1024 / 1024;
            } catch {}

            this.lblMemValue.Text = string.Format("{0:#.0} GB  /  {1:#.0} GB ", freeMemory, totalMemory);
        }
        moc.Dispose();
        mc.Dispose();

        //C:ドライブの情報を取得する
        DriveInfo drive = new DriveInfo("C");
        float totalSize = 0;
        float totalFreeSize = 0;
        //ドライブの準備ができているか調べる
        if (drive.IsReady) {
            totalSize = ((float)drive.TotalSize / 1024 / 1024 / 1024);
            totalFreeSize = ((float)drive.TotalFreeSpace / 1024 / 1024 / 1024);
        }
        this.lblDiskValue.Text = string.Format("{0:#,##0.0} GB  /  {1:#,##0.0} GB ", totalFreeSize, totalSize);
        
        //ネットワーク速度
        long previousbytessend = 0;
        long previousbytesreceived = 0;
        long downloadspeed = 0;
        long uploadspeed = 0;
        IPv4InterfaceStatistics interfaceStats;
        for (int i = 0; i < NetworkInterface.GetAllNetworkInterfaces().Length; i++ ) {
            if (NetworkInterface.GetAllNetworkInterfaces()[i].Description.Contains("Wireless Adapter")) {
                interfaceStats = NetworkInterface.GetAllNetworkInterfaces()[i].GetIPv4Statistics();
                previousbytessend = interfaceStats.BytesSent;
                previousbytesreceived = interfaceStats.BytesReceived;
                //Task.Run(async () => { await Task.Delay(5000); Console.WriteLine("待機終了"); });
                Thread.Sleep(1000);
                interfaceStats = NetworkInterface.GetAllNetworkInterfaces()[i].GetIPv4Statistics();
                uploadspeed = (interfaceStats.BytesSent - previousbytessend) / 1024; //In KB/s
                downloadspeed = (interfaceStats.BytesReceived - previousbytesreceived) / 1024;

            }
        }
        this.lblNetValue.Text = string.Format("UP {0:0.0} MB/s   DL {1:0.0} MB/s ", (float)uploadspeed / 1024, (float)downloadspeed / 1024);
        this.lblNetValue.Update();

        //ボリューム取得
        MMDevice device;
        MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
        device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        this.lblVolValue.Text = string.Format("{0:0} ", device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        this.sbHVol.Value = (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        DevEnum.Dispose();
        device.Dispose();
    }

    /// <summary>
    /// スクロールバー移動
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SbHVol_ValueChanged(object sender, EventArgs e) {
        int volValue = this.sbHVol.Value;
        this.lblVolValue.Text = string.Format("{0:0} ", volValue);

        MMDevice device;
        MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
        device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)volValue / 100.0f);
        DevEnum.Dispose();
        device.Dispose();
    }

    /// <summary>
    /// 日付クリックイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LblDate_Click(object sender, EventArgs e) {
        Application.Exit();
    }

    /// <summary>
    /// カレンダー設定／表示
    /// </summary>
    /// <param name="dicHoliday">日本の祝日（取得できない場合はnull）</param>
    private void SetCalendar(Dictionary<DateTime, string> dicHoliday) {

        //カレンダータイトル表示
        string[] weekTitle = new string[] {"日","月","火","水","木","金","土"};
        for (int i = 0; i < 7; i++) {
            Label CalendarTitle = new Label();
            CalendarTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            CalendarTitle.Font = new Font("BIZ UDPゴシック", 16);
            CalendarTitle.Location = new System.Drawing.Point(30+i*48, 150);
            CalendarTitle.Name = "CalendarTitle";
            CalendarTitle.Size = new System.Drawing.Size(48, 48);
            CalendarTitle.BackColor = System.Drawing.Color.Black;
            CalendarTitle.ForeColor = System.Drawing.Color.White;
            CalendarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight; 
            this.Controls.Add(CalendarTitle);

            if (weekTitle[i] == "日") {
                CalendarTitle.ForeColor = Color.Red;
            } else if (weekTitle[i] == "土") {
                CalendarTitle.ForeColor = Color.DeepSkyBlue;
            } else {
                CalendarTitle.ForeColor = Color.White;
            }

            CalendarTitle.Text = weekTitle[i];
        }

        //現在の日付を取得から当月1日を表すインスタンスを生成します
        DateTime now1 = new DateTime( DateTime.Now.Year, DateTime.Now.Month, 1 );
        //当月1日からその曜日分だけ引きます。
        DateTime curDay = now1.AddDays( -( int )now1.DayOfWeek );

        //日付を表示
        for (int j = 0; j < 6; j++) {
            for (int i = 0; i < 7; i++) {
                Label CalendarDay = new Label();
                CalendarDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                CalendarDay.Font = new Font("BIZ UDPゴシック", 12);
                CalendarDay.Location = new System.Drawing.Point(30+i*48, 198+j*48);
                CalendarDay.Name = "CalendarDay";
                CalendarDay.Size = new System.Drawing.Size(48, 48);
                CalendarDay.BackColor = System.Drawing.Color.Black;
                CalendarDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; 
                this.Controls.Add(CalendarDay);

                //基本の色を設定
                CalendarDay.Text = curDay.Day.ToString();
                if (curDay.DayOfWeek == DayOfWeek.Sunday) {
                    CalendarDay.ForeColor = Color.Red;
                } else if (curDay.DayOfWeek == DayOfWeek.Saturday) {
                    CalendarDay.ForeColor = Color.DeepSkyBlue;
                } else {
                    CalendarDay.ForeColor = Color.White;
                }

                //先月なら色を薄くする 
                if (curDay.Month != DateTime.Now.Month) {
                    CalendarDay.ForeColor = Color.SlateGray;
                }
                //当日なら色を付ける
                if (curDay.Date == DateTime.Now.Date) {
                    CalendarDay.BackColor = Color.DarkOliveGreen;
                }

                //祝日チェック
                if (dicHoliday != null) {
                    if (dicHoliday.ContainsKey(curDay.Date)) {
                        CalendarDay.ForeColor = Color.Coral;
                    }
                }

                //curDayを1日分進める
                curDay = curDay.AddDays(1.0);
            }
        }
    }

    /// <summary>
    /// 日本の祝日取得
    /// 内閣府から取得
    /// </summary>
    /// <returns>日本の祝日（取得できない場合はnullを返す）</returns>
    private Dictionary<DateTime, string> HolidayUtil()
    {
        Dictionary<DateTime, string> dicHoliday = new Dictionary<DateTime, string>();

        //.Net5でSJISを使う場合に必要
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //ファイルの中身を取得
        string _path = @"https://www8.cao.go.jp/chosei/shukujitsu/syukujitsu.csv";

        var client = new System.Net.WebClient();
        byte[] buffer = null;
        try {
            buffer = client.DownloadData(_path);
            string str = Encoding.GetEncoding("shift_jis").GetString(buffer);
            //行毎に配列に分割
            string[] rows = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //一行目を飛ばしてデータをディクショナリに格納
            rows.Skip(1).ToList().ForEach(row =>
            {
                var cols = row.Split(',');
                dicHoliday.Add(DateTime.Parse(cols[0]), cols[1]);
            });

        } catch {
            dicHoliday = null;
        }

        return dicHoliday;
    }
}
