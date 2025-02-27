using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace NOCDPatcher
{
    public partial class FormMain : Form
    {
        static string path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        string main = Path.Combine(path, "Morrowind.exe");
        string text = Path.Combine(path, "Text.dll");

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processFile(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            processFile(true);
        }

        void processFile(bool restore)
        {
            if (File.Exists(main) && File.Exists(text))
            {
                byte[] bytesFile = File.ReadAllBytes(main);
                if (restore)
                {
                    bytesFile[93827] = 117;
                    bytesFile[93828] = 41;

                    bytesFile[93858] = 138;
                    bytesFile[93859] = 7;

                    bytesFile[3635578] = 58;
                    bytesFile[3635630] = 58;
                }
                else
                {
                    bytesFile[93827] = 235;
                    bytesFile[93828] = 29;

                    bytesFile[93858] = 176;
                    bytesFile[93859] = 46;

                    bytesFile[3635578] = 92;
                    bytesFile[3635630] = 92;
                }
                File.WriteAllBytes(main, bytesFile);
                bytesFile = File.ReadAllBytes(text);
                if (restore)
                {
                    bytesFile[4614] = 15;
                    bytesFile[4615] = 133;
                    bytesFile[4616] = 244;

                    bytesFile[4810] = 133;
                    bytesFile[4811] = 192;
                    bytesFile[4812] = 117;
                    bytesFile[4813] = 50;
                    bytesFile[4814] = 138;
                    bytesFile[4815] = 7;

                    bytesFile[4835] = 116;
                    bytesFile[4836] = 27;

                    bytesFile[4854] = 116;
                    bytesFile[4855] = 8;

                    bytesFile[23981] = 117;
                    bytesFile[23982] = 24;

                    bytesFile[37074] = 58;
                }
                else
                {
                    bytesFile[4614] = 233;
                    bytesFile[4615] = 191;
                    bytesFile[4616] = 0;

                    bytesFile[4810] = 144;
                    bytesFile[4811] = 144;
                    bytesFile[4812] = 144;
                    bytesFile[4813] = 144;
                    bytesFile[4814] = 176;
                    bytesFile[4815] = 46;

                    bytesFile[4835] = 144;
                    bytesFile[4836] = 144;

                    bytesFile[4854] = 144;
                    bytesFile[4855] = 144;

                    bytesFile[23981] = 144;
                    bytesFile[23982] = 144;

                    bytesFile[37074] = 92;
                }
                File.WriteAllBytes(text, bytesFile);
            }
        }
    }
}
