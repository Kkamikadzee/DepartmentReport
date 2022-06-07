using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepostWinForms
{
    public class WindowApplication
    {
        private ReportWinForm _form;

        public ReportWinForm Form => _form;

        public WindowApplication()
        {
            _form = new ReportWinForm();
        }

        [STAThread]
        public void Start()
        {
            Application.Run(_form);
        }

        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
