using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TwilioSMS
{
    public partial class AttendantSearch : Form
    {
        protected Boolean m_BlankValid  = true;
        protected string m_returnText = "";
        public AttendantSearch()
        {
            InitializeComponent();
        }
         public DialogResult ShowDialog(
            String TitleText,
            String PromptText,
            String DefaultText,
           ref String EnteredText,
            Boolean BlankValid)
        {
            this.Text = TitleText;
            this.LastNameTxt.Text = DefaultText;
            this.FirstNameTxt.Text = DefaultText;
            this.ShowDialog();
            EnteredText = m_returnText;
            return this.DialogResult;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            String SelectString =  String.Empty;
            SqlCommand Command = new SqlCommand();
            SqlConnection Connection = new SqlConnection("Server=HRASQL\\HRASQL;Database=HRA;Integrated Security=SSPI");
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataTable DT = new DataTable();
            Int32 Count = 0;
            String WildCardParam = String.Empty;

            SelectString = "Select count(*) from mdnurdat where ";
            if (LastNameTxt.Text != "")
            {
                SelectString += "Last_Name like @param1";
                //SelectString += "Last_Name like '" + LastNameTxt.Text + "%'";
            }

            if(LastNameTxt.Text !=" " && FirstNameTxt.Text !=" ")
            {
                SelectString += " and ";
            }

            if(FirstNameTxt.Text !=" ")
            {
                SelectString += "First_Name like @param2";
                //SelectString += "First_Name like '" + FirstNameTxt.Text + "%'";
            }
            Command.CommandText = SelectString;
            Command.Connection = Connection; 
            Command.CommandType = CommandType.Text;
            Command.CommandTimeout = 300;
            WildCardParam = String.Format("{0}%", LastNameTxt.Text);
            Command.Parameters.AddWithValue("@param1", WildCardParam);
            WildCardParam = String.Format("{0}%", FirstNameTxt.Text);
            Command.Parameters.AddWithValue("@param2", WildCardParam);
            try
            {
                Connection.Open();
               Count = (Int32)Command.ExecuteScalar();
            
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            if(Count != 0)
            {
                SelectString = SelectString.Replace("count(*)", "Nurse_Id, First_Name, Last_Name, '1' + Phone as Phone");
                Command.CommandText = SelectString;
                Adapter.SelectCommand = Command;
                try
                {
                    Connection.Open();
                    Adapter.Fill(DT);
                    DataGridView1.DataSource = DT;
                    DataGridView1.Refresh();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Connection.Close();
                }
            }
            else
            {
                MessageBox.Show("No Attendant Found.");
            }

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            Int32 SelectedIndex = 0;
            try
            {
                SelectedIndex = DataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow CurRow = DataGridView1.Rows[SelectedIndex];
                m_returnText = CurRow.Cells["Phone"].Value.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
