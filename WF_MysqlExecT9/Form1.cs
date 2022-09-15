﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_MySqlExecT9
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;

        public Form1()
        {
            InitializeComponent();

            connection = new MySqlConnection("Server=localhost;Database=pizaaria;Uid=root;Pwd=;SslMode=none");
        }

        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            // cria lista do tipo Cliente
            List<Cliente> listaClientes = new List<Cliente>();
            // popular a lista através do select do banco de dados
            command = new MySqlCommand();
            // abre a conexão
            connection.Open();
            // seta a conexão para o comando
            command.Connection = connection;
            command.CommandText = "SELECT nome_completo, data_de_nascimento, telefone, ddd, complemento, cep FROM cliente";
            // executa o comando
            reader= command.ExecuteReader();

            while (reader.Read())
            {
                // cria a variável "cliente" dentro da class "Cliente"
                Cliente cliente = new Cliente();

                // obtém todos os campos da tabela "cliente" no banco de dados e joga dentro da variável "cliente"
                cliente.nome_completo = reader["nome_completo"].ToString();
                cliente.data_de_nascimento = reader["data_de_nascimento"].ToString();
                cliente.telefone = reader["telefone"].ToString();
                cliente.ddd = reader["ddd"].ToString();
                
                cliente.complemento = reader["complemento"].ToString();
                cliente.cep = reader["cep"].ToString();
                

                ListViewItem Cliente = new ListViewItem();

                // adiciona na listview todos os campos capturados pela variável "cliente"
                Cliente.Text = cliente.nome_completo;
                Cliente.SubItems.Add(cliente.data_de_nascimento);
                Cliente.SubItems.Add(cliente.telefone);
                Cliente.SubItems.Add(cliente.ddd);
                
                Cliente.SubItems.Add(cliente.complemento);
                Cliente.SubItems.Add(cliente.cep);
                

                listViewClientes.Items.Add(Cliente);
            }
            connection.Close();
        }
    }

    class Cliente
    {
        public string nome_completo { get; set; }
        public string data_de_nascimento { get; set; }
        public string telefone { get; set; }
        public string ddd { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
    }
}
