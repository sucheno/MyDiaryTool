namespace My_Dairy
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private ToolStripMenuItem aboutMyDairyToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private IContainer components = null;
        private DateTimePicker dateTimePicker1;
        private string DateToOpen;
        private Button DeleteButton;
        private ToolStripMenuItem exitToolStripMenuItem;
        private FileStream fileObj;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Button GoButton;
        private Label label1;
        private Label label2;
        private MenuStrip menuStrip1;
        private MonthCalendar monthCalendar1;
        private FileAccess MyAccess = FileAccess.ReadWrite;
        private string MyFile;
        private FileMode MyModeOpen = FileMode.Open;
        private FileMode MyModeOpenCreate = FileMode.OpenOrCreate;
        private FileShare MyShare = FileShare.Inheritable;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private string PersonalFolder = "";
        private Button SaveButton;
        private Button SaveChangesButton;
        private TextBox textBox1;
        private Button WriteTodayButton;

        public Form1()
        {
            this.InitializeComponent();
        }

        private void aboutMyDairyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void aboutMyDiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://mydiary.suchenoguri.in");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.DateToOpen = this.dateTimePicker1.Value.Year.ToString() + this.dateTimePicker1.Value.Month.ToString() + this.dateTimePicker1.Value.Day.ToString();
                this.MyFile = this.DateToOpen;
                if (File.Exists(this.PersonalFolder + @"\Diary Data\" + this.MyFile + ".txt"))
                {
                    File.Delete(this.PersonalFolder + @"\Diary Data\" + this.MyFile + ".txt");
                }
                this.WriteTodayButton.Visible = true;
                this.SaveChangesButton.Visible = false;
                this.textBox1.Visible = false;
                this.DeleteButton.Visible = false;
                this.textBox1.Text = null;
                this.SaveButton.Visible = false;
            }
            catch
            {
                MessageBox.Show("Close and run as Administrator");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.start_over("Load");
            this.PersonalFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(this.PersonalFolder + @"\Diary Data"))
            {
                Directory.CreateDirectory(this.PersonalFolder + @"\Diary Data");
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.start_over("GoButton");
                this.DateToOpen = this.dateTimePicker1.Value.Year.ToString() + this.dateTimePicker1.Value.Month.ToString() + this.dateTimePicker1.Value.Day.ToString();
                this.MyFile = this.DateToOpen;
                if (File.Exists(this.PersonalFolder + @"\Diary Data\" + this.MyFile + ".txt"))
                {
                    this.fileObj = new FileStream(this.PersonalFolder + @"\Diary Data\" + this.MyFile + ".txt", this.MyModeOpen, this.MyAccess, this.MyShare);
                    byte[] buffer = new byte[this.fileObj.Length];
                    this.fileObj.Read(buffer, 0, (int) this.fileObj.Length);
                    this.textBox1.Text = Encoding.ASCII.GetString(buffer);
                    this.fileObj.Close();
                }
            }
            catch
            {
                MessageBox.Show("Close and run as Administrator");
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Form1));
            this.monthCalendar1 = new MonthCalendar();
            this.textBox1 = new TextBox();
            this.WriteTodayButton = new Button();
            this.SaveButton = new Button();
            this.SaveChangesButton = new Button();
            this.DeleteButton = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.dateTimePicker1 = new DateTimePicker();
            this.GoButton = new Button();
            this.menuStrip1 = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.optionsToolStripMenuItem = new ToolStripMenuItem();
            this.aboutMyDairyToolStripMenuItem = new ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.monthCalendar1.BackColor = Color.MediumPurple;
            this.monthCalendar1.Font = new Font("Chiller", 14f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.monthCalendar1.Location = new Point(0x1b, 0xc9);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            this.textBox1.Font = new Font("Comic Sans MS", 9f, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.textBox1.Location = new Point(0x133, 0x62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Size = new Size(0x188, 0xf1);
            this.textBox1.TabIndex = 3;
            this.WriteTodayButton.Location = new Point(0x133, 0x45);
            this.WriteTodayButton.Name = "WriteTodayButton";
            this.WriteTodayButton.Size = new Size(0x4b, 0x17);
            this.WriteTodayButton.TabIndex = 4;
            this.WriteTodayButton.Text = "Write Today";
            this.WriteTodayButton.UseVisualStyleBackColor = true;
            this.WriteTodayButton.Click += new EventHandler(this.WriteTodayButton_Click);
            this.SaveButton.Location = new Point(370, 0x159);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(0x4b, 0x17);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
            this.SaveChangesButton.Location = new Point(0x1d8, 0x159);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Size = new Size(0x5e, 0x17);
            this.SaveChangesButton.TabIndex = 6;
            this.SaveChangesButton.Text = "Save changes";
            this.SaveChangesButton.UseVisualStyleBackColor = true;
            this.SaveChangesButton.Click += new EventHandler(this.SaveChangesButton_Click);
            this.DeleteButton.Location = new Point(0x24b, 0x159);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new Size(0x4b, 0x17);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new EventHandler(this.DeleteButton_Click);
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Location = new Point(12, 0x38);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x4c, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "View by Date..";
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.Location = new Point(15, 0xb0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Calendar..";
            this.dateTimePicker1.CalendarFont = new Font("Comic Sans MS", 15.75f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dateTimePicker1.Font = new Font("Chiller", 14f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.dateTimePicker1.Location = new Point(0x1b, 0x53);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(0xe3, 0x1d);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new EventHandler(this.dateTimePicker1_ValueChanged);
            this.GoButton.BackColor = Color.Transparent;
            this.GoButton.Location = new Point(0x60, 0x76);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new Size(0x4b, 0x17);
            this.GoButton.TabIndex = 10;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = false;
            this.GoButton.Click += new EventHandler(this.GoButton_Click);
            this.menuStrip1.BackColor = Color.Transparent;
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.fileToolStripMenuItem, this.optionsToolStripMenuItem });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x2d6, 0x18);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.exitToolStripMenuItem });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new Size(0x25, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(0x5c, 0x16);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.aboutMyDairyToolStripMenuItem, this.checkForUpdatesToolStripMenuItem });
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new Size(0x3d, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.aboutMyDairyToolStripMenuItem.Name = "aboutMyDairyToolStripMenuItem";
            this.aboutMyDairyToolStripMenuItem.Size = new Size(170, 0x16);
            this.aboutMyDairyToolStripMenuItem.Text = "About My Diary";
            this.aboutMyDairyToolStripMenuItem.Click += new EventHandler(this.aboutMyDairyToolStripMenuItem_Click);
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new Size(170, 0x16);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.checkForUpdatesToolStripMenuItem.Click += new EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = (Image) manager.GetObject("$this.BackgroundImage");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(0x2d6, 0x18e);
            base.Controls.Add(this.GoButton);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.DeleteButton);
            base.Controls.Add(this.SaveChangesButton);
            base.Controls.Add(this.SaveButton);
            base.Controls.Add(this.WriteTodayButton);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.monthCalendar1);
            base.Controls.Add(this.dateTimePicker1);
            base.Controls.Add(this.menuStrip1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MainMenuStrip = this.menuStrip1;
            base.MaximizeBox = false;
            base.Name = "Form1";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "My Diary";
            base.Load += new EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.start_over("SaveButton");
                this.fileObj = new FileStream(this.PersonalFolder + @"\Diary Data\" + this.MyFile + ".txt", FileMode.Create, this.MyAccess, this.MyShare);
                this.fileObj.Write(Encoding.ASCII.GetBytes(this.textBox1.Text), 0, this.textBox1.Text.Length);
                this.fileObj.Close();
                this.WriteTodayButton.Visible = true;
                this.SaveButton.Visible = false;
                this.textBox1.Visible = false;
            }
            catch
            {
                MessageBox.Show("Close and run as Administrator");
            }
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.DateToOpen = this.dateTimePicker1.Value.Year.ToString() + this.dateTimePicker1.Value.Month.ToString() + this.dateTimePicker1.Value.Day.ToString();
                this.MyFile = this.DateToOpen;
                this.fileObj = new FileStream(this.PersonalFolder + @"\Diary Data\" + this.MyFile + ".txt", FileMode.Create, this.MyAccess, this.MyShare);
                this.fileObj.Write(Encoding.ASCII.GetBytes(this.textBox1.Text), 0, this.textBox1.Text.Length);
                this.fileObj.Close();
                this.WriteTodayButton.Visible = true;
                this.SaveChangesButton.Visible = false;
                this.textBox1.Visible = false;
                this.DeleteButton.Visible = false;
            }
            catch
            {
                MessageBox.Show("Close and run as Administrator");
            }
        }

        private void start_over(string source)
        {
            if (source == "Load")
            {
                this.SaveChangesButton.Visible = false;
                base.MaximizeBox = false;
                this.SaveChangesButton.Visible = false;
                this.WriteTodayButton.Visible = true;
                this.textBox1.Visible = false;
                this.SaveButton.Visible = false;
                this.DeleteButton.Visible = false;
            }
            else if (source == "GoButton")
            {
                this.WriteTodayButton.Visible = true;
                this.textBox1.Visible = true;
                this.SaveButton.Visible = false;
                this.SaveChangesButton.Visible = true;
                this.DeleteButton.Visible = true;
                this.textBox1.Text = null;
            }
            else if (source == "SaveButton")
            {
                this.textBox1.Visible = false;
                this.SaveButton.Visible = false;
                this.WriteTodayButton.Visible = true;
                this.SaveChangesButton.Visible = false;
                this.DeleteButton.Visible = false;
            }
            else if (source == "WriteTodayButton")
            {
                this.WriteTodayButton.Visible = false;
                this.textBox1.Visible = true;
                this.SaveButton.Visible = true;
                this.SaveChangesButton.Visible = false;
                this.DeleteButton.Visible = true;
            }
        }

        private void WriteTodayButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.start_over("WriteTodayButton");
                this.dateTimePicker1.Value = DateTime.Now;
                string str = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                this.MyFile = str;
                if (File.Exists(this.PersonalFolder + @"\Diary Data\" + str + ".txt"))
                {
                    this.fileObj = new FileStream(this.PersonalFolder + @"\Diary Data\" + this.MyFile + ".txt", this.MyModeOpen, this.MyAccess, this.MyShare);
                    byte[] buffer = new byte[this.fileObj.Length];
                    this.fileObj.Read(buffer, 0, (int) this.fileObj.Length);
                    this.textBox1.Text = Encoding.ASCII.GetString(buffer);
                    this.fileObj.Close();
                }
            }
            catch
            {
                MessageBox.Show("Close and run as Administrator");
            }
        }
    }
}

