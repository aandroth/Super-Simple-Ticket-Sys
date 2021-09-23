
namespace TicketSys
{
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
            this.TicketSysLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TicketSysLabel
            // 
            this.TicketSysLabel.AutoSize = true;
            this.TicketSysLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TicketSysLabel.Location = new System.Drawing.Point(252, 56);
            this.TicketSysLabel.Name = "TicketSysLabel";
            this.TicketSysLabel.Size = new System.Drawing.Size(324, 76);
            this.TicketSysLabel.TabIndex = 0;
            this.TicketSysLabel.Text = "TicketSys";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 87);
            this.button1.TabIndex = 1;
            this.button1.Text = "Create Tickets";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(324, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 110);
            this.button2.TabIndex = 2;
            this.button2.Text = "Search Tickets";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 744);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TicketSysLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TicketSysLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

