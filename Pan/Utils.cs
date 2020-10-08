using System;
using System.Windows.Forms;

namespace Pan {
    class Utils {
        public static void OpenCloseWindows(Form abrir, Form cerrar) {
            cerrar.Hide();
            abrir.FormClosed += (s, args) => cerrar.Close();
            abrir.Show();
        }

        public static void exitApp(FormClosingEventArgs e = null) {
            DialogResult dr = MessageBox.Show("¿Quieres salir del programa?", "Salir", MessageBoxButtons.YesNo);

            switch (dr) {
                case DialogResult.Yes:
                    //Application.Exit();
                    //Environment.Exit(1);
                    Application.ExitThread();
                    break;

                case DialogResult.No:
                    if (e != null) {
                        e.Cancel = true;
                        break;

                    } else {
                        break;
                    }
            }
        }
    }
}
