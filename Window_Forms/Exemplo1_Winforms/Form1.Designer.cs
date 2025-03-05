namespace Exemplo1_Winforms;

partial class Form1
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label label1; // Declaração do rótulo
    private System.Windows.Forms.Button button1; // Declaração do botão
    private System.Windows.Forms.TextBox textBox1; // Declaração da caixa de texto
    private System.Windows.Forms.TextBox txtBox2; // Declaração da segunda caixa de texto

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
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Exemplo 1";

        // Inicialização dos controles
        this.label1 = new System.Windows.Forms.Label();
        this.button1 = new System.Windows.Forms.Button();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.txtBox2 = new System.Windows.Forms.TextBox();

        // Configuração do label1
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(30, 30);
        this.label1.Name = "label1";
        this.label1.Text = "Olá Mundo!";

        // Configuração do button1
        this.button1.Location = new System.Drawing.Point(30, 60);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(100, 30);
        this.button1.Text = "Clique Aqui";
        this.button1.Click += new System.EventHandler(this.button1_Click); // Associação do evento

        // Configuração do textBox1
        this.textBox1.Location = new System.Drawing.Point(30, 100);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(200, 20);

        // Configuração do txtBox2
        this.txtBox2.Location = new System.Drawing.Point(30, 130);
        this.txtBox2.Name = "txtBox2";
        this.txtBox2.Size = new System.Drawing.Size(200, 20);

        // Adicionar os controles ao formulário
        this.Controls.Add(this.label1);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.txtBox2);
    }

    #endregion
}