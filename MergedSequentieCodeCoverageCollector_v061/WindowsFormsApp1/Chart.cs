using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CoverageCollectorApp
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }


        // Create a chart from one ArrayList
        public void showChart(double[] x, double[] y, double[] dydx, double min, double max, int start, int numberActions, string type)
        {
            // int max = 30;
            // max = x.Length;

            /*
            // Declare the Arrays to determine the edges
            double[] x = new double[al1.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x.Length; ++i)
            { //iterate over the elements of the list
                x[i] = Double.Parse(al1[i + 1].ToString()); //store each element as a double in the array
            }
            */
            double vMax = x.Max(); // scales to the real max value
            double vMin = x.Min(); // scale to the real min value
            

            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisX.Minimum = start;
            //objChart.AxisX.Maximum = 3000;
            objChart.AxisX.Maximum = numberActions;
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = min;
            objChart.AxisY.Maximum = max;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 10;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightPink;
            //chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 5;
            //clear the old graph
            chart1.Series.Clear();

            chart1.Series.Add("sample1");
            chart1.Series["sample1"].Color = Color.FromArgb(255, 10, 10);
            //chart1.Series["sample1"].Legend = "Legend1";
            // chart1.Series["sample1"].ChartArea = "ChartArea1";

            if (type.Equals("Area"))
            {
                chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            }
            else if (type.Equals("Line"))
            {
                chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
            else if (type.Equals("Spline"))
            {
                chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }
            else if (type.Equals("Kagi"))
            {
                chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Kagi;
            }
            else if (type.Equals("Candlestick"))
            {
                chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            }
            else if (type.Equals("Column"))
            {
                chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            else chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["sample1"].Color = Color.Red;
            //adding data
            for (int i = 0; i < x.Length; i++)
            {
                //chart.Series["sample1"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                chart1.Series["sample1"].Points.AddXY(x[i], dydx[i]);
            }

            /*
            chart1.Series.Add("sample2");
            chart1.Series["sample2"].Color = Color.FromArgb(255, 10, 10);
            chart1.Series["sample1"].Legend = "Legend1";
            // chart1.Series["sample1"].ChartArea = "ChartArea1";
            chart1.Series["sample2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["sample2"].Color = Color.Blue;
            //adding data
            for (int i = 0; i < x.Length; i++)
            {
                //chart.Series["sample1"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                chart1.Series["sample2"].Points.AddXY(x[i], y[i]);
            }

            */

        } // end showCart




















        // Create a chart from one ArrayList
        public void showChart(ArrayList al1)
        {
            int max = 30;
            max = al1.Count;

            // Declare the Arrays to determine the edges
            double[] x = new double[al1.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x.Length; ++i)
            { //iterate over the elements of the list
                x[i] = Double.Parse(al1[i + 1].ToString()); //store each element as a double in the array
            }
            double vMax = x.Max(); // scales to the real max value
            double vMin = x.Min(); // scale to the real min value
            vMax = 100;// on request
            vMin = 0; // on request
  
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisX.Minimum = 1;
            objChart.AxisX.Maximum = max;
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = vMin;
            objChart.AxisY.Maximum = vMax;
            //clear the old graph
            chart1.Series.Clear();

            chart1.Series.Add("sample1");
            chart1.Series["sample1"].Color = Color.FromArgb(255, 10, 10);
            //chart1.Series["sample1"].Legend = "Legend1";
            // chart1.Series["sample1"].ChartArea = "ChartArea1";
            chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //adding data
            for (int i = 1; i < x.Length; i++)
            {
                //chart.Series["sample1"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                 chart1.Series["sample1"].Points.AddXY(0, x[i]);
            }
        } // end showCart


        // Create a chart from two ArrayLists
        public void showChart(ArrayList al1, ArrayList al2)
        {
            int max = 30;
            if (al1.Count >= al2.Count)
            {
                max = al1.Count;
            }
            else
            {
                max = al2.Count;
            }

            // Declare the Arrays to determine the edges
            double[] x = new double[al1.Count - 1];
            double[] y = new double[al2.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x.Length; ++i)
            { //iterate over the elements of the list
                x[i] = Double.Parse(al1[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < y.Length; ++i)
            { //iterate over the elements of the list
                y[i] = Double.Parse(al2[i + 1].ToString()); //store each element as a double in the array
            }
            double vMax = double.MaxValue;
            double vMin = 0;
            if (x.Max() >= y.Max())
            {
                vMax = x.Max();
            }
            else
            {
                vMax = y.Max();
            }
            if (x.Min() <= y.Min())
            {
                vMin = x.Min();
            }
            else
            {
                vMin = y.Min();
            }

            vMax = 100;// on request
            vMin = 0; // on request

            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisX.Minimum = 1;
            objChart.AxisX.Maximum = max;
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = vMin;
            objChart.AxisY.Maximum = vMax;
            //clear
            chart1.Series.Clear();

            // Draw second ArrayList
            chart1.Series.Add("sample2");
            chart1.Series["sample2"].Color = Color.FromArgb(10, 10, 255);
            chart1.Series["sample2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //adding data
            for (int i = 1; i < al2.Count; i++)
            {
                chart1.Series["sample2"].Points.AddXY(i, al2[i]);
            }

            // Draw first ArrayList
            chart1.Series.Add("sample1");
            chart1.Series["sample1"].Color = Color.FromArgb(255, 10, 10);
            chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //adding data
            for (int i = 1; i < al1.Count; i++)
            {
                //chart.Series["sample1"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                chart1.Series["sample1"].Points.AddXY(i, al1[i]);
            }
        } // end showCart


        // Create a chart from two ArrayLists
        public void showChart(ArrayList al1, ArrayList al2, string type)
        {
            int max = 30;
            if (al1.Count >= al2.Count)
            {
                max = al1.Count;
            }
            else
            {
                max = al2.Count;
            }

            // Declare the Arrays to determine the edges
            double[] x = new double[al1.Count - 1];
            double[] y = new double[al2.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x.Length; ++i)
            { //iterate over the elements of the list
                x[i] = Double.Parse(al1[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < y.Length; ++i)
            { //iterate over the elements of the list
                y[i] = Double.Parse(al2[i + 1].ToString()); //store each element as a double in the array
            }
            double vMax = double.MaxValue;
            double vMin = 0;
            if (x.Max() >= y.Max())
            {
                vMax = x.Max();
            }
            else
            {
                vMax = y.Max();
            }
            if (x.Min() <= y.Min())
            {
                vMin = x.Min();
            }
            else
            {
                vMin = y.Min();
            }

            vMax = 100;// on request
            vMin = 0; // on request

            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisX.Minimum = 1;
            objChart.AxisX.Maximum = max;
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = vMin;
            objChart.AxisY.Maximum = vMax;
            //clear
            chart1.Series.Clear();

            // Draw second ArrayList
            chart1.Series.Add("sample2");
            chart1.Series["sample2"].Color = Color.FromArgb(10, 10, 255);
            chart1.Series["sample2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //adding data
            for (int i = 1; i < al2.Count; i++)
            {
                chart1.Series["sample2"].Points.AddXY(i, al2[i]);
            }

            // Draw first ArrayList
            chart1.Series.Add("sample1");
            chart1.Series["sample1"].Color = Color.FromArgb(255, 10, 10);
            chart1.Series["sample1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //adding data
            for (int i = 1; i < al1.Count; i++)
            {
                //chart.Series["sample1"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                chart1.Series["sample1"].Points.AddXY(i, al1[i]);
            }
        } // end showCart

        // Create a chart from ten ArrayLists
        public void showChartSeq(ArrayList al1, ArrayList al2, ArrayList al3, ArrayList al4, ArrayList al5, ArrayList al6, ArrayList al7, ArrayList al8, ArrayList al9, ArrayList al10)
        {
            int max = 30;
            if (al1.Count >= al2.Count)
            {
                max = al1.Count;
            }
            else
            {
                max = al2.Count;
            }

            // Declare the Arrays to determine the edges
            double[] x1 = new double[al1.Count - 1];
            double[] x2 = new double[al2.Count - 1];
            double[] x3 = new double[al3.Count - 1];
            double[] x4 = new double[al4.Count - 1];
            double[] x5 = new double[al5.Count - 1];
            double[] x6 = new double[al6.Count - 1];
            double[] x7 = new double[al7.Count - 1];
            double[] x8 = new double[al8.Count - 1];
            double[] x9 = new double[al9.Count - 1];
            double[] x10 = new double[al10.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x1.Length; ++i)
            { //iterate over the elements of the list
                x1[i] = Double.Parse(al1[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x2.Length; ++i)
            { //iterate over the elements of the list
                x2[i] = Double.Parse(al2[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x3.Length; ++i)
            { //iterate over the elements of the list
                x3[i] = Double.Parse(al1[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x4.Length; ++i)
            { //iterate over the elements of the list
                x4[i] = Double.Parse(al2[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x5.Length; ++i)
            { //iterate over the elements of the list
                x5[i] = Double.Parse(al1[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x6.Length; ++i)
            { //iterate over the elements of the list
                x6[i] = Double.Parse(al2[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x7.Length; ++i)
            { //iterate over the elements of the list
                x7[i] = Double.Parse(al1[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x8.Length; ++i)
            { //iterate over the elements of the list
                x8[i] = Double.Parse(al2[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x9.Length; ++i)
            { //iterate over the elements of the list
                x9[i] = Double.Parse(al1[i + 1].ToString()); //store each element as a double in the array
            }
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < x10.Length; ++i)
            { //iterate over the elements of the list
                x10[i] = Double.Parse(al2[i + 1].ToString()); //store each element as a double in the array
            }
            double vMax = double.MaxValue;
            double vMin = 0;
            vMax = 100;// on request
            vMin = 0; // on request

            double[] arrayMax = new double[10];
            double[] arrayMin = new double[10];
            arrayMax[0] = x1.Max(); arrayMax[1] = x2.Max(); arrayMax[2] = x3.Max(); arrayMax[3] = x4.Max();
            arrayMax[4] = x5.Max(); arrayMax[5] = x6.Max(); arrayMax[6] = x7.Max(); arrayMax[7] = x8.Max();
            arrayMax[8] = x9.Max(); arrayMax[9] = x10.Max();
            arrayMin[0] = x1.Min(); arrayMin[1] = x2.Min(); arrayMin[2] = x3.Min(); arrayMin[3] = x4.Min();
            arrayMin[4] = x5.Min(); arrayMin[5] = x6.Min(); arrayMin[6] = x7.Min(); arrayMin[7] = x8.Min();
            arrayMin[8] = x9.Min(); arrayMin[9] = x10.Min();
            vMax = arrayMax.Max();
            vMin = arrayMin.Min();


            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisX.Minimum = 1;
            objChart.AxisX.Maximum = max;
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = vMin-2;
            objChart.AxisY.Maximum = vMax+5;
            //clear
            /*
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
                chart1.Series["Sequence10"].Points.Clear();
            }
            */
            //chart1.Series.Clear();

                        chart1.Series.Add("Sequence10");
                        chart1.Series["Sequence10"].Color = Color.FromArgb(0, 0, 0);
                        chart1.Series["Sequence10"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //chart1.Series["Sequence10"].Points.Clear();
                        //adding data
                        for (int i = 1; i < al10.Count; i++)
                        {
                            chart1.Series["Sequence10"].Points.AddXY(i, al10[i]);
                        }
 
                        chart1.Series.Add("Sequence9");
                        chart1.Series["Sequence9"].Color = Color.FromArgb(0, 100, 0);
                        chart1.Series["Sequence9"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //adding data
                        //chart1.Series["Sequence9"].Points.Clear();
                        for (int i = 1; i < al9.Count; i++)
                        {
                            //chart.Series["Sequence9"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                            chart1.Series["Sequence9"].Points.AddXY(i, al9[i]);
                        }

                        chart1.Series.Add("Sequence8");
                        chart1.Series["Sequence8"].Color = Color.FromArgb(0, 0, 128);
                        chart1.Series["Sequence8"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //chart1.Series["Sequence8"].Points.Clear();
                        //adding data
                        for (int i = 1; i < al8.Count; i++)
                        {
                            chart1.Series["Sequence8"].Points.AddXY(i, al8[i]);
                        }

                        chart1.Series.Add("Sequence7");
                        chart1.Series["Sequence7"].Color = Color.FromArgb(176, 48, 96);
                        chart1.Series["Sequence7"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //chart1.Series["Sequence7"].Points.Clear();
                        //adding data
                        for (int i = 1; i < al7.Count; i++)
                        {
                            //chart.Series["Sequence7"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                            chart1.Series["Sequence7"].Points.AddXY(i, al7[i]);
                        }

                        chart1.Series.Add("Sequence6");
                        chart1.Series["Sequence6"].Color = Color.FromArgb(255, 0, 0);
                        chart1.Series["Sequence6"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //chart1.Series["Sequence6"].Points.Clear();
                        //adding data
                        for (int i = 1; i < al6.Count; i++)
                        {
                            chart1.Series["Sequence6"].Points.AddXY(i, al6[i]);
                        }

                        chart1.Series.Add("Sequence5");
                        chart1.Series["Sequence5"].Color = Color.FromArgb(255, 210, 0);
                        chart1.Series["Sequence5"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //chart1.Series["Sequence5"].Points.Clear();
                        //adding data
                        for (int i = 1; i < al5.Count; i++)
                        {
                            //chart.Series["Sequence5"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                            chart1.Series["Sequence5"].Points.AddXY(i, al5[i]);
                        }

                        chart1.Series.Add("Sequence4");
                        chart1.Series["Sequence4"].Color = Color.FromArgb(0, 255, 0);
                        //chart1.Series["Sequence4"].Legend = "Legend1";
                        //chart1.Series["Sequence4"].ChartArea = "ChartArea1";
                        chart1.Series["Sequence4"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //chart1.Series["Sequence4"].Points.Clear();
                        //adding data
                        for (int i = 1; i < al4.Count; i++)
                        {
                            chart1.Series["Sequence4"].Points.AddXY(i, al4[i]);
                        }

                        chart1.Series.Add("Sequence3");
                        chart1.Series["Sequence3"].Color = Color.FromArgb(0, 191, 255);
                        //chart1.Series["Sequence3"].Legend = "Legend1";
                        // chart1.Series["Sequence3"].ChartArea = "ChartArea1";
                        chart1.Series["Sequence3"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //chart1.Series["Sequence3"].Points.Clear();
                        //adding data
                        for (int i = 1; i < al3.Count; i++)
                        {
                            chart1.Series["Sequence3"].Points.AddXY(i, al3[i]);
                        }

                        chart1.Series.Add("Sequence2");
                        chart1.Series["Sequence2"].Color = Color.FromArgb(255, 0, 255);
                        chart1.Series["Sequence2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //chart1.Series["Sequence2"].Points.Clear();
                        //adding data
                        for (int i = 1; i < al2.Count; i++)
                        {
                            chart1.Series["Sequence2"].Points.AddXY(i, al2[i]);
                        }

                        chart1.Series.Add("Sequence1");
                        chart1.Series["Sequence1"].Color = Color.FromArgb(255, 228, 196);
                        chart1.Series["Sequence1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        //chart1.Series["Sequence1"].Points.Clear();
                        //adding data
                        for (int i = 1; i < al1.Count; i++)
                        {
                            chart1.Series["Sequence1"].Points.AddXY(i, al1[i]);
                        }

        } // end showCartSeq


        // Create a chart from ArrayLists collected in one container ArrayList
        public void showChartCollectionOfArrayLists(ArrayList alalCollection)
        {
            Random random = new Random(); // for color variation
            chart1.Series.Clear();
            for (int countAL = 0; countAL < alalCollection.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList) alalCollection[countAL];

                int max = 3000;
                if (al.Count >= max)
                {
                    max = al.Count;
                }

                // Declare the Arrays to determine the edges
                double[] x1 = new double[al.Count-1];
                // Store the values of the received ArrayLists with the sample data in an Array
                for (int i = 0; i < x1.Length; ++i)
                { //iterate over the elements of the list
                    x1[i] = Double.Parse(al[i + 1].ToString()); //store each element as a double in the array
                }

                // double vMax = x1.Max();
                // double vMin = x1.Min();
                double vMax = 100;// on request
                double vMin = 0; // on request

                var objChart = chart1.ChartAreas[0];
                objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                objChart.AxisX.Minimum = 1;
                objChart.AxisX.Maximum = max;
                objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                objChart.AxisY.Minimum = vMin; // vMin - 2;
                objChart.AxisY.Maximum = vMax; // vMax + 5;
                //clear

                //Random random = new Random();
                int randomNumber = random.Next(0, 256);

                chart1.Series.Add("Sequence" + (countAL + 1));
                chart1.Series["Sequence" + (countAL + 1)].Color = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                chart1.Series["Sequence" + (countAL + 1)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //chart1.Series["Sequence10"].Points.Clear();
                //adding data
                for (int i = 1; i < al.Count; i++)
                {
                    chart1.Series["Sequence" + (countAL + 1)].Points.AddXY(i, Convert.ToDouble(al[i]));
                    //chart.Series["sample1"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                }
            }
        } // end graphs collection



        // Create a chart from ArrayLists collected in one container ArrayList
        // Only show the first (max) values
        public void show1000ChartCollectionOfArrayLists(ArrayList alalCollection, int max)
        {
            Random random = new Random(); // for color variation
            chart1.Series.Clear();
            for (int countAL = 0; countAL < alalCollection.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalCollection[countAL];

                // Declare the Arrays to determine the edges
                double[] x1 = new double[al.Count - 1];
                // Store the values of the received ArrayLists with the sample data in an Array
                for (int i = 0; i < x1.Length; ++i)
                { //iterate over the elements of the list
                    x1[i] = Double.Parse(al[i + 1].ToString()); //store each element as a double in the array
                }

                double vMax = x1.Max();
                double vMin = x1.Min();
                vMax = 100;// on request
                vMin = 0; // on request

                var objChart = chart1.ChartAreas[0];
                objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                objChart.AxisX.Minimum = 1;
                objChart.AxisX.Maximum = max;
                objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                //objChart.AxisY.Minimum = vMin - 2;
                //objChart.AxisY.Maximum = vMax + 5;
                objChart.AxisY.Minimum = vMin;
                objChart.AxisY.Maximum = vMax;
                //clear

                int randomNumber = random.Next(0, 256);

                chart1.Series.Add("Sequence" + (countAL + 1));
                chart1.Series["Sequence" + (countAL + 1)].Color = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                //chart1.Series["Sequence10"].Legend = "Legend1";
                //chart1.Series["Sequence10"].ChartArea = "ChartArea1";
                chart1.Series["Sequence" + (countAL + 1)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //chart1.Series["Sequence10"].Points.Clear();
                //adding data
                for (int i = 1; i < al.Count; i++)
                {
                    chart1.Series["Sequence" + (countAL + 1)].Points.AddXY(i, Convert.ToDouble(al[i]));
                    //chart.Series["sample1"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));

                }
            }
        } // end graphs collection


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        // Create a chart from ArrayLists collected in one container ArrayList
        public void showMeanValuesCollectionOfArrayLists(ArrayList alalCollection)
        {
            Random random = new Random(); // for color variation
            ArrayList alTotalValues = new ArrayList();
            ArrayList alMeanValues = new ArrayList();
            double[] aTotalValues = new double[3000];
            double[] aMeanValues = new double[3000];
            for (int countAL = 0; countAL < alalCollection.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalCollection[countAL];

                for (int i = 0; i < 3000; i++)
                {
                      if (i >= al.Count) aTotalValues[i] += Convert.ToDouble(al[al.Count - 1]);
                        else aTotalValues[i] += Convert.ToDouble(al[i]);
                }
            }
            for (int i = 0; i < 3000; i++)
            {
                aMeanValues[i] = aTotalValues[i] / alalCollection.Count;
            }                
                //double vMax = aMeanValues.Max();
                //double vMin = aMeanValues.Min();
                double vMax = 100.0;
                double vMin = 0.0;

                var objChart = chart1.ChartAreas[0];
                objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                objChart.AxisX.Minimum = 1;
                objChart.AxisX.Maximum = 3000;
                objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                objChart.AxisY.Minimum = vMin; // vMin - 2;
                objChart.AxisY.Maximum = vMax; // vMax + 5;
                                               //clear
            chart1.Series.Clear();
                chart1.Series.Add("Mean of Merged Coverage");
                chart1.Series["Mean of Merged Coverage"].Color = Color.FromArgb(0, 0, 200);
                chart1.Series["Mean of Merged Coverage"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //chart1.Series["Sequence10"].Points.Clear();
            chart1.Series["Mean of Merged Coverage"].BorderWidth = 2;
            chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 10;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 5;
            chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 2;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineWidth = 1;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Pink;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Pink;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineWidth = 1;
            chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 100;
            //adding data
            for (int i = 1; i < 3000; i++)
                {
                    chart1.Series["Mean of Merged Coverage"].Points.AddXY(i, aMeanValues[i]);
                    //chart.Series["sample1"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
                }
            
        } // end graphs collection

        // Create a chart from ArrayLists collected in one container ArrayList
        public void showMeanMaxValuesCollectionOfArrayLists(ArrayList alalCollection)
        {
            Random random = new Random(); // for color variation
            ArrayList alTotalValues = new ArrayList();
            ArrayList alMeanValues = new ArrayList();
            double[] aTotalValues = new double[3000];
            double[] aMeanValues = new double[3000];
            for (int countAL = 0; countAL < alalCollection.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalCollection[countAL];

                double max = 0;

                for (int i = 0; i < al.Count && i < 3000; i++)
                {
                    if (i == 0)
                    {
                        aTotalValues[i] = Convert.ToDouble(al[i]);
                    }
                    else if (Convert.ToDouble(al[i]) >= Convert.ToDouble(al[i - 1]) )
                    {
                        aTotalValues[i] += Convert.ToDouble(al[i]);
                        max = Convert.ToDouble(al[i]);
                        //Console.WriteLine("max is " + max);
                        //Console.WriteLine("aTotalValues[i] is " + aTotalValues[i]);
                    }
                    else
                    {
                        aTotalValues[i] += max;
                       // Console.WriteLine("max IN DE ELSE is " + max);
                       // Console.WriteLine("aTotalValues[i] is " + aTotalValues[i]);
                    }
                }
                for (int i = al.Count; i <3000; i++)
                {
                    aTotalValues[i] += max;
                }
            }
            for (int i = 0; i < 3000; i++)
            {
                aMeanValues[i] = aTotalValues[i] / alalCollection.Count;
            }
            //double vMax = aMeanValues.Max();
            //double vMin = aMeanValues.Min();
            double vMax = 100.0;
            double vMin = 0.0;

            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisX.Minimum = 1;
            objChart.AxisX.Maximum = 3000;
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = vMin; // vMin - 2;
            objChart.AxisY.Maximum = vMax; // vMax + 5;
                                           //clear
            chart1.Series.Clear();
            chart1.Series.Add("Mean of Merged Coverage");
            chart1.Series["Mean of Merged Coverage"].Color = Color.FromArgb(0, 0, 200);
            chart1.Series["Mean of Merged Coverage"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //chart1.Series["Sequence10"].Points.Clear();
            chart1.Series["Mean of Merged Coverage"].BorderWidth = 2;
            chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 10;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 5;
            chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 2;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineWidth = 1;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Pink;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Pink;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineWidth = 1;
            chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 100;
            //adding data
            for (int i = 1; i < 3000; i++)
            {
                chart1.Series["Mean of Merged Coverage"].Points.AddXY(i, aMeanValues[i]);
                //chart.Series["sample1"].Points.AddXY(i, Convert.ToInt32(al1[i][$"M{i}"]));
            }

        } // end graphs collection

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




