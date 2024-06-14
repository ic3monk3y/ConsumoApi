using ConsumoApi.Controllers;
using ConsumoApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumoApi
{
    public partial class Form1 : Form
    {
        private CharacterController characterController;
        private Models.Application character;
        public Form1()
        {
            InitializeComponent();
            characterController = new CharacterController();   
            character= new Models.Application();
        }

        private async void GetCharacters()
        {
            character = await characterController.GetAllCharacters();

            if (character != null)
            {
                foreach(var ch in character.results) 
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvCharacters);

                    row.Cells[0].Value = ch.name;
                    row.Cells[1].Value = ch.gender;
                    row.Cells[2].Value = ch.species;
                    row.Cells[3].Value = ch.origin;

                    dgvCharacters.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("No se puede obtener la peticion.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCharacters();
        }
    }
}
