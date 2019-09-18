namespace Gige_Vidion_Camera
{
    partial class Homepage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_opencamera = new System.Windows.Forms.Button();
            this.button_grab = new System.Windows.Forms.Button();
            this.button_freeze = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripLabel();
            this.StatusLabelInfo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PixelLabel = new System.Windows.Forms.ToolStripLabel();
            this.PixelDataValue = new System.Windows.Forms.ToolStripLabel();
            this.button_closecamera = new System.Windows.Forms.Button();
            this.button_View = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_opencamera
            // 
            this.button_opencamera.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_opencamera.Location = new System.Drawing.Point(12, 62);
            this.button_opencamera.Name = "button_opencamera";
            this.button_opencamera.Size = new System.Drawing.Size(169, 76);
            this.button_opencamera.TabIndex = 0;
            this.button_opencamera.Text = "打开相机";
            this.button_opencamera.UseVisualStyleBackColor = true;
            this.button_opencamera.Click += new System.EventHandler(this.button_opencamera_Click);
            // 
            // button_grab
            // 
            this.button_grab.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_grab.Location = new System.Drawing.Point(12, 186);
            this.button_grab.Name = "button_grab";
            this.button_grab.Size = new System.Drawing.Size(169, 76);
            this.button_grab.TabIndex = 1;
            this.button_grab.Text = "采集图像";
            this.button_grab.UseVisualStyleBackColor = true;
            this.button_grab.Click += new System.EventHandler(this.button_grab_Click);
            // 
            // button_freeze
            // 
            this.button_freeze.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_freeze.Location = new System.Drawing.Point(12, 320);
            this.button_freeze.Name = "button_freeze";
            this.button_freeze.Size = new System.Drawing.Size(169, 76);
            this.button_freeze.TabIndex = 2;
            this.button_freeze.Text = "停止采集";
            this.button_freeze.UseVisualStyleBackColor = true;
            this.button_freeze.Click += new System.EventHandler(this.button_freeze_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.StatusLabelInfo,
            this.toolStripSeparator1,
            this.PixelLabel,
            this.PixelDataValue});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1205, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(58, 22);
            this.StatusLabel.Text = "Status:";
            // 
            // StatusLabelInfo
            // 
            this.StatusLabelInfo.Name = "StatusLabelInfo";
            this.StatusLabelInfo.Size = new System.Drawing.Size(66, 22);
            this.StatusLabelInfo.Text = "nothing";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // PixelLabel
            // 
            this.PixelLabel.Name = "PixelLabel";
            this.PixelLabel.Size = new System.Drawing.Size(47, 22);
            this.PixelLabel.Text = "Pixel:";
            // 
            // PixelDataValue
            // 
            this.PixelDataValue.Name = "PixelDataValue";
            this.PixelDataValue.Size = new System.Drawing.Size(126, 22);
            this.PixelDataValue.Text = "Data not avaible";
            // 
            // button_closecamera
            // 
            this.button_closecamera.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_closecamera.Location = new System.Drawing.Point(12, 449);
            this.button_closecamera.Name = "button_closecamera";
            this.button_closecamera.Size = new System.Drawing.Size(169, 76);
            this.button_closecamera.TabIndex = 4;
            this.button_closecamera.Text = "关闭相机";
            this.button_closecamera.UseVisualStyleBackColor = true;
            this.button_closecamera.Click += new System.EventHandler(this.button_closecamera_Click);
            // 
            // button_View
            // 
            this.button_View.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_View.Location = new System.Drawing.Point(12, 580);
            this.button_View.Name = "button_View";
            this.button_View.Size = new System.Drawing.Size(169, 76);
            this.button_View.TabIndex = 5;
            this.button_View.Text = "View";
            this.button_View.UseVisualStyleBackColor = true;
            this.button_View.Click += new System.EventHandler(this.button_View_Click);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 718);
            this.Controls.Add(this.button_View);
            this.Controls.Add(this.button_closecamera);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button_freeze);
            this.Controls.Add(this.button_grab);
            this.Controls.Add(this.button_opencamera);
            this.Name = "Homepage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_opencamera;
        private System.Windows.Forms.Button button_grab;
        private System.Windows.Forms.Button button_freeze;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel StatusLabel;
        private System.Windows.Forms.ToolStripLabel StatusLabelInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel PixelLabel;
        private System.Windows.Forms.ToolStripLabel PixelDataValue;
        private System.Windows.Forms.Button button_closecamera;
        private System.Windows.Forms.Button button_View;
    }
}

