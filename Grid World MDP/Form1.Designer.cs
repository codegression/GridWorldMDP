namespace Grid_World_MDP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cmd10Steps = new System.Windows.Forms.Button();
            this.cmdOneStep = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtReward = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picUp = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.picDown = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(100, 61);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(65, 20);
            this.txtDiscount.TabIndex = 18;
            this.txtDiscount.Text = "0.9";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(21, 64);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(52, 13);
            this.lblDiscount.TabIndex = 17;
            this.lblDiscount.Text = "Discount:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(138, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(93, 17);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.Text = "Policy iteration";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(22, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 17);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Value iteration";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // cmd10Steps
            // 
            this.cmd10Steps.Location = new System.Drawing.Point(659, 41);
            this.cmd10Steps.Name = "cmd10Steps";
            this.cmd10Steps.Size = new System.Drawing.Size(104, 36);
            this.cmd10Steps.TabIndex = 21;
            this.cmd10Steps.Text = "Iterate 10 steps";
            this.cmd10Steps.UseVisualStyleBackColor = true;
            this.cmd10Steps.Click += new System.EventHandler(this.cmd10Steps_Click);
            // 
            // cmdOneStep
            // 
            this.cmdOneStep.Location = new System.Drawing.Point(484, 41);
            this.cmdOneStep.Name = "cmdOneStep";
            this.cmdOneStep.Size = new System.Drawing.Size(104, 36);
            this.cmdOneStep.TabIndex = 20;
            this.cmdOneStep.Text = "Iterate 1 step";
            this.cmdOneStep.UseVisualStyleBackColor = true;
            this.cmdOneStep.Click += new System.EventHandler(this.cmdOneStep_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(318, 41);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(104, 36);
            this.cmdReset.TabIndex = 19;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(398, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "Step #0";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(215, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 337);
            this.panel1.TabIndex = 23;
            // 
            // txtReward
            // 
            this.txtReward.Location = new System.Drawing.Point(100, 104);
            this.txtReward.Name = "txtReward";
            this.txtReward.Size = new System.Drawing.Size(65, 20);
            this.txtReward.TabIndex = 25;
            this.txtReward.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Living reward:";
            // 
            // picUp
            // 
            this.picUp.Image = global::Grid_World_MDP.Properties.Resources.Actions_arrow_up_icon;
            this.picUp.Location = new System.Drawing.Point(833, 431);
            this.picUp.Name = "picUp";
            this.picUp.Size = new System.Drawing.Size(96, 88);
            this.picUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picUp.TabIndex = 28;
            this.picUp.TabStop = false;
            this.picUp.Visible = false;
            // 
            // picRight
            // 
            this.picRight.Image = global::Grid_World_MDP.Properties.Resources.Actions_arrow_right_icon;
            this.picRight.Location = new System.Drawing.Point(831, 180);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(98, 49);
            this.picRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picRight.TabIndex = 27;
            this.picRight.TabStop = false;
            this.picRight.Visible = false;
            // 
            // picLeft
            // 
            this.picLeft.Image = global::Grid_World_MDP.Properties.Resources.Actions_arrow_left_icon;
            this.picLeft.Location = new System.Drawing.Point(781, 294);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(79, 70);
            this.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLeft.TabIndex = 26;
            this.picLeft.TabStop = false;
            this.picLeft.Visible = false;
            // 
            // picDown
            // 
            this.picDown.Image = global::Grid_World_MDP.Properties.Resources.Actions_arrow_down_icon;
            this.picDown.Location = new System.Drawing.Point(717, 440);
            this.picDown.Name = "picDown";
            this.picDown.Size = new System.Drawing.Size(70, 62);
            this.picDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picDown.TabIndex = 26;
            this.picDown.TabStop = false;
            this.picDown.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(991, 625);
            this.Controls.Add(this.picUp);
            this.Controls.Add(this.picRight);
            this.Controls.Add(this.picLeft);
            this.Controls.Add(this.picDown);
            this.Controls.Add(this.txtReward);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmd10Steps);
            this.Controls.Add(this.cmdOneStep);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Grid World - Markov Decision Process";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button cmd10Steps;
        private System.Windows.Forms.Button cmdOneStep;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtReward;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picDown;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picUp;
    }
}

