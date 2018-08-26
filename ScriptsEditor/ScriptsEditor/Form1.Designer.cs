namespace DialogEditor
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDialogKey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdNewDialog = new System.Windows.Forms.Button();
            this.cmdLoadScene = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKey = new System.Windows.Forms.ComboBox();
            this.lblScene = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdRoot = new System.Windows.Forms.Button();
            this.cmdSaveDialog = new System.Windows.Forms.Button();
            this.lblDialog = new System.Windows.Forms.Label();
            this.Nodo = new System.Windows.Forms.GroupBox();
            this.lblChildCount = new System.Windows.Forms.Label();
            this.cmbChildren = new System.Windows.Forms.ComboBox();
            this.cmdNewChild = new System.Windows.Forms.Button();
            this.btnCurrent = new System.Windows.Forms.Button();
            this.cmdParent = new System.Windows.Forms.Button();
            this.lblLine = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.cmbMood = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Nodo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDialogKey
            // 
            this.txtDialogKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDialogKey.Location = new System.Drawing.Point(286, 34);
            this.txtDialogKey.Name = "txtDialogKey";
            this.txtDialogKey.Size = new System.Drawing.Size(178, 23);
            this.txtDialogKey.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdNewDialog);
            this.groupBox1.Controls.Add(this.cmdLoadScene);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbKey);
            this.groupBox1.Controls.Add(this.lblScene);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(906, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Escena";
            // 
            // cmdNewDialog
            // 
            this.cmdNewDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewDialog.Location = new System.Drawing.Point(803, 23);
            this.cmdNewDialog.Name = "cmdNewDialog";
            this.cmdNewDialog.Size = new System.Drawing.Size(50, 22);
            this.cmdNewDialog.TabIndex = 4;
            this.cmdNewDialog.Text = "+";
            this.cmdNewDialog.UseVisualStyleBackColor = true;
            this.cmdNewDialog.Click += new System.EventHandler(this.cmdNewDialog_Click);
            // 
            // cmdLoadScene
            // 
            this.cmdLoadScene.Location = new System.Drawing.Point(9, 18);
            this.cmdLoadScene.Name = "cmdLoadScene";
            this.cmdLoadScene.Size = new System.Drawing.Size(135, 32);
            this.cmdLoadScene.TabIndex = 2;
            this.cmdLoadScene.Text = "Cargar Escena";
            this.cmdLoadScene.UseVisualStyleBackColor = true;
            this.cmdLoadScene.Click += new System.EventHandler(this.cmdLoadScene_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dialogo";
            // 
            // cmbKey
            // 
            this.cmbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKey.FormattingEnabled = true;
            this.cmbKey.Location = new System.Drawing.Point(556, 25);
            this.cmbKey.Name = "cmbKey";
            this.cmbKey.Size = new System.Drawing.Size(222, 21);
            this.cmbKey.TabIndex = 2;
            this.cmbKey.SelectedIndexChanged += new System.EventHandler(this.cmbKey_SelectedIndexChanged);
            // 
            // lblScene
            // 
            this.lblScene.AutoSize = true;
            this.lblScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScene.Location = new System.Drawing.Point(202, 26);
            this.lblScene.Name = "lblScene";
            this.lblScene.Size = new System.Drawing.Size(23, 17);
            this.lblScene.TabIndex = 1;
            this.lblScene.Text = "...";
            this.lblScene.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdRoot);
            this.groupBox2.Controls.Add(this.cmdSaveDialog);
            this.groupBox2.Controls.Add(this.txtDialogKey);
            this.groupBox2.Controls.Add(this.lblDialog);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(906, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Diálogo";
            // 
            // cmdRoot
            // 
            this.cmdRoot.Location = new System.Drawing.Point(496, 32);
            this.cmdRoot.Name = "cmdRoot";
            this.cmdRoot.Size = new System.Drawing.Size(79, 26);
            this.cmdRoot.TabIndex = 4;
            this.cmdRoot.Text = "Raíz";
            this.cmdRoot.UseVisualStyleBackColor = true;
            this.cmdRoot.Click += new System.EventHandler(this.cmdRoot_Click);
            // 
            // cmdSaveDialog
            // 
            this.cmdSaveDialog.Location = new System.Drawing.Point(803, 30);
            this.cmdSaveDialog.Name = "cmdSaveDialog";
            this.cmdSaveDialog.Size = new System.Drawing.Size(97, 31);
            this.cmdSaveDialog.TabIndex = 3;
            this.cmdSaveDialog.Text = "Salvar Diálogo";
            this.cmdSaveDialog.UseVisualStyleBackColor = true;
            this.cmdSaveDialog.Click += new System.EventHandler(this.cmdSaveDialog_Click);
            // 
            // lblDialog
            // 
            this.lblDialog.AutoSize = true;
            this.lblDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDialog.Location = new System.Drawing.Point(202, 35);
            this.lblDialog.Name = "lblDialog";
            this.lblDialog.Size = new System.Drawing.Size(78, 17);
            this.lblDialog.TabIndex = 1;
            this.lblDialog.Text = "DIÁLOGO";
            this.lblDialog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Nodo
            // 
            this.Nodo.Controls.Add(this.lblChildCount);
            this.Nodo.Controls.Add(this.cmbChildren);
            this.Nodo.Controls.Add(this.cmdNewChild);
            this.Nodo.Controls.Add(this.btnCurrent);
            this.Nodo.Controls.Add(this.cmdParent);
            this.Nodo.Controls.Add(this.lblLine);
            this.Nodo.Location = new System.Drawing.Point(12, 157);
            this.Nodo.Name = "Nodo";
            this.Nodo.Size = new System.Drawing.Size(211, 264);
            this.Nodo.TabIndex = 3;
            this.Nodo.TabStop = false;
            this.Nodo.Text = "Arbol";
            // 
            // lblChildCount
            // 
            this.lblChildCount.AutoSize = true;
            this.lblChildCount.Location = new System.Drawing.Point(6, 203);
            this.lblChildCount.Name = "lblChildCount";
            this.lblChildCount.Size = new System.Drawing.Size(13, 13);
            this.lblChildCount.TabIndex = 4;
            this.lblChildCount.Text = "0";
            this.lblChildCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbChildren
            // 
            this.cmbChildren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChildren.FormattingEnabled = true;
            this.cmbChildren.Location = new System.Drawing.Point(6, 219);
            this.cmbChildren.Name = "cmbChildren";
            this.cmbChildren.Size = new System.Drawing.Size(158, 21);
            this.cmbChildren.TabIndex = 4;
            this.cmbChildren.SelectedIndexChanged += new System.EventHandler(this.cmbChildren_SelectedIndexChanged);
            // 
            // cmdNewChild
            // 
            this.cmdNewChild.Location = new System.Drawing.Point(170, 210);
            this.cmdNewChild.Name = "cmdNewChild";
            this.cmdNewChild.Size = new System.Drawing.Size(35, 36);
            this.cmdNewChild.TabIndex = 0;
            this.cmdNewChild.Text = "+";
            this.cmdNewChild.UseVisualStyleBackColor = true;
            this.cmdNewChild.Click += new System.EventHandler(this.cmdNewChild_Click);
            // 
            // btnCurrent
            // 
            this.btnCurrent.Location = new System.Drawing.Point(65, 104);
            this.btnCurrent.Name = "btnCurrent";
            this.btnCurrent.Size = new System.Drawing.Size(49, 49);
            this.btnCurrent.TabIndex = 0;
            this.btnCurrent.Text = "Actual";
            this.btnCurrent.UseVisualStyleBackColor = true;
            // 
            // cmdParent
            // 
            this.cmdParent.Location = new System.Drawing.Point(65, 19);
            this.cmdParent.Name = "cmdParent";
            this.cmdParent.Size = new System.Drawing.Size(49, 49);
            this.cmdParent.TabIndex = 0;
            this.cmdParent.Text = "Padre";
            this.cmdParent.UseVisualStyleBackColor = true;
            this.cmdParent.Click += new System.EventHandler(this.cmdParent_Click);
            // 
            // lblLine
            // 
            this.lblLine.BackColor = System.Drawing.Color.Black;
            this.lblLine.Location = new System.Drawing.Point(84, 37);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(11, 179);
            this.lblLine.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbSpeed);
            this.groupBox3.Controls.Add(this.cmbMood);
            this.groupBox3.Controls.Add(this.cmbType);
            this.groupBox3.Controls.Add(this.txtText);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtOwner);
            this.groupBox3.Location = new System.Drawing.Point(229, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(689, 264);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Propiedades Nodo";
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cmbSpeed.Location = new System.Drawing.Point(69, 137);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(52, 21);
            this.cmbSpeed.TabIndex = 3;
            // 
            // cmbMood
            // 
            this.cmbMood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMood.FormattingEnabled = true;
            this.cmbMood.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cmbMood.Location = new System.Drawing.Point(69, 101);
            this.cmbMood.Name = "cmbMood";
            this.cmbMood.Size = new System.Drawing.Size(52, 21);
            this.cmbMood.TabIndex = 3;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cmbType.Location = new System.Drawing.Point(69, 65);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(52, 21);
            this.cmbType.TabIndex = 3;
            // 
            // txtText
            // 
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(69, 179);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(614, 79);
            this.txtText.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Velocidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Humor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dueño";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texto";
            // 
            // txtOwner
            // 
            this.txtOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOwner.Location = new System.Drawing.Point(69, 24);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(535, 23);
            this.txtOwner.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 439);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Nodo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Configurar diálogo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Nodo.ResumeLayout(false);
            this.Nodo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDialogKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdNewDialog;
        private System.Windows.Forms.Button cmdLoadScene;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKey;
        private System.Windows.Forms.Label lblScene;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdRoot;
        private System.Windows.Forms.Button cmdSaveDialog;
        private System.Windows.Forms.Label lblDialog;
        private System.Windows.Forms.GroupBox Nodo;
        private System.Windows.Forms.Label lblChildCount;
        private System.Windows.Forms.ComboBox cmbChildren;
        private System.Windows.Forms.Button cmdNewChild;
        private System.Windows.Forms.Button btnCurrent;
        private System.Windows.Forms.Button cmdParent;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbSpeed;
        private System.Windows.Forms.ComboBox cmbMood;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOwner;
    }
}

