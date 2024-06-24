namespace mywinform
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            connectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            tabPage3 = new TabPage();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(80, 24);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(98, 24);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 422);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 389);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "D0000";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(786, 383);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 389);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "D0100";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(786, 383);
            dataGridView2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(textBox2);
            tabPage3.Controls.Add(textBox1);
            tabPage3.Controls.Add(button1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 389);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "test";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(166, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(126, 27);
            textBox1.TabIndex = 1;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(327, 28);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "쓰기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form2";
            Text = "PLCServer";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataGridView1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridView2;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
