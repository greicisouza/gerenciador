﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Universidade.Controler;
using System.Windows.Forms;
using Universidade.DAO;
using Universidade.Entidades;

namespace Universidade.View
{
    public partial class CadastroCurso : Form
    {
        ControleClass controles = new ControleClass();

        private Curso curso     = new Curso();
        public int numerinho = 0;
        public int numMateria = 0;

        private static List<Materias> listaMaterias = new List<Materias>();

        public CadastroCurso()
        {
            InitializeComponent();

            btnCadastrarUsuario.FlatStyle = FlatStyle.Flat;
            btnCadastrarUsuario.FlatAppearance.BorderColor = Color.ForestGreen;
            btnCadastrarUsuario.FlatAppearance.BorderSize = 1;


            btnVoltar.FlatStyle = FlatStyle.Flat;
            btnVoltar.FlatAppearance.BorderColor = Color.DarkCyan;
            btnVoltar.FlatAppearance.BorderSize = 1;

            addItem.FlatStyle = FlatStyle.Flat;
            addItem.FlatAppearance.BorderColor = Color.ForestGreen;
            addItem.FlatAppearance.BorderSize = 1;

            PrencheerCombo();
            PrencheerComboProfessor();

            Random numRandCurso = new Random();
            numerinho = numRandCurso.Next(1000, 5000); 
            if (controles.procurarCurso(numerinho) == null)
            {
                txtCodigo.Value = numRandCurso.Next(1000, 5000);
            } else
            {
                Random numRande = new Random();
                numerinho = numRande.Next(1000, 5000);
            }
            curso.Codigo = Convert.ToInt32(txtCodigo.Value);



            /*
            Random numRandMateria = new Random();
            numMateria = numRandMateria.Next(6000, 9000);
            if (controles.procurarMateria(numMateria) == null)
            {
            txtCod.Value = numRandMateria.Next(6000, 9000);
            }
            else
            {
            Random numRandMateria2 = new Random();
           numMateria= numRandMateria2.Next(6000, 9000);
            }
            */




        }

        public void PrencheerCombo()
        {
            var listaCoordenador = controles.listarCoordenador();
            foreach (Coordenador coord in listaCoordenador)
            {
                txtCoordenador.Items.Add(coord.Nome);
            }
        }

        public void PrencheerComboProfessor()
        {
            var listaProfessor = controles.listarProfessorMateria();
            foreach (Professores professores in listaProfessor)
            {
                txtProfessor.Items.Add(professores.Nome);
            }
        }

        public void AddItem_Click(object sender, EventArgs e)
        {
            Materias materia = new Materias();

            materia.Nome            = txtNomeM.Text;
            materia.Codigo          = Convert.ToInt32(txtCod.Value);
            materia.Carga_horaria   = Convert.ToInt32(txtCarga.Value);
            materia.Periodo         = Convert.ToInt32(txtPeriodo.Text);

            var pesquisa            = new DaoProfessor().procurarProfessorNome(txtProfessor.Text);
            pesquisa.Curso_id       = Convert.ToInt32(txtCodigo.Value);
            pesquisa.Materia_id     = Convert.ToInt32(txtCod.Value);

            materia.Professor_id    = pesquisa.NR;
           
            listaMaterias.Add(materia);

            controles.excluirProfessor(pesquisa.NR);
            controles.adicionarProfessor(pesquisa);

            txtNomeM.Text       = "";
            txtCod.Value        = 0;
            txtCarga.Value      = 0;
            txtProfessor.Text   = "";
            txtPeriodo.Text     = "";
            listar();
        }

        public void listar()
        {
            richTextBox1.Clear();
            foreach (Materias materias in listaMaterias)
            {
                var pesquisa = controles.procurarProfessor(materias.Professor_id);
                richTextBox1.AppendText("Máteria: " + materias.Nome + "\nCódigo: " + materias.Codigo + "\nCarga Horária: " + materias.Carga_horaria + "\nProfessor: " + pesquisa.Nome + "\n\n");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Cursos curso = new Cursos();
            Hide();
            curso.Show();
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            
            Curso curso = new Curso();

            curso.Materias              = listaMaterias;
            curso.Codigo                = Convert.ToInt32(txtCodigo.Value);
            curso.Nome                  = txtNome.Text;
            curso.QuantidadePeriodo     = Convert.ToInt32(txtQuantidadePeriodo.Text);

            var pesquisaCood            = controles.procurarCoordenadorNome(txtCoordenador.Text);
            pesquisaCood.Curso_id       = Convert.ToInt32(txtCodigo.Value);

            curso.Coordernador_id       = pesquisaCood.NR;

            controles.excluirCoordenador(Convert.ToInt32(pesquisaCood.NR));
            controles.adicionarCoordenador(pesquisaCood);

            controles.adicionarCurso(curso);

            MessageBox.Show("Curso cadastrado com sucesso!", "Curso cadastrado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
        }

        private void txtCodigo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CadastroCurso_Load(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }


}