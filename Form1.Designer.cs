namespace iridiJSONParser4XilicaApp
{
    partial class XilicaCommandsParser
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
            inputFileSystemButton = new Button();
            inputFilePathTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            outputFilePathTextBox = new TextBox();
            outputFileSystemButton = new Button();
            parseButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            fileNameTextBox = new TextBox();
            label3 = new Label();
            txtFileCheckBox = new CheckBox();
            successLabel = new Label();
            faultLabel = new Label();
            SuspendLayout();
            // 
            // inputFileSystemButton
            // 
            inputFileSystemButton.Location = new Point(319, 117);
            inputFileSystemButton.Name = "inputFileSystemButton";
            inputFileSystemButton.Size = new Size(75, 23);
            inputFileSystemButton.TabIndex = 0;
            inputFileSystemButton.Text = "обзор";
            inputFileSystemButton.UseVisualStyleBackColor = true;
            inputFileSystemButton.Click += filePathButton_Click;
            // 
            // inputFilePathTextBox
            // 
            inputFilePathTextBox.Location = new Point(77, 117);
            inputFilePathTextBox.Name = "inputFilePathTextBox";
            inputFilePathTextBox.PlaceholderText = "Укажите файл...";
            inputFilePathTextBox.Size = new Size(236, 23);
            inputFilePathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 99);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 2;
            label1.Text = "Путь к документу Excel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(438, 100);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 5;
            label2.Text = "Сохранить в";
            // 
            // outputFilePathTextBox
            // 
            outputFilePathTextBox.Location = new Point(438, 118);
            outputFilePathTextBox.Name = "outputFilePathTextBox";
            outputFilePathTextBox.PlaceholderText = "Укажите путь...";
            outputFilePathTextBox.Size = new Size(236, 23);
            outputFilePathTextBox.TabIndex = 4;
            // 
            // outputFileSystemButton
            // 
            outputFileSystemButton.Location = new Point(680, 118);
            outputFileSystemButton.Name = "outputFileSystemButton";
            outputFileSystemButton.Size = new Size(75, 23);
            outputFileSystemButton.TabIndex = 3;
            outputFileSystemButton.Text = "обзор";
            outputFileSystemButton.UseVisualStyleBackColor = true;
            outputFileSystemButton.Click += folderPathButton_Click;
            // 
            // parseButton
            // 
            parseButton.Font = new Font("Segoe UI", 20F);
            parseButton.Location = new Point(332, 239);
            parseButton.Name = "parseButton";
            parseButton.Size = new Size(162, 120);
            parseButton.TabIndex = 6;
            parseButton.Text = "Создать файл";
            parseButton.UseVisualStyleBackColor = true;
            parseButton.Click += parseButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.Location = new Point(438, 167);
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.PlaceholderText = "Имя...";
            fileNameTextBox.Size = new Size(236, 23);
            fileNameTextBox.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(438, 149);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 9;
            label3.Text = "Имя json файла ";
            // 
            // txtFileCheckBox
            // 
            txtFileCheckBox.AutoSize = true;
            txtFileCheckBox.Location = new Point(441, 208);
            txtFileCheckBox.Name = "txtFileCheckBox";
            txtFileCheckBox.Size = new Size(236, 19);
            txtFileCheckBox.TabIndex = 10;
            txtFileCheckBox.Text = "Создать текстовый файл с командами";
            txtFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // successLabel
            // 
            successLabel.AutoSize = true;
            successLabel.BackColor = Color.FromArgb(192, 255, 192);
            successLabel.Font = new Font("Segoe UI", 15F);
            successLabel.ForeColor = Color.Black;
            successLabel.Location = new Point(309, 362);
            successLabel.Name = "successLabel";
            successLabel.Size = new Size(214, 28);
            successLabel.TabIndex = 11;
            successLabel.Text = "Файл успешно создан";
            successLabel.Visible = false;
            // 
            // faultLabel
            // 
            faultLabel.AutoSize = true;
            faultLabel.BackColor = Color.FromArgb(255, 192, 192);
            faultLabel.Font = new Font("Segoe UI", 15F);
            faultLabel.ForeColor = Color.Black;
            faultLabel.Location = new Point(280, 362);
            faultLabel.Name = "faultLabel";
            faultLabel.Size = new Size(87, 28);
            faultLabel.TabIndex = 12;
            faultLabel.Text = "Ошибка";
            faultLabel.Visible = false;
            // 
            // XilicaCommandsParser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(faultLabel);
            Controls.Add(successLabel);
            Controls.Add(txtFileCheckBox);
            Controls.Add(label3);
            Controls.Add(fileNameTextBox);
            Controls.Add(parseButton);
            Controls.Add(label2);
            Controls.Add(outputFilePathTextBox);
            Controls.Add(outputFileSystemButton);
            Controls.Add(label1);
            Controls.Add(inputFilePathTextBox);
            Controls.Add(inputFileSystemButton);
            Name = "XilicaCommandsParser";
            Text = "XilicaCommandsParser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button inputFileSystemButton;
        private TextBox inputFilePathTextBox;
        private Label label1;
        private Label label2;
        private TextBox outputFilePathTextBox;
        private Button outputFileSystemButton;
        private Button parseButton;
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox fileNameTextBox;
        private Label label3;
        private CheckBox txtFileCheckBox;
        private Label successLabel;
        private Label faultLabel;
    }
}
