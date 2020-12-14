namespace e_book_search
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.displayAllBooks = new System.Windows.Forms.DataGridView();
            this.ebooksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.displaySearchResult = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inputTitle = new System.Windows.Forms.TextBox();
            this.inputAuthor = new System.Windows.Forms.TextBox();
            this.inputFormatList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inputSearch = new System.Windows.Forms.TextBox();
            this.addEbookButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.chooseAuthorList = new System.Windows.Forms.ListBox();
            this.formatChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.displayAllBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebooksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.displaySearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatChart)).BeginInit();
            this.SuspendLayout();
            // 
            // displayAllBooks
            // 
            this.displayAllBooks.AllowUserToAddRows = false;
            this.displayAllBooks.AutoGenerateColumns = false;
            this.displayAllBooks.BackgroundColor = System.Drawing.Color.SaddleBrown;
            this.displayAllBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayAllBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.authorDataGridViewTextBoxColumn,
            this.formatDataGridViewTextBoxColumn});
            this.displayAllBooks.DataSource = this.ebooksBindingSource;
            this.displayAllBooks.Location = new System.Drawing.Point(361, 12);
            this.displayAllBooks.Name = "displayAllBooks";
            this.displayAllBooks.RowHeadersWidth = 51;
            this.displayAllBooks.RowTemplate.Height = 24;
            this.displayAllBooks.ShowEditingIcon = false;
            this.displayAllBooks.Size = new System.Drawing.Size(891, 395);
            this.displayAllBooks.TabIndex = 0;
            // 
            // ebooksBindingSource
            // 
            this.ebooksBindingSource.DataSource = typeof(e_book_search.ebooks);
            // 
            // displaySearchResult
            // 
            this.displaySearchResult.BackgroundColor = System.Drawing.Color.SaddleBrown;
            this.displaySearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displaySearchResult.Location = new System.Drawing.Point(362, 463);
            this.displaySearchResult.Name = "displaySearchResult";
            this.displaySearchResult.RowHeadersWidth = 51;
            this.displaySearchResult.RowTemplate.Height = 24;
            this.displaySearchResult.Size = new System.Drawing.Size(890, 174);
            this.displaySearchResult.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Register an e-book";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Author:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Format:";
            // 
            // inputTitle
            // 
            this.inputTitle.Location = new System.Drawing.Point(75, 80);
            this.inputTitle.Name = "inputTitle";
            this.inputTitle.Size = new System.Drawing.Size(209, 22);
            this.inputTitle.TabIndex = 6;
            // 
            // inputAuthor
            // 
            this.inputAuthor.Location = new System.Drawing.Point(75, 122);
            this.inputAuthor.Name = "inputAuthor";
            this.inputAuthor.Size = new System.Drawing.Size(209, 22);
            this.inputAuthor.TabIndex = 7;
            // 
            // inputFormatList
            // 
            this.inputFormatList.DisplayMember = "Format";
            this.inputFormatList.FormattingEnabled = true;
            this.inputFormatList.ItemHeight = 16;
            this.inputFormatList.Location = new System.Drawing.Point(75, 169);
            this.inputFormatList.Name = "inputFormatList";
            this.inputFormatList.Size = new System.Drawing.Size(63, 52);
            this.inputFormatList.TabIndex = 8;
            this.inputFormatList.ValueMember = "Format";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(127, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Search";
            // 
            // inputSearch
            // 
            this.inputSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputSearch.Location = new System.Drawing.Point(90, 336);
            this.inputSearch.MinimumSize = new System.Drawing.Size(4, 30);
            this.inputSearch.Name = "inputSearch";
            this.inputSearch.Size = new System.Drawing.Size(194, 30);
            this.inputSearch.TabIndex = 10;
            // 
            // addEbookButton
            // 
            this.addEbookButton.Location = new System.Drawing.Point(182, 178);
            this.addEbookButton.Name = "addEbookButton";
            this.addEbookButton.Size = new System.Drawing.Size(92, 36);
            this.addEbookButton.TabIndex = 11;
            this.addEbookButton.Text = "ADD";
            this.addEbookButton.UseVisualStyleBackColor = true;
            this.addEbookButton.Click += new System.EventHandler(this.addEbookButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(152, 377);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(44, 30);
            this.searchButton.TabIndex = 12;
            this.searchButton.Text = "OK";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // chooseAuthorList
            // 
            this.chooseAuthorList.DisplayMember = "Format";
            this.chooseAuthorList.FormattingEnabled = true;
            this.chooseAuthorList.ItemHeight = 16;
            this.chooseAuthorList.Location = new System.Drawing.Point(29, 334);
            this.chooseAuthorList.Name = "chooseAuthorList";
            this.chooseAuthorList.Size = new System.Drawing.Size(63, 36);
            this.chooseAuthorList.TabIndex = 13;
            this.chooseAuthorList.ValueMember = "Format";
            // 
            // formatChart
            // 
            chartArea3.Name = "ChartArea1";
            this.formatChart.ChartAreas.Add(chartArea3);
            this.formatChart.DataSource = this.ebooksBindingSource;
            legend3.Name = "Legend1";
            this.formatChart.Legends.Add(legend3);
            this.formatChart.Location = new System.Drawing.Point(29, 463);
            this.formatChart.Name = "formatChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.formatChart.Series.Add(series3);
            this.formatChart.Size = new System.Drawing.Size(255, 174);
            this.formatChart.TabIndex = 14;
            this.formatChart.Text = "chart1";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 2;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 350;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            this.authorDataGridViewTextBoxColumn.HeaderText = "Author";
            this.authorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            this.authorDataGridViewTextBoxColumn.Width = 175;
            // 
            // formatDataGridViewTextBoxColumn
            // 
            this.formatDataGridViewTextBoxColumn.DataPropertyName = "Format";
            this.formatDataGridViewTextBoxColumn.HeaderText = "Format";
            this.formatDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.formatDataGridViewTextBoxColumn.Name = "formatDataGridViewTextBoxColumn";
            this.formatDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.formatDataGridViewTextBoxColumn.Width = 40;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1264, 649);
            this.Controls.Add(this.formatChart);
            this.Controls.Add(this.chooseAuthorList);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.addEbookButton);
            this.Controls.Add(this.inputSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inputFormatList);
            this.Controls.Add(this.inputAuthor);
            this.Controls.Add(this.inputTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displaySearchResult);
            this.Controls.Add(this.displayAllBooks);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.displayAllBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebooksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.displaySearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView displayAllBooks;
        private System.Windows.Forms.DataGridView displaySearchResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputTitle;
        private System.Windows.Forms.TextBox inputAuthor;
        private System.Windows.Forms.ListBox inputFormatList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputSearch;
        private System.Windows.Forms.Button addEbookButton;
        private System.Windows.Forms.BindingSource ebooksBindingSource;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox chooseAuthorList;
        private System.Windows.Forms.DataVisualization.Charting.Chart formatChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formatDataGridViewTextBoxColumn;
    }
}

