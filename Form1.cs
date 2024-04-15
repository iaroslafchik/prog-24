using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_prog_4
{
    public partial class Form1 : Form
    {
        int currentPlayer;
        int fieldSize;
        int columnSize;
        int rowSize;

        int[] scoresX = new int[8];
        int[] scoresO = new int[8];

        public Form1()
        {
            InitializeComponent();
            currentPlayer = 0;
            fieldSize = 3;

            dataGridView1.ColumnCount = fieldSize;
            dataGridView1.RowCount = fieldSize;

            foreach (DataGridViewRow row in dataGridView1.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Value = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.ColumnIndex;
            int j = e.RowIndex;

            string selectedCell = dataGridView1[i, j].Value.ToString();

            if (selectedCell != "")
                return;

            if (currentPlayer == 0) {
                scoresX[i]++;
                scoresX[j + 3]++;
                if (i == j)
                    scoresX[6]++;
                if (i + j == 2)
                    scoresX[7]++;
                selectedCell = "╳";
            }
            if (currentPlayer == 1) {
                scoresO[i]++;
                scoresO[j + 3]++;
                if (i == j)
                    scoresO[6]++;
                if (i + j == 2)
                    scoresO[7]++;
                selectedCell = "◯";
            }

            dataGridView1[i,j].Value = selectedCell;

            currentPlayer += 1;
            currentPlayer %= 2;

            if (scoresX.Contains(3))
                MessageBox.Show("╳ wins");
            if (scoresO.Contains(3))
                MessageBox.Show("◯ wins");
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            columnSize = dataGridView1.Width / fieldSize;
            rowSize = dataGridView1.Height / fieldSize;

            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.Height = rowSize;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
                column.Width = columnSize;
        }
    }
}
