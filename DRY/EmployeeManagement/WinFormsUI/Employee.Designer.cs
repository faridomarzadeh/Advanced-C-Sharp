namespace WinFormsUI
{
    partial class Employee
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
            label1 = new Label();
            firstName = new TextBox();
            label2 = new Label();
            lastName = new TextBox();
            btnIdGenerator = new Button();
            displayTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 26);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // firstName
            // 
            firstName.Location = new Point(119, 26);
            firstName.Name = "firstName";
            firstName.Size = new Size(193, 27);
            firstName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 76);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 2;
            label2.Text = "Last Name";
            // 
            // lastName
            // 
            lastName.Location = new Point(118, 76);
            lastName.Name = "lastName";
            lastName.Size = new Size(194, 27);
            lastName.TabIndex = 3;
            // 
            // btnIdGenerator
            // 
            btnIdGenerator.Location = new Point(40, 134);
            btnIdGenerator.Name = "btnIdGenerator";
            btnIdGenerator.Size = new Size(247, 29);
            btnIdGenerator.TabIndex = 4;
            btnIdGenerator.Text = "Generate ID";
            btnIdGenerator.UseVisualStyleBackColor = true;
            btnIdGenerator.Click += btnIdGenerator_Click;
            // 
            // displayTextBox
            // 
            displayTextBox.Enabled = false;
            displayTextBox.Location = new Point(28, 210);
            displayTextBox.Multiline = true;
            displayTextBox.Name = "displayTextBox";
            displayTextBox.Size = new Size(319, 71);
            displayTextBox.TabIndex = 5;
            // 
            // Employee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(displayTextBox);
            Controls.Add(btnIdGenerator);
            Controls.Add(lastName);
            Controls.Add(label2);
            Controls.Add(firstName);
            Controls.Add(label1);
            Name = "Employee";
            Text = "Employee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox firstName;
        private Label label2;
        private TextBox lastName;
        private Button btnIdGenerator;
        private TextBox displayTextBox;
    }
}