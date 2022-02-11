namespace SystemInfo;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        /// <summary>
        /// lblDate
        /// </summary>
        /// <returns></returns>
        this.lblDate = new System.Windows.Forms.Label();
        this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.lblDate.Font = new Font("BIZ UDPゴシック", 24, FontStyle.Bold);
        this.lblDate.Location = new System.Drawing.Point(20, 10);
        this.lblDate.Name = "NowDate";
        this.lblDate.Size = new System.Drawing.Size(360, 60);
        this.lblDate.BackColor = System.Drawing.Color.Black;
        this.lblDate.ForeColor = System.Drawing.Color.White;
        this.lblDate.Text = System.DateTime.Now.ToShortDateString();
        this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lblDate.Click += LblDate_Click;

        /// <summary>
        /// lblTime
        /// </summary>
        /// <returns></returns>
        this.lblTime = new System.Windows.Forms.Label();
        this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.lblTime.Font = new Font("BIZ UDPゴシック", 24);
        this.lblTime.Location = new System.Drawing.Point(20, 70);
        this.lblTime.Name = "NowTime";
        this.lblTime.Size = new System.Drawing.Size(350, 60);
        this.lblTime.BackColor = System.Drawing.Color.Black;
        this.lblTime.ForeColor = System.Drawing.Color.Gold;
        this.lblTime.Text = System.DateTime.Now.ToShortTimeString();
        this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        /// <summary>
        /// lblBattery
        /// </summary>
        /// <returns></returns>
        this.lblBattery = new System.Windows.Forms.Label();
        this.lblBattery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblBattery.Font = new Font("BIZ UDPゴシック", 8);
        this.lblBattery.Location = new System.Drawing.Point(30, 500);
        this.lblBattery.Name = "Batt";
        this.lblBattery.Size = new System.Drawing.Size(335, 48);
        this.lblBattery.BackColor = System.Drawing.Color.Transparent;
        this.lblBattery.ForeColor = System.Drawing.Color.White;
        this.lblBattery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

        /// <summary>
        /// lblBatteryValue
        /// </summary>
        /// <returns></returns>
        this.lblBatteryValue = new System.Windows.Forms.Label();
        this.lblBatteryValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.lblBatteryValue.Font = new Font("BIZ UDPゴシック", 8);
        this.lblBatteryValue.Location = new System.Drawing.Point(0, 0);
        this.lblBatteryValue.Name = "BattValue";
        this.lblBatteryValue.Size = new System.Drawing.Size(335, 48);
        this.lblBatteryValue.BackColor = System.Drawing.Color.Transparent;
        this.lblBatteryValue.ForeColor = System.Drawing.Color.White;
        this.lblBatteryValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.lblBattery.Controls.Add(this.lblBatteryValue);

        /// <summary>
        /// lblCpu
        /// </summary>
        /// <returns></returns>
        this.lblCpu = new System.Windows.Forms.Label();
        this.lblCpu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblCpu.Font = new Font("BIZ UDPゴシック", 8);
        this.lblCpu.Location = new System.Drawing.Point(30, 547);
        this.lblCpu.Name = "CPU";
        this.lblCpu.Size = new System.Drawing.Size(335, 48);
        this.lblCpu.BackColor = System.Drawing.Color.Transparent;
        this.lblCpu.ForeColor = System.Drawing.Color.White;
        this.lblCpu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lblCpu.Text = " CPU ";

        /// <summary>
        /// lblCpuValue
        /// </summary>
        /// <returns></returns>
        this.lblCpuValue = new System.Windows.Forms.Label();
        this.lblCpuValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.lblCpuValue.Font = new Font("BIZ UDPゴシック", 8);
        this.lblCpuValue.Location = new System.Drawing.Point(0, 0);
        this.lblCpuValue.Name = "CPUValue";
        this.lblCpuValue.Size = new System.Drawing.Size(335, 48);
        this.lblCpuValue.BackColor = System.Drawing.Color.Transparent;
        this.lblCpuValue.ForeColor = System.Drawing.Color.White;
        this.lblCpuValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.lblCpu.Controls.Add(this.lblCpuValue);
  
        /// <summary>
        /// lblMem
        /// </summary>
        /// <returns></returns>
        this.lblMem = new System.Windows.Forms.Label();
        this.lblMem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblMem.Font = new Font("BIZ UDPゴシック", 8);
        this.lblMem.Location = new System.Drawing.Point(30, 594);
        this.lblMem.Name = "MEM";
        this.lblMem.Size = new System.Drawing.Size(335, 48);
        this.lblMem.BackColor = System.Drawing.Color.Transparent;
        this.lblMem.ForeColor = System.Drawing.Color.White;
        this.lblMem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lblMem.Text = " MEM ";

        /// <summary>
        /// lblMemValue
        /// </summary>
        /// <returns></returns>
        this.lblMemValue = new System.Windows.Forms.Label();
        this.lblMemValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.lblMemValue.Font = new Font("BIZ UDPゴシック", 8);
        this.lblMemValue.Location = new System.Drawing.Point(0, 0);
        this.lblMemValue.Name = "MEMValue";
        this.lblMemValue.Size = new System.Drawing.Size(335, 48);
        this.lblMemValue.BackColor = System.Drawing.Color.Transparent;
        this.lblMemValue.ForeColor = System.Drawing.Color.White;
        this.lblMemValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.lblMem.Controls.Add(this.lblMemValue);

        /// <summary>
        /// lblDisk
        /// </summary>
        /// <returns></returns>
        this.lblDisk = new System.Windows.Forms.Label();
        this.lblDisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblDisk.Font = new Font("BIZ UDPゴシック", 8);
        this.lblDisk.Location = new System.Drawing.Point(30, 641);
        this.lblDisk.Name = "DISK";
        this.lblDisk.Size = new System.Drawing.Size(335, 48);
        this.lblDisk.BackColor = System.Drawing.Color.Transparent;
        this.lblDisk.ForeColor = System.Drawing.Color.White;
        this.lblDisk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lblDisk.Text = " DISK ";

        /// <summary>
        /// lblDiskValue
        /// </summary>
        /// <returns></returns>
        this.lblDiskValue = new System.Windows.Forms.Label();
        this.lblDiskValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.lblDiskValue.Font = new Font("BIZ UDPゴシック", 8);
        this.lblDiskValue.Location = new System.Drawing.Point(0, 0);
        this.lblDiskValue.Name = "DISKValue";
        this.lblDiskValue.Size = new System.Drawing.Size(335, 48);
        this.lblDiskValue.BackColor = System.Drawing.Color.Transparent;
        this.lblDiskValue.ForeColor = System.Drawing.Color.White;
        this.lblDiskValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.lblDisk.Controls.Add(this.lblDiskValue);

        /// <summary>
        /// lblNet
        /// </summary>
        /// <returns></returns>
        this.lblNet = new System.Windows.Forms.Label();
        this.lblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblNet.Font = new Font("BIZ UDPゴシック", 8);
        this.lblNet.Location = new System.Drawing.Point(30, 688);
        this.lblNet.Name = "Net";
        this.lblNet.Size = new System.Drawing.Size(335, 48);
        this.lblNet.BackColor = System.Drawing.Color.Transparent;
        this.lblNet.ForeColor = System.Drawing.Color.White;
        this.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lblNet.Text = " NET ";

        /// <summary>
        /// lblNetValue
        /// </summary>
        /// <returns></returns>
        this.lblNetValue = new System.Windows.Forms.Label();
        this.lblNetValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.lblNetValue.Font = new Font("BIZ UDPゴシック", 8);
        this.lblNetValue.Location = new System.Drawing.Point(0, 0);
        this.lblNetValue.Name = "NetValue";
        this.lblNetValue.Size = new System.Drawing.Size(335, 48);
        this.lblNetValue.BackColor = System.Drawing.Color.Transparent;
        this.lblNetValue.ForeColor = System.Drawing.Color.White;
        this.lblNetValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.lblNet.Controls.Add(this.lblNetValue);

        /// <summary>
        /// lblVol
        /// </summary>
        /// <returns></returns>
        this.lblVol = new System.Windows.Forms.Label();
        this.lblVol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblVol.Font = new Font("BIZ UDPゴシック", 8);
        this.lblVol.Location = new System.Drawing.Point(30, 735);
        this.lblVol.Name = "Vol";
        this.lblVol.Size = new System.Drawing.Size(335, 48);
        this.lblVol.BackColor = System.Drawing.Color.Transparent;
        this.lblVol.ForeColor = System.Drawing.Color.White;
        this.lblVol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lblVol.Text = " VOL ";

        /// <summary>
        /// lblVolValue
        /// </summary>
        /// <returns></returns>
        this.lblVolValue = new System.Windows.Forms.Label();
        this.lblVolValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.lblVolValue.Font = new Font("BIZ UDPゴシック", 8);
        this.lblVolValue.Location = new System.Drawing.Point(0, 0);
        this.lblVolValue.Name = "VolValue";
        this.lblVolValue.Size = new System.Drawing.Size(335, 48);
        this.lblVolValue.BackColor = System.Drawing.Color.Transparent;
        this.lblVolValue.ForeColor = System.Drawing.Color.White;
        this.lblVolValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.lblVol.Controls.Add(this.lblVolValue);

        /// <summary>
        /// Form
        /// </summary>
        /// <returns></returns>
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 850);
        this.Text = "System Info";
        this.Opacity = 0.80;
        this.ControlBox = false;
        this.FormBorderStyle = FormBorderStyle.None;
        this.BackColor = System.Drawing.Color.Black;
        this.ShowInTaskbar = false;
        this.DoubleClick += Form_DoubleClick;

        this.Controls.Add(this.lblDate);
        this.Controls.Add(this.lblTime);
        this.Controls.Add(this.lblBattery);
        this.Controls.Add(this.lblCpu);
        this.Controls.Add(this.lblMem);
        this.Controls.Add(this.lblDisk);
        this.Controls.Add(this.lblNet);
        this.Controls.Add(this.lblVol);
    }

    #endregion

    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.Label lblBattery;
    private System.Windows.Forms.Label lblBatteryValue;
    private System.Windows.Forms.Label lblCpu;
    private System.Windows.Forms.Label lblCpuValue;
    private System.Windows.Forms.Label lblMem;
    private System.Windows.Forms.Label lblMemValue;
    private System.Windows.Forms.Label lblDisk;
    private System.Windows.Forms.Label lblDiskValue;
    private System.Windows.Forms.Label lblNet;
    private System.Windows.Forms.Label lblNetValue;
    private System.Windows.Forms.Label lblVol;
    private System.Windows.Forms.Label lblVolValue;
}
