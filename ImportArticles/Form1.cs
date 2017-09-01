using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportArticles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = ofdSelectFile.ShowDialog();
                if(result == DialogResult.OK)
                {
                    txtFileName.Text = ofdSelectFile.FileName; //show file name
                    btnImport.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Buttons(false);

                FileOperations fileOp = new FileOperations();
                List<Article> list = fileOp.ReadFile(ofdSelectFile.FileName);
                if (list.Count > 0)
                {
                    this.InitializeProgress(list.Count); //progress bar
                    DataBaseSettings db = new DataBaseSettings();

                    foreach (Article article in list)
                    {
                        //string query = string.Format("EXEC xsp_Rodo '{0}', '{1}'", article.ID, article.Description);
                        //db.ExecuteQuery(query);
                        Task.Delay(100).Wait();
                        pbArticles.Increment(1);
                    }

                    MessageBox.Show("Artículos importados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbArticles.Value = 0;
                }
                else
                {
                    MessageBox.Show("El archivo no contiene artículos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnSelectFile.Enabled = true;
                txtFileName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeProgress(int total)
        {
            try
            {
                pbArticles.Maximum = total;
                pbArticles.Step = 1;
                pbArticles.Value = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Buttons(bool enable)
        {
            try
            {
                btnImport.Enabled = enable;
                btnSelectFile.Enabled = enable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
