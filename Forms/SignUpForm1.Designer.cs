
namespace CoorseProdject01
{
    partial class SignUpForm
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
            this.UserList = new System.Windows.Forms.ListBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.SignUpButton = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.userCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.userCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UserList
            // 
            this.UserList.BackColor = System.Drawing.Color.Ivory;
            this.UserList.FormattingEnabled = true;
            this.UserList.Location = new System.Drawing.Point(127, 91);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(206, 43);
            this.UserList.TabIndex = 0;
            this.UserList.SelectedIndexChanged += new System.EventHandler(this.UserList_SelectedIndexChanged);
            // 
            // PasswordBox
            // 
            this.PasswordBox.BackColor = System.Drawing.Color.Ivory;
            this.PasswordBox.Location = new System.Drawing.Point(127, 208);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(206, 20);
            this.PasswordBox.TabIndex = 1;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // SignUpButton
            // 
            this.SignUpButton.BackColor = System.Drawing.Color.LightBlue;
            this.SignUpButton.Font = new System.Drawing.Font("Segoe Print", 15F);
            this.SignUpButton.ForeColor = System.Drawing.Color.Black;
            this.SignUpButton.Location = new System.Drawing.Point(155, 251);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(156, 54);
            this.SignUpButton.TabIndex = 2;
            this.SignUpButton.Text = "Увiйти";
            this.SignUpButton.UseVisualStyleBackColor = false;
            this.SignUpButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoginLabel.Font = new System.Drawing.Font("Segoe Print", 20F);
            this.LoginLabel.Location = new System.Drawing.Point(184, 41);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(95, 47);
            this.LoginLabel.TabIndex = 3;
            this.LoginLabel.Text = "Логiн";
            this.LoginLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("Segoe Print", 20F);
            this.PasswordLabel.Location = new System.Drawing.Point(173, 158);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(120, 47);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Пароль";
            // 
            // userCollectionBindingSource
            // 
            this.userCollectionBindingSource.DataSource = typeof(CoorseProdject01.Classes.UserCollection);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.BackgroundImage = global::CoorseProdject01.Properties.Resources.old_paper_texture_vintage_for_background_43157_35;
            this.ClientSize = new System.Drawing.Size(461, 370);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.SignUpButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserList);
            this.Name = "SignUpForm";
            this.Text = "Форма входу";
            this.Load += new System.EventHandler(this.SignUpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.BindingSource userCollectionBindingSource;
    }
}

