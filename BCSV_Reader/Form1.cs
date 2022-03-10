using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BCSV_Reader
{

    public partial class Form1 : Form
    {
        string EntryNbr;
        int int_EntryNbr;
        string EntrySize;
        int int_EntrySize;
        string ColumnNbr;
        int int_ColumnNbr;

        List<int> list_ColumnSize = new List<int>();
        List<int> list_ColumnLength = new List<int>();
        List<string> list_ColumnHeader = new List<string>();
        List<string> list_ColumnType = new List<string>();
        string numVersion = "v0.3 build 27112021";

        public string sFile;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "BCSV Editor (" + numVersion + ")";
        }
        public Form1()
        {
            
            InitializeComponent();
            
            this.dGV_Main.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dGV_Main.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dGV_Main.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dGV_Main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oFD_Main.ShowDialog();
        }

 

        static string LittleEndian(string num)
        {
            if (num == "") num = "0";
            int number = Convert.ToInt32(num, 16);
            byte[] bytes = BitConverter.GetBytes(number);
            string retval = "";
            foreach (byte b in bytes)
                retval += b.ToString("X2");
            return retval;
        }

        private void dGV_Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dGV_Main_DragDrop(object sender, DragEventArgs e)
        {
           
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string File in fileList)
                {
                    ReadBCSVFile(File);
                    if (cbx_ReplaceAuto.Checked)
                    {
                        replaceToolStripMenuItem.PerformClick();
                    }
                    if (cbx_CSV.Checked)
                    {
                        exportToCSVcsvToolStripMenuItem.PerformClick();
                    }
                }

                
            }
        }

        public string String_To_Hex(string text_to_convert)
        {
            Int64 intValue = Int64.Parse(text_to_convert);
            return intValue.ToString("X");
        }

        public string Int_To_Hex(int text_to_convert)
        {
            Int64 intValue = text_to_convert;
            return intValue.ToString("X");
        }

 
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            ReadBCSVFile(oFD_Main.FileName); 
          
        }

        private void ReadBCSVFile(string FilePath)
        {
            EntryNbr = String.Empty;
            int_EntryNbr = 0;
            EntrySize = String.Empty;
            int_EntrySize = 0;
            ColumnNbr = String.Empty;
            int_ColumnNbr = 0;
            bool IsSortable = false;


            this.dGV_Main.DataSource = null;
            this.dGV_Main.Rows.Clear();
            this.dGV_Main.Columns.Clear(); 
            this.dGV_Main.Refresh();

            this.dGV_Rows.DataSource = null;
            this.dGV_Rows.Rows.Clear();
            this.dGV_Rows.Refresh();

            list_ColumnSize.Clear();
            list_ColumnHeader.Clear();
            list_ColumnLength.Clear();

            using (BinaryReader br = new BinaryReader(File.OpenRead(FilePath)))
            {
                dGV_Main.Enabled = false;
                
                /* 0x0F to 0x0C - File Header*/
                string BCSV_FileType = String.Empty;
                string BCSV_Legacy = String.Empty;
                string BCSV_Version = String.Empty;
                for (int i = 0x0F; i >= 0x0C; i--)
                {
                    br.BaseStream.Position = i;
                    BCSV_FileType += br.ReadByte().ToString("x2");
                }
                for (int i = 0x0B; i >= 0x0A; i--)
                {
                    br.BaseStream.Position = i;
                    BCSV_Legacy += br.ReadByte().ToString("x2");
                }

                /*MAGIC NUMBER EQUIVALENT*/
                if (Snippet.InvertString(Hex.FromHexToString(BCSV_FileType)) == "BCSV" || (BCSV_Legacy == "0100" && Snippet.InvertString(Hex.FromHexToString(BCSV_FileType)) != "BCSV"))
                {
                    saveToolStripMenuItem.Enabled = true;
                   this.Text = "BCSV Editor ("+ numVersion +") - " + Path.GetFileName(FilePath);
                    sFile = Path.GetFileNameWithoutExtension(FilePath);
                    

                    /* 0x00 to 0x03 - Entries number */
                    for (int i = 0x03; i >= 0x00; i--)
                    {
                        br.BaseStream.Position = i;
                        EntryNbr += br.ReadByte().ToString("x2");
                    }

                    /* 0x07 to 0x04 - Entrie size */
                    for (int i = 0x07; i >= 0x04; i--)
                    {
                        br.BaseStream.Position = i;
                        EntrySize += br.ReadByte().ToString("x2");
                    }
 
                    /* 0x08 to 0x09 - Columns number*/
                     for (int i = 0x09; i >= 0x08; i--)
                    {
                        br.BaseStream.Position = i;
                        ColumnNbr += br.ReadByte().ToString("x2");
                    }
    
                    toolStripStatusLabel1.Text = "Line(s): " + Int32.Parse(EntryNbr, System.Globalization.NumberStyles.HexNumber).ToString();
                    int_EntryNbr = Int32.Parse(EntryNbr, System.Globalization.NumberStyles.HexNumber);

                    toolStripStatusLabel2.Text = "Data Size: " + Int32.Parse(EntrySize, System.Globalization.NumberStyles.HexNumber).ToString() + "Byte(s) ";
                    int_EntrySize = Int32.Parse(EntrySize, System.Globalization.NumberStyles.HexNumber);

                    toolStripStatusLabel3.Text = "Column(s): " + Int32.Parse(ColumnNbr, System.Globalization.NumberStyles.HexNumber).ToString();
                    int_ColumnNbr = Int32.Parse(ColumnNbr, System.Globalization.NumberStyles.HexNumber);

                    dGV_Main.ColumnCount = int_ColumnNbr;

                    int ColSpace = 0x08;
                    int ColSize = 0x03;
                    int ColStart = 0x1C;
                    if (BCSV_Legacy == "0100" && Snippet.InvertString(Hex.FromHexToString(BCSV_FileType)) != "BCSV")
                    {
                        ColStart = 0x0C;
                        toolStripStatusLabel4.Text = "BCSV Legacy";
                    } else
                    {
                        /* 0x08 to 0x09 - Columns number*/
                        for (int i = 0x11; i >= 0x10; i--)
                        {
                            br.BaseStream.Position = i;
                            BCSV_Version += br.ReadByte().ToString("x2");
                        }
                        ColStart = 0x1C;
                        toolStripStatusLabel4.Text = Snippet.InvertString(Hex.FromHexToString(BCSV_FileType)) + " Rev" + Int32.Parse(BCSV_Version, System.Globalization.NumberStyles.HexNumber).ToString();
                    }

                        int[] ColContentAdress = new int[int_ColumnNbr];

                    for (int iCol = 0; iCol <= int_ColumnNbr - 1; iCol++)
                    {
                        String ColumnName = String.Empty;

                        for (int i = (ColStart + ColSize); i >= ColStart; i--)
                        {
                            br.BaseStream.Position = i;
                            ColumnName += br.ReadByte().ToString("x2");
                        }

                        String ColumnSize = String.Empty;
                        for (int i = (ColStart + ColSize +0x04); i >= (ColStart + ColSize + 0x01); i--)
                        {
                            br.BaseStream.Position = i;
                            ColumnSize += br.ReadByte().ToString("x2");
                        }
                        dGV_Main.Columns[iCol].Name = ColumnName;
                        if (ColumnName == "54706054")
                        {
                            IsSortable = true;
                            dGV_Main.Columns[iCol].DefaultCellStyle.BackColor = Color.LightGray;
                            dGV_Main.Columns[iCol].DefaultCellStyle.Font = new Font(dGV_Main.Font, FontStyle.Bold); 
                        }
                        list_ColumnHeader.Add(ColumnName);
                        list_ColumnLength.Add(int.Parse(ColumnSize, System.Globalization.NumberStyles.HexNumber));

                        ColContentAdress[iCol] = int.Parse(ColumnSize, System.Globalization.NumberStyles.HexNumber);
                        ColStart += ColSpace;
                        list_ColumnSize.Add(0);
                    }

                    for (int iRow = 0; iRow < int_EntryNbr ; iRow++)  // Parcours chaque entrée
                    {
                        int ContentAdressStart = 0x00;
                        int ContentAdressEnd = 0x00;
                        int ContentLength = 0x00;


                        dGV_Main.Rows.Add();
                        for (int iColumn = 0; iColumn <= int_ColumnNbr - 1; iColumn++) // Parcours chaque colonne
                        {


                            ContentAdressStart = ColStart + ColContentAdress[iColumn];
                            if ((iColumn + 1) >= int_ColumnNbr)
                            {
                                ContentAdressEnd = ColStart + int_EntrySize;
                            }
                            else
                            {
                                ContentAdressEnd = ColStart + ColContentAdress[iColumn + 1];
                            }

                            ContentLength = (ContentAdressEnd - ContentAdressStart);
                            if (ContentLength < 0) { ContentLength = ContentLength * -1; };
                            list_ColumnSize[iColumn] = ContentLength;
                            if (ContentLength <= 2)
                            {
                                ((DataGridViewTextBoxColumn)dGV_Main.Columns[iColumn]).MaxInputLength = (ContentLength * 2)+1;
                            } else
                            {
                                ((DataGridViewTextBoxColumn)dGV_Main.Columns[iColumn]).MaxInputLength = ContentLength * 2;
                            }

                            String RowValue = String.Empty;

                            for (int i = (ContentAdressEnd - 0x01); i >= ContentAdressStart; i--)
                            {
                                br.BaseStream.Position = i;
                                if (br.BaseStream.Position <= br.BaseStream.Length)
                                {
                                    RowValue += br.ReadByte().ToString("x2");
                                } else
                                {
                                    break;
                                }
                            }
                            if (RowValue != null || RowValue != "") { 
                            
                            switch (ContentLength)
                            {
                                case 0:
                                    dGV_Main.Rows[iRow].Cells[iColumn].Value = "Error";
                                    break;
                                case 1:
                                        dGV_Main.Rows[iRow].Cells[iColumn].Value =  int.Parse(RowValue, System.Globalization.NumberStyles.HexNumber);
                                        break;
                                case 2:
                                        dGV_Main.Rows[iRow].Cells[iColumn].Value = int.Parse(RowValue, System.Globalization.NumberStyles.HexNumber);
                                        break;
                                case 4:
                                    dGV_Main.Rows[iRow].Cells[iColumn].Value =  RowValue.ToUpper();
                                    break;
                                case 5:
                                        //e8c448b2 fa71e75c 42cd8039 12d4d7a6
                                            dGV_Main.Rows[iRow].Cells[iColumn].Value = RowValue.ToUpper();
                                            dGV_Main.Rows[iRow].Cells[iColumn].Style.BackColor = Color.LightGray;
                                        break;
                                case 8:
                                    dGV_Main.Rows[iRow].Cells[iColumn].Value =  RowValue.ToUpper();
                                        dGV_Main.Rows[iRow].Cells[iColumn].ToolTipText = Hex.FromHexToString(RowValue);

                                        break;
                                case 16:
                                    dGV_Main.Rows[iRow].Cells[iColumn].Value =   RowValue.ToUpper();
                                        try
                                        {
                                            string HtmlColor = Hex.FromHexToString(RowValue.ToUpper()).Substring(0,7);
                                            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(HtmlColor);
                                            dGV_Main.Rows[iRow].Cells[iColumn].Style.BackColor = col;
                                        } catch { }
                                    break;
                                case 32:
                                        dGV_Main.Rows[iRow].Cells[iColumn].Value = Hex.FromHexToString(RowValue);
                                        dGV_Main.Rows[iRow].Cells[iColumn].ToolTipText = Hex.FromHexToString_JP(Snippet.InvertString(Snippet.InvertHex(RowValue)));
                                        break;
                                default:
                                            dGV_Main.Rows[iRow].Cells[iColumn].Value = Hex.FromHexToString(RowValue);
                                            dGV_Main.Rows[iRow].Cells[iColumn].ToolTipText = Hex.FromHexToString_JP(Snippet.InvertString(Snippet.InvertHex(RowValue)));
                                            dGV_Main.Rows[iRow].Cells[iColumn].Style.BackColor = Color.LightPink;
                                        break;
                            }
                            } else
                            {
                                dGV_Main.Rows[iRow].Cells[iColumn].Value = RowValue.ToUpper();
                            }

                        }

                        

                        ColStart += int_EntrySize;
                    }
                    for (int j = 0; j < list_ColumnHeader.Count; j++)
                    {
                        string ColumType = "";
                        switch (list_ColumnSize[j])
                        {
                            case 1:
                                ColumType = "int8";
                                break;
                            case 2:
                                ColumType = "int16";
                                break;
                            case 4:
                                ColumType = "int32/hash/float";
                                break;
                            case 5:
                                ColumType = "raw";
                                break;
                            default:
                                ColumType = "String";
                                break;
                         }
                        dGV_Rows.Rows.Add(list_ColumnHeader[j],list_ColumnSize[j], ColumType);
                        dGV_Main.Columns[j].ToolTipText = list_ColumnSize[j].ToString();

                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    dGV_Main.Enabled = true;
                    if (IsSortable)
                    {
                        dGV_Main.Sort(dGV_Main.Columns["54706054"], System.ComponentModel.ListSortDirection.Ascending);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid File Format ("+ Snippet.InvertString(Hex.FromHexToString(BCSV_FileType)) + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            
           

}


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dGV_Main.Rows != null)
            {
                saveFileDialog1.ShowDialog();
            }
        }

        public static byte[] ToByteArray(String HexString)
        {
            int NumberChars = HexString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return bytes;
        }



        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.FileName != "")
            {
                if (File.Exists(saveFileDialog1.FileName)) { File.Delete(saveFileDialog1.FileName); }
                BinaryWriter bw = new BinaryWriter(File.OpenWrite(saveFileDialog1.FileName));
 
                bw.BaseStream.Position = 0x00;
                bw.Write(dGV_Main.Rows.Count - 1);

                bw.BaseStream.Position = 0x04;
                bw.Write(int_EntrySize);
                
                bw.BaseStream.Position = 0x08;
                bw.Write(dGV_Main.Columns.Count);

                bw.BaseStream.Position = 0x0A;
                bw.Write(0x101);

                bw.BaseStream.Position = 0x0C;
                bw.Write(ToByteArray(Hex.StringToHex("VSCB")));
                
                bw.BaseStream.Position = 0x10;
                bw.Write(20000);
             
                int WriteStart = 0x1C;
                foreach (DataGridViewColumn column in dGV_Main.Columns)
                {
                    string Header = dGV_Main.Columns[column.Index].HeaderText;
                    int HeaderLength = list_ColumnLength[column.Index];
                    int HeaderSize = list_ColumnSize[column.Index];
                    bw.BaseStream.Position = WriteStart;
                
                    bw.Write(ToByteArray(LittleEndian(Header)));
                    WriteStart = WriteStart + 0x04;
                    bw.BaseStream.Position = WriteStart;
                    bw.Write(HeaderLength);
                    WriteStart = WriteStart + 0x04;
                }
                
                foreach (DataGridViewRow row in dGV_Main.Rows)
                {
                    if (row.Index >= (dGV_Main.Rows.Count -1))
                    {
                        break;
                    }

                    int Cellnb = 0;
                    bw.BaseStream.Position = WriteStart;
                    bw.Write(WriteStart);
                    
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string CellValue;
                        bw.BaseStream.Position = WriteStart + list_ColumnLength[Cellnb];
                        if (cell.Value == null)
                        {
                            CellValue = String.Empty;
                        } else
                        {
                            CellValue = cell.Value.ToString();
                        }
                        switch (list_ColumnSize[Cellnb])
                        {
                            case 1:

                                bw.Write(ToByteArray(LittleEndian(Hex.IntToHex(int.Parse(CellValue)))));
                                break;
                            case 2:
                                var test_1 = LittleEndian(CellValue);
                                var test_2 = Hex.IntToHex(int.Parse(CellValue));
                                bw.Write(ToByteArray(LittleEndian(test_2)));
                                break;
                            case 4:
                                bw.Write(ToByteArray(LittleEndian(CellValue)));
                                break;
                            case 5:
                                bw.Write(ToByteArray(CellValue));
                                break;
                            default:
                                bw.Write(ToByteArray(Hex.StringToHex(CellValue)));
                                break;
                        }
                     
                        Cellnb++;
                    }
                    WriteStart = WriteStart + int_EntrySize;
                }


                bw.Close();


            }

        }

        private void exportToCSVcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            SaveFileDialog saveExport_CSV = new SaveFileDialog();
            saveExport_CSV.Filter = "CSV File|*.csv";
            saveExport_CSV.Title = "Export to CSV File";
            saveExport_CSV.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            saveExport_CSV.FileName = sFile;
            /*
            saveExport_CSV.ShowDialog();
            */
            if (cbx_CSV.Checked)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "csv");

            }
            else
            {

                if (saveExport_CSV.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveExport_CSV.FileName))
                    {
                        try
                        {
                            File.Delete(saveExport_CSV.FileName);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Unable to write on disk." + ex.Message);
                        }
                    }
                }
            }
            int columnCount = dGV_Main.ColumnCount;
                string columnNames = "";
                string[] output = new string[dGV_Main.RowCount + 1];
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += dGV_Main.Columns[i].HeaderText.ToString() + ";";
                }
                output[0] += columnNames;
                for (int i = 1; (i - 1) < (dGV_Main.RowCount - 1); i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        string valueToWrite;
                        if (dGV_Main.Rows[i - 1].Cells[j].Value == null) {
                            valueToWrite = string.Empty; 
                        } else
                        {
                            valueToWrite = dGV_Main.Rows[i - 1].Cells[j].Value.ToString();
                        }
                        output[i] += valueToWrite + ";";
                    }
                }
                if (cbx_CSV.Checked)
                {
                     System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"csv\" + sFile + ".csv", output, System.Text.Encoding.UTF8);
                }
                else
                {
                    System.IO.File.WriteAllLines(saveExport_CSV.FileName, output, System.Text.Encoding.UTF8);
                }
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAbout = new About();
            frmAbout.ShowDialog();
      
        }

        private void cbx_Replace_CheckedChanged(object sender, EventArgs e)
        {
                pnl_Replace_Value_tbx.Enabled = !cbx_Replace.Checked;
          
        }
        private void replaceColumnValuesByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (dGV_Main.CurrentCell.Value != null)
            {
                pnl_Replace.Enabled = true;
                pnl_Replace.Visible = true;
                dGV_Main.Enabled = false;
                dGV_Main.ReadOnly = true;
                Application.DoEvents();
                pnl_Replace_Column_tbx.Text = dGV_Main.Columns[dGV_Main.CurrentCell.ColumnIndex].Name.ToString();
                pnl_Replace_Value_tbx.Text = dGV_Main.CurrentCell.Value.ToString();
                pnl_Replace_NewValue_tbx.Text = "";
                pnl_Replace_NewValue_tbx.Focus();
            }
        }

        private void btn_pnl_Replace_OK_Click(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dGV_Main.Font, FontStyle.Bold);
            style.BackColor = Color.LightGreen;
            try
            {
                for (int row = 0; row < dGV_Main.Rows.Count; row++)
                {
                    for (int column = 0; column < dGV_Main.Columns.Count; column++)
                    {
                        if (dGV_Main[column, row].OwningColumn.Name == pnl_Replace_Column_tbx.Text)
                        {
                            if (dGV_Main[column, row].Value != null && (dGV_Main[column, row].Value.ToString() == pnl_Replace_Value_tbx.Text) && !cbx_Replace.Checked)
                            {
                                dGV_Main[column, row].Value = pnl_Replace_NewValue_tbx.Text;
                                dGV_Main[column, row].Style = style;

                            }
                            else if (dGV_Main[column, row].Value != null && cbx_Replace.Checked)
                            {
                                dGV_Main[column, row].Value = pnl_Replace_NewValue_tbx.Text;
                                dGV_Main[column, row].Style = style;
                            }

                        }
                             
                       
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                pnl_Replace.Enabled = false;
                pnl_Replace.Visible = false;
                dGV_Main.Enabled = true;
                dGV_Main.ReadOnly = false;
            }



        }

        private void btn_pnl_Replace_Cancel_Click(object sender, EventArgs e)
        {
            pnl_Replace.Enabled = false;
            pnl_Replace.Visible = false;
            dGV_Main.Enabled = true;
            dGV_Main.ReadOnly = false;
        }

        private void pnl_Replace_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnl_Replace.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dGV_Main.CurrentCell != null)
            {
                if (dGV_Main.CurrentCell.Value != null)
                {
                    tbx_CellContent.Text = (dGV_Main.CurrentCell.ToolTipText.ToString() != "") ? dGV_Main.CurrentCell.ToolTipText.ToString() : dGV_Main.CurrentCell.Value.ToString();
                    tbx_X.Text = dGV_Main.CurrentCell.ColumnIndex.ToString();
                    tbx_Y.Text = e.RowIndex.ToString();
                    tbx_CellLength.Text = ((DataGridViewTextBoxColumn)dGV_Main.Columns[dGV_Main.CurrentCell.ColumnIndex]).MaxInputLength.ToString();
                    tbx_CellHeader.Text = dGV_Main.Columns[dGV_Main.CurrentCell.ColumnIndex].Name.ToString();

                    try
                    {
                        tbx_String.Text = Hex.FromHexToString(dGV_Main.CurrentCell.Value.ToString());
                    }
                    catch
                    {
                        tbx_String.Text = "~";
                    }
                    try
                    {
                        tbx_Int.Text = Convert.ToInt32(dGV_Main.CurrentCell.Value.ToString(), 16).ToString();
                    }
                    catch
                    {
                        tbx_Int.Text = "~";
                    }
                    try
                    {
                        tbx_Float.Text = Hex.HexStringToFloat(dGV_Main.CurrentCell.Value.ToString()).ToString();
                    }
                    catch
                    {
                        tbx_Float.Text = "~";
                    }
                }
            }
        }



        private void cbx_Hash_CheckedChanged(object sender, EventArgs e)
        {
            if(cbx_Hash.Checked)
            {
                tbx_CellContent.Text = Snippet.crc32b_Hash(tbx_CellContent.Text);
            } else
            {
                tbx_CellContent.Text = dGV_Main.CurrentCell.Value.ToString();
            }
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cp = new StringBuilder();
            string test = "";

            Clipboard.Clear();
            for (int i = 0; i < dGV_Main.GetCellCount(System.Windows.Forms.DataGridViewElementStates.Selected); i++)
            {
                test = RemoveSpecialCharacters(dGV_Main.SelectedCells[i].Value.ToString());
                cp.Append(test.ToString());
                cp.Append(Environment.NewLine);
                
            }
            Clipboard.SetText(cp.ToString());
        }

        private void stringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dGV_Main.GetCellCount(System.Windows.Forms.DataGridViewElementStates.Selected); i++)
            {
                try
                {
                    dGV_Main.SelectedCells[i].Value = Hex.FromHexToString(dGV_Main.SelectedCells[i].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Unable to convert [" + dGV_Main.SelectedCells[i].Value.ToString() + "] to String");
                }

            }
        }

        private void intToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dGV_Main.GetCellCount(System.Windows.Forms.DataGridViewElementStates.Selected); i++)
            {
                try { 
                dGV_Main.SelectedCells[i].Value = Convert.ToInt32(dGV_Main.SelectedCells[i].Value.ToString(), 16);
                }
                catch
                {
                    MessageBox.Show("Unable to convert [" + dGV_Main.SelectedCells[i].Value.ToString() + "] to Int32");
                }
            }
        }

        private void floatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dGV_Main.GetCellCount(System.Windows.Forms.DataGridViewElementStates.Selected); i++)
            {
                try { 
                dGV_Main.SelectedCells[i].Value = Hex.HexStringToFloat(dGV_Main.SelectedCells[i].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Unable to convert [" + dGV_Main.SelectedCells[i].Value.ToString() + "] to Float");
                }
            }
        }

        private void signedIntToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            for (int i = 0; i < dGV_Main.GetCellCount(System.Windows.Forms.DataGridViewElementStates.Selected); i++)
            {
                try
                {
                    dGV_Main.SelectedCells[i].Value = unchecked((short)Convert.ToUInt32(dGV_Main.SelectedCells[i].Value.ToString(), 16)).ToString();
                } catch
            {
                MessageBox.Show("Unable to convert [" + dGV_Main.SelectedCells[i].Value.ToString() + "] to Short Int");
            }
        }
        }


        private void hexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dGV_Main.GetCellCount(System.Windows.Forms.DataGridViewElementStates.Selected); i++)
            {
                try { 
                dGV_Main.SelectedCells[i].Value = Hex.StringToHexString(dGV_Main.SelectedCells[i].Value.ToString());
            } catch
            {
                MessageBox.Show("Unable to convert [" + dGV_Main.SelectedCells[i].Value.ToString() + "] to Hex");
            }
        }
        }

        private void replaceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
            string value;
            string HeaderValue;
            string CellValue;
            int countColumn = dGV_Main.Columns.Count;
            int countCells = dGV_Main.Rows.Count;
            saveToolStripMenuItem.Enabled = false;
            string Dict_File = AppDomain.CurrentDomain.BaseDirectory + "hash.csv";


            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Title = "Select Dict File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|dict files (*.dict)|*.dict|All files (*.*)|*.*",
                FilterIndex = 3,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (!File.Exists(Dict_File)) {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Dict_File = openFileDialog1.FileName;
                }
            }
            if (File.Exists(Dict_File))
            {
                try
                {
                    dGV_Main.EnableHeadersVisualStyles = false;

                    //var dict = File.ReadLines(Dict_File).Select(line => line.Split(';')).ToDictionary(line => line[0], line => line[1]);

                    Dictionary<string, string> dict = new Dictionary<string, string>();
    
                    using (StreamReader reader = new StreamReader(Dict_File))
                    {
                        string line = String.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            //line = line + sr.ReadLine();
                            string[] splitted = line.Split(';');
                            if (!dict.ContainsKey(splitted[0]))
                            {
                                dict.Add(splitted[0], splitted[1]);  //ERROR An item with the same key has already been added.
                            }
                            else
                            {
                                MessageBox.Show("Duplicate entrey: " + splitted[0]);
                            }
                        }
                    }

                    



                    


                    List<string> list_unkHash = new List<string>();

                    foreach (DataGridViewColumn col in dGV_Main.Columns)
                    {
                        HeaderValue = dGV_Main.Columns[col.Index].HeaderText;
                        bool keyExists = dict.TryGetValue(HeaderValue, out value);
                        if (keyExists)
                        {
                            
                            if ((value.Contains(" u8") || value.Contains(" s8")) && Int16.Parse(dGV_Main.Columns[col.Index].ToolTipText, 0) != 1)
                            {
                                list_unkHash.Add(HeaderValue + ";" + value);
                                dGV_Main.Columns[col.Index].HeaderCell.Style.ForeColor = Color.Red;
                                dGV_Main.Columns[col.Index].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Italic);
                            } 
                            else if ((value.Contains(" u16") || value.Contains(" s16")) && Int16.Parse(dGV_Main.Columns[col.Index].ToolTipText, 0) != 2)
                            {
                                list_unkHash.Add(HeaderValue + ";" + value);
                                dGV_Main.Columns[col.Index].HeaderCell.Style.ForeColor = Color.Red;
                                dGV_Main.Columns[col.Index].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Italic);
                            }
                            else if ((value.Contains(" u32") || value.Contains(".hshCstringRef") || value.Contains(" f32") || value.Contains(" s32")) && Int16.Parse(dGV_Main.Columns[col.Index].ToolTipText, 0) != 4)
                            {
                                list_unkHash.Add(HeaderValue + ";" + value);
                                dGV_Main.Columns[col.Index].HeaderCell.Style.ForeColor = Color.Red;
                                dGV_Main.Columns[col.Index].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Italic);
                            }
                            else if (value.Contains(" string") && Int16.Parse(dGV_Main.Columns[col.Index].ToolTipText,0) < 4)
                            {
                                list_unkHash.Add(HeaderValue + ";" + value);
                                dGV_Main.Columns[col.Index].HeaderCell.Style.ForeColor = Color.Red;
                                dGV_Main.Columns[col.Index].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Italic);
                            }
                            else if ((!value.Contains(" u32") && !value.Contains(".hshCstringRef") && !value.Contains(" f32") && value.Contains(" s32")) && Int16.Parse(dGV_Main.Columns[col.Index].ToolTipText, 0) == 4)
                            {
                                list_unkHash.Add(HeaderValue + ";" + value);
                                dGV_Main.Columns[col.Index].HeaderCell.Style.ForeColor = Color.Red;
                                dGV_Main.Columns[col.Index].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Italic);
                            }
                            else if ((!value.Contains(" u16") && !value.Contains(" s16")) && Int16.Parse(dGV_Main.Columns[col.Index].ToolTipText, 0) == 2)
                            {
                                list_unkHash.Add(HeaderValue + ";" + value);
                                dGV_Main.Columns[col.Index].HeaderCell.Style.ForeColor = Color.Red;
                                dGV_Main.Columns[col.Index].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Italic);
                            }
                            else if ((!value.Contains(" u8") && !value.Contains(" s8")) && Int16.Parse(dGV_Main.Columns[col.Index].ToolTipText, 0) == 1)
                            {
                                list_unkHash.Add(HeaderValue + ";" + value);
                                dGV_Main.Columns[col.Index].HeaderCell.Style.ForeColor = Color.Red;
                                dGV_Main.Columns[col.Index].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Italic);
                            }

                            dGV_Main.Columns[col.Index].HeaderText = value;

                        } else
                        {
                            list_unkHash.Add(HeaderValue);
                        }
                    }


                    

                    foreach (DataGridViewRow row in dGV_Main.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                CellValue = cell.Value.ToString();
                                bool keyExists = dict.TryGetValue(CellValue.ToLower(), out value);
                                if (keyExists)
                                {
                                    cell.Value = value;
                                }
                                else if (cell.ToolTipText.ToString() != "")
                                {
                                    cell.Value = cell.ToolTipText.ToString();
                                }
                                else
                                {
                                    if (CellValue.Length == 8) list_unkHash.Add(CellValue.ToLower());

                                }

                            }

                        }
                    }

                    if (cbx_Export.Checked)
                    {
                        TextWriter w = new StreamWriter(new BufferedStream(new FileStream(AppDomain.CurrentDomain.BaseDirectory + "unk_Hash.txt", FileMode.Append)));
                        for (int i = 0; i < list_unkHash.Count; i++)
                        {
                            w.WriteLine(list_unkHash[i]);
                        }
                        w.Close();
                    }

                    list_unkHash.Clear();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    MessageBox.Show(File.ReadLines(Dict_File).ToString());
                }
            }
        }

        private void ReadBCSVFile_Import(string FilePath)
        {
            EntryNbr = String.Empty;
            int_EntryNbr = 0;
            EntrySize = String.Empty;
            int_EntrySize = 0;
            ColumnNbr= String.Empty;
            int_ColumnNbr = 0;

            bool IsSortable = false;


            this.dGV_Import.DataSource = null;
            this.dGV_Import.Rows.Clear();
            this.dGV_Import.Columns.Clear();
            this.dGV_Import.Refresh();

            list_ColumnSize.Clear();
            list_ColumnHeader.Clear();
            list_ColumnLength.Clear();

            using (BinaryReader br = new BinaryReader(File.OpenRead(FilePath)))
            {

                /* 0x0F to 0x0C - File Header*/
                string BCSV_FileType = String.Empty;
                string BCSV_Legacy = String.Empty;
                string BCSV_Version = String.Empty;
                for (int i = 0x0F; i >= 0x0C; i--)
                {
                    br.BaseStream.Position = i;
                    BCSV_FileType += br.ReadByte().ToString("x2");
                }
                for (int i = 0x0B; i >= 0x0A; i--)
                {
                    br.BaseStream.Position = i;
                    BCSV_Legacy += br.ReadByte().ToString("x2");
                }

                /*MAGIC NUMBER EQUIVALENT*/
                if (Snippet.InvertString(Hex.FromHexToString(BCSV_FileType)) == "BCSV" || (BCSV_Legacy == "0100" && Snippet.InvertString(Hex.FromHexToString(BCSV_FileType)) != "BCSV"))
                {

                    /* 0x00 to 0x03 - Entries number */
                    for (int i = 0x03; i >= 0x00; i--)
                    {
                        br.BaseStream.Position = i;
                        EntryNbr += br.ReadByte().ToString("x2");
                    }

                    /* 0x07 to 0x04 - Entrie size */
                    for (int i = 0x07; i >= 0x04; i--)
                    {
                        br.BaseStream.Position = i;
                        EntrySize += br.ReadByte().ToString("x2");
                    }

                    /* 0x08 to 0x09 - Columns number*/
                    for (int i = 0x09; i >= 0x08; i--)
                    {
                        br.BaseStream.Position = i;
                        ColumnNbr += br.ReadByte().ToString("x2");
                    }

                    int_EntryNbr = Int32.Parse(EntryNbr, System.Globalization.NumberStyles.HexNumber);

                    int_EntrySize = Int32.Parse(EntrySize, System.Globalization.NumberStyles.HexNumber);

                    int_ColumnNbr = Int32.Parse(ColumnNbr, System.Globalization.NumberStyles.HexNumber);

                    dGV_Import.ColumnCount = int_ColumnNbr;


                    int ColSpace = 0x08;
                    int ColSize = 0x03;
                    int ColStart = 0x1C;
                    if (BCSV_Legacy == "0100" && Snippet.InvertString(Hex.FromHexToString(BCSV_FileType)) != "BCSV")
                    {
                        ColStart = 0x0C;
                    }
                    else
                    {
                        /* 0x08 to 0x09 - Columns number*/
                        for (int i = 0x11; i >= 0x10; i--)
                        {
                            br.BaseStream.Position = i;
                            BCSV_Version += br.ReadByte().ToString("x2");
                        }
                        ColStart = 0x1C;
                    }

                    int[] ColContentAdress = new int[int_ColumnNbr];

                    for (int iCol = 0; iCol <= int_ColumnNbr - 1; iCol++)
                    {
                        String ColumnName = String.Empty;

                        for (int i = (ColStart + ColSize); i >= ColStart; i--)
                        {
                            br.BaseStream.Position = i;
                            ColumnName += br.ReadByte().ToString("x2");
                        }

                        String ColumnSize = String.Empty;
                        for (int i = (ColStart + ColSize + 0x04); i >= (ColStart + ColSize + 0x01); i--)
                        {
                            br.BaseStream.Position = i;
                            ColumnSize += br.ReadByte().ToString("x2");
                        }
                        dGV_Import.Columns[iCol].Name = ColumnName;
                        if (ColumnName == "54706054")
                        {
                            IsSortable = true;
                            dGV_Import.Columns[iCol].DefaultCellStyle.BackColor = Color.LightGray;
                            dGV_Import.Columns[iCol].DefaultCellStyle.Font = new Font(dGV_Import.Font, FontStyle.Bold);
                        }
                        list_ColumnHeader.Add(ColumnName);
                        list_ColumnLength.Add(int.Parse(ColumnSize, System.Globalization.NumberStyles.HexNumber));

                        ColContentAdress[iCol] = int.Parse(ColumnSize, System.Globalization.NumberStyles.HexNumber);
                        ColStart += ColSpace;
                        list_ColumnSize.Add(0);
                    }

                    for (int iRow = 0; iRow < int_EntryNbr; iRow++)  // Parcours chaque entrée
                    {
                        int ContentAdressStart = 0x00;
                        int ContentAdressEnd = 0x00;
                        int ContentLength = 0x00;


                        dGV_Import.Rows.Add();
                        for (int iColumn = 0; iColumn <= int_ColumnNbr - 1; iColumn++) // Parcours chaque colonne
                        {


                            ContentAdressStart = ColStart + ColContentAdress[iColumn];
                            if ((iColumn + 1) >= int_ColumnNbr)
                            {
                                ContentAdressEnd = ColStart + int_EntrySize;
                            }
                            else
                            {
                                ContentAdressEnd = ColStart + ColContentAdress[iColumn + 1];
                            }

                            ContentLength = (ContentAdressEnd - ContentAdressStart);
                            if (ContentLength < 0) { ContentLength = ContentLength * -1; };
                            list_ColumnSize[iColumn] = ContentLength;
                            if (ContentLength <= 2)
                            {
                                ((DataGridViewTextBoxColumn)dGV_Import.Columns[iColumn]).MaxInputLength = (ContentLength * 2) + 1;
                            }
                            else
                            {
                                ((DataGridViewTextBoxColumn)dGV_Import.Columns[iColumn]).MaxInputLength = ContentLength * 2;
                            }

                            String RowValue = String.Empty;

                            for (int i = (ContentAdressEnd - 0x01); i >= ContentAdressStart; i--)
                            {
                                br.BaseStream.Position = i;
                                if (br.BaseStream.Position <= br.BaseStream.Length)
                                {
                                    RowValue += br.ReadByte().ToString("x2");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (RowValue != null || RowValue != "")
                            {

                                switch (ContentLength)
                                {
                                    case 0:
                                        dGV_Import.Rows[iRow].Cells[iColumn].Value = "Error";
                                        break;
                                    case 1:
                                        dGV_Import.Rows[iRow].Cells[iColumn].Value = int.Parse(RowValue, System.Globalization.NumberStyles.HexNumber);
                                        break;
                                    case 2:
                                        dGV_Import.Rows[iRow].Cells[iColumn].Value = int.Parse(RowValue, System.Globalization.NumberStyles.HexNumber);
                                        break;
                                    case 4:
                                        dGV_Import.Rows[iRow].Cells[iColumn].Value = RowValue.ToUpper();
                                        break;
                                    case 5:
                                        dGV_Import.Rows[iRow].Cells[iColumn].Value = RowValue.ToUpper();
                                        dGV_Import.Rows[iRow].Cells[iColumn].Style.BackColor = Color.LightGray;
                                        break;
                                    case 8:
                                        dGV_Import.Rows[iRow].Cells[iColumn].Value = RowValue.ToUpper();
                                        dGV_Import.Rows[iRow].Cells[iColumn].ToolTipText = Hex.FromHexToString(RowValue);

                                        break;
                                    case 16:
                                        dGV_Import.Rows[iRow].Cells[iColumn].Value = RowValue.ToUpper();
                                        try
                                        {
                                            string HtmlColor = Hex.FromHexToString(RowValue.ToUpper()).Substring(0, 7);
                                            Color col = System.Drawing.ColorTranslator.FromHtml(HtmlColor);
                                            dGV_Import.Rows[iRow].Cells[iColumn].Style.BackColor = col;
                                        }
                                        catch { }
                                        break;
                                    case 32:
                                        dGV_Import.Rows[iRow].Cells[iColumn].Value = Hex.FromHexToString(RowValue);
                                        dGV_Import.Rows[iRow].Cells[iColumn].ToolTipText = Hex.FromHexToString_JP(Snippet.InvertString(Snippet.InvertHex(RowValue)));
                                        break;
                                    default:
                                        dGV_Import.Rows[iRow].Cells[iColumn].Value = Hex.FromHexToString(RowValue);
                                        dGV_Import.Rows[iRow].Cells[iColumn].ToolTipText = Hex.FromHexToString_JP(Snippet.InvertString(Snippet.InvertHex(RowValue)));
                                        dGV_Import.Rows[iRow].Cells[iColumn].Style.BackColor = Color.LightPink;
                                        break;
                                }
                            }
                            else
                            {
                                dGV_Import.Rows[iRow].Cells[iColumn].Value = RowValue.ToUpper();
                            }

                        }



                        ColStart += int_EntrySize;
                    }



                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    if (IsSortable)
                    {
                        dGV_Import.Sort(dGV_Import.Columns["54706054"], System.ComponentModel.ListSortDirection.Ascending);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid File Format (" + Snippet.InvertString(Hex.FromHexToString(BCSV_FileType)) + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

            private void importAndUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oFD_Import.ShowDialog();
            
        }

        private DataTable ToDataTable(DataGridView dataGridView)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
            {
                if (dataGridViewColumn.Visible)
                {
                    dt.Columns.Add();
                }
            }
            var cell = new object[dataGridView.Columns.Count];
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }
            return dt;
        }

        private void oFD_Import_FileOk(object sender, CancelEventArgs e)
        {
            ReadBCSVFile_Import(oFD_Import.FileName);
            dGV_Import.Enabled = true;
            dGV_Import.Visible = true;
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
            Compare_BCSV();
        }

        private void Compare_BCSV()
        {
            int Diff = 0;
            DataGridViewCellStyle styleOK = new DataGridViewCellStyle();
            styleOK.Font = new Font(dGV_Main.Font, FontStyle.Bold);
            styleOK.BackColor = Color.Blue;

            DataGridViewCellStyle styleKO = new DataGridViewCellStyle();
            styleKO.Font = new Font(dGV_Main.Font, FontStyle.Bold);
            styleKO.BackColor = Color.Red;

            DataTable src1 = ToDataTable(dGV_Main);
            DataTable src2 = ToDataTable(dGV_Import);

            if (src1.Rows.Count == src2.Rows.Count)
            {
                for (int i = 0; i < src1.Rows.Count; i++)
                {
                    var row1 = src1.Rows[i].ItemArray;
                    var row2 = src2.Rows[i].ItemArray;

                    if (row1.Length == row2.Length)
                    {
                        for (int j = 0; j < row1.Length; j++)
                        {
                            try
                            {
                                if (!row1[j].ToString().Equals(row2[j].ToString()))
                                {
                                    dGV_Main.Rows[i].Cells[j].Style.BackColor = Color.Orange;
                                    dGV_Import.Rows[i].Cells[j].Style.BackColor = Color.Orange;
                                    Diff++;
                                }
                                else
                                {
                                    dGV_Main.Rows[i].Cells[j].Style.BackColor = Color.White;
                                    dGV_Import.Rows[i].Cells[j].Style.BackColor = Color.White;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.ToString());
                            }
                        }
                    }
                }
                if (Diff > 0) MessageBox.Show("Found " + Diff.ToString() + " modified value(s) !");
            } else
            {
                MessageBox.Show("Files does not match in size");
            }
        }

        private void compareAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compare_BCSV();
        }


        
    }
}
