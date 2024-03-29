﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universidade.View
{
    public partial class TelaSetores : Form
    {
        public TelaSetores()
        {
            InitializeComponent();
            btnCadastrarCargo.FlatStyle = FlatStyle.Flat;
            btnCadastrarCargo.FlatAppearance.BorderColor = Color.LightGray;
            btnCadastrarCargo.FlatAppearance.BorderSize = 1;

            btnCadastrarSetores.FlatStyle = FlatStyle.Flat;
            btnCadastrarSetores.FlatAppearance.BorderColor = Color.LightGray;
            btnCadastrarSetores.FlatAppearance.BorderSize = 1;

            btnVoltar.FlatStyle = FlatStyle.Flat;
            btnVoltar.FlatAppearance.BorderColor = Color.DarkCyan;
            btnVoltar.FlatAppearance.BorderSize = 1;
        }

        private void BtnCadastrarSetores_Click(object sender, EventArgs e)
        {
            Setores setor = new Setores();
            Hide();
            setor.Show();
        }

        private void BtnCadastrarCargo_Click(object sender, EventArgs e)
        {
            Cargos cargo = new Cargos();
            Hide();
            cargo.Show();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Hide();
            form1.Show();
        }
    }
}
