using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku_Solver
{
    public partial class FormSolver : Form
    {
        public FormSolver()
        {
            InitializeComponent();
        }

        // ------- Åpner en fil og skriver det ut til txtInput og comboboxene------
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string filename , text;
            dlgOpen.InitialDirectory = Directory.GetCurrentDirectory();
            dlgOpen.Filter = "Text Files|*.txt|All Files|*.*";
            dlgOpen.ShowDialog();
            filename = dlgOpen.FileName;
            filename = Path.GetFileName(filename);

            text = (ReadFromFile(filename));
            PrintOutFromFile(text);
        }

        // ------- Henter tallene fra txtInput og lagrer de i en txt fil som string --------
        private void mnuSave_Click(object sender, EventArgs e) 
        {
            string filename, text;
            string inputGrid = "";

            dlgSave.InitialDirectory = Directory.GetCurrentDirectory();
            dlgSave.Filter = "Text Files|*.txt|All Files|*.*";
            dlgSave.ShowDialog();
            filename = dlgSave.FileName;
            filename = Path.GetFileName(filename);

            foreach (Control control in tlpNumbers.Controls)
            {
                if (control is ComboBox)
                {
                    inputGrid = (((ComboBox)control).Text);
                    txtInput.AppendText(inputGrid);
                }
            }

            text = txtInput.Text; // Leser tallene som står i txtInput. Problemmet er at programmet krasjer før det skjer.
            WriteToFile(filename, text);
        }

        // ------- Lukker programmet ------------
        private void mnuClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ------- Lenke til nettside om sukoku ------------
        private void mnuLearnMore_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://sudoku.com/how-to-play/sudoku-rules-for-complete-beginners/");
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke åpne lenken som ble klikket på.");
            }
        }

        // --------- Skriver til fil ------------
        void WriteToFile(string filename, string text)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(text);
            streamWriter.Close();
        }

        // ------- Leser fra fil ------------
        string ReadFromFile(string filename)
        {
            string text = "";

            try
            {
                FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileStream);
                text = streamReader.ReadToEnd();
                streamReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return text;
        }

        // ---------- Henter ut tall fra Comboboxene --------------
        int[,] CollectNumbers(int [,] grid)
        {
            string inputGrid = "";

            foreach (Control control in tlpNumbers.Controls)
            {
                if (control is ComboBox)
                {
                    inputGrid = (((ComboBox)control).Text);
                    txtInput.AppendText(inputGrid);
                }
            }

            // prøvde å lage en løkke som tok seg av dette, men den fungerte ikke slik jeg ønsket
            // Gi meg gjerne råd om hvordan jeg gjør det riktig

            //foreach (Control control in tlpNumbers.Controls)
            //{
            //    if (control is ComboBox)
            //    {
            //        for (int y = 0; y <= grid.GetUpperBound(0); y++) //Itererer alle rader
            //        {
            //            for (int x = 0; x <= grid.GetUpperBound(1); x++) //Itererer alle koloner
            //            {
            //                grid[y, x] = Convert.ToInt32(((ComboBox)control).Text);
            //                txtInput.AppendText(grid[y,x].ToString());
            //            }
            //        }
            //        //index++;
            //    }

            //}

            grid[0, 0] = Convert.ToInt32(cbo00.Text);
            grid[0, 1] = Convert.ToInt32(cbo01.Text);
            grid[0, 2] = Convert.ToInt32(cbo02.Text);
            grid[0, 3] = Convert.ToInt32(cbo03.Text);
            grid[0, 4] = Convert.ToInt32(cbo04.Text);
            grid[0, 5] = Convert.ToInt32(cbo05.Text);
            grid[0, 6] = Convert.ToInt32(cbo06.Text);
            grid[0, 7] = Convert.ToInt32(cbo07.Text);
            grid[0, 8] = Convert.ToInt32(cbo08.Text);
            grid[1, 0] = Convert.ToInt32(cbo10.Text);
            grid[1, 1] = Convert.ToInt32(cbo11.Text);
            grid[1, 2] = Convert.ToInt32(cbo12.Text);
            grid[1, 3] = Convert.ToInt32(cbo13.Text);
            grid[1, 4] = Convert.ToInt32(cbo14.Text);
            grid[1, 5] = Convert.ToInt32(cbo15.Text);
            grid[1, 6] = Convert.ToInt32(cbo16.Text);
            grid[1, 7] = Convert.ToInt32(cbo17.Text);
            grid[1, 8] = Convert.ToInt32(cbo18.Text);
            grid[2, 0] = Convert.ToInt32(cbo20.Text);
            grid[2, 1] = Convert.ToInt32(cbo21.Text);
            grid[2, 2] = Convert.ToInt32(cbo22.Text);
            grid[2, 3] = Convert.ToInt32(cbo23.Text);
            grid[2, 4] = Convert.ToInt32(cbo24.Text);
            grid[2, 5] = Convert.ToInt32(cbo25.Text);
            grid[2, 6] = Convert.ToInt32(cbo26.Text);
            grid[2, 7] = Convert.ToInt32(cbo27.Text);
            grid[2, 8] = Convert.ToInt32(cbo28.Text);
            grid[3, 0] = Convert.ToInt32(cbo30.Text);
            grid[3, 1] = Convert.ToInt32(cbo31.Text);
            grid[3, 2] = Convert.ToInt32(cbo32.Text);
            grid[3, 3] = Convert.ToInt32(cbo33.Text);
            grid[3, 4] = Convert.ToInt32(cbo34.Text);
            grid[3, 5] = Convert.ToInt32(cbo35.Text);
            grid[3, 6] = Convert.ToInt32(cbo36.Text);
            grid[3, 7] = Convert.ToInt32(cbo37.Text);
            grid[3, 8] = Convert.ToInt32(cbo38.Text);
            grid[4, 0] = Convert.ToInt32(cbo40.Text);
            grid[4, 1] = Convert.ToInt32(cbo41.Text);
            grid[4, 2] = Convert.ToInt32(cbo42.Text);
            grid[4, 3] = Convert.ToInt32(cbo43.Text);
            grid[4, 4] = Convert.ToInt32(cbo44.Text);
            grid[4, 5] = Convert.ToInt32(cbo45.Text);
            grid[4, 6] = Convert.ToInt32(cbo46.Text);
            grid[4, 7] = Convert.ToInt32(cbo47.Text);
            grid[4, 8] = Convert.ToInt32(cbo48.Text);
            grid[5, 0] = Convert.ToInt32(cbo50.Text);
            grid[5, 1] = Convert.ToInt32(cbo51.Text);
            grid[5, 2] = Convert.ToInt32(cbo52.Text);
            grid[5, 3] = Convert.ToInt32(cbo53.Text);
            grid[5, 4] = Convert.ToInt32(cbo54.Text);
            grid[5, 5] = Convert.ToInt32(cbo55.Text);
            grid[5, 6] = Convert.ToInt32(cbo56.Text);
            grid[5, 7] = Convert.ToInt32(cbo57.Text);
            grid[5, 8] = Convert.ToInt32(cbo58.Text);
            grid[6, 0] = Convert.ToInt32(cbo60.Text);
            grid[6, 1] = Convert.ToInt32(cbo61.Text);
            grid[6, 2] = Convert.ToInt32(cbo62.Text);
            grid[6, 3] = Convert.ToInt32(cbo63.Text);
            grid[6, 4] = Convert.ToInt32(cbo64.Text);
            grid[6, 5] = Convert.ToInt32(cbo65.Text);
            grid[6, 6] = Convert.ToInt32(cbo66.Text);
            grid[6, 7] = Convert.ToInt32(cbo67.Text);
            grid[6, 8] = Convert.ToInt32(cbo68.Text);
            grid[7, 0] = Convert.ToInt32(cbo70.Text);
            grid[7, 1] = Convert.ToInt32(cbo71.Text);
            grid[7, 2] = Convert.ToInt32(cbo72.Text);
            grid[7, 3] = Convert.ToInt32(cbo73.Text);
            grid[7, 4] = Convert.ToInt32(cbo74.Text);
            grid[7, 5] = Convert.ToInt32(cbo75.Text);
            grid[7, 6] = Convert.ToInt32(cbo76.Text);
            grid[7, 7] = Convert.ToInt32(cbo77.Text);
            grid[7, 8] = Convert.ToInt32(cbo78.Text);
            grid[8, 0] = Convert.ToInt32(cbo80.Text);
            grid[8, 1] = Convert.ToInt32(cbo81.Text);
            grid[8, 2] = Convert.ToInt32(cbo82.Text);
            grid[8, 3] = Convert.ToInt32(cbo83.Text);
            grid[8, 4] = Convert.ToInt32(cbo84.Text);
            grid[8, 5] = Convert.ToInt32(cbo85.Text);
            grid[8, 6] = Convert.ToInt32(cbo86.Text);
            grid[8, 7] = Convert.ToInt32(cbo87.Text);
            grid[8, 8] = Convert.ToInt32(cbo88.Text);

            return grid;
        }

        // ----------- Printer ut tall til Combobox -----------
        void PrintOutNumbers (int[,] grid)
        {
            string outputGrid = "";

            // prøvde å lage en løkke som tok seg av dette, men den fungerte ikke slik jeg ønsket
            // Gi meg gjerne råd om hvordan jeg gjør det riktig

            cbo00.Text = grid[0, 0].ToString();
            cbo01.Text = grid[0, 1].ToString();
            cbo02.Text = grid[0, 2].ToString();
            cbo03.Text = grid[0, 3].ToString();
            cbo04.Text = grid[0, 4].ToString();
            cbo05.Text = grid[0, 5].ToString();
            cbo06.Text = grid[0, 6].ToString();
            cbo07.Text = grid[0, 7].ToString();
            cbo08.Text = grid[0, 8].ToString();
            cbo10.Text = grid[1, 0].ToString();
            cbo11.Text = grid[1, 1].ToString();
            cbo12.Text = grid[1, 2].ToString();
            cbo13.Text = grid[1, 3].ToString();
            cbo14.Text = grid[1, 4].ToString();
            cbo15.Text = grid[1, 5].ToString();
            cbo16.Text = grid[1, 6].ToString();
            cbo17.Text = grid[1, 7].ToString();
            cbo18.Text = grid[1, 8].ToString();
            cbo20.Text = grid[2, 0].ToString();
            cbo21.Text = grid[2, 1].ToString();
            cbo22.Text = grid[2, 2].ToString();
            cbo23.Text = grid[2, 3].ToString();
            cbo24.Text = grid[2, 4].ToString();
            cbo25.Text = grid[2, 5].ToString();
            cbo26.Text = grid[2, 6].ToString();
            cbo27.Text = grid[2, 7].ToString();
            cbo28.Text = grid[2, 8].ToString();
            cbo30.Text = grid[3, 0].ToString();
            cbo31.Text = grid[3, 1].ToString();
            cbo32.Text = grid[3, 2].ToString();
            cbo33.Text = grid[3, 3].ToString();
            cbo34.Text = grid[3, 4].ToString();
            cbo35.Text = grid[3, 5].ToString();
            cbo36.Text = grid[3, 6].ToString();
            cbo37.Text = grid[3, 7].ToString();
            cbo38.Text = grid[3, 8].ToString();
            cbo40.Text = grid[4, 0].ToString();
            cbo41.Text = grid[4, 1].ToString();
            cbo42.Text = grid[4, 2].ToString();
            cbo43.Text = grid[4, 3].ToString();
            cbo44.Text = grid[4, 4].ToString();
            cbo45.Text = grid[4, 5].ToString();
            cbo46.Text = grid[4, 6].ToString();
            cbo47.Text = grid[4, 7].ToString();
            cbo48.Text = grid[4, 8].ToString();
            cbo50.Text = grid[5, 0].ToString();
            cbo51.Text = grid[5, 1].ToString();
            cbo52.Text = grid[5, 2].ToString();
            cbo53.Text = grid[5, 3].ToString();
            cbo54.Text = grid[5, 4].ToString();
            cbo55.Text = grid[5, 5].ToString();
            cbo56.Text = grid[5, 6].ToString();
            cbo57.Text = grid[5, 7].ToString();
            cbo58.Text = grid[5, 8].ToString();
            cbo60.Text = grid[6, 0].ToString();
            cbo61.Text = grid[6, 1].ToString();
            cbo62.Text = grid[6, 2].ToString();
            cbo63.Text = grid[6, 3].ToString();
            cbo64.Text = grid[6, 4].ToString();
            cbo65.Text = grid[6, 5].ToString();
            cbo66.Text = grid[6, 6].ToString();
            cbo67.Text = grid[6, 7].ToString();
            cbo68.Text = grid[6, 8].ToString();
            cbo70.Text = grid[7, 0].ToString();
            cbo71.Text = grid[7, 1].ToString();
            cbo72.Text = grid[7, 2].ToString();
            cbo73.Text = grid[7, 3].ToString();
            cbo74.Text = grid[7, 4].ToString();
            cbo75.Text = grid[7, 5].ToString();
            cbo76.Text = grid[7, 6].ToString();
            cbo77.Text = grid[7, 7].ToString();
            cbo78.Text = grid[7, 8].ToString();
            cbo80.Text = grid[8, 0].ToString();
            cbo81.Text = grid[8, 1].ToString();
            cbo82.Text = grid[8, 2].ToString();
            cbo83.Text = grid[8, 3].ToString();
            cbo84.Text = grid[8, 4].ToString();
            cbo85.Text = grid[8, 5].ToString();
            cbo86.Text = grid[8, 6].ToString();
            cbo87.Text = grid[8, 7].ToString();
            cbo88.Text = grid[8, 8].ToString();

            foreach (Control control in tlpNumbers.Controls)
            {
                if (control is ComboBox)
                {
                    outputGrid = (((ComboBox)control).Text);
                    txtOutput.AppendText(outputGrid);
                }
            }
           
        }

        void PrintOutFromFile(string text)
        {
            try
            {
                int numbers = Int32.Parse(text);
                
                foreach (Control control in tlpNumbers.Controls)
                {
                    if (control is ComboBox)
                    {
                        ((ComboBox)control).Text = numbers.ToString();
                        txtInput.AppendText(text);
                    }
                }
            }
            catch (Exception)
            {
                txtInput.Text = "Kunne ikke lese fra fil";
            }
        }

        //------ Bruker brute-force til å regne ut riktig svar ------
        bool possible(int y, int x, int n, int [,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[y,i] == n)
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (grid[i,x] == n)
                {
                    return false;
                }
            }

            double xx0 = Math.Floor(x / 3.0) * 3;
            double yy0 = Math.Floor(y / 3.0) * 3;

            int x0 = Convert.ToInt32(xx0);
            int y0 = Convert.ToInt32(yy0);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[y0+i,x0+j] == n)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        void solve (int [,] grid)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (grid[y, x] == 0)
                    {
                        for (int n = 1; n < 10; n++)
                        {
                            if (possible(y, x, n, grid))
                            {
                                grid[y, x] = n;
                                solve(grid);
                                grid[y, x] = 0;
                            }
                        }
                        return;
                    }
                }
            }
            PrintOutNumbers(grid);
        }

        // -------------------------------------------------------
        private void bntResult_Click(object sender, EventArgs e)
        {
            int[,] grid = new int[9, 9];
            CollectNumbers(grid);
            solve(grid);
        }

        private void bntRestart_Click(object sender, EventArgs e)
        {
            foreach (Control control in tlpNumbers.Controls)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).Text = "0";
                }
            }
        }
    }
}
