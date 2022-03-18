using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bio
{
    public partial class impresora : Form
    {
        public impresora()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string WT1 = "TSC Printers";
            string B1 = "20080101";
            byte[] result_unicode = System.Text.Encoding.GetEncoding("utf-16").GetBytes("unicode test");
            byte[] result_utf8 = System.Text.Encoding.UTF8.GetBytes("TEXT 40,620,\"ARIAL.TTF\",0,12,12,\"utf8 test Wörter auf Deutsch\"");

            //TSCLIB_DLL.about();
            byte status = TSCLIB_DLL.usbportqueryprinter();//0 = idle, 1 = head open, 16 = pause, following <ESC>!? command of TSPL manual
            TSCLIB_DLL.openport("TSC TE210");
            TSCLIB_DLL.sendcommand("SIZE 100 mm, 120 mm");
            TSCLIB_DLL.sendcommand("SPEED 4");
            TSCLIB_DLL.sendcommand("DENSITY 12");
            TSCLIB_DLL.sendcommand("DIRECTION 1");
            TSCLIB_DLL.sendcommand("SET TEAR ON");
            TSCLIB_DLL.sendcommand("CODEPAGE UTF-8");
            TSCLIB_DLL.clearbuffer();
            TSCLIB_DLL.downloadpcx("UL.PCX", "UL.PCX");
            TSCLIB_DLL.windowsfont(40, 490, 48, 0, 0, 0, "Arial", "Windows Font Test");
            TSCLIB_DLL.windowsfontUnicode(40, 550, 48, 0, 0, 0, "Arial", result_unicode);
            TSCLIB_DLL.sendcommand("PUTPCX 40,40,\"UL.PCX\"");
            TSCLIB_DLL.sendBinaryData(result_utf8, result_utf8.Length);
            TSCLIB_DLL.barcode("40", "300", "128", "80", "1", "0", "2", "2", B1);
            TSCLIB_DLL.printerfont("40", "440", "0", "0", "15", "15", WT1);
            TSCLIB_DLL.printlabel("1", "1");
            TSCLIB_DLL.closeport();

            
        }
    }
}