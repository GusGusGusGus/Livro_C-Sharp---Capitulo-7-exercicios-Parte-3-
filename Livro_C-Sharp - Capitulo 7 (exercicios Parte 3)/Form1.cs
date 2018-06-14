using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livro_C_Sharp___Capitulo_7__exercicios_Parte_3_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
          
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var lista = from Departamentos in dc.Departamentos select Departamentos;
            foreach (Departamentos dep in lista)
            {
                treeView1.Nodes.Add(dep.Sigla);
            }

            DataClasses1DataContext dc2 = new DataClasses1DataContext();
            var lista2 = from Funcionarios in dc2.Funcionarios orderby Funcionarios.Nome select Funcionarios;
            string departamento;
            foreach (Funcionarios func in lista2)
            {
                departamento = func.Departamento;
                foreach (TreeNode noPrincipal in treeView1.Nodes)
                {
                    if (noPrincipal.Text == departamento)
                    {
                        noPrincipal.Nodes.Add(func.Nome);
                    }
                }
            }
        }
    }
}
