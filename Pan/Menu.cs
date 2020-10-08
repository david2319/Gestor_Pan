using System;
using System.Reflection;
using System.Windows.Forms;


namespace Pan
{
    public partial class Menu : Form {

        public Menu(){
            InitializeComponent();

            //Obtener la versión del archivo Assembly.cs
            lVersion.Text = (Assembly.GetEntryAssembly().GetName().Version).ToString();
        }


        private void fMenu(object sender, EventArgs e) {
            //Button clickedButton = sender as Button;

            switch ((sender as Button).Tag.ToString()) {

                case "insertarMenu":
                    Utils.OpenCloseWindows(new Insertar(), this);
                    break;

                case "modificarMenu":
                    Utils.OpenCloseWindows(new Modificar(), this);
                    break;

                case "configuracionMenu":
                    Utils.OpenCloseWindows(new Configuracion(), this);
                    break;

                case "ayudaMenu":
                    Utils.OpenCloseWindows(new Ayuda(), this);
                    break;

                default:
                    break;
            }
        }

        private void fSalir(object sender, EventArgs e) {
            Utils.exitApp();
        }

        private void fExitApp(object sender, FormClosingEventArgs e) {
            Utils.exitApp(e);
        }
    }
}
