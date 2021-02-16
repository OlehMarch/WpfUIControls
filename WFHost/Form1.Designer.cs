namespace WFHost
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.transform1 = new WpfUIControls.UI.Main.Transform();
            this.buttonGetModelData = new System.Windows.Forms.Button();
            this.labelModelData = new System.Windows.Forms.Label();
            this.buttonSetModelData = new System.Windows.Forms.Button();
            this.buttonSetLightingData = new System.Windows.Forms.Button();
            this.labelLightingData = new System.Windows.Forms.Label();
            this.buttonGetLightingData = new System.Windows.Forms.Button();
            this.elementHost4 = new System.Windows.Forms.Integration.ElementHost();
            this.materials1 = new WpfUIControls.UI.Main.Materials();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.collisions1 = new WpfUIControls.UI.Main.Collisions();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.lighting1 = new WpfUIControls.UI.Main.Lighting();
            this.buttonAddItemToGrid = new System.Windows.Forms.Button();
            this.elementHost5 = new System.Windows.Forms.Integration.ElementHost();
            this.entityParamHolder1 = new WpfUIControls.UI.Main.EntityParamHolder();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.elementHost2);
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 233);
            this.panel1.TabIndex = 0;
            // 
            // elementHost2
            // 
            this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost2.Location = new System.Drawing.Point(0, 0);
            this.elementHost2.Margin = new System.Windows.Forms.Padding(2);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(474, 233);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.transform1;
            // 
            // buttonGetModelData
            // 
            this.buttonGetModelData.Location = new System.Drawing.Point(493, 11);
            this.buttonGetModelData.Name = "buttonGetModelData";
            this.buttonGetModelData.Size = new System.Drawing.Size(143, 40);
            this.buttonGetModelData.TabIndex = 1;
            this.buttonGetModelData.Text = "Get Model Data";
            this.buttonGetModelData.UseVisualStyleBackColor = true;
            this.buttonGetModelData.Click += new System.EventHandler(this.buttonGetModelData_Click);
            // 
            // labelModelData
            // 
            this.labelModelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelModelData.Location = new System.Drawing.Point(494, 54);
            this.labelModelData.Name = "labelModelData";
            this.labelModelData.Size = new System.Drawing.Size(142, 97);
            this.labelModelData.TabIndex = 2;
            // 
            // buttonSetModelData
            // 
            this.buttonSetModelData.Location = new System.Drawing.Point(493, 154);
            this.buttonSetModelData.Name = "buttonSetModelData";
            this.buttonSetModelData.Size = new System.Drawing.Size(143, 40);
            this.buttonSetModelData.TabIndex = 3;
            this.buttonSetModelData.Text = "Set Model Data";
            this.buttonSetModelData.UseVisualStyleBackColor = true;
            this.buttonSetModelData.Click += new System.EventHandler(this.buttonSetModelData_Click);
            // 
            // buttonSetLightingData
            // 
            this.buttonSetLightingData.Location = new System.Drawing.Point(493, 347);
            this.buttonSetLightingData.Name = "buttonSetLightingData";
            this.buttonSetLightingData.Size = new System.Drawing.Size(143, 40);
            this.buttonSetLightingData.TabIndex = 7;
            this.buttonSetLightingData.Text = "Set Lighting Data";
            this.buttonSetLightingData.UseVisualStyleBackColor = true;
            this.buttonSetLightingData.Click += new System.EventHandler(this.buttonSetLightingData_Click);
            // 
            // labelLightingData
            // 
            this.labelLightingData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLightingData.Location = new System.Drawing.Point(494, 247);
            this.labelLightingData.Name = "labelLightingData";
            this.labelLightingData.Size = new System.Drawing.Size(142, 97);
            this.labelLightingData.TabIndex = 6;
            // 
            // buttonGetLightingData
            // 
            this.buttonGetLightingData.Location = new System.Drawing.Point(493, 204);
            this.buttonGetLightingData.Name = "buttonGetLightingData";
            this.buttonGetLightingData.Size = new System.Drawing.Size(143, 40);
            this.buttonGetLightingData.TabIndex = 5;
            this.buttonGetLightingData.Text = "Get Lighting Data";
            this.buttonGetLightingData.UseVisualStyleBackColor = true;
            this.buttonGetLightingData.Click += new System.EventHandler(this.buttonGetLightingData_Click);
            // 
            // elementHost4
            // 
            this.elementHost4.Location = new System.Drawing.Point(643, 11);
            this.elementHost4.Name = "elementHost4";
            this.elementHost4.Size = new System.Drawing.Size(502, 376);
            this.elementHost4.TabIndex = 9;
            this.elementHost4.Text = "elementHost4";
            this.elementHost4.Child = this.materials1;
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(11, 635);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(474, 105);
            this.elementHost3.TabIndex = 8;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.collisions1;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(11, 256);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(474, 373);
            this.elementHost1.TabIndex = 4;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.lighting1;
            // 
            // buttonAddItemToGrid
            // 
            this.buttonAddItemToGrid.Location = new System.Drawing.Point(494, 394);
            this.buttonAddItemToGrid.Name = "buttonAddItemToGrid";
            this.buttonAddItemToGrid.Size = new System.Drawing.Size(142, 61);
            this.buttonAddItemToGrid.TabIndex = 11;
            this.buttonAddItemToGrid.Text = "Add item to grid";
            this.buttonAddItemToGrid.UseVisualStyleBackColor = true;
            this.buttonAddItemToGrid.Click += new System.EventHandler(this.buttonAddItemToGrid_Click);
            // 
            // elementHost5
            // 
            this.elementHost5.Location = new System.Drawing.Point(643, 394);
            this.elementHost5.Name = "elementHost5";
            this.elementHost5.Size = new System.Drawing.Size(502, 346);
            this.elementHost5.TabIndex = 12;
            this.elementHost5.Text = "elementHost5";
            this.elementHost5.Child = this.entityParamHolder1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 752);
            this.Controls.Add(this.elementHost5);
            this.Controls.Add(this.buttonAddItemToGrid);
            this.Controls.Add(this.elementHost4);
            this.Controls.Add(this.elementHost3);
            this.Controls.Add(this.buttonSetLightingData);
            this.Controls.Add(this.labelLightingData);
            this.Controls.Add(this.buttonGetLightingData);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.buttonSetModelData);
            this.Controls.Add(this.labelModelData);
            this.Controls.Add(this.buttonGetModelData);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private WpfUIControls.UI.Main.Transform transform1;
        private System.Windows.Forms.Button buttonGetModelData;
        private System.Windows.Forms.Label labelModelData;
        private System.Windows.Forms.Button buttonSetModelData;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Button buttonSetLightingData;
        private System.Windows.Forms.Label labelLightingData;
        private System.Windows.Forms.Button buttonGetLightingData;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private WpfUIControls.UI.Main.Collisions collisions1;
        private WpfUIControls.UI.Main.Lighting lighting1;
        private System.Windows.Forms.Integration.ElementHost elementHost4;
        private WpfUIControls.UI.Main.Materials materials1;
        private System.Windows.Forms.Button buttonAddItemToGrid;
        private System.Windows.Forms.Integration.ElementHost elementHost5;
        private WpfUIControls.UI.Main.EntityParamHolder entityParamHolder1;
    }
}

