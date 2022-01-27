using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace UrlChange
{
  public partial class Main : Form
  {
    IConfiguration CONFIG;
    Dictionary<string, string> ROW_LIST;
    MySqlConnection CONN;
    char TYPE = 'N';

    public Main()
    {
      Cursor = Cursors.WaitCursor;
      InitializeComponent();
      CONN = null;
      string msg = null;
      rbTypeNomal.Checked = false;
      rbTypeFile.Checked = true;

      try
      {
        ROW_LIST = new Dictionary<string, string>();
        CONFIG = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                         .AddJsonFile("config.json", true, true)
                                         .Build();
        IConfigurationSection section = CONFIG.GetSection("Corp");
        string strDBConn = section["DBConn"];
        CONN = new MySqlConnection(strDBConn);
        CONN.Open();
      }
      catch (MySqlException ex)
      {
        msg = ex.Message;
        Console.Write(ex.Message);
      }
      catch (Exception ex)
      {
        msg = ex.Message;
        Console.Write(ex.Message);
      }
      finally
      {
        Cursor = Cursors.Default;
        if(msg != null)
        {
          MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void btnView_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      dgvList.Rows.Clear();
      string msg = null;

      try
      {
        SelectToMySQL();
      }
      catch (MySqlException ex)
      {
        msg = ex.Message;
        Console.Write(ex.Message);
      }
      finally
      {
        Cursor = Cursors.Default;
        if (msg == null)
        {
          MessageBox.Show("view success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }
      }
    }

    private void btnChange_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      string value = "";
      int intColContext = dgvList.Columns["ColContext"].Index;
      int intColChange = dgvList.Columns["ColChange"].Index;
      int intColChangeAfter = dgvList.Columns["ColChangeAfter"].Index;
      int intColAfterContext = dgvList.Columns["ColAfterContext"].Index;
      string msg = null;

      try
      {
        foreach (DataGridViewRow dgvr in dgvList.Rows)
        {
          if (dgvr.Cells[intColContext].Value == null)
          {
            break;
          }
          value = dgvr.Cells[intColContext].Value.ToString();
          dgvr.Cells[intColChange].Value = "";
          dgvr.Cells[intColChangeAfter].Value = "";
          dgvr.Cells[intColAfterContext].Value = "";
                //  相対パス
          // "(\/profile\/news\/)(.*?)((pdf)|(jpg)|(png)|(zip)|(pptx)|(jpeg))"
                 //  絶対パス
          // "(https:\/\/willgroup.co.jp)(.*?)((pdf)|(jpg)|(png)|(zip)|(pptx)|(jpeg))"|'(https:\/\/willgroup.co.jp)(.*?)((pdf)|(jpg)|(png)|(zip)|(pptx)|(jpeg))'
          var matches = Regex.Matches(value, txtRegex.Text).Cast<Match>().OrderBy(x => x.Length);
          foreach (Match mItem in matches)
          {
            dgvr.Cells[intColChange].Value += mItem.Value;
            dgvr.Cells[intColChangeAfter].Value += ChangeValue(mItem.Value);
            value = value.Replace(dgvr.Cells[intColChange].Value.ToString(), dgvr.Cells[intColChangeAfter].Value.ToString());
          }
          dgvr.Cells[intColAfterContext].Value = value;
        }
      }
      catch (MySqlException ex)
      {
        msg = ex.Message;
        Console.Write(ex.Message);
      }
      catch (Exception ex)
      {
        msg = ex.Message;
        Console.Write(ex.Message);
      }
      finally
      {
        Cursor = Cursors.Default;
        if (msg == null)
        {
          MessageBox.Show("change success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (CONN != null)
      {
        CONN.Close();
        CONN.Dispose();
        CONN = null;
      }
      if (ROW_LIST != null)
      {
        ROW_LIST.Clear();
        ROW_LIST = null;
      }
      CONFIG = null;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      dgvList.Rows.Clear();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      string key = "";
      string val = "";
      string change = "";
      List<string> noChange = new List<string>();
      bool result = true;
      int intColKey = dgvList.Columns["ColKey"].Index;
      int intColChange = dgvList.Columns["ColChange"].Index;
      int intColAfterContext = dgvList.Columns["ColAfterContext"].Index;
      string msg = null;

      try
      {
        foreach (DataGridViewRow dgvr in dgvList.Rows)
        {
          if (dgvr.Cells[intColKey].Value == null || !result)
          {
            break;
          }
          key = dgvr.Cells[intColKey].Value.ToString();
          change = dgvr.Cells[intColChange].Value.ToString();
          val = dgvr.Cells[intColAfterContext].Value.ToString();

          if (!string.IsNullOrEmpty(change) && !string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(val))
          {
            result = UpdateToMySQL(key, val);
          }
          else
          {
            noChange.Add(key);
          }
        }
      }
      catch (MySqlException ex)
      {
        msg = ex.Message;
        Console.Write(ex.Message);
      }
      catch (Exception ex)
      {
        msg = ex.Message;
        Console.Write(ex.Message);
      }
      finally
      {
        Cursor = Cursors.Default;
        
        if (msg == null)
        {
          if (result)
          {
            string strNoChange = "";
            if(noChange != null)
            {
              strNoChange = string.Join(", ", noChange);
            }
            MessageBox.Show(string.Format("save success.{0}", strNoChange), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show(string.Format("error in key = {0}", key), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {
          MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        noChange = null;
      }
    }

    private string ChangeValue(string moto)
    {
      string result = "";
      string cBeforeVal = "";

      if (TYPE == 'L')
      {
        string[] arrMoto = moto.Split('/');
        cBeforeVal = moto.Replace(arrMoto[arrMoto.Length - 1], "");
      }
      else
      {
        cBeforeVal = moto;
      }

      string cAfterVal = txtAfterUrl.Text;
      result = moto.Replace(cBeforeVal, cAfterVal);
      return result;
    }

    private void SelectToMySQL()
    {
      MySqlCommand cmd = null;
      MySqlDataReader reader = null;

      try
      {
        if (CONN.State != ConnectionState.Open) {
          CONN.Open();
        }
        cmd = CONN.CreateCommand();
        cmd.CommandText = string.Format("SELECT p.{0}, p.{1} FROM willgroupcorp.{2} p WHERE {3};", txtKeyColumn.Text, txtValColumn.Text, txtTable.Text, txtWhere.Text);

        reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        while (reader.Read())
        {
          dgvList.Rows.Add(reader.GetString(txtKeyColumn.Text), reader.GetString(txtValColumn.Text), "", "", "");
        }
      }
      catch (MySqlException)
      {
        throw;
      }
      catch (Exception)
      {
        throw;
      }
      finally
      {
        if (cmd != null)
        {
          cmd.Dispose();
        }
        if (reader != null)
        {
          reader.Close();
          reader.Dispose();
        }
      }
    }

    private bool UpdateToMySQL(string key, string val)
    {
      bool result = false;

      MySqlCommand cmd = null;
      MySqlTransaction trans = null;

      try
      {
        if (CONN.State != ConnectionState.Open)
        {
          CONN.Open();
        }
        cmd = CONN.CreateCommand();
        cmd.CommandText = string.Format("UPDATE willgroupcorp.{0} SET {1} = '{2}' WHERE {3} = '{4}';", txtTable.Text, txtValColumn.Text, val, txtKeyColumn.Text, key);

        trans = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
        cmd.ExecuteNonQuery();
        trans.Commit();
        result = true;
      }
      catch (MySqlException)
      {
        trans.Rollback();
        throw;
      }
      catch (Exception)
      {
        throw;
      }
      finally
      {
        if (cmd != null)
        {
          cmd.Dispose();
        }
        if (trans != null)
        {
          trans.Dispose();
        }
      }

      return result;
    }

    private void rbTypeNomal_CheckedChanged(object sender, EventArgs e)
    {
      if (rbTypeNomal.Checked)
      {
        TYPE = 'N';
      }
      lblAfterUrl.Text = "AfterText";
    }

    private void rbTypeFile_CheckedChanged(object sender, EventArgs e)
    {
      if(rbTypeFile.Checked)
      {
        TYPE = 'L';
      }
      lblAfterUrl.Text = "AfterUrl";
    }

    
  }
}
