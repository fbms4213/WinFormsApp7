using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source;

public partial class Dialog_Form : Form
{
    public Dialog_Form()
    {
        InitializeComponent();
    }



    private void btn_openFile_Click(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "All files|*.*|Text Files|*.txt";
        openFileDialog1.FilterIndex = 2;

        // openFileDialog1.Multiselect = true;


        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            // var fileNames = openFileDialog1.FileNames;
            using StreamReader sr = new(openFileDialog1.FileName);
            textBox1.Text = sr.ReadToEnd();
        }
    }




    private void btn_save_Click(object sender, EventArgs e)
    {
        saveFileDialog1.Filter = "Text Files|*.txt";
        saveFileDialog1.FilterIndex = 1;

        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            using StreamWriter sw = new(saveFileDialog1.FileName);
            sw.Write(textBox1.Text);
        }
    }





    private void btn_openImage_Click(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "PNG|*.png|JPG|*.jpg; *.jpeg;|GIF|*.gif";

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            pictureBox1.Load(openFileDialog1.FileName);
        }
    }

    private void Btn_openFolder_Click(object sender, EventArgs e)
    {
        folderBrowserDialog1.ShowDialog();
        lbl_folderPath.Text = folderBrowserDialog1.SelectedPath;
    }

    private void btn_openColorDialog_Click(object sender, EventArgs e)
    {
        colorDialog1.FullOpen = true;
        colorDialog1.ShowHelp = true;
        colorDialog1.HelpRequest += (s, e) => { };


        colorDialog1.ShowDialog();
        lbl_color.ForeColor = colorDialog1.Color;
    }

    private void btn_fontDialog_Click(object sender, EventArgs e)
    {
        fontDialog1.ShowDialog();
        lbl_font.Font = fontDialog1.Font;
    }


    private void Dialog_Form_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Control && e.KeyCode == Keys.S)
            lbl_shortcut.Text = "ctrl + s";
    }
}
