using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula_ADO
{
    public class Executar
    {
        [STAThread] // Atributo para indicar que o método é um método de entrada de thread de aplicativo
        static void Main()
        {
            Application.EnableVisualStyles(); // Habilitar estilos visuais
            Application.SetCompatibleTextRenderingDefault(false); // Definir o texto de renderização compatível como falso
            Application.Run(new Cadastro()); // Executar o formulário
        }
    }
    public class Cadastro : Form
    {
        private Label label1, label2, label3; // Declaração de variáveis label
        private TextBox txtId, txtNome, txtEmail; // Declaração de variáveis TextBox
        private Button btnInserir, btnListar, btnAtualizar, btnDeletar; // Declaração de variáveis Button
        private ListBox lstUsuarios; // Declaração de variáveis, para eu colocar os valores dos resultados do TextBox em uma lista
        private CRUD crud;

        public Cadastro() // Construtor
        {
            // Inicializar o objeto CRUD
            crud = new CRUD();

            // Definir o tamanho da janela e cor de fundo 
            this.Size = new Size(500, 500);
            this.Text = "Cadastro de Usuários";
            this.BackColor = Color.White; // Cor de fundo

            // Fonte padrão para os textos
            Font fontePadrao = new Font("Arial", 12, FontStyle.Bold); // FontStyle é para definir o estilo da fonte
            Font fontealternativa = new Font("Italic", 12, FontStyle.Bold);

            // Criando as labels
            label1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fontePadrao, ForeColor = Color.Blue };
            label2 = new Label { Text = "Nome:", Location = new Point(20, 60), Font = fontePadrao, ForeColor = Color.Blue };
            label3 = new Label { Text = "Email:", Location = new Point(20, 110), Font = fontePadrao, ForeColor = Color.Blue };

            // Criando os TextBox
            txtId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fontealternativa };
            txtNome = new TextBox { Location = new Point(20, 80), Width = 220, Font = fontealternativa };
            txtEmail = new TextBox { Location = new Point(20, 130), Width = 220, Font = fontealternativa };

            // Criando os botões
            btnInserir = CriarBotao("Inserir", new Point(270, 30), Color.LightGreen);
            btnListar = CriarBotao("Listar", new Point(270, 80), Color.LightGreen);
            btnAtualizar = CriarBotao("Atualizar", new Point(270, 130), Color.LightGreen);
            btnDeletar = CriarBotao("Deletar", new Point(270, 170), Color.LightGreen);

            // Craindo enventos dos botões
            btnInserir.Click += new EventHandler(ButtonInserir_Click);
            btnListar.Click += new EventHandler(ButtonListar_Click);
            btnAtualizar.Click += new EventHandler(ButtonAtualizar_Click);
            btnDeletar.Click += new EventHandler(ButtonDeletar_Click);

            // Criando a ListBox 
            lstUsuarios = new ListBox
            {
                Location = new Point(20, 220),
                Width = 500,
                Height = 150,
                BackColor = Color.White, // Cor de fundo
                ForeColor = Color.Blue, // ForeColor é a cor da fonte
            };

            // Adicionando os controles na janela
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(txtId);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnInserir);
            this.Controls.Add(btnListar);
            this.Controls.Add(btnAtualizar);
            this.Controls.Add(btnDeletar);
            this.Controls.Add(lstUsuarios);

        }

        private Button CriarBotao(string texto, Point localizacao, Color cor)
        {
            return new Button
            {
                Text = texto,
                Location = localizacao,
                Width = 100,
                Height = 30,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
            };
        }

        private void ButtonInserir_Click(object sender, EventArgs e) // sender é objeto quando dispara o evneto
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                crud.InserirUsuario(id, nome, email);
                MessageBox.Show("Usuário inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;

                crud.AtualizarUsuario(id, nome);
                MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonListar_Click(object sender, EventArgs e)
        {
            try
            {
                lstUsuarios.Items.Clear(); // Limpar a lista

                List<string> usuarios = crud.ListarClientes();
                if (usuarios.Count > 0)
                {
                    foreach (string usuario in usuarios)
                        lstUsuarios.Items.Add(usuario);
                }
                else
                {
                    lstUsuarios.Items.Add("Nenhum usuário encontrado!");
                }


            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao listar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ButtonDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                crud.DeletarUsuario(id);
                MessageBox.Show("Usuário deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtId.Clear(); // Limpar o campo
            txtNome.Clear();
            txtEmail.Clear();
        }


    }
}