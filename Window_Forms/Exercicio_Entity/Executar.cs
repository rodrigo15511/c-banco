using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Exercicio_Entity

{
    public class Executar
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms());
        }
    }

    public class Forms : Form
    {
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private CRUD crud;

        private Maquina maquinaForm;
        private Software softwareForm;
        private Usuario usuarioForm;
        private TableLayoutPanel tableLayoutPanel1;

        public Forms()
        {
            this.Text = "Sistema Multi-Telas";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            tabControl = new TabControl { Dock = DockStyle.Fill };

            tabPage1 = new TabPage(Text = "Maquina");
            tabPage2 = new TabPage(Text = "Software");
            tabPage3 = new TabPage(Text = "Usuario");

            maquinaForm = new Maquina();
            softwareForm = new Software();
            usuarioForm = new Usuario();

            tabPage1.Controls.Add(maquinaForm);
            tabPage2.Controls.Add(softwareForm);
            tabPage3.Controls.Add(usuarioForm);

            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);
            tabControl.TabPages.Add(tabPage3);

            this.Controls.Add(tabControl);
        }

        public class Maquina : UserControl
        {
            public int Id { get; set; }
            public string Tipo { get; set; }
            public int Velocidade { get; set; }
            public int Hardidisk { get; set; }
            public int Placa_rede { get; set; }
            public int Memoria_ram { get; set; }
            public int Fk_usuario { get; set; }

            private Label labelM1, labelM2, labelM3, labelM4, labelM5, labelM6, labelM7;
            private TextBox txtMId, txtMTipo, txtMVelocidade, txtMHarddisk, txtMPlacaRede, txtMMemoriaRam, txtMFkUsuario;
            private Button MbtnInserir, MbtnListar, MbtnAtualizar, MbtnDeletar;
            private CRUD crud = new CRUD();
            public Maquina()
            {
                this.Text = "Maquinas";
                this.Size = new Size(1000, 1000);
                this.BackColor = Color.White;
                Font fonte = new Font("Poppins", 12, FontStyle.Bold);

                labelM1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelM2 = new Label { Text = "Tipo:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };
                labelM3 = new Label { Text = "Velocidade:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.DarkBlue };
                labelM4 = new Label { Text = "Hard-Disk:", Location = new Point(270, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelM5 = new Label { Text = "Placa de Rede:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };
                labelM6 = new Label { Text = "Memoria Ram:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.DarkBlue };
                labelM7 = new Label { Text = "Fk Usuario:", Location = new Point(160, 160), Font = fonte, ForeColor = Color.DarkBlue };

                txtMId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonte };
                txtMTipo = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonte };
                txtMVelocidade = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonte };
                txtMHarddisk = new TextBox { Location = new Point(270, 30), Width = 220, Font = fonte };
                txtMPlacaRede = new TextBox { Location = new Point(270, 80), Width = 220, Font = fonte };
                txtMMemoriaRam = new TextBox { Location = new Point(270, 130), Width = 220, Font = fonte };
                txtMFkUsuario = new TextBox { Location = new Point(160, 190), Width = 220, Font = fonte };

                MbtnInserir = CriarBotao("Inserir", new Point(20, 240));
                MbtnAtualizar = CriarBotao("Atualizar", new Point(130, 240));
                MbtnDeletar = CriarBotao("Deletar", new Point(240, 240));
                MbtnListar = CriarBotao("Listar", new Point(340, 240));

                MbtnInserir.Click += MbtnInserir_Click;
                MbtnAtualizar.Click += MbtnAtualizar_Click;
                MbtnDeletar.Click += MbtnDeletar_Click;
                MbtnListar.Click += MbtnListar_Click;

                this.Controls.Add(labelM1);
                this.Controls.Add(labelM2);
                this.Controls.Add(labelM3);
                this.Controls.Add(labelM4);
                this.Controls.Add(labelM5);
                this.Controls.Add(labelM6);
                this.Controls.Add(labelM7);
                this.Controls.Add(txtMId);
                this.Controls.Add(txtMTipo);
                this.Controls.Add(txtMVelocidade);
                this.Controls.Add(txtMHarddisk);
                this.Controls.Add(txtMPlacaRede);
                this.Controls.Add(txtMMemoriaRam);
                this.Controls.Add(txtMFkUsuario);
                this.Controls.Add(MbtnInserir);
                this.Controls.Add(MbtnAtualizar);
                this.Controls.Add(MbtnDeletar);
                this.Controls.Add(MbtnListar);
            }
            private void MbtnInserir_Click(object sender, EventArgs e)
            {
                var maquinaa = new Exercicio_Entity.Maquina
                {
                    Tipo = txtMTipo.Text,
                    Velocidade = int.Parse(txtMVelocidade.Text),
                    HardDisk = int.Parse(txtMHarddisk.Text),
                    Placa_Rede = int.Parse(txtMPlacaRede.Text),
                    Memoria_Ram = int.Parse(txtMMemoriaRam.Text),
                };
                crud.InserirMaquina(maquinaa);
            }

            private void MbtnAtualizar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtMId.Text);
                var maquina = new Exercicio_Entity.Maquina
                {
                    Id = int.Parse(txtMId.Text),
                    Tipo = txtMTipo.Text,
                    Velocidade = int.Parse(txtMVelocidade.Text),
                    HardDisk = int.Parse(txtMHarddisk.Text),
                    Placa_Rede = int.Parse(txtMPlacaRede.Text),
                    Memoria_Ram = int.Parse(txtMMemoriaRam.Text),
                };
                crud.AtualizarMaquina(id, maquina);
            }

            private void MbtnDeletar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtMId.Text);
                crud.DeletarMaquina(id);
            }

            private void MbtnListar_Click(object sender, EventArgs e)
            {
                crud.ListarMaquinas();
            }
        }



        public class Software : UserControl
        {
            public int Id { get; set; }
            public string Produto { get; set; }
            public int Hardidisk { get; set; }
            public int Memoria_ram { get; set; }
            public int Fk_usuario { get; set; }
            private Label labelS1, labelS2, labelS3, labelS4, labelS5;
            private TextBox txtSId, txtSProduto, txtSHarddisk, txtSMemoria_ram, txtSFkMaquina;
            private Button SbtnInserir, SbtnListar, SbtnAtualizar, SbtnDeletar;
            private CRUD crud = new CRUD();

            public Software()
            {
                this.Text = "Sofwares";
                this.Size = new Size(1000, 1000);
                this.BackColor = Color.White;
                Font fonte = new Font("Poppins", 12, FontStyle.Bold);

                labelS1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelS2 = new Label { Text = "Produto:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };
                labelS3 = new Label { Text = "Hard-Disk:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.DarkBlue };
                labelS4 = new Label { Text = "Memoria Ram:", Location = new Point(270, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelS5 = new Label { Text = "Fk Usuario:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };

                txtSId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonte };
                txtSProduto = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonte };
                txtSHarddisk = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonte };
                txtSMemoria_ram = new TextBox { Location = new Point(270, 30), Width = 220, Font = fonte };
                txtSFkMaquina = new TextBox { Location = new Point(270, 80), Width = 220, Font = fonte };

                SbtnInserir = CriarBotao("Inserir", new Point(20, 240));
                SbtnAtualizar = CriarBotao("Atualizar", new Point(130, 240));
                SbtnDeletar = CriarBotao("Deletar", new Point(240, 240));
                SbtnListar = CriarBotao("Listar", new Point(340, 240));

                SbtnInserir.Click += SbtnInserir_Click;
                SbtnAtualizar.Click += SbtnAtualizar_Click;
                SbtnDeletar.Click += SbtnDeletar_Click;
                SbtnListar.Click += SbtnListar_Click;

                this.Controls.Add(labelS1);
                this.Controls.Add(labelS2);
                this.Controls.Add(labelS3);
                this.Controls.Add(labelS4);
                this.Controls.Add(labelS5);
                this.Controls.Add(txtSId);
                this.Controls.Add(txtSHarddisk);
                this.Controls.Add(txtSMemoria_ram);
                this.Controls.Add(SbtnInserir);
                this.Controls.Add(SbtnAtualizar);
                this.Controls.Add(SbtnDeletar);
                this.Controls.Add(SbtnListar);
            }
            private void SbtnInserir_Click(object sender, EventArgs e)
            {
                var software = new Exercicio_Entity.Software
                {
                    Id = int.Parse(txtSId.Text),
                    Produto = txtSProduto.Text,
                    HardDisk = int.Parse(txtSHarddisk.Text),
                    Memoria_Ram = int.Parse(txtSMemoria_ram.Text),
                };
                crud.InserirSoftware(software);
            }

            private void SbtnAtualizar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtSId.Text);
                var software = new Exercicio_Entity.Software
                {
                    Produto = txtSProduto.Text,
                    HardDisk = int.Parse(txtSHarddisk.Text),
                    Memoria_Ram = int.Parse(txtSMemoria_ram.Text),
                };
                crud.AtualizarSoftware(id, software);
            }

            private void SbtnDeletar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtSId.Text);
                crud.DeletarSoftware(id);
            }

            private void SbtnListar_Click(object sender, EventArgs e)
            {
                crud.ListarSoftwares();
            }
        }

        public class Usuario : UserControl
        {
            public int Id { get; set; }
            public string Nome_Usuario { get; set; }
            public string Senha_Usuario { get; set; }
            public int Ramal_Usuario { get; set; }
            public string Especialidade_Usuario { get; set; }
            private Label labelU1, labelU2, labelU3, labelU4, labelU5;
            private TextBox txtUId, txtUPassword, txtUNome, txtURamal, txtUEspecialidade;
            private Button UbtnInserir, UbtnListar, UbtnAtualizar, UbtnDeletar;
            private CRUD crud = new CRUD();

            public Usuario()
            {
                this.Text = "Usuarios";
                this.Size = new Size(1000, 1000);
                this.BackColor = Color.White;
                Font fonte = new Font("Poppins", 12, FontStyle.Bold);

                labelU1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelU2 = new Label { Text = "Senha:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };
                labelU3 = new Label { Text = "Nome:", Location = new Point(20, 110), Font = fonte, ForeColor = Color.DarkBlue };
                labelU4 = new Label { Text = "Ramal:", Location = new Point(270, 10), Font = fonte, ForeColor = Color.DarkBlue };
                labelU5 = new Label { Text = "Especialidade:", Location = new Point(20, 60), Font = fonte, ForeColor = Color.DarkBlue };

                txtUId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonte };
                txtUPassword = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonte };
                txtUNome = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonte };
                txtURamal = new TextBox { Location = new Point(270, 30), Width = 220, Font = fonte };
                txtUEspecialidade = new TextBox { Location = new Point(270, 80), Width = 220, Font = fonte };


                UbtnInserir = CriarBotao("Inserir", new Point(20, 240));
                UbtnAtualizar = CriarBotao("Atualizar", new Point(130, 240));
                UbtnDeletar = CriarBotao("Deletar", new Point(240, 240));
                UbtnListar = CriarBotao("Listar", new Point(340, 240));
                // UbtnInserir = CriarBotao("Inserir", "https://cdn-icons-png.flaticon.com/512/992/992651.png");
                // UbtnAtualizar = CriarBotao("Atualizar", "https://cdn-icons-png.flaticon.com/512/3063/3063825.png");
                // UbtnListar = CriarBotao("Listar", "https://cdn-icons-png.flaticon.com/512/1087/1087080.png");
                // UbtnDeletar = CriarBotao("Deletar", "https://cdn-icons-png.flaticon.com/512/1214/1214428.png");

                UbtnInserir.Click += UbtnInserir_Click;
                UbtnAtualizar.Click += UbtnAtualizar_Click;
                UbtnDeletar.Click += UbtnDeletar_Click;
                UbtnListar.Click += UbtnListar_Click;

                this.Controls.Add(labelU1);
                this.Controls.Add(labelU2);
                this.Controls.Add(labelU3);
                this.Controls.Add(labelU4);
                this.Controls.Add(labelU5);
                this.Controls.Add(txtUId);
                this.Controls.Add(txtUId);
                this.Controls.Add(txtUPassword);
                this.Controls.Add(UbtnInserir);
                this.Controls.Add(UbtnAtualizar);
                this.Controls.Add(UbtnDeletar);
                this.Controls.Add(UbtnListar);
            }

            private void UbtnInserir_Click(object sender, EventArgs e)
            {
                var usuario = new Usuarios
                {
                    Id = int.Parse(txtUId.Text),
                    Nome_Usuario = txtUNome.Text,
                    Password = txtUPassword.Text,
                    Ramal = int.Parse(txtURamal.Text),
                    Especialidade = txtUEspecialidade.Text
                };

                crud.InserirUsuario(usuario);
            }


            private void UbtnAtualizar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtUId.Text);  // Assumindo que você tenha um campo ID no formulário
                var usuario = new Usuarios
                {
                    Nome_Usuario = txtUNome.Text,
                    Password = txtUPassword.Text,
                    Ramal = int.Parse(txtURamal.Text),
                    Especialidade = txtUEspecialidade.Text
                };

                crud.AtualizarUsuario(id, usuario);
            }


            private void UbtnDeletar_Click(object sender, EventArgs e)
            {
                var id = int.Parse(txtUId.Text);  // Assumindo que o ID do usuário seja passado no campo de ID
                crud.DeletarUsuario(id);
            }


            private void UbtnListar_Click(object sender, EventArgs e)
            {
                crud.ListarUsuarios(); // Listar todos os usuários no console (ou em uma listbox, se necessário)
            }


        }
        private static Button CriarBotao(string texto, Point localizacao)
        {
            return new Button
            {
                Text = texto,
                Location = localizacao,
                Width = 100,
                Height = 30,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Roboto", 12, FontStyle.Bold)
            };
        }
        private Button Criar Botao(string texto, Point localizacao, Color cor)
        {
            Button botao = new Button
            {
                Text = texto,
                Location = localizacao,
                Width = 100,
                Height = 30,
                BackColor = Color.LightCyan
                ForeColor = Color.White,
                Font = new Font("Roboto", 12, FontStyle.Bold)
                TextImageRelation = TextImageRelation.ImageBeforeText,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 5, 0),

                try
                {
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            byte[] imagemBytes = webClient.DownloadData(urlImagem);
                            using (var ms = new System.IO.MemoryStream(imagemBytes))
                            {
                                botao.Image = Image.FromStream(ms);
                                botao.Image = new Bitmap(botao.Image, new Size(30, 30));
                            }
                        } 
                    }
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Erro ao carregar imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                return botao;
            }
        }
    }
}