namespace MandelbrotSetApplication
{
    partial class MandelbrotSetForm
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
            this.mandelbrotSetPictureBox = new System.Windows.Forms.PictureBox();
            this.displayMandelbrotSetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colouringMethodComboBox = new System.Windows.Forms.ComboBox();
            this.mouseCoordinatesLabel = new System.Windows.Forms.Label();
            this.complexPlaneCoordinatesLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mandelbrotSetPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mandelbrotSetPictureBox
            // 
            this.mandelbrotSetPictureBox.Location = new System.Drawing.Point(13, -1);
            this.mandelbrotSetPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.mandelbrotSetPictureBox.Name = "mandelbrotSetPictureBox";
            this.mandelbrotSetPictureBox.Size = new System.Drawing.Size(1102, 738);
            this.mandelbrotSetPictureBox.TabIndex = 0;
            this.mandelbrotSetPictureBox.TabStop = false;
            this.mandelbrotSetPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mandelbrotSetPictureBox_Paint);
            this.mandelbrotSetPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mandelbrotSetPictureBox_MouseMove);
            // 
            // displayMandelbrotSetButton
            // 
            this.displayMandelbrotSetButton.Location = new System.Drawing.Point(5, 746);
            this.displayMandelbrotSetButton.Margin = new System.Windows.Forms.Padding(4);
            this.displayMandelbrotSetButton.Name = "displayMandelbrotSetButton";
            this.displayMandelbrotSetButton.Size = new System.Drawing.Size(249, 55);
            this.displayMandelbrotSetButton.TabIndex = 1;
            this.displayMandelbrotSetButton.Text = "Display Mandelbrot Set";
            this.displayMandelbrotSetButton.UseVisualStyleBackColor = true;
            this.displayMandelbrotSetButton.Click += new System.EventHandler(this.displayMandelbrotSetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 764);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Colouring Method";
            // 
            // colouringMethodComboBox
            // 
            this.colouringMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colouringMethodComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colouringMethodComboBox.FormattingEnabled = true;
            this.colouringMethodComboBox.Location = new System.Drawing.Point(435, 761);
            this.colouringMethodComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.colouringMethodComboBox.Name = "colouringMethodComboBox";
            this.colouringMethodComboBox.Size = new System.Drawing.Size(228, 28);
            this.colouringMethodComboBox.TabIndex = 3;
            this.colouringMethodComboBox.SelectedValueChanged += new System.EventHandler(this.colouringMethodComboBox_SelectedValueChanged);
            // 
            // mouseCoordinatesLabel
            // 
            this.mouseCoordinatesLabel.AutoSize = true;
            this.mouseCoordinatesLabel.Location = new System.Drawing.Point(768, 774);
            this.mouseCoordinatesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mouseCoordinatesLabel.Name = "mouseCoordinatesLabel";
            this.mouseCoordinatesLabel.Size = new System.Drawing.Size(0, 17);
            this.mouseCoordinatesLabel.TabIndex = 4;
            // 
            // complexPlaneCoordinatesLabel
            // 
            this.complexPlaneCoordinatesLabel.AutoSize = true;
            this.complexPlaneCoordinatesLabel.Location = new System.Drawing.Point(949, 773);
            this.complexPlaneCoordinatesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.complexPlaneCoordinatesLabel.Name = "complexPlaneCoordinatesLabel";
            this.complexPlaneCoordinatesLabel.Size = new System.Drawing.Size(0, 17);
            this.complexPlaneCoordinatesLabel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(691, 746);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mouse Co-ordinates";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(880, 746);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Complex Plane Co-ordinates";
            // 
            // MandelbrotSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 815);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.complexPlaneCoordinatesLabel);
            this.Controls.Add(this.mouseCoordinatesLabel);
            this.Controls.Add(this.colouringMethodComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayMandelbrotSetButton);
            this.Controls.Add(this.mandelbrotSetPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MandelbrotSetForm";
            this.Text = "MandelBrot Set";
            ((System.ComponentModel.ISupportInitialize)(this.mandelbrotSetPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mandelbrotSetPictureBox;
        private System.Windows.Forms.Button displayMandelbrotSetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox colouringMethodComboBox;
        private System.Windows.Forms.Label mouseCoordinatesLabel;
        private System.Windows.Forms.Label complexPlaneCoordinatesLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

