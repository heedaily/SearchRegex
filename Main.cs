using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace SearchRegex
{
  public partial class Main : Form
  {
    /// <summary>
    /// Connection settings
    /// </summary>
    IConfiguration CONFIG;
    /// <summary>
    /// Connection
    /// </summary>
    MySqlConnection CONN;
    /// <summary>
    /// regex change type
    /// </summary>
    char TYPE = 'N';

    /// <summary>
    /// Start the program
    /// </summary>
    /// <remarks>
    /// Read the configuration file and mark it in the database configuration text.
    /// Proceed with the basic setting of the regular expression change type.
    /// </remarks>
    public Main()
    {
      Cursor = Cursors.WaitCursor;
      InitializeComponent();
      CONN = null;
      rbTypeNomal.Checked = false;
      rbTypeFile.Checked = true;
      CONFIG = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                         .AddJsonFile("config.json", true, true)
                                         .Build();
      IConfigurationSection section = CONFIG.GetSection("Corp");
      string strDBConn = section["DBConn"];
      if (string.IsNullOrEmpty(txtDBConn.Text.Trim()))
      {
        txtDBConn.Text = strDBConn;
      }
      Cursor = Cursors.Default;
    }

    /// <summary>
    /// Action when the View button is clicked.
    /// </summary>
    /// <remarks>
    /// Connect to the database.
    /// and read data from database.
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnView_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      dgvList.Rows.Clear();
      string msg = null;

      try
      {
        DBConn();
        SelectToDB();
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
          MessageBox.Show("view success", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }
      }
    }

    /// <summary>
    /// It works when the change button is pressed.
    /// </summary>
    /// <remarks>
    /// Changes a value according to a regular expression and displays the changed value,
    /// the changed value, and the total changed value.
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    /// <summary>
    /// Runs when the program is closed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
      close();
    }

    /// <summary>
    /// It works when the clear button is pressed.
    /// </summary>
    /// <remarks>
    /// The connection to the database is persistent.
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnClear_Click(object sender, EventArgs e)
    {
      dgvList.Rows.Clear();
    }

    /// <summary>
    /// It works when the save button is pressed.
    /// </summary>
    /// <remarks>
    /// It is processed one row at a time, and it is not saved for rows that do not change.
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            result = UpdateToDB(key, val);
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

    /// <summary>
    /// Make general changes based on regular expressions.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void rbTypeNomal_CheckedChanged(object sender, EventArgs e)
    {
      rbTypeChange();
    }

    /// <summary>
    /// Change the file format according to the regular expression.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void rbTypeFile_CheckedChanged(object sender, EventArgs e)
    {
      rbTypeChange();
    }

    /// <summary>
    /// DB Connection
    /// </summary>
    /// <remarks>
    /// Currently, only MySQL can connect. We plan to add other database connections as well.
    /// </remarks>
    private void DBConn()
    {
      Cursor = Cursors.WaitCursor;

      try
      {
        string strDBConn = txtDBConn.Text.Trim();
        CONN = new MySqlConnection(strDBConn);
        CONN.Open();
      }
      catch
      {
        throw;
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }

    /// <summary>
    /// change of value
    /// </summary>
    /// <remarks>
    /// Change the matching value according to the regular expression.
    /// In case of changing the URL format, only the part except the file name is changed.
    /// </remarks>
    /// <param name="original">A string that matches the regular expression</param>
    /// <returns></returns>
    private string ChangeValue(string original)
    {
      string result = "";
      string cBeforeVal = "";

      if (TYPE == 'L')
      {
        string[] arrMoto = original.Split('/');
        cBeforeVal = original.Replace(arrMoto[arrMoto.Length - 1], "");
      }
      else
      {
        cBeforeVal = original;
      }

      string cAfterVal = txtAfter.Text;
      result = original.Replace(cBeforeVal, cAfterVal);
      return result;
    }

    /// <summary>
    /// Read data from database.
    /// </summary>
    private void SelectToDB()
    {
      MySqlCommand cmd = null;
      MySqlDataReader reader = null;

      try
      {
        if (CONN.State != ConnectionState.Open) {
          CONN.Open();
        }
        cmd = CONN.CreateCommand();
        cmd.CommandText = string.Format("SELECT p.{0}, p.{1} FROM {2} p WHERE {3};", txtKeyColumn.Text, txtValColumn.Text, txtTable.Text, txtWhere.Text);

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

    /// <summary>
    /// change of the data
    /// </summary>
    /// <remarks>
    /// Updates one row at a time. 
    /// It also rollback row by row.
    /// </remarks>
    /// <param name="key">The value of the key column that is the condition to update the table.</param>
    /// <param name="val">value to change in that column.</param>
    /// <returns></returns>
    private bool UpdateToDB(string key, string val)
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
        cmd.CommandText = string.Format("UPDATE {0} SET {1} = '{2}' WHERE {3} = '{4}';", txtTable.Text, txtValColumn.Text, val, txtKeyColumn.Text, key);

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
        trans.Rollback();
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

    /// <summary>
    /// Change the regular expression type.
    /// </summary>
    /// <remarks>
    /// Set variables for screen change and logic change according to regular expression type change.
    /// </remarks>
    private void rbTypeChange()
    {
      string label = "";

      if (rbTypeNomal.Checked)
      {
        TYPE = 'N';
        label = "AfterText";
      }
      else
      {
        TYPE = 'L';
        label = "AfterUrl";
      }
      lblAfterUrl.Text = label;
    }

    /// <summary>
    /// Handling when the program ends
    /// </summary>
    private void close()
    {
      if (CONN != null)
      {
        CONN.Close();
        CONN.Dispose();
        CONN = null;
      }
      CONFIG = null;
    }

  }
}
