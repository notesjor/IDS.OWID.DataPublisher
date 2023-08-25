namespace IDS.OWID.DataPublisher.Tool.Prepper
{
  partial class PivotHelper
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
      btn_save = new Telerik.WinControls.UI.RadButton();
      btn_add = new Telerik.WinControls.UI.RadButton();
      panel = new Telerik.WinControls.UI.RadScrollablePanel();
      ((System.ComponentModel.ISupportInitialize)btn_save).BeginInit();
      ((System.ComponentModel.ISupportInitialize)btn_add).BeginInit();
      ((System.ComponentModel.ISupportInitialize)panel).BeginInit();
      panel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)this).BeginInit();
      SuspendLayout();
      // 
      // btn_save
      // 
      btn_save.Dock = System.Windows.Forms.DockStyle.Top;
      btn_save.Image = Properties.Resources.save_24px;
      btn_save.Location = new System.Drawing.Point(0, 0);
      btn_save.Name = "btn_save";
      btn_save.Size = new System.Drawing.Size(617, 24);
      btn_save.TabIndex = 0;
      btn_save.Text = "PivotHelper beenden";
      btn_save.Click += btn_save_Click;
      // 
      // btn_add
      // 
      btn_add.Dock = System.Windows.Forms.DockStyle.Bottom;
      btn_add.Image = Properties.Resources.add_circle_outline_24px;
      btn_add.Location = new System.Drawing.Point(0, 426);
      btn_add.Name = "btn_add";
      btn_add.Size = new System.Drawing.Size(617, 24);
      btn_add.TabIndex = 1;
      btn_add.Text = "Neuer Pivot-Eintrag";
      btn_add.Click += btn_add_Click;
      // 
      // panel
      // 
      panel.Dock = System.Windows.Forms.DockStyle.Fill;
      panel.Location = new System.Drawing.Point(0, 24);
      panel.Name = "panel";
      // 
      // panel.PanelContainer
      // 
      panel.PanelContainer.Size = new System.Drawing.Size(598, 400);
      panel.Size = new System.Drawing.Size(617, 402);
      panel.TabIndex = 2;
      panel.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      // 
      // PivotHelper
      // 
      AutoScaleBaseSize = new System.Drawing.Size(7, 15);
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(617, 450);
      Controls.Add(panel);
      Controls.Add(btn_add);
      Controls.Add(btn_save);
      Name = "PivotHelper";
      Text = "DataPublisher - Prepper - PivotHelper";
      ((System.ComponentModel.ISupportInitialize)btn_save).EndInit();
      ((System.ComponentModel.ISupportInitialize)btn_add).EndInit();
      ((System.ComponentModel.ISupportInitialize)panel).EndInit();
      panel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)this).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Telerik.WinControls.UI.RadButton btn_save;
    private Telerik.WinControls.UI.RadButton btn_add;
    private Telerik.WinControls.UI.RadScrollablePanel panel;
  }
}