﻿using System;

namespace Exeplo2
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Calculadora());
        }

        public class MeuFormulario : Form
        {
            public MeuFormulario()
            {
                this.Text = "Meu Formulário";
                this.Size = new Size(300, 300);

                Label label1 = new Label();
                label1.Text = "Olá Mundo!";
                label1.Location = new Point(100, 100);
                this.AutoSize = true;

                this.Controls.Add(label1);
            }
        }
    }

    public class Calculadora : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;

        public Calculadora()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.BackColor = System.Drawing.Color.Gray;
            this.Text = "Calculadora";

            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.Text = "Digite os números";

            this.textBox1.Location = new System.Drawing.Point(30, 60);
            this.textBox1.Name = "textBox1";
            this.BackColor = System.Drawing.Color.Blue;
            this.textBox1.Size = new System.Drawing.Size(200, 27);

            this.textBox2.Location = new System.Drawing.Point(30, 90);
            this.textBox2.Name = "textBox1";
            this.textBox2.Size = new System.Drawing.Size(200, 27);

            this.button1.Location = new System.Drawing.Point(30, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.Text = "Calcular";
            this.button1.Click += new System.EventHandler(this.button1_Click);

            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = int.Parse(this.textBox1.Text);
                int num2 = int.Parse(this.textBox2.Text);

                MessageBox.Show("A soma é: " + (num1 + num2)
                    + "\nA subtração é: " + (num1 - num2)
                    + "\nA multiplicação é: " + (num1 * num2)
                    + "\nA divisão é: " + (num1 / num2));
            }
            catch (System.Exception)
            {
                MessageBox.Show("Digite apenas números inteiros");
                return;
            }
        }
    }
}