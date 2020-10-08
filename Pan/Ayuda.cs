using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pan {
    public partial class Ayuda : Form {

        /*Para deshabilitar el boton de cerrar*/
        // private const int CP_NOCLOSE_BUTTON = 0x200;

        /*Deshabilitar el boton de cerrar*/
        //protected override CreateParams CreateParams {
        //    get {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}

        private string[] labelHelp = {"Insertar", "Modificar", "Configuración", "Ayuda" };
       
        public Ayuda() {
            InitializeComponent();
            rellenarRichTextHelpInsertar();
            rellenarRichTextHelpModificar();
            rellenarRichTextHelpConfiguracion();
            lHelp.Text = "";
        }


        private void rellenarRichTextHelpInsertar() {
            rtHelpInsertar.Text = "Se pueden insertar los datos segun 2 condiciones:\n\n" +
                "1.Si no existe aún ningún excel, simplemente hay que añadir los datos, " +
                "escribir el nombre de la hoja y pulsar el botón <<Guardar>>.\n" +
                "Se abrirá una ventana para indicar donde se va a crear y guardar el nuevo excel.\n\n" +
                "2.Si ya existe un excel, hay que pulsar el boton de <<ABRIR EXCEL>> donde se abrirá una ventana" +
                "para elegir el excel (otra opción es arrastrar directamente el excel a la aplicación)" +
                " y a continuación rellenar los datos, escribir el nombre de la hoja y" +
                " finalmente pulsar sobre el botón <<Guardar>>.";
        }

        private void rellenarRichTextHelpModificar() {
            rtHelpModificar.Text = "Se pueden modificar los datos de una hoja del excel, para ello:\n\n" +
                "1.Pulsar <<ABRIR EXCEL>> (o arrastrar el archivo excel a la ventana).\n\n" +
                "2.Seleccionar la hoja que se desea modificar en el cuadro despleglable, y " +
                "a continuación pulsar sobre <<ABRIR HOJA>>.\n\n" +
                "3.Modificar los datos correspondientes y pulsar en <<Guardar>>.\n\n" +
                "4.Para borrar la hoja seleccionada, pulsar en <<Borrar Hoja>>";
        }

        private void rellenarRichTextHelpConfiguracion() {
            rtHelpConfiguracion.Text = "Se pueden configurar los datos que compondrá:\n\n" +
                "1.Al pulsar <<Cambiar nombres>> se podrá modificar los nombres de los panes.\n\n" +
                "2.Se pueden cambiar también los Precios Compra y los Precios Venta.**HAY QUE USAR COMAS**\n\n" +
                "           ***IMPORTANTE***\n" +
                "***NO USAR PUNTOS AUNQUE APAREZCA ASI EN LOS CUADROS***";
        }

        private void fHelp(object sender, EventArgs e) {
            //Para detectar que boton se ha pulsado
            Button clickedButton = sender as Button;

            switch (clickedButton.Tag.ToString()) {
                case "insertar":
                    lHelp.Text = labelHelp[0];
                    rtHelpMenu.Text = "Al pulsar el botón <<Insertar>> se abrirá una " +
                        "nueva ventana en la cual se podrá realizar diversas funciones:\n\n" +
                        "1.Crear nuevo excel.\n" +
                        "2.Añadir una nueva a un excel ya existente.\n" +
                        "3.Indicar la cantidad de pan <<Traído>> y <<Venta>>.";
                    break;

                case "modificar":
                    lHelp.Text = labelHelp[1];
                    rtHelpMenu.Text = "Al pulsar el botón <<Modificar>> se abrirá una " +
                        "nueva ventana en la cual se podrá realizar diversas funciones:\n\n" +
                        "1.Abrir un excel existente.\n" +
                        "2.Abrir una hoja de un excel existente.\n" +
                        "3.Borrar una hoja de un excel existente.\n" +
                        "4.Modificar los campos <<Traído>> y <<Venta>> de la hoja abierta.";
                    break;

                case "configuracion":
                    lHelp.Text = labelHelp[2];
                    rtHelpMenu.Text = "Al pulsar el botón <<Configuración>> se abrirá una " +
                        "nueva ventana en la cual se podrá realizar diversas funciones:\n\n" +
                        "1.Modificar <<Precio Compra>> y <<Precio Venta>>.\n" +
                        "2.Añadir nuevos tipos de pan.\n" +
                        "3.Eliminar uno o varios tipos de pan.\n";
                    break;

                case "ayuda":
                    lHelp.Text = labelHelp[3];
                    rtHelpMenu.Text = "Al pulsar el botón <<Ayuda>> se abrirá una " +
                        "nueva ventana que mostrará información acerca de aplicación y de como usarla.";
                    break;

                default:
                    lHelp.Text = "";
                    rtHelpMenu.Text = "";
                    MessageBox.Show("Error");
                    break;
            }

        }

        private void fCerrarHelp(object sender, EventArgs e) {
            Utils.OpenCloseWindows(new Menu(), this);
        }

        private void fSalirApp(object sender, FormClosingEventArgs e) {
            Utils.exitApp(e);
        }
    }
}
