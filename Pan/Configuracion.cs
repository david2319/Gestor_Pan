using Pan.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Pan{
    public partial class Configuracion : Form{

        private Settings props = Settings.Default;

        private List<TextBox> tbPreciosList;
        private List<TextBox> tbNombresPanesList;


        public Configuracion() {
            InitializeComponent();

            //tbPreciosList = new List<TextBox>()
            //        {
            //            tbPCCCandeal,
            //            tbPCCCandeal,
            //            tbPCCPicos,
            //            tbPCCAnticrisis,
            //            tbPCCAVerano,
            //            tbPCCPistolas,
            //            tbPCCIntegral,
            //            tbPCCSinSal,
            //            tbPCCMejorena,
            //            tbPCCMGrande,
            //            tbPCCNatural,
            //            tbPVCBarrita,
            //            tbPVCCandeal,
            //            tbPVCCandeal,
            //            tbPVCPicos,
            //            tbPVCAnticrisis,
            //            tbPVCAVerano,
            //            tbPVCPistolas,
            //            tbPVCIntegral,
            //            tbPVCSinSal,
            //            tbPVCMejorena,
            //            tbPVCMGrande,
            //            tbPVCNatural,
            //            tbPVCBarrita
            //        };

            //foreach (SettingsProperty currentProperty in Settings.Default.Properties) {

            //    foreach (TextBox box in textboxesArray) {
            //        box.Text = Settings.Default[currentProperty.Name].ToString();
            //        break;
            //    }
            //textboxesArray[i].Text = Settings.Default[currentProperty.Name];
            //Settings.Default[currentProperty.Name] = result.ToString();
            //Settings.Default.Save();
            //}

            //var enumerator = Settings.Default.Properties;

            //LO BUENO
            tbNombresPanesList = new List<TextBox>(){

                        tbPan1,
                        tbPan2,
                        tbPan3,
                        tbPan4,
                        tbPan5,
                        tbPan6,
                        tbPan7,
                        tbPan8,
                        tbPan9,
                        tbPan10,
                        tbPan11,
                        tbPan12  };
            //for (int i = 0; i < tbNombresPanesList.Count; i++) {
            int i = 0;
                foreach (SettingsProperty currentProperty in Settings.Default.Properties) {

                //enumerator.MoveNext();
                //SettingsProperty prop = (SettingsProperty)enumerator.Current;
                //tbNombresPanesList[i].Text = Settings.Default[currentProperty.Name].ToString();

                    if (currentProperty.Name.ToString().Contains("Pan")) {
                        

                        tbNombresPanesList[i].Text = currentProperty.Name.ToString();
                        i++;
                        if (i >= tbNombresPanesList.Count) { i = 0; break; }
                    }

                    
                }
            
           // }



            tbPCCColon.Text = props.PCColon.ToString();
            tbPCCCandeal.Text = props.PCCandeal.ToString();
            tbPCCPicos.Text = props.PCPicos.ToString();
            tbPCCAnticrisis.Text = props.PCAnticrisis.ToString();
            tbPCCAVerano.Text = props.PCAVerano.ToString();
            tbPCCPistolas.Text = props.PCPistolas.ToString();
            tbPCCIntegral.Text = props.PCIntegral.ToString();
            tbPCCSinSal.Text = props.PCSinSal.ToString();
            tbPCCMejorena.Text = props.PCMejorena.ToString();
            tbPCCMGrande.Text = props.PCMGrande.ToString();
            tbPCCNatural.Text = props.PCNatural.ToString();
            tbPCCBarrita.Text = props.PCBarrita.ToString();

            tbPVCColon.Text = props.PVColon.ToString();
            tbPVCCandeal.Text = props.PVCandeal.ToString();
            tbPVCPicos.Text = props.PVPicos.ToString();
            tbPVCAnticrisis.Text = props.PVAnticrisis.ToString();
            tbPVCAVerano.Text = props.PVAVerano.ToString();
            tbPVCPistolas.Text = props.PVPistolas.ToString();
            tbPVCIntegral.Text = props.PVIntegral.ToString();
            tbPVCSinSal.Text = props.PVSinSal.ToString();
            tbPVCMejorena.Text = props.PVMejorena.ToString();
            tbPVCMGrande.Text = props.PVMGrande.ToString();
            tbPVCNatural.Text = props.PVNatural.ToString();
            tbPVCBarrita.Text = props.PVBarrita.ToString();

            /*tbPan1.Text = props.Pan1.ToString();
            tbPan2.Text = props.Pan2.ToString();
            tbPan3.Text = props.Pan3.ToString();
            tbPan4.Text = props.Pan4.ToString();
            tbPan5.Text = props.Pan5.ToString();
            tbPan6.Text = props.Pan6.ToString();
            tbPan7.Text = props.Pan7.ToString();
            tbPan8.Text = props.Pan8.ToString();
            tbPan9.Text = props.Pan9.ToString();
            tbPan10.Text = props.Pan10.ToString();
            tbPan11.Text = props.Pan11.ToString();
            tbPan12.Text = props.Pan12.ToString();*/

        }

        

        private void fCerrarConfiguracion(object sender, EventArgs e) {
            Utils.OpenCloseWindows(new Menu(), this);
        }

        private void fGuardarConfiguracionj(object sender, EventArgs e) {
            try {
                /*ESTABLECE EL PRECIO COMPRA*/
                props.PCColon = double.Parse(tbPCCColon.Text);
                props.PCCandeal = double.Parse(tbPCCCandeal.Text);
                props.PCPicos = double.Parse(tbPCCPicos.Text);
                props.PCAnticrisis = double.Parse(tbPCCAnticrisis.Text);
                props.PCAVerano = double.Parse(tbPCCAVerano.Text);
                props.PCPistolas = double.Parse(tbPCCPistolas.Text);
                props.PCIntegral = double.Parse(tbPCCIntegral.Text);
                props.PCSinSal = double.Parse(tbPCCSinSal.Text);
                props.PCMejorena = double.Parse(tbPCCMejorena.Text);
                props.PCMGrande = double.Parse(tbPCCMGrande.Text);
                props.PCNatural = double.Parse(tbPCCNatural.Text);
                props.PCBarrita = double.Parse(tbPCCBarrita.Text);

                /*ESTABLECE EL PRECIO VENTA*/
                props.PVColon = double.Parse(tbPVCColon.Text);
                props.PVCandeal = double.Parse(tbPVCCandeal.Text);
                props.PVPicos = double.Parse(tbPVCPicos.Text);
                props.PVAnticrisis = double.Parse(tbPVCAnticrisis.Text);
                props.PVAVerano = double.Parse(tbPVCAVerano.Text);
                props.PVPistolas = double.Parse(tbPVCPistolas.Text);
                props.PVIntegral = double.Parse(tbPVCIntegral.Text);
                props.PVSinSal = double.Parse(tbPVCSinSal.Text);
                props.PVMejorena = double.Parse(tbPVCMejorena.Text);
                props.PVMGrande = double.Parse(tbPVCMGrande.Text);
                props.PVNatural = double.Parse(tbPVCNatural.Text);
                props.PVBarrita = double.Parse(tbPVCBarrita.Text);

                /*ESTABLECE EL NOMVBRE DE LOS PANES*/
                props.Pan1 = tbPan1.Text;
                props.Pan2 = tbPan2.Text;
                props.Pan3 = tbPan3.Text;
                props.Pan4 = tbPan4.Text;
                props.Pan5 = tbPan5.Text;
                props.Pan6 = tbPan6.Text;
                props.Pan7 = tbPan7.Text;
                props.Pan8 = tbPan8.Text;
                props.Pan9 = tbPan9.Text;
                props.Pan10 = tbPan10.Text;
                props.Pan11 = tbPan11.Text;
                props.Pan12 = tbPan12.Text;

                props.Save();

                DialogResult result = MessageBox.Show("Cambios guardados", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK) {
                    Utils.OpenCloseWindows(new Menu(), this);
                }

            } catch (Exception) {

                MessageBox.Show("Valores Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void fChangeBreadNames(object sender, EventArgs e) {

            foreach (TextBox tb in tbNombresPanesList) {
                tb.ReadOnly = false;
                tb.BorderStyle = BorderStyle.Fixed3D;
                tb.BackColor = Color.White;
            }
        }

        private void fExitApp(object sender, FormClosingEventArgs e) {
            Utils.exitApp(e);
        }
    }
}
