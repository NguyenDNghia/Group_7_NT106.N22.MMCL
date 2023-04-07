namespace Server
{
    partial class Server
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtbox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.txtport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cnt = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(648, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 46);
            this.button1.TabIndex = 8;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbox
            // 
            this.txtbox.Location = new System.Drawing.Point(32, 383);
            this.txtbox.Multiline = true;
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(610, 46);
            this.txtbox.TabIndex = 7;
            this.txtbox.TextChanged += new System.EventHandler(this.txtbox_TextChanged);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(32, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(701, 340);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(850, 24);
            this.txtport.Multiline = true;
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(166, 29);
            this.txtport.TabIndex = 9;
            this.txtport.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(763, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "PORT";
            // 
            // cnt
            // 
            this.cnt.Location = new System.Drawing.Point(850, 73);
            this.cnt.Name = "cnt";
            this.cnt.Size = new System.Drawing.Size(166, 32);
            this.cnt.TabIndex = 13;
            this.cnt.Text = "Connect";
            this.cnt.UseVisualStyleBackColor = true;
            this.cnt.Click += new System.EventHandler(this.cnt_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(850, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 37);
            this.button2.TabIndex = 14;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Server
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtbox);
            this.Controls.Add(this.listView1);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cnt;
        private System.Windows.Forms.Button button2;
    }
}

