using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            // Hentet inspirasjon fra Tesla Ludicrous mode
        }

        private void bntExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bntStart(object sender, EventArgs e)
        {
            FormSolver frmSolver = new FormSolver();
            frmSolver.ShowDialog();
        }
    }
}
