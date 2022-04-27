using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for FormReport1070
/// </summary>
public class FormReport1070 : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRCheckBox Parapono;
    private XRCheckBox EktaktoDeigma;
    private XRCheckBox MetrisiCLMeLovipond;
    private XRCheckBox MetrisiCLMeSwan;
    private XRCheckBox MetrisiCLMeFotometroLovipond;
    private XRCheckBox MetrisiApolimantikonMeSwan;
    private XRCheckBox MetrisiApolimantikonMePalintest;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private XRLabel xrLabel1;
    private GroupHeaderBand groupHeaderBand1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private GroupFooterBand groupFooterBand1;
    private XRLabel xrLabel2;
    private XRControlStyle Title;
    private XRControlStyle GroupCaption3;
    private XRControlStyle GroupData3;
    private XRControlStyle DetailCaption3;
    private XRControlStyle DetailData3;
    private XRControlStyle DetailData3_Odd;
    private XRControlStyle DetailCaptionBackground3;
    private XRControlStyle PageInfo;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private PageHeaderBand PageHeader;
    private XRLabel DateOfAssignment;
    private XRLabel Status;
    private XRLabel Task_Description;
    private XRLabel Energeies;
    private XRLabel Remarks;
    private XRPanel xrPanel2;
    private XRLabel HmerominiaDeigmatolipsias;
    private XRLabel OraDeigmatolipsias;
    private XRLabel CLPedio;
    private XRLabel CLMetatropi;
    private XRLabel MetrisiYpolCLPedioA;
    private XRLabel CL_A_B;
    private XRLabel Deigmatoliptis;
    private XRLabel EpipleonDeigma1;
    private XRLabel EpipleonCL1;
    private XRLabel EpipleonDeigma2;
    private XRLabel EpipleonCL2;
    private XRLabel EpipleonDeigma3;
    private XRLabel EpipleonCL3;
    private XRLabel EpipleonDeigma4;
    private XRLabel EpipleonCL4;
    private XRLabel AddressMunicipality;
    private XRLabel AddressOdos;
    private XRLabel AddressArithmos;
    private XRLabel DiktyoParoxi;
    private XRLabel ProblemCategory;
    private XRLabel Diagnosi;
    private XRLabel Symperasma;
    private XRLabel EidosProblematos;
    private DevExpress.XtraReports.Parameters.Parameter AssignmentId;
    private XRPanel xrPanel1;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel9;
    private XRLabel xrLabel7;
    private XRPanel xrPanel3;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRPanel xrPanel4;
    private XRLabel xrLabel25;
    private XRLabel xrLabel24;
    private XRLabel xrLabel28;
    private XRLabel xrLabel27;
    private XRLabel xrLabel30;
    private XRLabel xrLabel29;
    private XRPanel xrPanel5;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;
    private XRPanel xrPanel6;
    private XRLabel xrLabel34;
    private XRLabel xrLabel33;
    private XRLabel xrLabel37;
    private XRLabel xrLabel39;
    private XRLabel xrLabel38;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel40;
    private XRLabel xrLabel41;
    private XRPanel xrPanel7;
    private XRLabel xrLabel43;
    private XRLabel xrLabel42;
    private XRPanel xrPanel8;
    private XRLabel xrLabel47;
    private XRLabel xrLabel46;
    private XRLabel xrLabel45;
    private XRLabel xrLabel44;
    private XRPanel xrPanel9;
    private XRLabel ArithmosMetriti;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public FormReport1070()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport1070));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrPanel9 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.Symperasma = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.Diagnosi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.Remarks = new DevExpress.XtraReports.UI.XRLabel();
            this.Energeies = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel8 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.DiktyoParoxi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel7 = new DevExpress.XtraReports.UI.XRPanel();
            this.EidosProblematos = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.ProblemCategory = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel6 = new DevExpress.XtraReports.UI.XRPanel();
            this.EpipleonDeigma4 = new DevExpress.XtraReports.UI.XRLabel();
            this.EpipleonDeigma3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.EpipleonDeigma2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.EpipleonDeigma1 = new DevExpress.XtraReports.UI.XRLabel();
            this.EpipleonCL4 = new DevExpress.XtraReports.UI.XRLabel();
            this.EpipleonCL3 = new DevExpress.XtraReports.UI.XRLabel();
            this.EpipleonCL2 = new DevExpress.XtraReports.UI.XRLabel();
            this.EpipleonCL1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel5 = new DevExpress.XtraReports.UI.XRPanel();
            this.ArithmosMetriti = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.Deigmatoliptis = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel4 = new DevExpress.XtraReports.UI.XRPanel();
            this.CL_A_B = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.MetrisiYpolCLPedioA = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.CLMetatropi = new DevExpress.XtraReports.UI.XRLabel();
            this.CLPedio = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.OraDeigmatolipsias = new DevExpress.XtraReports.UI.XRLabel();
            this.HmerominiaDeigmatolipsias = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel3 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.MetrisiCLMeLovipond = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.MetrisiCLMeSwan = new DevExpress.XtraReports.UI.XRCheckBox();
            this.Parapono = new DevExpress.XtraReports.UI.XRCheckBox();
            this.MetrisiApolimantikonMePalintest = new DevExpress.XtraReports.UI.XRCheckBox();
            this.MetrisiCLMeFotometroLovipond = new DevExpress.XtraReports.UI.XRCheckBox();
            this.MetrisiApolimantikonMeSwan = new DevExpress.XtraReports.UI.XRCheckBox();
            this.EktaktoDeigma = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Status = new DevExpress.XtraReports.UI.XRLabel();
            this.Task_Description = new DevExpress.XtraReports.UI.XRLabel();
            this.AddressArithmos = new DevExpress.XtraReports.UI.XRLabel();
            this.AddressOdos = new DevExpress.XtraReports.UI.XRLabel();
            this.AddressMunicipality = new DevExpress.XtraReports.UI.XRLabel();
            this.DateOfAssignment = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupCaption3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupData3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaptionBackground3 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.AssignmentId = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrPanel2});
            this.Detail.HeightF = 781.6663F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(11.18975F, 764.1664F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(676.8102F, 2.083374F);
            this.xrLabel2.StyleName = "GroupCaption3";
            this.xrLabel2.StylePriority.UseBorders = false;
            // 
            // xrPanel2
            // 
            this.xrPanel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPanel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel9,
            this.xrPanel8,
            this.xrPanel7,
            this.xrPanel6,
            this.xrPanel5,
            this.xrPanel4,
            this.xrPanel3,
            this.xrPanel1});
            this.xrPanel2.KeepTogether = false;
            this.xrPanel2.LocationFloat = new DevExpress.Utils.PointFloat(10.00004F, 10.00001F);
            this.xrPanel2.Name = "xrPanel2";
            this.xrPanel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.xrPanel2.SizeF = new System.Drawing.SizeF(678F, 730.4163F);
            this.xrPanel2.StylePriority.UseBorders = false;
            this.xrPanel2.StylePriority.UseFont = false;
            this.xrPanel2.StylePriority.UseForeColor = false;
            this.xrPanel2.StylePriority.UsePadding = false;
            this.xrPanel2.StylePriority.UseTextAlignment = false;
            // 
            // xrPanel9
            // 
            this.xrPanel9.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel47,
            this.Symperasma,
            this.xrLabel44,
            this.xrLabel46,
            this.Diagnosi,
            this.xrLabel45,
            this.Remarks,
            this.Energeies});
            this.xrPanel9.LocationFloat = new DevExpress.Utils.PointFloat(15.83811F, 609.8427F);
            this.xrPanel9.Name = "xrPanel9";
            this.xrPanel9.SizeF = new System.Drawing.SizeF(651.8738F, 110.5737F);
            // 
            // xrLabel47
            // 
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(6.875738F, 64.99977F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(81.97372F, 19.87508F);
            this.xrLabel47.Text = "Συμπέρασμα";
            // 
            // Symperasma
            // 
            this.Symperasma.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Symperasma.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Symperasma]")});
            this.Symperasma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Symperasma.ForeColor = System.Drawing.Color.Black;
            this.Symperasma.LocationFloat = new DevExpress.Utils.PointFloat(107.3083F, 64.99977F);
            this.Symperasma.Name = "Symperasma";
            this.Symperasma.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Symperasma.SizeF = new System.Drawing.SizeF(531.4417F, 19.87489F);
            this.Symperasma.StylePriority.UseBorders = false;
            this.Symperasma.StylePriority.UseFont = false;
            this.Symperasma.StylePriority.UseForeColor = false;
            this.Symperasma.StylePriority.UsePadding = false;
            this.Symperasma.StylePriority.UseTextAlignment = false;
            this.Symperasma.Text = "xrTableCell370";
            this.Symperasma.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel44
            // 
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(6.875738F, 3.509204F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(92.26144F, 19.875F);
            this.xrLabel44.Text = "Παρατηρήσεις";
            // 
            // xrLabel46
            // 
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(6.875738F, 43.25917F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(92.26144F, 19.875F);
            this.xrLabel46.Text = "Ενέργειες";
            // 
            // Diagnosi
            // 
            this.Diagnosi.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Diagnosi.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Diagnosi]")});
            this.Diagnosi.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Diagnosi.ForeColor = System.Drawing.Color.Black;
            this.Diagnosi.LocationFloat = new DevExpress.Utils.PointFloat(107.3083F, 23.38428F);
            this.Diagnosi.Name = "Diagnosi";
            this.Diagnosi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Diagnosi.SizeF = new System.Drawing.SizeF(531.4418F, 19.87489F);
            this.Diagnosi.StylePriority.UseBorders = false;
            this.Diagnosi.StylePriority.UseFont = false;
            this.Diagnosi.StylePriority.UseForeColor = false;
            this.Diagnosi.StylePriority.UsePadding = false;
            this.Diagnosi.StylePriority.UseTextAlignment = false;
            this.Diagnosi.Text = "xrTableCell369";
            this.Diagnosi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel45
            // 
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(6.875738F, 23.38428F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(92.26144F, 19.875F);
            this.xrLabel45.Text = "Διάγνωση";
            // 
            // Remarks
            // 
            this.Remarks.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Remarks.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Remarks]")});
            this.Remarks.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Remarks.ForeColor = System.Drawing.Color.Black;
            this.Remarks.LocationFloat = new DevExpress.Utils.PointFloat(107.3083F, 3.509204F);
            this.Remarks.Name = "Remarks";
            this.Remarks.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Remarks.SizeF = new System.Drawing.SizeF(531.4417F, 19.87502F);
            this.Remarks.StylePriority.UseBorders = false;
            this.Remarks.StylePriority.UseFont = false;
            this.Remarks.StylePriority.UseForeColor = false;
            this.Remarks.StylePriority.UsePadding = false;
            this.Remarks.StylePriority.UseTextAlignment = false;
            this.Remarks.Text = "xrTableCell207";
            this.Remarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Energeies
            // 
            this.Energeies.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Energeies.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Energeies]")});
            this.Energeies.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Energeies.ForeColor = System.Drawing.Color.Black;
            this.Energeies.LocationFloat = new DevExpress.Utils.PointFloat(107.3083F, 45.12501F);
            this.Energeies.Name = "Energeies";
            this.Energeies.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Energeies.SizeF = new System.Drawing.SizeF(531.4418F, 19.87489F);
            this.Energeies.StylePriority.UseBorders = false;
            this.Energeies.StylePriority.UseFont = false;
            this.Energeies.StylePriority.UseForeColor = false;
            this.Energeies.StylePriority.UsePadding = false;
            this.Energeies.StylePriority.UseTextAlignment = false;
            this.Energeies.Text = "xrTableCell204";
            this.Energeies.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPanel8
            // 
            this.xrPanel8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel37,
            this.DiktyoParoxi});
            this.xrPanel8.LocationFloat = new DevExpress.Utils.PointFloat(15.83812F, 536.5358F);
            this.xrPanel8.Name = "xrPanel8";
            this.xrPanel8.SizeF = new System.Drawing.SizeF(651.8738F, 37.89014F);
            // 
            // xrLabel37
            // 
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(11.5799F, 10.00004F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(168.3031F, 19.87494F);
            this.xrLabel37.Text = "Τύπος";
            // 
            // DiktyoParoxi
            // 
            this.DiktyoParoxi.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DiktyoParoxi.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DiktyoParoxi]")});
            this.DiktyoParoxi.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DiktyoParoxi.ForeColor = System.Drawing.Color.Black;
            this.DiktyoParoxi.LocationFloat = new DevExpress.Utils.PointFloat(183.3346F, 10.00004F);
            this.DiktyoParoxi.Name = "DiktyoParoxi";
            this.DiktyoParoxi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DiktyoParoxi.SizeF = new System.Drawing.SizeF(153.8561F, 19.87489F);
            this.DiktyoParoxi.StylePriority.UseBorders = false;
            this.DiktyoParoxi.StylePriority.UseFont = false;
            this.DiktyoParoxi.StylePriority.UseForeColor = false;
            this.DiktyoParoxi.StylePriority.UsePadding = false;
            this.DiktyoParoxi.StylePriority.UseTextAlignment = false;
            this.DiktyoParoxi.Text = "xrTableCell366";
            this.DiktyoParoxi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPanel7
            // 
            this.xrPanel7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.EidosProblematos,
            this.xrLabel43,
            this.ProblemCategory,
            this.xrLabel42});
            this.xrPanel7.LocationFloat = new DevExpress.Utils.PointFloat(15.83812F, 574.4259F);
            this.xrPanel7.Name = "xrPanel7";
            this.xrPanel7.SizeF = new System.Drawing.SizeF(651.8738F, 35.41675F);
            // 
            // EidosProblematos
            // 
            this.EidosProblematos.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.EidosProblematos.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EidosProblematos]")});
            this.EidosProblematos.Font = new System.Drawing.Font("Tahoma", 8F);
            this.EidosProblematos.ForeColor = System.Drawing.Color.Black;
            this.EidosProblematos.LocationFloat = new DevExpress.Utils.PointFloat(527.6047F, 10.0001F);
            this.EidosProblematos.Name = "EidosProblematos";
            this.EidosProblematos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EidosProblematos.SizeF = new System.Drawing.SizeF(107.7468F, 19.87495F);
            this.EidosProblematos.StylePriority.UseBorders = false;
            this.EidosProblematos.StylePriority.UseFont = false;
            this.EidosProblematos.StylePriority.UseForeColor = false;
            this.EidosProblematos.StylePriority.UsePadding = false;
            this.EidosProblematos.StylePriority.UseTextAlignment = false;
            this.EidosProblematos.Text = "xrTableCell368";
            this.EidosProblematos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel43
            // 
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(355.1877F, 9.999974F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(168.3031F, 19.87499F);
            this.xrLabel43.Text = "Είδος Προβλήματος";
            // 
            // ProblemCategory
            // 
            this.ProblemCategory.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ProblemCategory.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProblemCategory]")});
            this.ProblemCategory.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ProblemCategory.ForeColor = System.Drawing.Color.Black;
            this.ProblemCategory.LocationFloat = new DevExpress.Utils.PointFloat(183.3347F, 10.00004F);
            this.ProblemCategory.Name = "ProblemCategory";
            this.ProblemCategory.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ProblemCategory.SizeF = new System.Drawing.SizeF(153.856F, 19.87502F);
            this.ProblemCategory.StylePriority.UseBorders = false;
            this.ProblemCategory.StylePriority.UseFont = false;
            this.ProblemCategory.StylePriority.UseForeColor = false;
            this.ProblemCategory.StylePriority.UsePadding = false;
            this.ProblemCategory.StylePriority.UseTextAlignment = false;
            this.ProblemCategory.Text = "xrTableCell367";
            this.ProblemCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel42
            // 
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(11.58002F, 10.00004F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(168.3031F, 19.87499F);
            this.xrLabel42.Text = "Κατηγορία Προβλήματος";
            // 
            // xrPanel6
            // 
            this.xrPanel6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.EpipleonDeigma4,
            this.EpipleonDeigma3,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel40,
            this.xrLabel41,
            this.EpipleonDeigma2,
            this.xrLabel39,
            this.xrLabel38,
            this.EpipleonDeigma1,
            this.EpipleonCL4,
            this.EpipleonCL3,
            this.EpipleonCL2,
            this.EpipleonCL1,
            this.xrLabel34,
            this.xrLabel33});
            this.xrPanel6.LocationFloat = new DevExpress.Utils.PointFloat(15.83812F, 431.3274F);
            this.xrPanel6.Name = "xrPanel6";
            this.xrPanel6.SizeF = new System.Drawing.SizeF(651.8738F, 105.2084F);
            // 
            // EpipleonDeigma4
            // 
            this.EpipleonDeigma4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.EpipleonDeigma4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonDeigma4]")});
            this.EpipleonDeigma4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.EpipleonDeigma4.ForeColor = System.Drawing.Color.Black;
            this.EpipleonDeigma4.LocationFloat = new DevExpress.Utils.PointFloat(527.6047F, 50.45827F);
            this.EpipleonDeigma4.Name = "EpipleonDeigma4";
            this.EpipleonDeigma4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EpipleonDeigma4.SizeF = new System.Drawing.SizeF(105.707F, 19.16653F);
            this.EpipleonDeigma4.StylePriority.UseBorders = false;
            this.EpipleonDeigma4.StylePriority.UseFont = false;
            this.EpipleonDeigma4.StylePriority.UseForeColor = false;
            this.EpipleonDeigma4.StylePriority.UsePadding = false;
            this.EpipleonDeigma4.StylePriority.UseTextAlignment = false;
            this.EpipleonDeigma4.Text = "xrTableCell324";
            this.EpipleonDeigma4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // EpipleonDeigma3
            // 
            this.EpipleonDeigma3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.EpipleonDeigma3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonDeigma3]")});
            this.EpipleonDeigma3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.EpipleonDeigma3.ForeColor = System.Drawing.Color.Black;
            this.EpipleonDeigma3.LocationFloat = new DevExpress.Utils.PointFloat(527.6047F, 9.999974F);
            this.EpipleonDeigma3.Name = "EpipleonDeigma3";
            this.EpipleonDeigma3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EpipleonDeigma3.SizeF = new System.Drawing.SizeF(105.707F, 19.87502F);
            this.EpipleonDeigma3.StylePriority.UseBorders = false;
            this.EpipleonDeigma3.StylePriority.UseFont = false;
            this.EpipleonDeigma3.StylePriority.UseForeColor = false;
            this.EpipleonDeigma3.StylePriority.UsePadding = false;
            this.EpipleonDeigma3.StylePriority.UseTextAlignment = false;
            this.EpipleonDeigma3.Text = "xrTableCell322";
            this.EpipleonDeigma3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel35
            // 
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(355.1877F, 69.62477F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(168.3031F, 19.87499F);
            this.xrLabel35.Text = "Χλώριο #4";
            // 
            // xrLabel36
            // 
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(355.1877F, 29.87493F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(168.3031F, 19.87498F);
            this.xrLabel36.Text = "Χλώριο #3";
            // 
            // xrLabel40
            // 
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(355.1877F, 49.74988F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(168.3032F, 19.87498F);
            this.xrLabel40.Text = "Επιπλέον Δείγμα #4";
            // 
            // xrLabel41
            // 
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(355.1877F, 9.291585F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(168.3031F, 19.87498F);
            this.xrLabel41.Text = "Επιπλέον Δείγμα #3";
            // 
            // EpipleonDeigma2
            // 
            this.EpipleonDeigma2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.EpipleonDeigma2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonDeigma2]")});
            this.EpipleonDeigma2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.EpipleonDeigma2.ForeColor = System.Drawing.Color.Black;
            this.EpipleonDeigma2.LocationFloat = new DevExpress.Utils.PointFloat(183.3346F, 50.45824F);
            this.EpipleonDeigma2.Name = "EpipleonDeigma2";
            this.EpipleonDeigma2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EpipleonDeigma2.SizeF = new System.Drawing.SizeF(104.5704F, 19.87499F);
            this.EpipleonDeigma2.StylePriority.UseBorders = false;
            this.EpipleonDeigma2.StylePriority.UseFont = false;
            this.EpipleonDeigma2.StylePriority.UseForeColor = false;
            this.EpipleonDeigma2.StylePriority.UsePadding = false;
            this.EpipleonDeigma2.StylePriority.UseTextAlignment = false;
            this.EpipleonDeigma2.Text = "xrTableCell320";
            this.EpipleonDeigma2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel39
            // 
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(11.58021F, 50.45824F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(168.3031F, 19.87499F);
            this.xrLabel39.Text = "Επιπλέον Δείγμα #2";
            // 
            // xrLabel38
            // 
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(11.58078F, 30.58329F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(168.3031F, 19.87499F);
            this.xrLabel38.Text = "Χλώριο #1";
            // 
            // EpipleonDeigma1
            // 
            this.EpipleonDeigma1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.EpipleonDeigma1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonDeigma1]")});
            this.EpipleonDeigma1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.EpipleonDeigma1.ForeColor = System.Drawing.Color.Black;
            this.EpipleonDeigma1.LocationFloat = new DevExpress.Utils.PointFloat(183.3346F, 9.999943F);
            this.EpipleonDeigma1.Name = "EpipleonDeigma1";
            this.EpipleonDeigma1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EpipleonDeigma1.SizeF = new System.Drawing.SizeF(104.5704F, 19.87499F);
            this.EpipleonDeigma1.StylePriority.UseBorders = false;
            this.EpipleonDeigma1.StylePriority.UseFont = false;
            this.EpipleonDeigma1.StylePriority.UseForeColor = false;
            this.EpipleonDeigma1.StylePriority.UsePadding = false;
            this.EpipleonDeigma1.StylePriority.UseTextAlignment = false;
            this.EpipleonDeigma1.Text = "xrTableCell318";
            this.EpipleonDeigma1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // EpipleonCL4
            // 
            this.EpipleonCL4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.EpipleonCL4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonCL4]")});
            this.EpipleonCL4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.EpipleonCL4.ForeColor = System.Drawing.Color.Black;
            this.EpipleonCL4.LocationFloat = new DevExpress.Utils.PointFloat(527.6047F, 69.62477F);
            this.EpipleonCL4.Name = "EpipleonCL4";
            this.EpipleonCL4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EpipleonCL4.SizeF = new System.Drawing.SizeF(105.707F, 20.58347F);
            this.EpipleonCL4.StylePriority.UseBorders = false;
            this.EpipleonCL4.StylePriority.UseFont = false;
            this.EpipleonCL4.StylePriority.UseForeColor = false;
            this.EpipleonCL4.StylePriority.UsePadding = false;
            this.EpipleonCL4.StylePriority.UseTextAlignment = false;
            this.EpipleonCL4.Text = "xrTableCell325";
            this.EpipleonCL4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // EpipleonCL3
            // 
            this.EpipleonCL3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.EpipleonCL3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonCL3]")});
            this.EpipleonCL3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.EpipleonCL3.ForeColor = System.Drawing.Color.Black;
            this.EpipleonCL3.LocationFloat = new DevExpress.Utils.PointFloat(527.6047F, 29.87499F);
            this.EpipleonCL3.Name = "EpipleonCL3";
            this.EpipleonCL3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EpipleonCL3.SizeF = new System.Drawing.SizeF(105.707F, 19.87492F);
            this.EpipleonCL3.StylePriority.UseBorders = false;
            this.EpipleonCL3.StylePriority.UseFont = false;
            this.EpipleonCL3.StylePriority.UseForeColor = false;
            this.EpipleonCL3.StylePriority.UsePadding = false;
            this.EpipleonCL3.StylePriority.UseTextAlignment = false;
            this.EpipleonCL3.Text = "xrTableCell323";
            this.EpipleonCL3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // EpipleonCL2
            // 
            this.EpipleonCL2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.EpipleonCL2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonCL2]")});
            this.EpipleonCL2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.EpipleonCL2.ForeColor = System.Drawing.Color.Black;
            this.EpipleonCL2.LocationFloat = new DevExpress.Utils.PointFloat(183.3346F, 70.33323F);
            this.EpipleonCL2.Name = "EpipleonCL2";
            this.EpipleonCL2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EpipleonCL2.SizeF = new System.Drawing.SizeF(104.5704F, 19.87495F);
            this.EpipleonCL2.StylePriority.UseBorders = false;
            this.EpipleonCL2.StylePriority.UseFont = false;
            this.EpipleonCL2.StylePriority.UseForeColor = false;
            this.EpipleonCL2.StylePriority.UsePadding = false;
            this.EpipleonCL2.StylePriority.UseTextAlignment = false;
            this.EpipleonCL2.Text = "xrTableCell321";
            this.EpipleonCL2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // EpipleonCL1
            // 
            this.EpipleonCL1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.EpipleonCL1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EpipleonCL1]")});
            this.EpipleonCL1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.EpipleonCL1.ForeColor = System.Drawing.Color.Black;
            this.EpipleonCL1.LocationFloat = new DevExpress.Utils.PointFloat(183.3346F, 29.87496F);
            this.EpipleonCL1.Name = "EpipleonCL1";
            this.EpipleonCL1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EpipleonCL1.SizeF = new System.Drawing.SizeF(104.5704F, 19.87499F);
            this.EpipleonCL1.StylePriority.UseBorders = false;
            this.EpipleonCL1.StylePriority.UseFont = false;
            this.EpipleonCL1.StylePriority.UseForeColor = false;
            this.EpipleonCL1.StylePriority.UsePadding = false;
            this.EpipleonCL1.StylePriority.UseTextAlignment = false;
            this.EpipleonCL1.Text = "xrTableCell319";
            this.EpipleonCL1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel34
            // 
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(11.58002F, 70.33323F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(168.3031F, 19.87499F);
            this.xrLabel34.Text = "Χλώριο #2";
            // 
            // xrLabel33
            // 
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(11.58075F, 9.999974F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(168.3031F, 19.87499F);
            this.xrLabel33.Text = "Επιπλέον Δείγμα #1";
            // 
            // xrPanel5
            // 
            this.xrPanel5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ArithmosMetriti,
            this.xrLabel32,
            this.xrLabel31,
            this.Deigmatoliptis});
            this.xrPanel5.LocationFloat = new DevExpress.Utils.PointFloat(15.83812F, 392.7858F);
            this.xrPanel5.Name = "xrPanel5";
            this.xrPanel5.SizeF = new System.Drawing.SizeF(651.8738F, 38.54163F);
            // 
            // ArithmosMetriti
            // 
            this.ArithmosMetriti.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ArithmosMetriti]")});
            this.ArithmosMetriti.LocationFloat = new DevExpress.Utils.PointFloat(527.6048F, 8.666675F);
            this.ArithmosMetriti.Name = "ArithmosMetriti";
            this.ArithmosMetriti.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ArithmosMetriti.SizeF = new System.Drawing.SizeF(105.707F, 19.87498F);
            this.ArithmosMetriti.Text = "ArithmosMetriti";
            // 
            // xrLabel32
            // 
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(355.1877F, 8.666642F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(168.3032F, 19.87499F);
            this.xrLabel32.Text = "Αριθμός Μετρητή";
            // 
            // xrLabel31
            // 
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(11.58072F, 8.666642F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(168.3032F, 19.87499F);
            this.xrLabel31.Text = "Δειγματολήπτης";
            // 
            // Deigmatoliptis
            // 
            this.Deigmatoliptis.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Deigmatoliptis.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Deigmatoliptis]")});
            this.Deigmatoliptis.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Deigmatoliptis.ForeColor = System.Drawing.Color.Black;
            this.Deigmatoliptis.LocationFloat = new DevExpress.Utils.PointFloat(183.3346F, 8.666642F);
            this.Deigmatoliptis.Name = "Deigmatoliptis";
            this.Deigmatoliptis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Deigmatoliptis.SizeF = new System.Drawing.SizeF(110.9298F, 19.87499F);
            this.Deigmatoliptis.StylePriority.UseBorders = false;
            this.Deigmatoliptis.StylePriority.UseFont = false;
            this.Deigmatoliptis.StylePriority.UseForeColor = false;
            this.Deigmatoliptis.StylePriority.UsePadding = false;
            this.Deigmatoliptis.StylePriority.UseTextAlignment = false;
            this.Deigmatoliptis.Text = "xrTableCell316";
            this.Deigmatoliptis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPanel4
            // 
            this.xrPanel4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CL_A_B,
            this.xrLabel30,
            this.MetrisiYpolCLPedioA,
            this.xrLabel29,
            this.xrLabel28,
            this.xrLabel27,
            this.CLMetatropi,
            this.CLPedio,
            this.xrLabel25,
            this.xrLabel24,
            this.OraDeigmatolipsias,
            this.HmerominiaDeigmatolipsias});
            this.xrPanel4.LocationFloat = new DevExpress.Utils.PointFloat(15.83812F, 266.25F);
            this.xrPanel4.Name = "xrPanel4";
            this.xrPanel4.SizeF = new System.Drawing.SizeF(651.8738F, 126.5358F);
            // 
            // CL_A_B
            // 
            this.CL_A_B.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CL_A_B.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CL_A_B]")});
            this.CL_A_B.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CL_A_B.ForeColor = System.Drawing.Color.Black;
            this.CL_A_B.LocationFloat = new DevExpress.Utils.PointFloat(547.3718F, 35.45825F);
            this.CL_A_B.Name = "CL_A_B";
            this.CL_A_B.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CL_A_B.SizeF = new System.Drawing.SizeF(76.50269F, 23.00002F);
            this.CL_A_B.StylePriority.UseBorders = false;
            this.CL_A_B.StylePriority.UseFont = false;
            this.CL_A_B.StylePriority.UseForeColor = false;
            this.CL_A_B.StylePriority.UsePadding = false;
            this.CL_A_B.StylePriority.UseTextAlignment = false;
            this.CL_A_B.Text = "xrTableCell314";
            this.CL_A_B.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel30
            // 
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(355.1878F, 35.45821F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(183.8067F, 22.99998F);
            this.xrLabel30.Text = "Χλώριο (Α-Β)";
            // 
            // MetrisiYpolCLPedioA
            // 
            this.MetrisiYpolCLPedioA.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.MetrisiYpolCLPedioA.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MetrisiYpolCLPedioA]")});
            this.MetrisiYpolCLPedioA.Font = new System.Drawing.Font("Tahoma", 8F);
            this.MetrisiYpolCLPedioA.ForeColor = System.Drawing.Color.Black;
            this.MetrisiYpolCLPedioA.LocationFloat = new DevExpress.Utils.PointFloat(547.3717F, 11.22906F);
            this.MetrisiYpolCLPedioA.Name = "MetrisiYpolCLPedioA";
            this.MetrisiYpolCLPedioA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MetrisiYpolCLPedioA.SizeF = new System.Drawing.SizeF(76.50287F, 22.99999F);
            this.MetrisiYpolCLPedioA.StylePriority.UseBorders = false;
            this.MetrisiYpolCLPedioA.StylePriority.UseFont = false;
            this.MetrisiYpolCLPedioA.StylePriority.UseForeColor = false;
            this.MetrisiYpolCLPedioA.StylePriority.UsePadding = false;
            this.MetrisiYpolCLPedioA.StylePriority.UseTextAlignment = false;
            this.MetrisiYpolCLPedioA.Text = "xrTableCell312";
            this.MetrisiYpolCLPedioA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(355.1878F, 11.22906F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(183.8067F, 22.99999F);
            this.xrLabel29.Text = "Μέτρηση Υπ.Χλ. ppm πεδίο (Α)";
            // 
            // xrLabel28
            // 
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(11.58066F, 92.91687F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(168.3032F, 22.99998F);
            this.xrLabel28.Text = "Χλώριο Μετατροπή";
            // 
            // xrLabel27
            // 
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(11.58085F, 66.53118F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(168.3032F, 22.99998F);
            this.xrLabel27.Text = "Χλώριο Πεδίο";
            // 
            // CLMetatropi
            // 
            this.CLMetatropi.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CLMetatropi.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CLMetatropi]")});
            this.CLMetatropi.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CLMetatropi.ForeColor = System.Drawing.Color.Black;
            this.CLMetatropi.LocationFloat = new DevExpress.Utils.PointFloat(183.3347F, 92.91684F);
            this.CLMetatropi.Name = "CLMetatropi";
            this.CLMetatropi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CLMetatropi.SizeF = new System.Drawing.SizeF(153.8561F, 22.99999F);
            this.CLMetatropi.StylePriority.UseBorders = false;
            this.CLMetatropi.StylePriority.UseFont = false;
            this.CLMetatropi.StylePriority.UseForeColor = false;
            this.CLMetatropi.StylePriority.UsePadding = false;
            this.CLMetatropi.StylePriority.UseTextAlignment = false;
            this.CLMetatropi.Text = "xrTableCell311";
            this.CLMetatropi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CLPedio
            // 
            this.CLPedio.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CLPedio.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CLPedio]")});
            this.CLPedio.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CLPedio.ForeColor = System.Drawing.Color.Black;
            this.CLPedio.LocationFloat = new DevExpress.Utils.PointFloat(183.3347F, 66.53118F);
            this.CLPedio.Name = "CLPedio";
            this.CLPedio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CLPedio.SizeF = new System.Drawing.SizeF(153.8561F, 22.99999F);
            this.CLPedio.StylePriority.UseBorders = false;
            this.CLPedio.StylePriority.UseFont = false;
            this.CLPedio.StylePriority.UseForeColor = false;
            this.CLPedio.StylePriority.UsePadding = false;
            this.CLPedio.StylePriority.UseTextAlignment = false;
            this.CLPedio.Text = "xrTableCell310";
            this.CLPedio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel25
            // 
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(11.58078F, 35.45818F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(168.3032F, 22.99999F);
            this.xrLabel25.Text = "Ωρα Δειγματοληψίας";
            // 
            // xrLabel24
            // 
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(11.58078F, 11.22906F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(168.3032F, 22.99999F);
            this.xrLabel24.Text = "Ημερομηνία Δειγματοληψίας";
            // 
            // OraDeigmatolipsias
            // 
            this.OraDeigmatolipsias.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.OraDeigmatolipsias.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OraDeigmatolipsias]")});
            this.OraDeigmatolipsias.Font = new System.Drawing.Font("Tahoma", 8F);
            this.OraDeigmatolipsias.ForeColor = System.Drawing.Color.Black;
            this.OraDeigmatolipsias.LocationFloat = new DevExpress.Utils.PointFloat(183.3347F, 35.45818F);
            this.OraDeigmatolipsias.Name = "OraDeigmatolipsias";
            this.OraDeigmatolipsias.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OraDeigmatolipsias.SizeF = new System.Drawing.SizeF(153.8561F, 22.99999F);
            this.OraDeigmatolipsias.StylePriority.UseBorders = false;
            this.OraDeigmatolipsias.StylePriority.UseFont = false;
            this.OraDeigmatolipsias.StylePriority.UseForeColor = false;
            this.OraDeigmatolipsias.StylePriority.UsePadding = false;
            this.OraDeigmatolipsias.StylePriority.UseTextAlignment = false;
            this.OraDeigmatolipsias.Text = "xrTableCell309";
            this.OraDeigmatolipsias.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // HmerominiaDeigmatolipsias
            // 
            this.HmerominiaDeigmatolipsias.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.HmerominiaDeigmatolipsias.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[HmerominiaDeigmatolipsias]")});
            this.HmerominiaDeigmatolipsias.Font = new System.Drawing.Font("Tahoma", 8F);
            this.HmerominiaDeigmatolipsias.ForeColor = System.Drawing.Color.Black;
            this.HmerominiaDeigmatolipsias.LocationFloat = new DevExpress.Utils.PointFloat(183.3347F, 11.22906F);
            this.HmerominiaDeigmatolipsias.Name = "HmerominiaDeigmatolipsias";
            this.HmerominiaDeigmatolipsias.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.HmerominiaDeigmatolipsias.SizeF = new System.Drawing.SizeF(153.8561F, 22.99999F);
            this.HmerominiaDeigmatolipsias.StylePriority.UseBorders = false;
            this.HmerominiaDeigmatolipsias.StylePriority.UseFont = false;
            this.HmerominiaDeigmatolipsias.StylePriority.UseForeColor = false;
            this.HmerominiaDeigmatolipsias.StylePriority.UsePadding = false;
            this.HmerominiaDeigmatolipsias.StylePriority.UseTextAlignment = false;
            this.HmerominiaDeigmatolipsias.Text = "xrTableCell308";
            this.HmerominiaDeigmatolipsias.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPanel3
            // 
            this.xrPanel3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel18,
            this.MetrisiCLMeLovipond,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.xrLabel17,
            this.xrLabel16,
            this.MetrisiCLMeSwan,
            this.Parapono,
            this.MetrisiApolimantikonMePalintest,
            this.MetrisiCLMeFotometroLovipond,
            this.MetrisiApolimantikonMeSwan,
            this.EktaktoDeigma});
            this.xrPanel3.LocationFloat = new DevExpress.Utils.PointFloat(15.83812F, 123.5417F);
            this.xrPanel3.Name = "xrPanel3";
            this.xrPanel3.SizeF = new System.Drawing.SizeF(651.8738F, 142.7083F);
            // 
            // xrLabel18
            // 
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(237.0216F, 9.916687F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(333.7839F, 22.99995F);
            this.xrLabel18.Text = "Μέτρηση Υπολοίπου CL με Lovipond (DPD)";
            // 
            // MetrisiCLMeLovipond
            // 
            this.MetrisiCLMeLovipond.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.MetrisiCLMeLovipond.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.MetrisiCLMeLovipond.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiCLMeLovipond]")});
            this.MetrisiCLMeLovipond.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MetrisiCLMeLovipond.LocationFloat = new DevExpress.Utils.PointFloat(570.8055F, 9.916671F);
            this.MetrisiCLMeLovipond.Name = "MetrisiCLMeLovipond";
            this.MetrisiCLMeLovipond.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MetrisiCLMeLovipond.SizeF = new System.Drawing.SizeF(45.96326F, 22.99995F);
            // 
            // xrLabel22
            // 
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(237.0216F, 109.7083F);
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(333.784F, 23.00001F);
            this.xrLabel22.Text = "Μετρηση Απολυμαντικών με Φωτόμετρο SWAN (DPD)";
            // 
            // xrLabel21
            // 
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(11.58066F, 33.00006F);
            this.xrLabel21.Multiline = true;
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(168.3033F, 23F);
            this.xrLabel21.Text = "Εκτακτο Δείγμα";
            // 
            // xrLabel20
            // 
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(237.0215F, 32.91664F);
            this.xrLabel20.Multiline = true;
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(333.784F, 23.08343F);
            this.xrLabel20.Text = "Μετρηση Υπολοίπου CL με Φωτόμετρο Lovipond";
            // 
            // xrLabel19
            // 
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(237.0216F, 63.70831F);
            this.xrLabel19.Multiline = true;
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(333.784F, 22.99995F);
            this.xrLabel19.Text = "Μετρηση Απολυμαντικών με Φωτόμετρο Palintest (DPD)";
            // 
            // xrLabel17
            // 
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(237.0215F, 86.70826F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(333.6146F, 23F);
            this.xrLabel17.Text = "Μέτρηση Υπολοίπου CL με Φωτόμετρο SWAN (DPD)";
            // 
            // xrLabel16
            // 
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(11.58078F, 9.999974F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(168.3033F, 23F);
            this.xrLabel16.Text = "Παράπονο";
            // 
            // MetrisiCLMeSwan
            // 
            this.MetrisiCLMeSwan.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.MetrisiCLMeSwan.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.MetrisiCLMeSwan.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiCLMeSwan]")});
            this.MetrisiCLMeSwan.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MetrisiCLMeSwan.LocationFloat = new DevExpress.Utils.PointFloat(570.8056F, 86.70826F);
            this.MetrisiCLMeSwan.Name = "MetrisiCLMeSwan";
            this.MetrisiCLMeSwan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MetrisiCLMeSwan.SizeF = new System.Drawing.SizeF(45.67451F, 22.99995F);
            // 
            // Parapono
            // 
            this.Parapono.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.Parapono.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.Parapono.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[Parapono]")});
            this.Parapono.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Parapono.LocationFloat = new DevExpress.Utils.PointFloat(179.8841F, 9.999963F);
            this.Parapono.Name = "Parapono";
            this.Parapono.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Parapono.SizeF = new System.Drawing.SizeF(45.84F, 23F);
            // 
            // MetrisiApolimantikonMePalintest
            // 
            this.MetrisiApolimantikonMePalintest.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.MetrisiApolimantikonMePalintest.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.MetrisiApolimantikonMePalintest.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiApolimantikonMePalintest]")});
            this.MetrisiApolimantikonMePalintest.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MetrisiApolimantikonMePalintest.LocationFloat = new DevExpress.Utils.PointFloat(570.9751F, 63.70831F);
            this.MetrisiApolimantikonMePalintest.Name = "MetrisiApolimantikonMePalintest";
            this.MetrisiApolimantikonMePalintest.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MetrisiApolimantikonMePalintest.SizeF = new System.Drawing.SizeF(45.67065F, 23F);
            // 
            // MetrisiCLMeFotometroLovipond
            // 
            this.MetrisiCLMeFotometroLovipond.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.MetrisiCLMeFotometroLovipond.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.MetrisiCLMeFotometroLovipond.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiCLMeFotometroLovipond]")});
            this.MetrisiCLMeFotometroLovipond.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MetrisiCLMeFotometroLovipond.LocationFloat = new DevExpress.Utils.PointFloat(570.8057F, 33.00009F);
            this.MetrisiCLMeFotometroLovipond.Name = "MetrisiCLMeFotometroLovipond";
            this.MetrisiCLMeFotometroLovipond.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MetrisiCLMeFotometroLovipond.SizeF = new System.Drawing.SizeF(45.67F, 23F);
            // 
            // MetrisiApolimantikonMeSwan
            // 
            this.MetrisiApolimantikonMeSwan.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.MetrisiApolimantikonMeSwan.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.MetrisiApolimantikonMeSwan.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[MetrisiApolimantikonMeSwan]")});
            this.MetrisiApolimantikonMeSwan.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MetrisiApolimantikonMeSwan.LocationFloat = new DevExpress.Utils.PointFloat(570.8057F, 109.7083F);
            this.MetrisiApolimantikonMeSwan.Name = "MetrisiApolimantikonMeSwan";
            this.MetrisiApolimantikonMeSwan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MetrisiApolimantikonMeSwan.SizeF = new System.Drawing.SizeF(45.84F, 23F);
            // 
            // EktaktoDeigma
            // 
            this.EktaktoDeigma.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.EktaktoDeigma.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.EktaktoDeigma.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[EktaktoDeigma]")});
            this.EktaktoDeigma.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EktaktoDeigma.LocationFloat = new DevExpress.Utils.PointFloat(179.8841F, 33.00006F);
            this.EktaktoDeigma.Name = "EktaktoDeigma";
            this.EktaktoDeigma.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EktaktoDeigma.SizeF = new System.Drawing.SizeF(45.67F, 23F);
            // 
            // xrPanel1
            // 
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel9,
            this.xrLabel7,
            this.Status,
            this.Task_Description,
            this.AddressArithmos,
            this.AddressOdos,
            this.AddressMunicipality,
            this.DateOfAssignment});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(15.83812F, 10.00001F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(651.8738F, 113.5417F);
            this.xrPanel1.StylePriority.UseBorders = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(337.4779F, 36.79168F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel15.StylePriority.UseBorders = false;
            this.xrLabel15.Text = "Κατάσταση";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(337.3084F, 10.33335F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.Text = "Εργασία";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(11.86771F, 82.79169F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(144.0818F, 23F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.Text = "Αριθμός";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(11.86765F, 59.79168F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(144.0818F, 23F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.Text = "Οδός";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(11.86771F, 36.79168F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(144.0818F, 23F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.Text = "Δήμος";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(11.86771F, 10.33335F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(144.0818F, 23F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.Text = "Ημερομηνία Ανάθεσης";
            // 
            // Status
            // 
            this.Status.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Status.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Status]")});
            this.Status.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Status.ForeColor = System.Drawing.Color.Black;
            this.Status.LocationFloat = new DevExpress.Utils.PointFloat(439.2819F, 36.79168F);
            this.Status.Name = "Status";
            this.Status.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Status.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.Status.StylePriority.UseBorders = false;
            this.Status.StylePriority.UseFont = false;
            this.Status.StylePriority.UseForeColor = false;
            this.Status.StylePriority.UsePadding = false;
            this.Status.StylePriority.UseTextAlignment = false;
            this.Status.Text = "xrTableCell189";
            this.Status.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Task_Description
            // 
            this.Task_Description.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Task_Description.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Task_Description]")});
            this.Task_Description.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Task_Description.ForeColor = System.Drawing.Color.Black;
            this.Task_Description.LocationFloat = new DevExpress.Utils.PointFloat(439.2819F, 10.00001F);
            this.Task_Description.Name = "Task_Description";
            this.Task_Description.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Task_Description.SizeF = new System.Drawing.SizeF(202.88F, 23.33333F);
            this.Task_Description.StylePriority.UseBorders = false;
            this.Task_Description.StylePriority.UseFont = false;
            this.Task_Description.StylePriority.UseForeColor = false;
            this.Task_Description.StylePriority.UsePadding = false;
            this.Task_Description.StylePriority.UseTextAlignment = false;
            this.Task_Description.Text = "xrTableCell194";
            this.Task_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AddressArithmos
            // 
            this.AddressArithmos.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AddressArithmos.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AddressArithmos]")});
            this.AddressArithmos.Font = new System.Drawing.Font("Tahoma", 8F);
            this.AddressArithmos.ForeColor = System.Drawing.Color.Black;
            this.AddressArithmos.LocationFloat = new DevExpress.Utils.PointFloat(162.2423F, 82.79166F);
            this.AddressArithmos.Name = "AddressArithmos";
            this.AddressArithmos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AddressArithmos.SizeF = new System.Drawing.SizeF(175.2355F, 23F);
            this.AddressArithmos.StylePriority.UseBorders = false;
            this.AddressArithmos.StylePriority.UseFont = false;
            this.AddressArithmos.StylePriority.UseForeColor = false;
            this.AddressArithmos.StylePriority.UsePadding = false;
            this.AddressArithmos.StylePriority.UseTextAlignment = false;
            this.AddressArithmos.Text = "xrTableCell329";
            this.AddressArithmos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AddressOdos
            // 
            this.AddressOdos.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AddressOdos.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AddressOdos]")});
            this.AddressOdos.Font = new System.Drawing.Font("Tahoma", 8F);
            this.AddressOdos.ForeColor = System.Drawing.Color.Black;
            this.AddressOdos.LocationFloat = new DevExpress.Utils.PointFloat(162.0728F, 59.79168F);
            this.AddressOdos.Name = "AddressOdos";
            this.AddressOdos.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AddressOdos.SizeF = new System.Drawing.SizeF(175.2355F, 23F);
            this.AddressOdos.StylePriority.UseBorders = false;
            this.AddressOdos.StylePriority.UseFont = false;
            this.AddressOdos.StylePriority.UseForeColor = false;
            this.AddressOdos.StylePriority.UsePadding = false;
            this.AddressOdos.StylePriority.UseTextAlignment = false;
            this.AddressOdos.Text = "xrTableCell328";
            this.AddressOdos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // AddressMunicipality
            // 
            this.AddressMunicipality.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AddressMunicipality.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AddressMunicipality]")});
            this.AddressMunicipality.Font = new System.Drawing.Font("Tahoma", 8F);
            this.AddressMunicipality.ForeColor = System.Drawing.Color.Black;
            this.AddressMunicipality.LocationFloat = new DevExpress.Utils.PointFloat(162.2423F, 36.79168F);
            this.AddressMunicipality.Name = "AddressMunicipality";
            this.AddressMunicipality.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AddressMunicipality.SizeF = new System.Drawing.SizeF(175.2355F, 23F);
            this.AddressMunicipality.StylePriority.UseBorders = false;
            this.AddressMunicipality.StylePriority.UseFont = false;
            this.AddressMunicipality.StylePriority.UseForeColor = false;
            this.AddressMunicipality.StylePriority.UsePadding = false;
            this.AddressMunicipality.StylePriority.UseTextAlignment = false;
            this.AddressMunicipality.Text = "xrTableCell327";
            this.AddressMunicipality.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DateOfAssignment
            // 
            this.DateOfAssignment.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DateOfAssignment.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateOfAssignment]")});
            this.DateOfAssignment.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DateOfAssignment.ForeColor = System.Drawing.Color.Black;
            this.DateOfAssignment.LocationFloat = new DevExpress.Utils.PointFloat(162.0728F, 10.33335F);
            this.DateOfAssignment.Name = "DateOfAssignment";
            this.DateOfAssignment.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DateOfAssignment.SizeF = new System.Drawing.SizeF(175.2355F, 23F);
            this.DateOfAssignment.StylePriority.UseBorders = false;
            this.DateOfAssignment.StylePriority.UseFont = false;
            this.DateOfAssignment.StylePriority.UseForeColor = false;
            this.DateOfAssignment.StylePriority.UsePadding = false;
            this.DateOfAssignment.StylePriority.UseTextAlignment = false;
            this.DateOfAssignment.Text = "Ημερομηνία Ανάθεσης";
            this.DateOfAssignment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3});
            this.TopMargin.HeightF = 141.5F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(4.776287F, 105.5F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(638F, 26F);
            this.xrLabel5.StyleName = "Title";
            this.xrLabel5.Text = "PORTAL ΥΔΡΕΥΣΗΣ";
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(4.876009F, 53.50001F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(638F, 26F);
            this.xrLabel4.StyleName = "Title";
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "ΔΙΕΥΘΥΝΣΗ ΔΙΚΤΥΟΥ ΥΔΡΕΥΣΗΣ";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(4.875946F, 79.50001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(638F, 25.99999F);
            this.xrLabel3.StyleName = "Title";
            this.xrLabel3.Text = "ΕΥΔΑΠ Α.Ε.";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.BottomMargin.HeightF = 36F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(6F, 6F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StyleName = "PageInfo";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(331F, 6F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StyleName = "PageInfo";
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrPageInfo2.TextFormatString = "Σελίδα {0} of {1}";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "sql";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Visits";
            queryParameter1.Name = "pAssignmentId";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.AssignmentId]", typeof(System.Guid));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 5.208333F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(698F, 23.33333F);
            this.xrLabel1.StyleName = "Title";
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "ΦΟΡΜΑ ΑΝΑΘΕΣΗΣ ΠΟΙΟΤΙΚΟΥ ΕΛΕΓΧΟΥ ΥΔΑΤΟΣ";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("AssignmentId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.groupHeaderBand1.HeightF = 29.16667F;
            this.groupHeaderBand1.KeepTogether = true;
            this.groupHeaderBand1.Level = 1;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            this.groupHeaderBand1.RepeatEveryPage = true;
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(698F, 25F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell1.StyleName = "GroupCaption3";
            this.xrTableCell1.Text = "Κωδικός Ανάθεσης";
            this.xrTableCell1.Weight = 0.27967325063852161D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AssignmentId]")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell2.StyleName = "GroupData3";
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.Weight = 0.79417290320763223D;
            // 
            // groupFooterBand1
            // 
            this.groupFooterBand1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.groupFooterBand1.HeightF = 1.833344F;
            this.groupFooterBand1.Name = "groupFooterBand1";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Title.Name = "Title";
            // 
            // GroupCaption3
            // 
            this.GroupCaption3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.GroupCaption3.BorderColor = System.Drawing.Color.White;
            this.GroupCaption3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GroupCaption3.BorderWidth = 2F;
            this.GroupCaption3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupCaption3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.GroupCaption3.Name = "GroupCaption3";
            this.GroupCaption3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100F);
            this.GroupCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupData3
            // 
            this.GroupData3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(137)))));
            this.GroupData3.BorderColor = System.Drawing.Color.White;
            this.GroupData3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GroupData3.BorderWidth = 2F;
            this.GroupData3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupData3.ForeColor = System.Drawing.Color.White;
            this.GroupData3.Name = "GroupData3";
            this.GroupData3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100F);
            this.GroupData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailCaption3
            // 
            this.DetailCaption3.BackColor = System.Drawing.Color.Transparent;
            this.DetailCaption3.BorderColor = System.Drawing.Color.Transparent;
            this.DetailCaption3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailCaption3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.DetailCaption3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.DetailCaption3.Name = "DetailCaption3";
            this.DetailCaption3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3
            // 
            this.DetailData3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DetailData3.ForeColor = System.Drawing.Color.Black;
            this.DetailData3.Name = "DetailData3";
            this.DetailData3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailCaptionBackground3
            // 
            this.DetailCaptionBackground3.BackColor = System.Drawing.Color.Transparent;
            this.DetailCaptionBackground3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.DetailCaptionBackground3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.DetailCaptionBackground3.BorderWidth = 2F;
            this.DetailCaptionBackground3.Name = "DetailCaptionBackground3";
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.PageHeader.HeightF = 34.79166F;
            this.PageHeader.Name = "PageHeader";
            // 
            // AssignmentId
            // 
            this.AssignmentId.Description = "Visits Assignment Id";
            this.AssignmentId.Name = "AssignmentId";
            this.AssignmentId.Type = typeof(System.Guid);
            this.AssignmentId.ValueInfo = "00000000-0000-0000-0000-000000000000";
            this.AssignmentId.Visible = false;
            // 
            // FormReport1070
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.groupHeaderBand1,
            this.groupFooterBand1,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Visits";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(52, 100, 142, 36);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.AssignmentId});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.GroupCaption3,
            this.GroupData3,
            this.DetailCaption3,
            this.DetailData3,
            this.DetailData3_Odd,
            this.DetailCaptionBackground3,
            this.PageInfo});
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
