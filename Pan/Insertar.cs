using OfficeOpenXml;
using OfficeOpenXml.Style;
using Pan.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Pan
{
    public partial class Insertar : Form{

        private Settings props = Settings.Default;

        private string fileContent = string.Empty;
        private string filePath = string.Empty;
        private string fileName = string.Empty;
        private bool abierto = false;
        private string headerRange;
        private List<string[]> headerRow;
        private ExcelPackage excel;
        private FileInfo openedExcel;


        public Insertar(){
            InitializeComponent();
            /*DragDrop += new DragEventHandler(fDragDropFile);
            DragEnter += new DragEventHandler(fDragEnterFile);*/
            ttAbrirExcel.SetToolTip(bAbrirExcelInsertar, "Añade la hoja a un exel existente");

            /*Se establecen los label con los precios de compra correspondientes*/
            lPCIColon.Text = props.PCColon.ToString();
            lPCICandeal.Text = props.PCCandeal.ToString();
            lPCIPicos.Text = props.PCPicos.ToString();
            lPCIAnticrisis.Text = props.PCAnticrisis.ToString();
            lPCIAVerano.Text = props.PCAVerano.ToString();
            lPCIPistolas.Text = props.PCPistolas.ToString();
            lPCIIntegral.Text = props.PCIntegral.ToString();
            lPCISinSal.Text = props.PCSinSal.ToString();
            lPCIMejorena.Text = props.PCMejorena.ToString();
            lPCIMGrande.Text = props.PCMGrande.ToString();
            lPCINatural.Text = props.PCNatural.ToString();
            lPCIBarrita.Text = props.PCBarrita.ToString();

            /*Se establecen los label con los precios de venta correspondientes*/
            lPVIColon.Text = props.PVColon.ToString();
            lPVICandeal.Text = props.PVCandeal.ToString();
            lPVIPicos.Text = props.PVPicos.ToString();
            lPVIAnticrisis.Text = props.PVAnticrisis.ToString();
            lPVIAVerano.Text = props.PVAVerano.ToString();
            lPVIPistolas.Text = props.PVPistolas.ToString();
            lPVIIntegral.Text = props.PVIntegral.ToString();
            lPVISinSal.Text = props.PVSinSal.ToString();
            lPVIMejorena.Text = props.PVMejorena.ToString();
            lPVIMGrande.Text = props.PVMGrande.ToString();
            lPVINatural.Text = props.PVNatural.ToString();
            lPVIBarrita.Text = props.PVBarrita.ToString();

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
                    lAbrirExcelInsertar.Text = "Archivo seleccionado: " + fileName;
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

        private void fCerrarInsertar(object sender, EventArgs e){
            Utils.OpenCloseWindows(new Menu(), this);
        }

        private void fAbrirExcelInsertar(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
                openFileDialog.Filter = "Excel(*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    fileName = openFileDialog.SafeFileName;
                    lAbrirExcelInsertar.Text = "Archivo seleccionado: "+fileName;
                    abierto = true;

                    //Read the contents of the file into a stream
                    /*var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream)) {
                        fileContent = reader.ReadToEnd();
                    }*/

                }
            }

        }

        private int getDevuelto(string num1, string num2) {
            return (int.Parse(num1) - int.Parse(num2));
        }


        private void fGuardarInsertar(object sender, EventArgs e) {

            //Comprobaciones y asignaciones
            if (tbNombreHoja.Text != null && tbNombreHoja.Text != "" && tbNombreHoja.Text != " ") {
                try {

                    if ((getDevuelto(tbTraidoColonInsertar.Text, tbVentaColonInsertar.Text) >= 0) && (getDevuelto(tbTraidoCandealInsertar.Text, tbVentaCandealInsertar.Text) >= 0) && (getDevuelto(tbTraidoPicosInsertar.Text, tbVentaPicosInsertar.Text) >= 0)
                        && (getDevuelto(tbTraidoAnticrisisInsertar.Text, tbVentaAnticrisisInsertar.Text) >= 0) && (getDevuelto(tbTraidoAVeranoInsertar.Text, tbVentaAVeranoInsertar.Text) >= 0) && (getDevuelto(tbTraidoPistolasInsertar.Text, tbVentaPistolasInsertar.Text) >= 0)
                        && (getDevuelto(tbTraidoIntegralInsertar.Text, tbVentaIntegralInsertar.Text) >= 0) && (getDevuelto(tbTraidoSinSalInsertar.Text, tbVentaSinSalInsertar.Text) >= 0) && (getDevuelto(tbTraidoMejorenaInsertar.Text, tbVentaMejorenaInsertar.Text) >= 0)
                        && (getDevuelto(tbTraidoMGrandeInsertar.Text, tbVentaMGrandeInsertar.Text) >= 0) && (getDevuelto(tbTraidoNaturalInsertar.Text, tbVentaNaturalInsertar.Text) >= 0) && (getDevuelto(tbTraidoBarritaInsertar.Text, tbVentaBarritaInsertar.Text) >= 0)) {

                        progressBar.Value = 5;
                        /*Devuelto = traido-ventas = venta*precioventa */
                        lDevueltoColonInsertar.Text = getDevuelto(tbTraidoColonInsertar.Text, tbVentaColonInsertar.Text).ToString();
                        lDevueltoCandealInsertar.Text = getDevuelto(tbTraidoCandealInsertar.Text, tbVentaCandealInsertar.Text).ToString();
                        lDevueltoPicosInsertar.Text = getDevuelto(tbTraidoPicosInsertar.Text, tbVentaPicosInsertar.Text).ToString();
                        lDevueltoAnticrisisInsertar.Text = getDevuelto(tbTraidoAnticrisisInsertar.Text, tbVentaAnticrisisInsertar.Text).ToString();
                        lDevueltoAVeranoInsertar.Text = getDevuelto(tbTraidoAVeranoInsertar.Text, tbVentaAVeranoInsertar.Text).ToString();
                        lDevueltoPistolasInsertar.Text = getDevuelto(tbTraidoPistolasInsertar.Text, tbVentaPistolasInsertar.Text).ToString();
                        lDevueltoIntegralInsertar.Text = getDevuelto(tbTraidoIntegralInsertar.Text, tbVentaIntegralInsertar.Text).ToString();
                        lDevueltoSinSalInsertar.Text = getDevuelto(tbTraidoSinSalInsertar.Text, tbVentaSinSalInsertar.Text).ToString();
                        lDevueltoMejorenaInsertar.Text = getDevuelto(tbTraidoMejorenaInsertar.Text, tbVentaMejorenaInsertar.Text).ToString();
                        lDevueltoMGrandeInsertar.Text = getDevuelto(tbTraidoMGrandeInsertar.Text, tbVentaMGrandeInsertar.Text).ToString();
                        lDevueltoNaturalInsertar.Text = getDevuelto(tbTraidoNaturalInsertar.Text, tbVentaNaturalInsertar.Text).ToString();
                        lDevueltoBarritaInsertar.Text = getDevuelto(tbTraidoBarritaInsertar.Text, tbVentaBarritaInsertar.Text).ToString();

                        progressBar.Value += 10;

                        /*Total a cobrar = venta*precioventa */
                        lTCIColon.Text = (double.Parse(tbVentaColonInsertar.Text) * double.Parse(lPVIColon.Text)).ToString();
                        lTCICandeal.Text = (double.Parse(tbVentaCandealInsertar.Text) * double.Parse(lPVICandeal.Text)).ToString();
                        lTCIPicos.Text = (double.Parse(tbVentaPicosInsertar.Text) * double.Parse(lPVIPicos.Text)).ToString();
                        lTCIAnticrisis.Text = (double.Parse(tbVentaAnticrisisInsertar.Text) * double.Parse(lPVIAnticrisis.Text)).ToString();
                        lTCIAVerano.Text = (double.Parse(tbVentaAVeranoInsertar.Text) * double.Parse(lPVIAVerano.Text)).ToString();
                        lTCIPistolas.Text = (double.Parse(tbVentaPistolasInsertar.Text) * double.Parse(lPVIPistolas.Text)).ToString();
                        lTCIIntegral.Text = (double.Parse(tbVentaIntegralInsertar.Text) * double.Parse(lPVIIntegral.Text)).ToString();
                        lTCISinSal.Text = (double.Parse(tbVentaSinSalInsertar.Text) * double.Parse(lPVISinSal.Text)).ToString();
                        lTCIMejorena.Text = (double.Parse(tbVentaMejorenaInsertar.Text) * double.Parse(lPVIMejorena.Text)).ToString();
                        lTCIMGrande.Text = (double.Parse(tbVentaMGrandeInsertar.Text) * double.Parse(lPVIMGrande.Text)).ToString();
                        lTCINatural.Text = (double.Parse(tbVentaNaturalInsertar.Text) * double.Parse(lPVINatural.Text)).ToString();
                        lTCIBarrita.Text = (double.Parse(tbVentaBarritaInsertar.Text) * double.Parse(lPVIBarrita.Text)).ToString();
                        

                        progressBar.Value += 10;

                        /*Total a pagar = venta*preciocompra */
                        lTPIColon.Text = (double.Parse(tbVentaColonInsertar.Text) * double.Parse(lPCIColon.Text)).ToString();
                        lTPICandeal.Text = (double.Parse(tbVentaCandealInsertar.Text) * double.Parse(lPCICandeal.Text)).ToString();
                        lTPIPicos.Text = (double.Parse(tbVentaPicosInsertar.Text) * double.Parse(lPCIPicos.Text)).ToString();
                        lTPIAnticrisis.Text = (double.Parse(tbVentaAnticrisisInsertar.Text) * double.Parse(lPCIAnticrisis.Text)).ToString();
                        lTPIAVerano.Text = (double.Parse(tbVentaAVeranoInsertar.Text) * double.Parse(lPCIAVerano.Text)).ToString();
                        lTPIPistolas.Text = (double.Parse(tbVentaPistolasInsertar.Text) * double.Parse(lPCIPistolas.Text)).ToString();
                        lTPIIntegral.Text = (double.Parse(tbVentaIntegralInsertar.Text) * double.Parse(lPCIIntegral.Text)).ToString();
                        lTPISinSal.Text = (double.Parse(tbVentaSinSalInsertar.Text) * double.Parse(lPCISinSal.Text)).ToString();
                        lTPIMejorena.Text = (double.Parse(tbVentaMejorenaInsertar.Text) * double.Parse(lPCIMejorena.Text)).ToString();
                        lTPIMGrande.Text = (double.Parse(tbVentaMGrandeInsertar.Text) * double.Parse(lPCIMGrande.Text)).ToString();
                        lTPINatural.Text = (double.Parse(tbVentaNaturalInsertar.Text) * double.Parse(lPCINatural.Text)).ToString();
                        lTPIBarrita.Text = (double.Parse(tbVentaBarritaInsertar.Text) * double.Parse(lPCIBarrita.Text)).ToString();

                        /*Total factura = sumaDeTodosTotalPagar*/
                        lTotalFacturaInsertar.Text = (

                            (double.Parse(lTPIColon.Text)+double.Parse(lTPICandeal.Text)+double.Parse(lTPIPicos.Text)+double.Parse(lTPIAnticrisis.Text)+double.Parse(lTPIAVerano.Text)+
                            double.Parse(lTPIPistolas.Text)+double.Parse(lTPIIntegral.Text)+double.Parse(lTPISinSal.Text)+double.Parse(lTPIMejorena.Text)+double.Parse(lTPIMGrande.Text)+double.Parse(lTPINatural.Text)+double.Parse(lTPIBarrita.Text))

                        ).ToString();

                        progressBar.Value += 10;

                        /*Total devolucion = sumaDeTodosDevuelto*/
                        lTotalDevolucionInsertar.Text = (int.Parse(lDevueltoColonInsertar.Text) + int.Parse(lDevueltoCandealInsertar.Text) + int.Parse(lDevueltoPicosInsertar.Text) + int.Parse(lDevueltoAnticrisisInsertar.Text) + int.Parse(lDevueltoAVeranoInsertar.Text)
                            + int.Parse(lDevueltoPistolasInsertar.Text) + int.Parse(lDevueltoIntegralInsertar.Text) + int.Parse(lDevueltoSinSalInsertar.Text) + int.Parse(lDevueltoMejorenaInsertar.Text) + int.Parse(lDevueltoMGrandeInsertar.Text)
                            + int.Parse(lDevueltoNaturalInsertar.Text) + int.Parse(lDevueltoBarritaInsertar.Text)).ToString();

                        /*Beneficios =sumaTotalCobrar - sumaTotalPagar*/
                        lBeneficiosInsertar.Text = (

                            (double.Parse(lTCIColon.Text) + double.Parse(lTCICandeal.Text) + double.Parse(lTCIPicos.Text) + double.Parse(lTCIAnticrisis.Text) + double.Parse(lTCIAVerano.Text) +
                            double.Parse(lTCIPistolas.Text) + double.Parse(lTCIIntegral.Text) + double.Parse(lTCISinSal.Text) + double.Parse(lTCIMejorena.Text) + double.Parse(lTCIMGrande.Text) + double.Parse(lTCINatural.Text) + double.Parse(lTCIBarrita.Text)
                            ) - double.Parse(lTotalFacturaInsertar.Text)

                        ).ToString();


                        progressBar.Value += 15;

                        // Deshabilita los traidos
                        tbTraidoColonInsertar.Enabled = false;
                        tbTraidoCandealInsertar.Enabled = false;
                        tbTraidoPicosInsertar.Enabled = false;
                        tbTraidoAnticrisisInsertar.Enabled = false;
                        tbTraidoAVeranoInsertar.Enabled = false;
                        tbTraidoPistolasInsertar.Enabled = false;
                        tbTraidoIntegralInsertar.Enabled = false;
                        tbTraidoSinSalInsertar.Enabled = false;
                        tbTraidoMejorenaInsertar.Enabled = false;
                        tbTraidoMGrandeInsertar.Enabled = false;
                        tbTraidoNaturalInsertar.Enabled = false;
                        tbTraidoBarritaInsertar.Enabled = false;


                        //Deshabilita las ventas
                        tbVentaColonInsertar.Enabled = false;
                        tbVentaCandealInsertar.Enabled = false;
                        tbVentaPicosInsertar.Enabled = false;
                        tbVentaAnticrisisInsertar.Enabled = false;
                        tbVentaAVeranoInsertar.Enabled = false;
                        tbVentaPistolasInsertar.Enabled = false;
                        tbVentaIntegralInsertar.Enabled = false;
                        tbVentaSinSalInsertar.Enabled = false;
                        tbVentaMejorenaInsertar.Enabled = false;
                        tbVentaMGrandeInsertar.Enabled = false;
                        tbVentaNaturalInsertar.Enabled = false;
                        tbVentaBarritaInsertar.Enabled = false;

                        tbNombreHoja.Enabled = false;

                        if (abierto) {
                            openedExcel = new FileInfo(filePath);
                            //openedExcel.OpenWrite();
                            excel = new ExcelPackage(openedExcel);

                        } else {
                            excel = new ExcelPackage();
                        }

                        progressBar.Value += 15;

                        //Nombre a la nueva hoja
                        excel.Workbook.Worksheets.Add(tbNombreHoja.Text);
                        var excelWorksheet = excel.Workbook.Worksheets[tbNombreHoja.Text];


                        headerRow = new List<string[]>(){new string[] { "", "Traido", "Venta", "Devuelto", "Precio Compra", "Total a Pagar", "Precio Venta", "Total a Cobrar" } };
                        headerRange = "A1:H1";
                        excelWorksheet.Cells[headerRange].Style.ShrinkToFit = true;
                        excelWorksheet.Cells[headerRange].Style.WrapText = true;
                        excelWorksheet.Cells[headerRange].Style.Font.Bold = true;
                        excelWorksheet.Cells[headerRange].Style.Font.UnderLine = true;
                        excelWorksheet.Cells[headerRange].Style.Font.Size = 11;
                        excelWorksheet.Cells[headerRange].AutoFitColumns();

                        excelWorksheet.Cells["A2:A13"].Style.Font.Bold = true;
                        excelWorksheet.Cells["A2:A13"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        excelWorksheet.Cells["A2:A13"].AutoFitColumns();
                        
                        /*Se carga las cabeceras*/
                        excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);
                        
                        /*Un array por cada fila*/
                        var cellData = new List<object[]>()
                        {
                            new object[] {"Colon", tbTraidoColonInsertar.Text, tbVentaColonInsertar.Text, lDevueltoColonInsertar.Text,lPCIColon.Text, lTPIColon.Text, lPVIColon.Text, lTCIColon.Text},
                            new object[] {"Candeal",tbTraidoCandealInsertar.Text, tbVentaCandealInsertar.Text, lDevueltoCandealInsertar.Text,lPCICandeal.Text, lTPICandeal.Text, lPVICandeal.Text, lTCICandeal.Text},
                            new object[] {"Picos",tbTraidoPicosInsertar.Text, tbVentaPicosInsertar.Text, lDevueltoPicosInsertar.Text,lPCIPicos.Text, lTPIPicos.Text, lPVIPicos.Text, lTCIPicos.Text},
                            new object[] {"Anticrisis",tbTraidoAnticrisisInsertar.Text, tbVentaAnticrisisInsertar.Text, lDevueltoAnticrisisInsertar.Text,lPCIAnticrisis.Text, lTPIAnticrisis.Text, lPVIAnticrisis.Text, lTCIAnticrisis.Text},
                            new object[] {"A.Verano",tbTraidoAVeranoInsertar.Text, tbVentaAVeranoInsertar.Text, lDevueltoAVeranoInsertar.Text,lPCIAVerano.Text, lTPIAVerano.Text, lPVIAVerano.Text, lTCIAVerano.Text},
                            new object[] {"Pistolas",tbTraidoPistolasInsertar.Text, tbVentaPistolasInsertar.Text, lDevueltoPistolasInsertar.Text,lPCIPistolas.Text, lTPIPistolas.Text, lPVIPistolas.Text, lTCIPistolas.Text},
                            new object[] {"Integral",tbTraidoIntegralInsertar.Text, tbVentaIntegralInsertar.Text, lDevueltoIntegralInsertar.Text,lPCIIntegral.Text, lTPIIntegral.Text, lPVIIntegral.Text, lTCIIntegral.Text},
                            new object[] {"Sin Sal",tbTraidoSinSalInsertar.Text, tbVentaSinSalInsertar.Text, lDevueltoSinSalInsertar.Text,lPCISinSal.Text, lTPISinSal.Text, lPVISinSal.Text, lTCISinSal.Text},
                            new object[] {"Mejoreña",tbTraidoMejorenaInsertar.Text, tbVentaMejorenaInsertar.Text, lDevueltoMejorenaInsertar.Text,lPCIMejorena.Text, lTPIMejorena.Text, lPVIMejorena.Text, lTCIMejorena.Text},
                            new object[] {"M.Grande",tbTraidoMGrandeInsertar.Text, tbVentaMGrandeInsertar.Text, lDevueltoMGrandeInsertar.Text,lPCIMGrande.Text, lTPIMGrande.Text, lPVIMGrande.Text, lTCIMGrande.Text},
                            new object[] {"Natural",tbTraidoNaturalInsertar.Text, tbVentaNaturalInsertar.Text, lDevueltoNaturalInsertar.Text,lPCINatural.Text, lTPINatural.Text, lPVINatural.Text, lTCINatural.Text},
                            new object[] {"Barrita",tbTraidoBarritaInsertar.Text, tbVentaBarritaInsertar.Text, lDevueltoBarritaInsertar.Text,lPCIBarrita.Text, lTPIBarrita.Text, lPVIBarrita.Text, lTCIBarrita.Text},
                            new object[] {},
                            new object[] {"", "" , "" , lTotalDevolucionInsertar.Text , "" , lTotalFacturaInsertar.Text , "" , lBeneficiosInsertar.Text}
                        };
                        /*Se rellena las celdas con los datos*/
                        excelWorksheet.Cells[2, 1].LoadFromArrays(cellData);

                        string[] rangos = { "A2:H2", "A3:H3", "A4:H4", "A5:H5", "A6:H6", "A7:H7", "A8:H8", "A9:H9", "A10:H10", "A11:H11", "A12:H12", "A13:H13" };
                        var cont = 0;
                        //Aplicar estilos a cada fila
                        foreach (var item in rangos) {
                            excelWorksheet.Cells[item].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            excelWorksheet.Cells[item].AutoFitColumns();
                            if (cont % 2 == 0) {
                                excelWorksheet.Cells[item].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                            } else {
                                excelWorksheet.Cells[item].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                            }

                            excelWorksheet.Cells[item].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            cont++;
                        }

                        cont = 0;

                        excelWorksheet.Cells["H15"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells["H15"].Style.Fill.BackgroundColor.SetColor(Color.LightSalmon);

                        progressBar.Value += 10;

                        if (abierto) {
                            excel.Save();
                            progressBar.Value += 25;
                            MessageBox.Show("Terminado", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else {

                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Filter = "Excel(*.xlsx)|*.xlsx";

                            if (sfd.ShowDialog() == DialogResult.OK) {
                                
                                FileInfo excelFile = new FileInfo(Path.GetFullPath(sfd.FileName));
                                excel.SaveAs(excelFile);
                                progressBar.Value += 25;
                                MessageBox.Show("Terminado", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bGuardarInsertar.Enabled = false;
                                bAbrirExcelInsertar.Enabled = false;
                            } else {
                                progressBar.Value = 0;
                            }

                            
                        }
                        

                    } else {
                        MessageBox.Show("Valores Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                } catch (FormatException) {
                    MessageBox.Show("Campos vacios o incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    progressBar.Value = 0;
                }

            } else {
                MessageBox.Show("Nombre de la hoja vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fExitApp(object sender, FormClosingEventArgs e) {
            Utils.exitApp(e);
        }
    }
}
