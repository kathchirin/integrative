namespace Water_Billing_System
{
    partial class BillingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClientRecord = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.dgvPaid = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnPaid = new System.Windows.Forms.Button();
            this.dgvUnpaid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbYear = new System.Windows.Forms.Label();
            this.LbMonth = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LbBalance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LbName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnPrintReceipt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSearchClient = new System.Windows.Forms.Button();
            this.TbxSearchClient = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.RtbReceipt = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientRecord)).BeginInit();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "BILLING FORM";
            // 
            // dgvClientRecord
            // 
            this.dgvClientRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientRecord.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientRecord.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientRecord.Location = new System.Drawing.Point(15, 233);
            this.dgvClientRecord.Margin = new System.Windows.Forms.Padding(4);
            this.dgvClientRecord.Name = "dgvClientRecord";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientRecord.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClientRecord.RowHeadersWidth = 51;
            this.dgvClientRecord.Size = new System.Drawing.Size(567, 439);
            this.dgvClientRecord.TabIndex = 2;
            this.dgvClientRecord.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientRecord_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(173, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "CLIENTS RECORD";
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Panel.Controls.Add(this.dgvPaid);
            this.Panel.Controls.Add(this.label11);
            this.Panel.Controls.Add(this.BtnPaid);
            this.Panel.Controls.Add(this.dgvUnpaid);
            this.Panel.Controls.Add(this.panel1);
            this.Panel.Location = new System.Drawing.Point(587, 124);
            this.Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(567, 548);
            this.Panel.TabIndex = 4;
            // 
            // dgvPaid
            // 
            this.dgvPaid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaid.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaid.Location = new System.Drawing.Point(24, 423);
            this.dgvPaid.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPaid.Name = "dgvPaid";
            this.dgvPaid.RowHeadersWidth = 51;
            this.dgvPaid.Size = new System.Drawing.Size(521, 106);
            this.dgvPaid.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 398);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 21);
            this.label11.TabIndex = 3;
            this.label11.Text = "Paid Records";
            // 
            // BtnPaid
            // 
            this.BtnPaid.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPaid.Location = new System.Drawing.Point(127, 339);
            this.BtnPaid.Margin = new System.Windows.Forms.Padding(4);
            this.BtnPaid.Name = "BtnPaid";
            this.BtnPaid.Size = new System.Drawing.Size(316, 38);
            this.BtnPaid.TabIndex = 2;
            this.BtnPaid.Text = "PAY";
            this.BtnPaid.UseVisualStyleBackColor = true;
            this.BtnPaid.Click += new System.EventHandler(this.BtnPaid_Click);
            // 
            // dgvUnpaid
            // 
            this.dgvUnpaid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnpaid.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvUnpaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnpaid.Location = new System.Drawing.Point(24, 226);
            this.dgvUnpaid.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUnpaid.Name = "dgvUnpaid";
            this.dgvUnpaid.RowHeadersWidth = 51;
            this.dgvUnpaid.Size = new System.Drawing.Size(521, 105);
            this.dgvUnpaid.TabIndex = 1;
            this.dgvUnpaid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnpaid_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LbYear);
            this.panel1.Controls.Add(this.LbMonth);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.LbBalance);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.LbName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(24, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 192);
            this.panel1.TabIndex = 0;
            // 
            // LbYear
            // 
            this.LbYear.AutoSize = true;
            this.LbYear.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbYear.Location = new System.Drawing.Point(80, 127);
            this.LbYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbYear.Name = "LbYear";
            this.LbYear.Size = new System.Drawing.Size(43, 24);
            this.LbYear.TabIndex = 12;
            this.LbYear.Text = "N/A";
            // 
            // LbMonth
            // 
            this.LbMonth.AutoSize = true;
            this.LbMonth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbMonth.Location = new System.Drawing.Point(99, 90);
            this.LbMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbMonth.Name = "LbMonth";
            this.LbMonth.Size = new System.Drawing.Size(43, 24);
            this.LbMonth.TabIndex = 11;
            this.LbMonth.Text = "N/A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 127);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 24);
            this.label10.TabIndex = 6;
            this.label10.Text = "Year:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 92);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Month:";
            // 
            // LbBalance
            // 
            this.LbBalance.AutoSize = true;
            this.LbBalance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbBalance.Location = new System.Drawing.Point(223, 53);
            this.LbBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbBalance.Name = "LbBalance";
            this.LbBalance.Size = new System.Drawing.Size(21, 24);
            this.LbBalance.TabIndex = 4;
            this.LbBalance.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(201, 53);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 24);
            this.label7.TabIndex = 3;
            this.label7.Text = "₱";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 24);
            this.label6.TabIndex = 2;
            this.label6.Text = "Unpaind Balance:";
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbName.Location = new System.Drawing.Point(101, 18);
            this.LbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(35, 24);
            this.LbName.TabIndex = 1;
            this.LbName.Text = "NA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name:";
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.Image = global::Water_Billing_System.Properties.Resources.icons8_back_30;
            this.BtnBack.Location = new System.Drawing.Point(7, 698);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(55, 42);
            this.BtnBack.TabIndex = 5;
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            this.BtnBack.MouseLeave += new System.EventHandler(this.BtnBack_MouseLeave);
            this.BtnBack.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnBack_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "RECEIPT";
            // 
            // BtnPrintReceipt
            // 
            this.BtnPrintReceipt.Font = new System.Drawing.Font("Tahoma", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrintReceipt.Location = new System.Drawing.Point(1367, 680);
            this.BtnPrintReceipt.Margin = new System.Windows.Forms.Padding(4);
            this.BtnPrintReceipt.Name = "BtnPrintReceipt";
            this.BtnPrintReceipt.Size = new System.Drawing.Size(189, 36);
            this.BtnPrintReceipt.TabIndex = 8;
            this.BtnPrintReceipt.Text = "Print Receipt";
            this.BtnPrintReceipt.UseVisualStyleBackColor = true;
            this.BtnPrintReceipt.Click += new System.EventHandler(this.BtnPrintReceipt_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.BtnSearchClient);
            this.panel2.Controls.Add(this.TbxSearchClient);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(15, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 106);
            this.panel2.TabIndex = 9;
            // 
            // BtnSearchClient
            // 
            this.BtnSearchClient.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchClient.Location = new System.Drawing.Point(4, 65);
            this.BtnSearchClient.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSearchClient.Name = "BtnSearchClient";
            this.BtnSearchClient.Size = new System.Drawing.Size(116, 36);
            this.BtnSearchClient.TabIndex = 1;
            this.BtnSearchClient.Text = "Search";
            this.BtnSearchClient.UseVisualStyleBackColor = true;
            this.BtnSearchClient.Click += new System.EventHandler(this.BtnSearchClient_Click);
            // 
            // TbxSearchClient
            // 
            this.TbxSearchClient.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxSearchClient.Location = new System.Drawing.Point(123, 66);
            this.TbxSearchClient.Margin = new System.Windows.Forms.Padding(4);
            this.TbxSearchClient.Name = "TbxSearchClient";
            this.TbxSearchClient.Size = new System.Drawing.Size(332, 32);
            this.TbxSearchClient.TabIndex = 0;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // RtbReceipt
            // 
            this.RtbReceipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.RtbReceipt.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RtbReceipt.Location = new System.Drawing.Point(1160, 179);
            this.RtbReceipt.Margin = new System.Windows.Forms.Padding(4);
            this.RtbReceipt.Name = "RtbReceipt";
            this.RtbReceipt.Size = new System.Drawing.Size(555, 493);
            this.RtbReceipt.TabIndex = 10;
            this.RtbReceipt.Text = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(1160, 124);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(555, 53);
            this.panel3.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Water_Billing_System.Properties.Resources.icons8_receipt_and_change_96;
            this.pictureBox1.Location = new System.Drawing.Point(13, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1732, 722);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.RtbReceipt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnPrintReceipt);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.dgvClientRecord);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BillingForm";
            this.Text = "BillingForm";
            this.Load += new System.EventHandler(this.BillingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientRecord)).EndInit();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnpaid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvClientRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.DataGridView dgvPaid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnPaid;
        private System.Windows.Forms.DataGridView dgvUnpaid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LbBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnPrintReceipt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSearchClient;
        private System.Windows.Forms.TextBox TbxSearchClient;
        private System.Windows.Forms.Label LbYear;
        private System.Windows.Forms.Label LbMonth;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.RichTextBox RtbReceipt;
        private System.Windows.Forms.Panel panel3;
    }
}