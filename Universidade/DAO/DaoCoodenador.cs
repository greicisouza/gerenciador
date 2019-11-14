﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidade.Arquivo;
using Universidade.Entidades;

namespace Universidade.DAO
{
    class DaoCoodenador
    {
        private static List<Coordenador> listaCoordenador = new List<Coordenador>();
        Arquivos arquivo = new Arquivos();

        public void addCoordenador(Coordenador coordenador)
        {
            listaCoordenador.Add(coordenador);
            arquivo.SalvarCoordenadores(listaCoordenador);
        }

        public void addCoordenadorLer(List<Coordenador> coordenador)
        {
            listaCoordenador = coordenador;
            arquivo.SalvarCoordenadores(listaCoordenador);
        }

        public List<Coordenador> listarCoordenador()
        {
            return listaCoordenador;
        }

        public List<Coordenador> listarCoordenadorCodigo(int codigo)
        {
            List<Coordenador> listinha = listaCoordenador.FindAll(x => x.NR == codigo);
            return listinha;
        }

        public List<Coordenador> listarCoordenadorNome(string codigo)
        {
            List<Coordenador> listinha = listaCoordenador.FindAll(x => x.Nome == codigo);
            return listinha;
        }

        public void excluirCoordenador(int item)
        {
            listaCoordenador.RemoveAll(x => x.NR == item);
            arquivo.SalvarCoordenadores(listaCoordenador);
        }

        public Coordenador procurarCoordenador(int item)
        {
            Coordenador coordenador = listaCoordenador.Find(x => x.NR == item);
            return coordenador;
        }

        public Coordenador procurarCoordenadorNome(string item)
        {
            Coordenador coordenador = listaCoordenador.Find(x => x.Nome == item);
            return coordenador;
        }
    }
}
