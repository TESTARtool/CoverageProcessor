using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using MathNet.Numerics;
using System.Diagnostics;
using MathNet.Numerics.Interpolation;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Complex;
using DenseVector = MathNet.Numerics.LinearAlgebra.Double.DenseVector;


namespace CoverageCollectorApp
{
    public partial class BoxPlotChart : Form
    {
        private Button btnExportAsImage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        public BoxPlotChart(double[] yValues)
        {

            InitializeComponent();
            //row["MIN"], row["MAX"], row["25TH_PCT_NUMBER"], row["75TH_PCT_NUMBER"], 
            // row["50TH_PCT_NUMBER"], row["AVG"]
            // MyDataCollection data = new MyDataCollection(array);
            Console.WriteLine(yValues.Length);
            double[] boxplot = MathNet.Numerics.Statistics.ArrayStatistics.FiveNumberSummaryInplace(yValues);

            double lowestData = boxplot[0];
            Console.WriteLine(lowestData);
            double highestData = boxplot[4];
            Console.WriteLine(highestData);
            double lowerEdgeBox = boxplot[1];
            Console.WriteLine(lowerEdgeBox);
            double higherEdgeBox = boxplot[3];
            Console.WriteLine(higherEdgeBox);
            double mean = MathNet.Numerics.Statistics.ArrayStatistics.Mean(yValues);
            Console.WriteLine(mean);
            double median = boxplot[2];
            Console.WriteLine(median);

            double XValue = 1;
            double LowWhisker = lowestData;
            double UpWhisker = highestData;
            double LowWBox = lowerEdgeBox;
            double UpBox = higherEdgeBox;
            double Average = mean;
            double Median = median;

            chart1.Series.Add("Sample");
            chart1.Series["Sample"].Color = Color.FromArgb(250, 100, 100);
            chart1.Series["Sample"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            chart1.ChartAreas[0].AxisY.Minimum = Math.Round(LowWhisker - 5);
            chart1.ChartAreas[0].AxisY.Maximum = Math.Round(UpWhisker + 5);
            // chart1.Series["Sample"].Points.DataBind(data, "XValue", "LowWhisker,UpWhisker,LowWBox,UpBox,Average,Median", null);
            chart1.Series["Sample"].Points.AddXY(XValue, LowWhisker, UpWhisker, LowWBox, UpBox, Average, Median);





            /*
            double[] yValues = { 2, 3, 4, 5, 4, 5, 5, 2, 1, 9, 20, 4 };
            chart1.Series.Add("Sequence10");
            chart1.Series["Sequence10"].Color = Color.FromArgb(250, 0, 0);
            chart1.Series["Sequence10"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Sequence10"].Points.DataBindY(yValues);
            chart1.Series.Add("Seq1");
            chart1.Series["Seq1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            chart1.Series["Seq1"].Points.AddXY(1, 3, 15, 7, 12, 9.4, 10);
            chart1.Series.Add("S2");
            chart1.Series["S2"].Color = Color.FromArgb(0, 250, 0);
            chart1.Series["S2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 1; i < 5; i++)
            {
                chart1.Series["S2"].Points.AddXY(i, 15);
            }
            */

            /*
             chart1.ChartAreas[0].Visible = true;
             chart1.ChartAreas[0].Position.Auto = true;


            chart1.Parent = this;
            chart1.Visible = true;
            */

        }

        public BoxPlotChart(double[] yValues, double[] yValues2)
        {

            InitializeComponent();
            //row["MIN"], row["MAX"], row["25TH_PCT_NUMBER"], row["75TH_PCT_NUMBER"], 
            // row["50TH_PCT_NUMBER"], row["AVG"]
            // MyDataCollection data = new MyDataCollection(array);
            Console.WriteLine(yValues.Length);
            double[] boxplot = MathNet.Numerics.Statistics.ArrayStatistics.FiveNumberSummaryInplace(yValues);
            double[] boxplot2 = MathNet.Numerics.Statistics.ArrayStatistics.FiveNumberSummaryInplace(yValues2);

            Console.WriteLine("");
            double lowestData = boxplot[0];
            Console.WriteLine(lowestData);
            double highestData = boxplot[4];
            Console.WriteLine(highestData);
            double lowerEdgeBox = boxplot[1];
            Console.WriteLine(lowerEdgeBox);
            double higherEdgeBox = boxplot[3];
            Console.WriteLine(higherEdgeBox);
            double mean = MathNet.Numerics.Statistics.ArrayStatistics.Mean(yValues);
            Console.WriteLine(mean);
            double median = boxplot[2];
            Console.WriteLine(median);

            double XValue = 1;
            double LowWhisker = lowestData;
            double UpWhisker = highestData;
            double LowWBox = lowerEdgeBox;
            double UpBox = higherEdgeBox;
            double Average = mean;
            double Median = median;

            Console.WriteLine("");
            double lowestData2 = boxplot2[0];
            Console.WriteLine(lowestData2);
            double highestData2 = boxplot2[4];
            Console.WriteLine(highestData2);
            double lowerEdgeBox2 = boxplot2[1];
            Console.WriteLine(lowerEdgeBox2);
            double higherEdgeBox2 = boxplot2[3];
            Console.WriteLine(higherEdgeBox2);
            double mean2 = MathNet.Numerics.Statistics.ArrayStatistics.Mean(yValues2);
            Console.WriteLine(mean2);
            double median2 = boxplot2[2];
            Console.WriteLine(median2);

            double XValue2 = 2;
            double LowWhisker2 = lowestData2;
            double UpWhisker2 = highestData2;
            double LowWBox2 = lowerEdgeBox2;
            double UpBox2 = higherEdgeBox2;
            double Average2 = mean2;
            double Median2 = median2;


            if (LowWhisker <= LowWhisker2)
            {
                chart1.ChartAreas[0].AxisY.Minimum = Math.Round(LowWhisker - 5);
            }
            else chart1.ChartAreas[0].AxisY.Minimum = Math.Round(LowWhisker2 - 5);
            if (UpWhisker >= UpWhisker2)
            {
                chart1.ChartAreas[0].AxisY.Maximum = Math.Round(UpWhisker + 5);
            }
            else chart1.ChartAreas[0].AxisY.Maximum = Math.Round(UpWhisker2 + 5);

            chart1.Series.Add("Sample1");
            chart1.Series["Sample1"].Color = Color.FromArgb(250, 100, 100);
            chart1.Series["Sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            // chart1.Series["Sample"].Points.DataBind(data, "XValue", "LowWhisker,UpWhisker,LowWBox,UpBox,Average,Median", null);
            chart1.Series["Sample1"].Points.AddXY(XValue, LowWhisker, UpWhisker, LowWBox, UpBox, Average, Median);


            chart1.Series.Add("Sample2");
            chart1.Series["Sample2"].Color = Color.FromArgb(100, 100, 250);
            chart1.Series["Sample2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            // chart1.Series["Sample2"].Points.DataBind(data, "XValue", "LowWhisker,UpWhisker,LowWBox,UpBox,Average,Median", null);
            chart1.Series["Sample2"].Points.AddXY(XValue2, LowWhisker2, UpWhisker2, LowWBox2, UpBox2, Average2, Median2);


            /*
            double[] yValues = { 2, 3, 4, 5, 4, 5, 5, 2, 1, 9, 20, 4 };
            chart1.Series.Add("Sequence10");
            chart1.Series["Sequence10"].Color = Color.FromArgb(250, 0, 0);
            chart1.Series["Sequence10"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Sequence10"].Points.DataBindY(yValues);
            chart1.Series.Add("Seq1");
            chart1.Series["Seq1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            chart1.Series["Seq1"].Points.AddXY(1, 3, 15, 7, 12, 9.4, 10);
            chart1.Series.Add("S2");
            chart1.Series["S2"].Color = Color.FromArgb(0, 250, 0);
            chart1.Series["S2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 1; i < 5; i++)
            {
                chart1.Series["S2"].Points.AddXY(i, 15);
            }
            */

            /*
             chart1.ChartAreas[0].Visible = true;
             chart1.ChartAreas[0].Position.Auto = true;


            chart1.Parent = this;
            chart1.Visible = true;
            */

        }





        //public System.Windows.Forms.DataVisualization.Charting.Chart Chart2 { get => chart2; set => chart2 = value; }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MyDataCollection data = new MyDataCollection();
            // chart1.Series[0].Points.AddXY(1, 3, 5, 7);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExportAsImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(-3, -1);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1073, 764);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnExportAsImage
            // 
            this.btnExportAsImage.Location = new System.Drawing.Point(1118, 590);
            this.btnExportAsImage.Name = "btnExportAsImage";
            this.btnExportAsImage.Size = new System.Drawing.Size(185, 108);
            this.btnExportAsImage.TabIndex = 1;
            this.btnExportAsImage.Text = "Export As Image";
            this.btnExportAsImage.UseVisualStyleBackColor = true;
            this.btnExportAsImage.Click += new System.EventHandler(this.btnExportAsImage_Click);
            // 
            // BoxPlotChart
            // 
            this.ClientSize = new System.Drawing.Size(1344, 759);
            this.Controls.Add(this.btnExportAsImage);
            this.Controls.Add(this.chart1);
            this.Name = "BoxPlotChart";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnExportAsImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|JPeg Image|*.jpg";
            saveFileDialog.Title = "Save Chart As Image File";
            saveFileDialog.FileName = "Sample.png";

            DialogResult result = saveFileDialog.ShowDialog();
            saveFileDialog.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                try
                {
                    if (saveFileDialog.CheckPathExists)
                    {
                        if (saveFileDialog.FilterIndex == 2)
                        {
                            chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                        }
                        else if (saveFileDialog.FilterIndex == 1)
                        {
                            chart1.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Given Path does not exist");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}