
namespace CGoL
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.RenderTarget = new System.Windows.Forms.PictureBox();
            this.SizePicker = new System.Windows.Forms.NumericUpDown();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SimulationTimer = new System.Windows.Forms.Timer(this.components);
            this.StepTimeLabel = new System.Windows.Forms.Label();
            this.StepTimePicker = new System.Windows.Forms.NumericUpDown();
            this.GliderButton = new System.Windows.Forms.Button();
            this.GunButton = new System.Windows.Forms.Button();
            this.PresetLabel = new System.Windows.Forms.Label();
            this.BlinkersButton = new System.Windows.Forms.Button();
            this.AcornButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RenderTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepTimePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // RenderTarget
            // 
            this.RenderTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RenderTarget.Location = new System.Drawing.Point(95, 1);
            this.RenderTarget.Name = "RenderTarget";
            this.RenderTarget.Size = new System.Drawing.Size(882, 478);
            this.RenderTarget.TabIndex = 0;
            this.RenderTarget.TabStop = false;
            this.RenderTarget.SizeChanged += new System.EventHandler(this.RenderTarget_SizeChanged);
            // 
            // SizePicker
            // 
            this.SizePicker.Location = new System.Drawing.Point(15, 24);
            this.SizePicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SizePicker.Name = "SizePicker";
            this.SizePicker.Size = new System.Drawing.Size(53, 20);
            this.SizePicker.TabIndex = 1;
            this.SizePicker.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SizePicker.ValueChanged += new System.EventHandler(this.SizePicker_ValueChanged);
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(12, 8);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(50, 13);
            this.SizeLabel.TabIndex = 2;
            this.SizeLabel.Text = "Cell Size:";
            // 
            // SimulationTimer
            // 
            this.SimulationTimer.Enabled = true;
            this.SimulationTimer.Interval = 30;
            this.SimulationTimer.Tick += new System.EventHandler(this.SimulationTimer_Tick);
            // 
            // StepTimeLabel
            // 
            this.StepTimeLabel.AutoSize = true;
            this.StepTimeLabel.Location = new System.Drawing.Point(12, 57);
            this.StepTimeLabel.Name = "StepTimeLabel";
            this.StepTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.StepTimeLabel.TabIndex = 8;
            this.StepTimeLabel.Text = "Step Time:";
            // 
            // StepTimePicker
            // 
            this.StepTimePicker.Location = new System.Drawing.Point(15, 73);
            this.StepTimePicker.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.StepTimePicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StepTimePicker.Name = "StepTimePicker";
            this.StepTimePicker.Size = new System.Drawing.Size(53, 20);
            this.StepTimePicker.TabIndex = 9;
            this.StepTimePicker.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.StepTimePicker.ValueChanged += new System.EventHandler(this.StepTimePicker_ValueChanged);
            // 
            // GliderButton
            // 
            this.GliderButton.Location = new System.Drawing.Point(12, 194);
            this.GliderButton.Name = "GliderButton";
            this.GliderButton.Size = new System.Drawing.Size(74, 23);
            this.GliderButton.TabIndex = 12;
            this.GliderButton.Text = "Glider";
            this.GliderButton.UseVisualStyleBackColor = true;
            this.GliderButton.Click += new System.EventHandler(this.GliderButton_Click);
            // 
            // GunButton
            // 
            this.GunButton.Location = new System.Drawing.Point(12, 223);
            this.GunButton.Name = "GunButton";
            this.GunButton.Size = new System.Drawing.Size(74, 23);
            this.GunButton.TabIndex = 14;
            this.GunButton.Text = "Glider Gun";
            this.GunButton.UseVisualStyleBackColor = true;
            this.GunButton.Click += new System.EventHandler(this.GunButton_Click);
            // 
            // PresetLabel
            // 
            this.PresetLabel.AutoSize = true;
            this.PresetLabel.Location = new System.Drawing.Point(26, 120);
            this.PresetLabel.Name = "PresetLabel";
            this.PresetLabel.Size = new System.Drawing.Size(42, 13);
            this.PresetLabel.TabIndex = 15;
            this.PresetLabel.Text = "Presets";
            // 
            // BlinkersButton
            // 
            this.BlinkersButton.Location = new System.Drawing.Point(12, 136);
            this.BlinkersButton.Name = "BlinkersButton";
            this.BlinkersButton.Size = new System.Drawing.Size(74, 23);
            this.BlinkersButton.TabIndex = 16;
            this.BlinkersButton.Text = "Blinkers";
            this.BlinkersButton.UseVisualStyleBackColor = true;
            this.BlinkersButton.Click += new System.EventHandler(this.BlinkersButton_Click);
            // 
            // AcornButton
            // 
            this.AcornButton.Location = new System.Drawing.Point(12, 165);
            this.AcornButton.Name = "AcornButton";
            this.AcornButton.Size = new System.Drawing.Size(74, 23);
            this.AcornButton.TabIndex = 17;
            this.AcornButton.Text = "Acorn";
            this.AcornButton.UseVisualStyleBackColor = true;
            this.AcornButton.Click += new System.EventHandler(this.AcornButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 480);
            this.Controls.Add(this.AcornButton);
            this.Controls.Add(this.BlinkersButton);
            this.Controls.Add(this.PresetLabel);
            this.Controls.Add(this.GunButton);
            this.Controls.Add(this.GliderButton);
            this.Controls.Add(this.StepTimePicker);
            this.Controls.Add(this.StepTimeLabel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.SizePicker);
            this.Controls.Add(this.RenderTarget);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CGoL";
            ((System.ComponentModel.ISupportInitialize)(this.RenderTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepTimePicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox RenderTarget;
        private System.Windows.Forms.NumericUpDown SizePicker;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Timer SimulationTimer;
        private System.Windows.Forms.Label StepTimeLabel;
        private System.Windows.Forms.NumericUpDown StepTimePicker;
        private System.Windows.Forms.Button GliderButton;
        private System.Windows.Forms.Button GunButton;
        private System.Windows.Forms.Label PresetLabel;
        private System.Windows.Forms.Button BlinkersButton;
        private System.Windows.Forms.Button AcornButton;
    }
}

