﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Universidade.Controler;
using Universidade.DAO;
using Universidade.Entidades;

namespace Universidade.View
{
    public partial class CadastroCoordenador : Form
    {
        public int verificar = 0;
        public int curso_id = 0;
        public int numCoordenador = 0;
        ControleClass controleCoordenador = new ControleClass();

        public CadastroCoordenador(int NR)
        {
            InitializeComponent();
            btnCadastrarUsuario.FlatStyle = FlatStyle.Flat;
            btnCadastrarUsuario.FlatAppearance.BorderColor = Color.ForestGreen;
            btnCadastrarUsuario.FlatAppearance.BorderSize = 1;


            btnVoltar.FlatStyle = FlatStyle.Flat;
            btnVoltar.FlatAppearance.BorderColor = Color.DarkCyan;
            btnVoltar.FlatAppearance.BorderSize = 1;


            Random numRandCoordenador = new Random();
            numCoordenador = numRandCoordenador.Next(91000000, 91999999);
            if (controleCoordenador.procurarCoordenador(numCoordenador) == null)
            {
                txtNR.Value = numRandCoordenador.Next(91000000, 91999999);
            }
            else
            {
                Random numRandCoordenador2 = new Random();
                numCoordenador = numRandCoordenador2.Next(91000000, 91999999);
            }



            if (NR != 0)
            {
                verificar = NR;
                btnCadastrarUsuario.Text = "Editar";
                label3.Text = "Edição de Professor";
                var pesquisa = new ControleClass().procurarCoordenador(NR);
                PreencherCampos(pesquisa);
            }
        }

        private void PreencherCampos(Coordenador item)
        {
            txtNome.Text = item.Nome;
            txtIdade.Value = Convert.ToInt32(item.Idade);
            txtSexo.Text = item.Sexo;
            txtEstadoCivil.Text = item.EstadoCivil;
            txtCpf.Text = item.CPF;
            txtNR.Value = item.NR;
            txtEmail.Text = item.Email;
            txtNumero.Value = item.Endereco.Numero;
            txtRua.Text = item.Endereco.Rua;
            txtCep.Text = item.Endereco.Cep;
            txtBairro.Text = item.Endereco.Bairro;
            txtEstado.Text = item.Endereco.Estado;
            txtPais.Text = item.Endereco.Pais;
            txtCidade.Text = item.Endereco.Cidade;
            txtTelefoneCelular.Text = item.Telefone.TelefoneCelular;
            txtTelefoneFixo.Text = item.Telefone.TelefoneFixo;






            curso_id = item.Curso_id;
            // var pesquisaCurso = new ControleClass().procurarCursoNomes(curso_id);
            txtCurso.Text = new ControleClass().procurarCursoNomes(curso_id);
        }

        private void BtnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            Coordenador coordenador = new Coordenador();
            Endereco endereco = new Endereco();
            Telefone telefone = new Telefone();


            coordenador.Nome = txtNome.Text;
            coordenador.Idade = Convert.ToInt32(txtIdade.Value);
            coordenador.Sexo = txtSexo.Text;
            coordenador.EstadoCivil = txtEstadoCivil.Text;
            coordenador.CPF = txtCpf.Text;
            coordenador.NR = Convert.ToInt32(txtNR.Text);
            coordenador.Email = txtEmail.Text;
            coordenador.Curso_id = curso_id;
            endereco.Cep = txtCep.Text;
            endereco.Numero = Convert.ToInt32(txtNumero.Value);
            endereco.Rua = txtRua.Text;
            endereco.Bairro = txtBairro.Text;
            endereco.Cidade = txtCidade.Text;
            endereco.Estado = txtEstado.Text;
            endereco.Pais = txtPais.Text;

            telefone.TelefoneFixo = txtTelefoneFixo.Text;
            telefone.TelefoneCelular = txtTelefoneCelular.Text;

            coordenador.Endereco = endereco;
            coordenador.Telefone = telefone;

            if (verificar == 0)
            {
                new ControleClass().adicionarCoordenador(coordenador);

                MessageBox.Show("Seu cadastro foi efetuado com sucesso!", "Cadastro efetuado com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                new ControleClass().excluirCoordenador(verificar);
                new ControleClass().adicionarCoordenador(coordenador);

                var pesquisa = new ControleClass().procurarProfessor(verificar);
                if (pesquisa != null)
                {
                    pesquisa.Nome = txtNome.Text;
                    pesquisa.Idade = Convert.ToInt32(txtIdade.Value);
                    pesquisa.Sexo = txtSexo.Text;
                    pesquisa.EstadoCivil = txtEstadoCivil.Text;
                    pesquisa.CPF = txtCpf.Text;
                    pesquisa.NR = Convert.ToInt32(txtNR.Text);
                    pesquisa.Email = txtEmail.Text;


                    pesquisa.Endereco = endereco;
                    pesquisa.Telefone = telefone;

                    new ControleClass().excluirProfessor(verificar);
                    new ControleClass().adicionarProfessor(pesquisa);
                }
                MessageBox.Show("Edição efetuada com sucesso!", "Edição efetuada com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Coordenadores coordenador = new Coordenadores();
            Hide();
            coordenador.Show();
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCep.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())

                    try
                    {
                        var endereco = ws.consultaCEP(txtCep.Text.Trim());

                        txtEstado.Text = endereco.uf;
                        txtCidade.Text = endereco.cidade;
                        txtBairro.Text = endereco.bairro;
                        txtRua.Text = endereco.end;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cep não localizado...");
                    }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido");
            }
        }
    }
}
