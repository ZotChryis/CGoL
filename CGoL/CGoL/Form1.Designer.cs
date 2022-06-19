
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
            this.SimulationTimer = new System.Windows.Forms.Timer(this.components);
            this.StepTimeLabel = new System.Windows.Forms.Label();
            this.StepTimePicker = new System.Windows.Forms.NumericUpDown();
            this.GliderButton = new System.Windows.Forms.Button();
            this.GunButton = new System.Windows.Forms.Button();
            this.PresetLabel = new System.Windows.Forms.Label();
            this.BlinkersButton = new System.Windows.Forms.Button();
            this.AcornButton = new System.Windows.Forms.Button();
            this.BigBlinkersButton = new System.Windows.Forms.Button();
            this.BigBoardLabel = new System.Windows.Forms.Label();
            this.BigAcornButton = new System.Windows.Forms.Button();
            this.PromptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RenderTarget)).BeginInit();
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
            this.RenderTarget.Size = new System.Drawing.Size(882, 541);
            this.RenderTarget.TabIndex = 0;
            this.RenderTarget.TabStop = false;
            this.RenderTarget.SizeChanged += new System.EventHandler(this.RenderTarget_SizeChanged);
            // 
            // SimulationTimer
            // 
            this.SimulationTimer.Enabled = true;
            this.SimulationTimer.Tick += new System.EventHandler(this.SimulationTimer_Tick);
            // 
            // StepTimeLabel
            // 
            this.StepTimeLabel.AutoSize = true;
            this.StepTimeLabel.Location = new System.Drawing.Point(20, 11);
            this.StepTimeLabel.Name = "StepTimeLabel";
            this.StepTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.StepTimeLabel.TabIndex = 8;
            this.StepTimeLabel.Text = "Step Time:";
            // 
            // StepTimePicker
            // 
            this.StepTimePicker.Location = new System.Drawing.Point(23, 27);
            this.StepTimePicker.Maximum = new decimal(new int[] {
            3000,
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
            100,
            0,
            0,
            0});
            this.StepTimePicker.ValueChanged += new System.EventHandler(this.StepTimePicker_ValueChanged);
            // 
            // GliderButton
            // 
            this.GliderButton.Location = new System.Drawing.Point(12, 133);
            this.GliderButton.Name = "GliderButton";
            this.GliderButton.Size = new System.Drawing.Size(74, 23);
            this.GliderButton.TabIndex = 12;
            this.GliderButton.Text = "Glider";
            this.GliderButton.UseVisualStyleBackColor = true;
            this.GliderButton.Click += new System.EventHandler(this.GliderButton_Click);
            // 
            // GunButton
            // 
            this.GunButton.Location = new System.Drawing.Point(12, 162);
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
            this.PresetLabel.Location = new System.Drawing.Point(26, 59);
            this.PresetLabel.Name = "PresetLabel";
            this.PresetLabel.Size = new System.Drawing.Size(42, 13);
            this.PresetLabel.TabIndex = 15;
            this.PresetLabel.Text = "Presets";
            // 
            // BlinkersButton
            // 
            this.BlinkersButton.Location = new System.Drawing.Point(12, 75);
            this.BlinkersButton.Name = "BlinkersButton";
            this.BlinkersButton.Size = new System.Drawing.Size(74, 23);
            this.BlinkersButton.TabIndex = 16;
            this.BlinkersButton.Text = "Blinkers";
            this.BlinkersButton.UseVisualStyleBackColor = true;
            this.BlinkersButton.Click += new System.EventHandler(this.BlinkersButton_Click);
            // 
            // AcornButton
            // 
            this.AcornButton.Location = new System.Drawing.Point(12, 104);
            this.AcornButton.Name = "AcornButton";
            this.AcornButton.Size = new System.Drawing.Size(74, 23);
            this.AcornButton.TabIndex = 17;
            this.AcornButton.Text = "Acorn";
            this.AcornButton.UseVisualStyleBackColor = true;
            this.AcornButton.Click += new System.EventHandler(this.AcornButton_Click);
            // 
            // BigBlinkersButton
            // 
            this.BigBlinkersButton.Location = new System.Drawing.Point(12, 426);
            this.BigBlinkersButton.Name = "BigBlinkersButton";
            this.BigBlinkersButton.Size = new System.Drawing.Size(74, 23);
            this.BigBlinkersButton.TabIndex = 18;
            this.BigBlinkersButton.Text = "Blinkers";
            this.BigBlinkersButton.UseVisualStyleBackColor = true;
            this.BigBlinkersButton.Click += new System.EventHandler(this.BigBlinkersButton_Click);
            // 
            // BigBoardLabel
            // 
            this.BigBoardLabel.AutoSize = true;
            this.BigBoardLabel.Location = new System.Drawing.Point(20, 399);
            this.BigBoardLabel.Name = "BigBoardLabel";
            this.BigBoardLabel.Size = new System.Drawing.Size(50, 13);
            this.BigBoardLabel.TabIndex = 19;
            this.BigBoardLabel.Text = "BigBoard";
            // 
            // BigAcornButton
            // 
            this.BigAcornButton.Location = new System.Drawing.Point(12, 455);
            this.BigAcornButton.Name = "BigAcornButton";
            this.BigAcornButton.Size = new System.Drawing.Size(74, 23);
            this.BigAcornButton.TabIndex = 22;
            this.BigAcornButton.Text = "Acorn";
            this.BigAcornButton.UseVisualStyleBackColor = true;
            this.BigAcornButton.Click += new System.EventHandler(this.BigAcornButton_Click);
            // 
            // PromptButton
            // 
            this.PromptButton.Location = new System.Drawing.Point(12, 489);
            this.PromptButton.Name = "PromptButton";
            this.PromptButton.Size = new System.Drawing.Size(74, 23);
            this.PromptButton.TabIndex = 23;
            this.PromptButton.Text = "Prompt";
            this.PromptButton.UseVisualStyleBackColor = true;
            this.PromptButton.Click += new System.EventHandler(this.PromptButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 542);
            this.Controls.Add(this.PromptButton);
            this.Controls.Add(this.BigAcornButton);
            this.Controls.Add(this.BigBoardLabel);
            this.Controls.Add(this.BigBlinkersButton);
            this.Controls.Add(this.AcornButton);
            this.Controls.Add(this.BlinkersButton);
            this.Controls.Add(this.PresetLabel);
            this.Controls.Add(this.GunButton);
            this.Controls.Add(this.GliderButton);
            this.Controls.Add(this.StepTimePicker);
            this.Controls.Add(this.StepTimeLabel);
            this.Controls.Add(this.RenderTarget);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CGoL";
            ((System.ComponentModel.ISupportInitialize)(this.RenderTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepTimePicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox RenderTarget;
        private System.Windows.Forms.Timer SimulationTimer;
        private System.Windows.Forms.Label StepTimeLabel;
        private System.Windows.Forms.NumericUpDown StepTimePicker;
        private System.Windows.Forms.Button GliderButton;
        private System.Windows.Forms.Button GunButton;
        private System.Windows.Forms.Label PresetLabel;
        private System.Windows.Forms.Button BlinkersButton;
        private System.Windows.Forms.Button AcornButton;
        private System.Windows.Forms.Button BigBlinkersButton;
        private System.Windows.Forms.Label BigBoardLabel;
        private System.Windows.Forms.Button BigAcornButton;
        private System.Windows.Forms.Button PromptButton;
    }
}

