using OfficeOpenXml;
using Pan.Properties;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Pan {
    public partial class Modificar : Form {

        private string filePath = string.Empty;
        private string fileName = string.Empty;
        //private ExcelPackage package;
        private ExcelPackage excel;
        private FileInfo openedExcel;
        private ExcelWorksheets workSheets;
        private ExcelWorksheet workSheet;
        private bool abierto = false;
        private string selectedSheet;
        private object cellValue;

        public Modificar() {
            InitializeComponent();
        }

        private void fDragDropFile(object sender, DragEventArgs e) {

            string[] files = ((string[])e.Data.GetData(DataFormats.FileDrop, false)).ToArray();
            if (files.Length > 1) {
                MessageBox.Show("Arrastre solo un archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                filePath = files[0];
                int indice = filePath.LastIndexOf('\\');
                int indice2 = filePath.LastIndexOf('.');

                if (indice != -1 && indice2 != -1 && filePath.Substring(indice2 + 1) == "xlsx") {

                    fileName = filePath.Substring(indice + 1);
                    lAbrirExcelModificar.Text = "Archivo seleccionado: " + fileName;

                    openedExcel = new FileInfo(filePath);
                    excel = new ExcelPackage(openedExcel);
                    workSheets = excel.Workbook.Worksheets;

                    foreach (var sheet  in workSheets) {
                        cbHojaModificar.Items.Add(new ComboBoxItem(sheet.Name,sheet.Index.ToString()));
                    }
                    cbHojaModificar.SelectedIndex = 0;

                } else {
                    MessageBox.Show("Archivo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            //foreach (string file in files) MessageBox.Show(file);
        }

        private void fDragEnterFile(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
                abierto = true;
            } else {
                e.Effect = DragDropEffects.None;
            }

        }

        private void fCerrarModificar(object sender, EventArgs e) {
            Utils.OpenCloseWindows(new Menu(), this);
        }

        private void fBorrarHoja(object sender, EventArgs e) {
            if (abierto) {
                DialogResult dr = MessageBox.Show("¿Seguro que quieres borrar la hoja?", "Eliminar hoja", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Information);

                if (dr == DialogResult.Yes) {
                    excel.Workbook.Worksheets.Delete(cbHojaModificar.SelectedItem.ToString());
                    excel.Save();

                    cbHojaModificar.Items.Clear();
                    foreach (var sheet in workSheets) {
                        cbHojaModificar.Items.Add(new ComboBoxItem(sheet.Name, sheet.Index.ToString()));
                    }
                    cbHojaModificar.SelectedIndex = 0;
                }
            }
        }

        private void fAbrirHoja(object sender, EventArgs e) {
            if (abierto) {
                selectedSheet = ((ComboBoxItem)cbHojaModificar.SelectedItem).HiddenValue;

                int cont = 0;
                Control[] rangos = {
                tbTraidoColonModificar, tbVentaColonModificar, lDevueltoColonModificar, lPCMColon, lTPMColon, lPVMColon, lTCMColon,
                tbTraidoCandealModificar, tbVentaCandealModificar, lDevueltoCandealModificar, lPCMCandeal, lTPMCandeal, lPVMCandeal, lTCMCandeal,
                tbTraidoPicosModificar, tbVentaPicosModificar, lDevueltoPicosModificar, lPCMPicos, lTPMPicos, lPVMPicos, lTCMPicos,
                tbTraidoAnticrisisModificar, tbVentaAnticrisisModificar, lDevueltoAnticrisisModificar, lPCMAnticrisis, lTPMAnticrisis, lPVMAnticrisis, lTCMAnticrisis,
                tbTraidoAVeranoModificar, tbVentaAVeranoModificar, lDevueltoAVeranoModificar, lPCMAVerano, lTPMAVerano, lPVMAVerano, lTCMAVerano,
                tbTraidoPistolasModificar, tbVentaPistolasModificar, lDevueltoPistolasModificar, lPCMPistolas, lTPMPistolas, lPVMPistolas, lTCMPistolas,
                tbTraidoIntegralModificar, tbVentaIntegralModificar, lDevueltoIntegralModificar, lPCMIntegral, lTPMIntegral, lPVMIntegral, lTCMIntegral,
                tbTraidoSinSalModificar, tbVentaSinSalModificar, lDevueltoSinSalModificar, lPCMSinSal, lTPMSinSal, lPVMSinSal, lTCMSinSal,
                tbTraidoMejorenaModificar, tbVentaMejorenaModificar, lDevueltoMejorenaModificar, lPCMMejorena, lTPMMejorena, lPVMMejorena, lTCMMejorena,
                tbTraidoMGrandeModificar, tbVentaMGrandeModificar, lDevueltoMGrandeModificar, lPCMMGrande, lTPMMGrande, lPVMMGrande, lTCMMGrande,
                tbTraidoNaturalModificar, tbVentaNaturalModificar, lDevueltoNaturalModificar, lPCMNatural, lTPMNatural, lPVMNatural, lTCMNatural,
                tbTraidoBarritaModificar, tbVentaBarritaModificar, lDevueltoBarritaModificar, lPCMBarrita, lTPMBarrita, lPVMBarrita, lTCMBarrita,
                lTotalDevolucionModificar,lTotalFacturaModificar, lBeneficiosModificar
                };

                if (selectedSheet != "" || selectedSheet != " " || selectedSheet != null) {
                    workSheet = excel.Workbook.Worksheets[int.Parse(selectedSheet)];

                    for (int i = 2; i <= 15; i++) {
                        for (int j = 2; j <= 8; j++) {
                            cellValue = (workSheet.Cells[i, j].Value);

                            if (cellValue != null) {
                                rangos[cont].Text = cellValue.ToString();
                                cont++;
                            }

                        }
                    }

                }
            }
        }

        private void fAbrirExcel(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
                openFileDialog.Filter = "Excel(*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    fileName = openFileDialog.SafeFileName;
                    lAbrirExcelModificar.Text = "Archivo seleccionado: " + fileName;
                    abierto = true;

                    openedExcel = new FileInfo(filePath);
                    excel = new ExcelPackage(openedExcel);
                    workSheets = excel.Workbook.Worksheets;

                    foreach (var sheet in workSheets) {
                        cbHojaModificar.Items.Add(new ComboBoxItem(sheet.Name, sheet.Index.ToString()));
                    }
                    cbHojaModificar.SelectedIndex = 0;

                }
            }
        }

        private int getDevuelto(string num1, string num2) {
            return (int.Parse(num1) - int.Parse(num2));
        }

        private void fGuardarCambios(object sender, EventArgs e) {
            try {

                if ((getDevuelto(tbTraidoColonModificar.Text, tbVentaColonModificar.Text) >= 0) && (getDevuelto(tbTraidoCandealModificar.Text, tbVentaCandealModificar.Text) >= 0) && (getDevuelto(tbTraidoPicosModificar.Text, tbVentaPicosModificar.Text) >= 0)
                    && (getDevuelto(tbTraidoAnticrisisModificar.Text, tbVentaAnticrisisModificar.Text) >= 0) && (getDevuelto(tbTraidoAVeranoModificar.Text, tbVentaAVeranoModificar.Text) >= 0) && (getDevuelto(tbTraidoPistolasModificar.Text, tbVentaPistolasModificar.Text) >= 0)
                    && (getDevuelto(tbTraidoIntegralModificar.Text, tbVentaIntegralModificar.Text) >= 0) && (getDevuelto(tbTraidoSinSalModificar.Text, tbVentaSinSalModificar.Text) >= 0) && (getDevuelto(tbTraidoMejorenaModificar.Text, tbVentaMejorenaModificar.Text) >= 0)
                    && (getDevuelto(tbTraidoMGrandeModificar.Text, tbVentaMGrandeModificar.Text) >= 0) && (getDevuelto(tbTraidoNaturalModificar.Text, tbVentaNaturalModificar.Text) >= 0) && (getDevuelto(tbTraidoBarritaModificar.Text, tbVentaBarritaModificar.Text) >= 0)) {

                    /*Devuelto = traido-ventas = venta*precioventa */
                    lDevueltoColonModificar.Text = getDevuelto(tbTraidoColonModificar.Text, tbVentaColonModificar.Text).ToString();
                    lDevueltoCandealModificar.Text = getDevuelto(tbTraidoCandealModificar.Text, tbVentaCandealModificar.Text).ToString();
                    lDevueltoPicosModificar.Text = getDevuelto(tbTraidoPicosModificar.Text, tbVentaPicosModificar.Text).ToString();
                    lDevueltoAnticrisisModificar.Text = getDevuelto(tbTraidoAnticrisisModificar.Text, tbVentaAnticrisisModificar.Text).ToString();
                    lDevueltoAVeranoModificar.Text = getDevuelto(tbTraidoAVeranoModificar.Text, tbVentaAVeranoModificar.Text).ToString();
                    lDevueltoPistolasModificar.Text = getDevuelto(tbTraidoPistolasModificar.Text, tbVentaPistolasModificar.Text).ToString();
                    lDevueltoIntegralModificar.Text = getDevuelto(tbTraidoIntegralModificar.Text, tbVentaIntegralModificar.Text).ToString();
                    lDevueltoSinSalModificar.Text = getDevuelto(tbTraidoSinSalModificar.Text, tbVentaSinSalModificar.Text).ToString();
                    lDevueltoMejorenaModificar.Text = getDevuelto(tbTraidoMejorenaModificar.Text, tbVentaMejorenaModificar.Text).ToString();
                    lDevueltoMGrandeModificar.Text = getDevuelto(tbTraidoMGrandeModificar.Text, tbVentaMGrandeModificar.Text).ToString();
                    lDevueltoNaturalModificar.Text = getDevuelto(tbTraidoNaturalModificar.Text, tbVentaNaturalModificar.Text).ToString();
                    lDevueltoBarritaModificar.Text = getDevuelto(tbTraidoBarritaModificar.Text, tbVentaBarritaModificar.Text).ToString();


                    /*Total a cobrar = venta*precioventa */
                    lTCMColon.Text = (double.Parse(tbVentaColonModificar.Text) * double.Parse(lPVMColon.Text)).ToString();
                    lTCMCandeal.Text = (double.Parse(tbVentaCandealModificar.Text) * double.Parse(lPVMCandeal.Text)).ToString();
                    lTCMPicos.Text = (double.Parse(tbVentaPicosModificar.Text) * double.Parse(lPVMPicos.Text)).ToString();
                    lTCMAnticrisis.Text = (double.Parse(tbVentaAnticrisisModificar.Text) * double.Parse(lPVMAnticrisis.Text)).ToString();
                    lTCMAVerano.Text = (double.Parse(tbVentaAVeranoModificar.Text) * double.Parse(lPVMAVerano.Text)).ToString();
                    lTCMPistolas.Text = (double.Parse(tbVentaPistolasModificar.Text) * double.Parse(lPVMPistolas.Text)).ToString();
                    lTCMIntegral.Text = (double.Parse(tbVentaIntegralModificar.Text) * double.Parse(lPVMIntegral.Text)).ToString();
                    lTCMSinSal.Text = (double.Parse(tbVentaSinSalModificar.Text) * double.Parse(lPVMSinSal.Text)).ToString();
                    lTCMMejorena.Text = (double.Parse(tbVentaMejorenaModificar.Text) * double.Parse(lPVMMejorena.Text)).ToString();
                    lTCMMGrande.Text = (double.Parse(tbVentaMGrandeModificar.Text) * double.Parse(lPVMMGrande.Text)).ToString();
                    lTCMNatural.Text = (double.Parse(tbVentaNaturalModificar.Text) * double.Parse(lPVMNatural.Text)).ToString();
                    lTCMBarrita.Text = (double.Parse(tbVentaBarritaModificar.Text) * double.Parse(lPVMBarrita.Text)).ToString();


                    /*Total a pagar = venta*preciocompra */
                    lTPMColon.Text = (double.Parse(tbVentaColonModificar.Text) * double.Parse(lPCMColon.Text)).ToString();
                    lTPMCandeal.Text = (double.Parse(tbVentaCandealModificar.Text) * double.Parse(lPCMCandeal.Text)).ToString();
                    lTPMPicos.Text = (double.Parse(tbVentaPicosModificar.Text) * double.Parse(lPCMPicos.Text)).ToString();
                    lTPMAnticrisis.Text = (double.Parse(tbVentaAnticrisisModificar.Text) * double.Parse(lPCMAnticrisis.Text)).ToString();
                    lTPMAVerano.Text = (double.Parse(tbVentaAVeranoModificar.Text) * double.Parse(lPCMAVerano.Text)).ToString();
                    lTPMPistolas.Text = (double.Parse(tbVentaPistolasModificar.Text) * double.Parse(lPCMPistolas.Text)).ToString();
                    lTPMIntegral.Text = (double.Parse(tbVentaIntegralModificar.Text) * double.Parse(lPCMIntegral.Text)).ToString();
                    lTPMSinSal.Text = (double.Parse(tbVentaSinSalModificar.Text) * double.Parse(lPCMSinSal.Text)).ToString();
                    lTPMMejorena.Text = (double.Parse(tbVentaMejorenaModificar.Text) * double.Parse(lPCMMejorena.Text)).ToString();
                    lTPMMGrande.Text = (double.Parse(tbVentaMGrandeModificar.Text) * double.Parse(lPCMMGrande.Text)).ToString();
                    lTPMNatural.Text = (double.Parse(tbVentaNaturalModificar.Text) * double.Parse(lPCMNatural.Text)).ToString();
                    lTPMBarrita.Text = (double.Parse(tbVentaBarritaModificar.Text) * double.Parse(lPCMBarrita.Text)).ToString();

                    /*Total factura = sumaDeTodosTotalPagar*/
                    lTotalFacturaModificar.Text = (

                        (double.Parse(lTPMColon.Text) + double.Parse(lTPMCandeal.Text) + double.Parse(lTPMPicos.Text) + double.Parse(lTPMAnticrisis.Text) + double.Parse(lTPMAVerano.Text) +
                        double.Parse(lTPMPistolas.Text) + double.Parse(lTPMIntegral.Text) + double.Parse(lTPMSinSal.Text) + double.Parse(lTPMMejorena.Text) + double.Parse(lTPMMGrande.Text) + double.Parse(lTPMNatural.Text) + double.Parse(lTPMBarrita.Text))

                    ).ToString();


                    /*Total devolucion = sumaDeTodosDevuelto*/
                    lTotalDevolucionModificar.Text = (int.Parse(lDevueltoColonModificar.Text) + int.Parse(lDevueltoCandealModificar.Text) + int.Parse(lDevueltoPicosModificar.Text) + int.Parse(lDevueltoAnticrisisModificar.Text) + int.Parse(lDevueltoAVeranoModificar.Text)
                        + int.Parse(lDevueltoPistolasModificar.Text) + int.Parse(lDevueltoIntegralModificar.Text) + int.Parse(lDevueltoSinSalModificar.Text) + int.Parse(lDevueltoMejorenaModificar.Text) + int.Parse(lDevueltoMGrandeModificar.Text)
                        + int.Parse(lDevueltoNaturalModificar.Text) + int.Parse(lDevueltoBarritaModificar.Text)).ToString();

                    /*Beneficios = sumaTotalCobrar - sumaTotalPagar*/
                    lBeneficiosModificar.Text = (

                        (double.Parse(lTCMColon.Text) + double.Parse(lTCMCandeal.Text) + double.Parse(lTCMPicos.Text) + double.Parse(lTCMAnticrisis.Text) + double.Parse(lTCMAVerano.Text) +
                        double.Parse(lTCMPistolas.Text) + double.Parse(lTCMIntegral.Text) + double.Parse(lTCMSinSal.Text) + double.Parse(lTCMMejorena.Text) + double.Parse(lTCMMGrande.Text) + double.Parse(lTCMNatural.Text) + double.Parse(lTCMBarrita.Text)
                        ) - double.Parse(lTotalFacturaModificar.Text)

                    ).ToString();

                    openedExcel = new FileInfo(filePath);
                    //openedExcel.OpenWrite();
                    excel = new ExcelPackage(openedExcel);

                    workSheet = excel.Workbook.Worksheets[int.Parse(selectedSheet)];
                    int contador = 0;
                    Control[] rangos = {
                    tbTraidoColonModificar, tbVentaColonModificar, lDevueltoColonModificar, lPCMColon, lTPMColon, lPVMColon, lTCMColon,
                    tbTraidoCandealModificar, tbVentaCandealModificar, lDevueltoCandealModificar, lPCMCandeal, lTPMCandeal, lPVMCandeal, lTCMCandeal,
                    tbTraidoPicosModificar, tbVentaPicosModificar, lDevueltoPicosModificar, lPCMPicos, lTPMPicos, lPVMPicos, lTCMPicos,
                    tbTraidoAnticrisisModificar, tbVentaAnticrisisModificar, lDevueltoAnticrisisModificar, lPCMAnticrisis, lTPMAnticrisis, lPVMAnticrisis, lTCMAnticrisis,
                    tbTraidoAVeranoModificar, tbVentaAVeranoModificar, lDevueltoAVeranoModificar, lPCMAVerano, lTPMAVerano, lPVMAVerano, lTCMAVerano,
                    tbTraidoPistolasModificar, tbVentaPistolasModificar, lDevueltoPistolasModificar, lPCMPistolas, lTPMPistolas, lPVMPistolas, lTCMPistolas,
                    tbTraidoIntegralModificar, tbVentaIntegralModificar, lDevueltoIntegralModificar, lPCMIntegral, lTPMIntegral, lPVMIntegral, lTCMIntegral,
                    tbTraidoSinSalModificar, tbVentaSinSalModificar, lDevueltoSinSalModificar, lPCMSinSal, lTPMSinSal, lPVMSinSal, lTCMSinSal,
                    tbTraidoMejorenaModificar, tbVentaMejorenaModificar, lDevueltoMejorenaModificar, lPCMMejorena, lTPMMejorena, lPVMMejorena, lTCMMejorena,
                    tbTraidoMGrandeModificar, tbVentaMGrandeModificar, lDevueltoMGrandeModificar, lPCMMGrande, lTPMMGrande, lPVMMGrande, lTCMMGrande,
                    tbTraidoNaturalModificar, tbVentaNaturalModificar, lDevueltoNaturalModificar, lPCMNatural, lTPMNatural, lPVMNatural, lTCMNatural,
                    tbTraidoBarritaModificar, tbVentaBarritaModificar, lDevueltoBarritaModificar, lPCMBarrita, lTPMBarrita, lPVMBarrita, lTCMBarrita,
                    lTotalDevolucionModificar,lTotalFacturaModificar, lBeneficiosModificar
                    };

                    for (int i = 2; i <= 15; i++) {
                        for (int j = 2; j <= 8; j++) {
                            //MessageBox.Show((workSheet.Cells[i, j].Value).ToString());
                            //if (i!=13 && (i!=14 && j !=2) && (i != 14 && j != 3) && (i != 14 && j != 5)&& (i != 14 && j != 7)) {
                            if (workSheet.Cells[i, j].Value != null) {
                                workSheet.Cells[i, j].Value = rangos[contador].Text;
                                contador++;
                            }
                                
                            /*} else {
                                continue;
                            }*/
                            
                        }
                    }

                    excel.Save();
                    MessageBox.Show("Terminado", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (FormatException) {
                MessageBox.Show("Campos vacios o incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException) {
                MessageBox.Show("Cierre el excel y pulse el botón guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fExitApp(object sender, FormClosingEventArgs e) {
            Utils.exitApp(e);
        }
    }
}
