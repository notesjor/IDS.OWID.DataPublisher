namespace IDS.OWID.DataPublisher.Tool.Prepper
{
  partial class RadForm1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      btn_open = new Telerik.WinControls.UI.CommandBarButton();
      btn_export = new Telerik.WinControls.UI.CommandBarButton();
      list = new Telerik.WinControls.UI.RadCheckedListBox();
      ((System.ComponentModel.ISupportInitialize)radCommandBar1).BeginInit();
      ((System.ComponentModel.ISupportInitialize)list).BeginInit();
      ((System.ComponentModel.ISupportInitialize)this).BeginInit();
      SuspendLayout();
      // 
      // radCommandBar1
      // 
      radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      radCommandBar1.Location = new System.Drawing.Point(0, 0);
      radCommandBar1.Name = "radCommandBar1";
      radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] { commandBarRowElement1 });
      radCommandBar1.Size = new System.Drawing.Size(587, 56);
      radCommandBar1.TabIndex = 0;
      // 
      // commandBarRowElement1
      // 
      commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      commandBarRowElement1.Name = "commandBarRowElement1";
      commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] { commandBarStripElement1 });
      // 
      // commandBarStripElement1
      // 
      commandBarStripElement1.DisplayName = "commandBarStripElement1";
      commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] { btn_open, btn_export });
      commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_open
      // 
      btn_open.DisplayName = "commandBarButton1";
      btn_open.Image = Properties.Resources.folder_open_24px;
      btn_open.Name = "btn_open";
      btn_open.Text = "JSON-Laden";
      btn_open.Click += btn_open_Click;
      // 
      // btn_export
      // 
      btn_export.AutoEllipsis = true;
      btn_export.DisplayName = "commandBarButton2";
      btn_export.Image = Properties.Resources.save_24px;
      btn_export.Name = "btn_export";
      btn_export.Text = "SPLIT-JSON Erstellen";
      btn_export.Click += btn_export_Click;
      // 
      // list
      // 
      list.Dock = System.Windows.Forms.DockStyle.Fill;
      list.GroupItemSize = new System.Drawing.Size(200, 28);
      list.ItemSize = new System.Drawing.Size(200, 28);
      list.Location = new System.Drawing.Point(0, 56);
      list.Name = "list";
      list.Size = new System.Drawing.Size(587, 373);
      list.TabIndex = 1;
      // 
      // RadForm1
      // 
      AutoScaleBaseSize = new System.Drawing.Size(7, 15);
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(587, 429);
      Controls.Add(list);
      Controls.Add(radCommandBar1);
      Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      Name = "RadForm1";
      Text = "DataPrepper";
      ((System.ComponentModel.ISupportInitialize)radCommandBar1).EndInit();
      ((System.ComponentModel.ISupportInitialize)list).EndInit();
      ((System.ComponentModel.ISupportInitialize)this).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_open;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private Telerik.WinControls.UI.RadCheckedListBox list;
  }
}