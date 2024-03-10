
namespace game
{
    partial class lifegame
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lifegame));
            this.startButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.onestepButton = new System.Windows.Forms.Button();
            this.refr = new System.Windows.Forms.Timer(this.components);
            this.timerDelay_slider = new System.Windows.Forms.TrackBar();
            this.timerDelay_sliderValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timerDelay_slider)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 8);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(87, 38);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.start_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // onestepButton
            // 
            this.onestepButton.Location = new System.Drawing.Point(105, 8);
            this.onestepButton.Name = "onestepButton";
            this.onestepButton.Size = new System.Drawing.Size(87, 38);
            this.onestepButton.TabIndex = 1;
            this.onestepButton.Text = "One step 0";
            this.onestepButton.UseVisualStyleBackColor = true;
            this.onestepButton.Click += new System.EventHandler(this.onestepButton_Click);
            // 
            // refr
            // 
            this.refr.Interval = 2000;
            // 
            // timerDelay_slider
            // 
            this.timerDelay_slider.Location = new System.Drawing.Point(292, 1);
            this.timerDelay_slider.Maximum = 10000;
            this.timerDelay_slider.Name = "timerDelay_slider";
            this.timerDelay_slider.Size = new System.Drawing.Size(230, 45);
            this.timerDelay_slider.TabIndex = 2;
            this.timerDelay_slider.Scroll += new System.EventHandler(this.timerDelay_slider_Scroll);
            // 
            // timerDelay_sliderValue
            // 
            this.timerDelay_sliderValue.AutoSize = true;
            this.timerDelay_sliderValue.Location = new System.Drawing.Point(528, 13);
            this.timerDelay_sliderValue.Name = "timerDelay_sliderValue";
            this.timerDelay_sliderValue.Size = new System.Drawing.Size(29, 13);
            this.timerDelay_sliderValue.TabIndex = 3;
            this.timerDelay_sliderValue.Text = "0 ms";
            // 
            // lifegame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 741);
            this.Controls.Add(this.timerDelay_sliderValue);
            this.Controls.Add(this.timerDelay_slider);
            this.Controls.Add(this.onestepButton);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "lifegame";
            this.Text = "lifegame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.timerDelay_slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button onestepButton;
        private System.Windows.Forms.Timer refr;
        private System.Windows.Forms.TrackBar timerDelay_slider;
        private System.Windows.Forms.Label timerDelay_sliderValue;
    }
}

