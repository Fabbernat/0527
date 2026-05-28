namespace RealEstateGUI
{
    partial class Ingatlanok
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
            sellersListBox = new ListBox();
            sellerNameTextLabel = new Label();
            label2 = new Label();
            sellerPhoneTextLabel = new Label();
            sellerPhoneValueLabel = new Label();
            adCountTextLabel = new Label();
            adCountValueLabel = new Label();
            loadAdsButton = new Button();
            mainTableLayoutPanel = new TableLayoutPanel();
            detailsTableLayoutPanel = new TableLayoutPanel();
            mainTableLayoutPanel.SuspendLayout();
            detailsTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sellersListBox
            // 
            sellersListBox.Dock = DockStyle.Fill;
            sellersListBox.FormattingEnabled = true;
            sellersListBox.ItemHeight = 15;
            sellersListBox.Location = new Point(3, 3);
            sellersListBox.Name = "sellersListBox";
            sellersListBox.Size = new Size(394, 444);
            sellersListBox.TabIndex = 0;
            sellersListBox.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // sellerNameTextLabel
            // 
            sellerNameTextLabel.AutoSize = true;
            sellerNameTextLabel.Location = new Point(3, 0);
            sellerNameTextLabel.Name = "sellerNameTextLabel";
            sellerNameTextLabel.Size = new Size(67, 15);
            sellerNameTextLabel.TabIndex = 1;
            sellerNameTextLabel.Text = "Eladó neve:";
            sellerNameTextLabel.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 0);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // sellerPhoneTextLabel
            // 
            sellerPhoneTextLabel.AutoSize = true;
            sellerPhoneTextLabel.Location = new Point(3, 106);
            sellerPhoneTextLabel.Name = "sellerPhoneTextLabel";
            sellerPhoneTextLabel.Size = new Size(112, 15);
            sellerPhoneTextLabel.TabIndex = 3;
            sellerPhoneTextLabel.Text = "Eladó telefonszáma:";
            // 
            // sellerPhoneValueLabel
            // 
            sellerPhoneValueLabel.AutoSize = true;
            sellerPhoneValueLabel.Location = new Point(200, 106);
            sellerPhoneValueLabel.Name = "sellerPhoneValueLabel";
            sellerPhoneValueLabel.Size = new Size(38, 15);
            sellerPhoneValueLabel.TabIndex = 4;
            sellerPhoneValueLabel.Text = "label4";
            // 
            // adCountTextLabel
            // 
            adCountTextLabel.AutoSize = true;
            adCountTextLabel.Location = new Point(3, 306);
            adCountTextLabel.Name = "adCountTextLabel";
            adCountTextLabel.Size = new Size(102, 15);
            adCountTextLabel.TabIndex = 5;
            adCountTextLabel.Text = "Hirdetések száma:";
            // 
            // adCountValueLabel
            // 
            adCountValueLabel.AutoSize = true;
            adCountValueLabel.Location = new Point(200, 306);
            adCountValueLabel.Name = "adCountValueLabel";
            adCountValueLabel.Size = new Size(13, 15);
            adCountValueLabel.TabIndex = 6;
            adCountValueLabel.Text = "0";
            // 
            // loadAdsButton
            // 
            loadAdsButton.Location = new Point(3, 215);
            loadAdsButton.Name = "loadAdsButton";
            loadAdsButton.Size = new Size(191, 23);
            loadAdsButton.TabIndex = 8;
            loadAdsButton.Text = "Hirdetések betöltése";
            loadAdsButton.UseVisualStyleBackColor = true;
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.ColumnCount = 2;
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTableLayoutPanel.Controls.Add(sellersListBox, 0, 0);
            mainTableLayoutPanel.Controls.Add(detailsTableLayoutPanel, 1, 0);
            mainTableLayoutPanel.Dock = DockStyle.Fill;
            mainTableLayoutPanel.Location = new Point(0, 0);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 1;
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainTableLayoutPanel.Size = new Size(800, 450);
            mainTableLayoutPanel.TabIndex = 9;
            // 
            // detailsTableLayoutPanel
            // 
            detailsTableLayoutPanel.ColumnCount = 2;
            detailsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            detailsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            detailsTableLayoutPanel.Controls.Add(adCountValueLabel, 1, 3);
            detailsTableLayoutPanel.Controls.Add(loadAdsButton, 0, 2);
            detailsTableLayoutPanel.Controls.Add(adCountTextLabel, 0, 3);
            detailsTableLayoutPanel.Controls.Add(sellerNameTextLabel, 0, 0);
            detailsTableLayoutPanel.Controls.Add(label2, 1, 0);
            detailsTableLayoutPanel.Controls.Add(sellerPhoneTextLabel, 0, 1);
            detailsTableLayoutPanel.Controls.Add(sellerPhoneValueLabel, 1, 1);
            detailsTableLayoutPanel.Dock = DockStyle.Fill;
            detailsTableLayoutPanel.Location = new Point(403, 3);
            detailsTableLayoutPanel.Name = "detailsTableLayoutPanel";
            detailsTableLayoutPanel.RowCount = 4;
            detailsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            detailsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            detailsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
            detailsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 138F));
            detailsTableLayoutPanel.Size = new Size(394, 444);
            detailsTableLayoutPanel.TabIndex = 1;
            // 
            // Ingatlanok
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainTableLayoutPanel);
            Name = "Ingatlanok";
            Text = "Ingatlanok";
            Load += MainForm_Load;
            mainTableLayoutPanel.ResumeLayout(false);
            detailsTableLayoutPanel.ResumeLayout(false);
            detailsTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox sellersListBox;
        private Label sellerNameTextLabel;
        private Label label2;
        private Label sellerPhoneTextLabel;
        private Label sellerPhoneValueLabel;
        private Label adCountTextLabel;
        private Label adCountValueLabel;
        private Button loadAdsButton;
        private TableLayoutPanel mainTableLayoutPanel;
        private TableLayoutPanel detailsTableLayoutPanel;
    }
}
