using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Collections;

using MathNet.Numerics;
using System.Diagnostics;
using MathNet.Numerics.Interpolation;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Complex;
using DenseVector = MathNet.Numerics.LinearAlgebra.Double.DenseVector;
using Meta.Numerics.Statistics;

namespace CoverageCollectorApp
{
    public partial class CoverageCollector : Form
    {
        // Declaring and Initializing used ArayLists
        private ArrayList alMergedConditionCoverageTestRun = new ArrayList();
        private ArrayList alMergedBranchCoverageTestRun = new ArrayList();
        private ArrayList alSequenceActions = new ArrayList();

        private ArrayList alMergedConditionCoverageTestRun2 = new ArrayList();
        private ArrayList alMergedBranchCoverageTestRun2 = new ArrayList();
        private ArrayList alSequenceActions2 = new ArrayList();

        private ArrayList alActionNumbers = new ArrayList();
        private ArrayList alSequenceNumbers = new ArrayList();
        private ArrayList alConditionCoverage = new ArrayList();
        private ArrayList alBranchCoverage = new ArrayList();
        private ArrayList alMergedConditionCoverage = new ArrayList();
        private ArrayList alMergedBranchCoverage = new ArrayList();

        private string path;
        private string filePath;


        // nieuwe functies
        private ArrayList alActionNumbers1 = new ArrayList();
        private ArrayList alSequenceNumbers1 = new ArrayList();
        private ArrayList alConditionCoverage1 = new ArrayList();
        private ArrayList alBranchCoverage1 = new ArrayList();
        private ArrayList alActionNumbers2 = new ArrayList();
        private ArrayList alSequenceNumbers2 = new ArrayList();
        private ArrayList alConditionCoverage2 = new ArrayList();
        private ArrayList alBranchCoverage2 = new ArrayList();
        private ArrayList alActionNumbers3 = new ArrayList();
        private ArrayList alSequenceNumbers3 = new ArrayList();
        private ArrayList alConditionCoverage3 = new ArrayList();
        private ArrayList alBranchCoverage3 = new ArrayList();
        private ArrayList alActionNumbers4 = new ArrayList();
        private ArrayList alSequenceNumbers4 = new ArrayList();
        private ArrayList alConditionCoverage4 = new ArrayList();
        private ArrayList alBranchCoverage4 = new ArrayList();
        private ArrayList alActionNumbers5 = new ArrayList();
        private ArrayList alSequenceNumbers5 = new ArrayList();
        private ArrayList alConditionCoverage5 = new ArrayList();
        private ArrayList alBranchCoverage5 = new ArrayList();
        private ArrayList alActionNumbers6 = new ArrayList();
        private ArrayList alSequenceNumbers6 = new ArrayList();
        private ArrayList alConditionCoverage6 = new ArrayList();
        private ArrayList alBranchCoverage6 = new ArrayList();
        private ArrayList alActionNumbers7 = new ArrayList();
        private ArrayList alSequenceNumbers7 = new ArrayList();
        private ArrayList alConditionCoverage7 = new ArrayList();
        private ArrayList alBranchCoverage7 = new ArrayList();
        private ArrayList alActionNumbers8 = new ArrayList();
        private ArrayList alSequenceNumbers8 = new ArrayList();
        private ArrayList alConditionCoverage8 = new ArrayList();
        private ArrayList alBranchCoverage8 = new ArrayList();
        private ArrayList alActionNumbers9 = new ArrayList();
        private ArrayList alSequenceNumbers9 = new ArrayList();
        private ArrayList alConditionCoverage9 = new ArrayList();
        private ArrayList alBranchCoverage9 = new ArrayList();
        private ArrayList alActionNumbers10 = new ArrayList();
        private ArrayList alSequenceNumbers10 = new ArrayList();
        private ArrayList alConditionCoverage10 = new ArrayList();
        private ArrayList alBranchCoverage10 = new ArrayList();

        ArrayList alalInstructionMerged = new ArrayList();
        ArrayList alalBrancheMerged = new ArrayList();

        Boolean keepOld = false;

        // Constructor
        public CoverageCollector()
        {
            InitializeComponent();
            // Write to the 0-index of the ArrayLists the info over the contents of the ArrayLists
            alActionNumbers.Add("Action");
            alSequenceNumbers.Add("Sequence");
            alConditionCoverage.Add("Percentage");
            alBranchCoverage.Add("Percentage");
            alMergedConditionCoverage.Add("Percentage");
            alMergedBranchCoverage.Add("Percentage");
            path = "";
            
            alMergedConditionCoverageTestRun.Add("MergedConditionCoverage");
            alMergedBranchCoverageTestRun.Add("MergedBranchCoverage");
            alSequenceActions.Add("SequenceActions");

            alMergedConditionCoverageTestRun2.Add("MergedConditionCoverage");
            alMergedBranchCoverageTestRun2.Add("MergedBranchCoverage");
            alSequenceActions2.Add("SequenceActions");

            // nieuwe functies
            alActionNumbers1.Add("Action");
            alSequenceNumbers1.Add("Sequence");
            alConditionCoverage1.Add("Percentage");
            alBranchCoverage1.Add("Percentage");
            alActionNumbers2.Add("Action");
            alSequenceNumbers2.Add("Sequence");
            alConditionCoverage2.Add("Percentage");
            alBranchCoverage2.Add("Percentage");
            alActionNumbers3.Add("Action");
            alSequenceNumbers3.Add("Sequence");
            alConditionCoverage3.Add("Percentage");
            alBranchCoverage3.Add("Percentage");
            alActionNumbers4.Add("Action");
            alSequenceNumbers4.Add("Sequence");
            alConditionCoverage4.Add("Percentage");
            alBranchCoverage4.Add("Percentage");
            alActionNumbers5.Add("Action");
            alSequenceNumbers5.Add("Sequence");
            alConditionCoverage5.Add("Percentage");
            alBranchCoverage5.Add("Percentage");
            alActionNumbers6.Add("Action");
            alSequenceNumbers6.Add("Sequence");
            alConditionCoverage6.Add("Percentage");
            alBranchCoverage6.Add("Percentage");
            alActionNumbers7.Add("Action");
            alSequenceNumbers7.Add("Sequence");
            alConditionCoverage7.Add("Percentage");
            alBranchCoverage7.Add("Percentage");
            alActionNumbers8.Add("Action");
            alSequenceNumbers8.Add("Sequence");
            alConditionCoverage8.Add("Percentage");
            alBranchCoverage8.Add("Percentage");
            alActionNumbers9.Add("Action");
            alSequenceNumbers9.Add("Sequence");
            alConditionCoverage9.Add("Percentage");
            alBranchCoverage9.Add("Percentage");
            alActionNumbers10.Add("Action");
            alSequenceNumbers10.Add("Sequence");
            alConditionCoverage10.Add("Percentage");
            alBranchCoverage10.Add("Percentage");

            

        } // end constructor
        

        // Open folder in which the Code Coverage Results are collected per sample of TestRuns
        // for example a folder with the results 30 TestRuns of one Action Selection Mechanism on one SUT
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            btnInstructionCoverage.Visible = false;
            btnShowBranchCoverage.Visible = false;
            btnSaveReports.Visible = false;
            btnSaveValuesList.Visible = false;

            btnShowMergedInstructionCoverage.Visible = true;
            btnShowMergedBranchCoverage.Visible = true;
            btnSaveMergeReport.Visible = true;
            brnSaveMergeValues.Visible = true;
            btnShowRuntimeActions.Visible = true;
            btnBoxPlot.Visible = true;

            btnSelectSecondSample.Visible = true;
            btnStartTTest.Visible = false;
            rbActionSamples.Visible = false;
            rbBranchSamples.Visible = false;
            rbConditionSamples.Visible = false;
            cbShowChart.Visible = false;
            cbShowBoxPlots.Visible = false;

            btnShowGraphs.Visible = false;

            btnShowMergedGraphs.Visible = false;
            btnShowMergedBranchGraphs.Visible = false;
            btnShowMergedBranchGraphsCollection.Visible = false;
            btnShowMergedGraphsCollection.Visible = false;
            btnShowInstructionGraphs1000.Visible = false;
            btnShowBranchGraphs1000.Visible = false;

            pnlGraphs.Visible = false;


            taOutput.BackColor = Color.White;

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            // PATH TO THE FOLDER WHICH OPENs BY DEFAULT
            if (path.Equals("")) path = @"C:\AAA_metrics\";
            folderDlg.SelectedPath = path;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                taOutput.Text = folderDlg.SelectedPath;
                path = folderDlg.SelectedPath;
                readMergedCoverage(folderDlg.SelectedPath);
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        } // end btnSelectFolder_Click


        // Read the Coverage Values of the individual documents within the opened folder
        // and populate the ArrayLists used
        public void readMergedCoverage(string folder)
        {
            // Clear already filled ArayLists
            alMergedConditionCoverageTestRun.Clear();
            alMergedBranchCoverageTestRun.Clear();
            alSequenceActions.Clear();
            // Write to the 0-index of the ArrayLists the info over the contents of the ArrayLists
            alMergedConditionCoverageTestRun.Add("MergedConditionCoverage");
            alMergedBranchCoverageTestRun.Add("MergedBranchCoverage");
            alSequenceActions.Add("TestRunActions");
            taOutput.Text = folder;
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("TestRun   conditionCoverage   branchCoverage   TestRunActions");
            taOutput.AppendText(Environment.NewLine);
            DirectoryInfo objDirectoryInfo = new DirectoryInfo(folder);
            FileInfo[] coverageFiles = objDirectoryInfo.GetFiles();

            int counter = 1;
            // Check every file in the Folder
            foreach (var file in coverageFiles)
            {
                // Use only the file with the text coverageMetrics in the filename, and discard the others
                if (file.Name.Contains("coverageMetrics") && !file.Name.Contains("coverageMetricsMerged"))
                {
                    string text = "";
                    string line = "";
                    int sequenceActionCounter = 0;
                    using (StreamReader sr = file.OpenText())
                    {
                        // Check every textline in the individual file
                        while ((line = sr.ReadLine()) != null)
                        {
                            // Read only the coverage values in the line starting with RunTotal
                            // these are the line with merged values
                            if (line.Substring(0, 8).Equals("RunTotal"))
                            {
                                Console.WriteLine(counter + " " + line.Substring(0, 8));
                                string[] aPartLine = line.Split('|');
                                //Console.Write(aPartLine[3].Trim(' ').Substring(0, 3));
                                if (!aPartLine[3].Trim(' ').Substring(0, 3).Equals("Sum"))
                                {
                                    alMergedConditionCoverageTestRun.Add(aPartLine[6]);
                                    alMergedBranchCoverageTestRun.Add(aPartLine[10]);
                                }
                            }
                            // Count the line starting with Sequence
                            // these are the lines with values obtained when an action is processed
                            if (line.Substring(0, 9).Equals("Sequence "))
                            {
                                sequenceActionCounter++;
                            }
                        }
                        sr.Close();
                    }
                    // write to TextArea
                    taOutput.AppendText(counter + "               " + alMergedConditionCoverageTestRun[counter] + "                            " + alMergedBranchCoverageTestRun[counter] + "                            "   + sequenceActionCounter);
                    taOutput.AppendText(Environment.NewLine);
                    alSequenceActions.Add(sequenceActionCounter);
                    counter++;
                }
            }
        } // end readMergedCoverage


        // Select the individual result file of ONE TestRun
        private void btnSelectFile_Click_1(object sender, EventArgs e)
        {
                btnInstructionCoverage.Visible = true;
                btnShowBranchCoverage.Visible = true;
                btnSaveReports.Visible = true;
                btnSaveValuesList.Visible = true;

                btnShowMergedInstructionCoverage.Visible = false;
                btnShowMergedBranchCoverage.Visible = false;
                btnSaveMergeReport.Visible = false;
                brnSaveMergeValues.Visible = false;
                btnShowRuntimeActions.Visible = false;
                btnBoxPlot.Visible = false;

                btnSelectSecondSample.Visible = false;
                btnStartTTest.Visible = false;
                rbActionSamples.Visible = false;
                rbBranchSamples.Visible = false;
                rbConditionSamples.Visible = false;
                cbShowChart.Visible = false;
            cbShowBoxPlots.Visible = false;

            btnShowGraphs.Visible = true;

            btnShowMergedGraphs.Visible = false;
            btnShowMergedBranchGraphs.Visible = false;
            btnShowMergedBranchGraphsCollection.Visible = false;
            btnShowMergedGraphsCollection.Visible = false;
            btnShowInstructionGraphs1000.Visible = false;
            btnShowBranchGraphs1000.Visible = false;

            pnlGraphs.Visible = false;
            pnlInCollectionInFolder.Visible = false;
            pnlInMergedSingleFile.Visible = false;

            taOutput.BackColor = Color.White;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";   
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                taOutput.Text = "";

                //Get the path of specified file
                filePath = openFileDialog.FileName;
                path = Path.GetDirectoryName(filePath);

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    int counter = 1;
                    string line = "";
                    string line2 = "";

                    // Read the file and display it line by line.  
                    while ((line = reader.ReadLine()) != null)
                    {
                        taOutput.AppendText(line);
                        taOutput.AppendText(Environment.NewLine);

                        // Split the line in an Array of strings, using the verticals
                        string[] aPartLine = line.Split('|');
                        // Use the first (index 0) element of this Array to determine the ArrayLists whereto line-data has to be written
                        if (aPartLine[0].Trim(' ').Equals("SequenceTotal"))
                        { // Fill the ArrayList with info about sequences
                          // System.Console.WriteLine("Sequencenummer = " + aPartLine[1].Trim(' '));
                            alSequenceNumbers.Add(aPartLine[1].Trim(' '));
                        }
                        else   if (aPartLine[0].Trim(' ').Equals("RunTotal")) 
                               { // fill the Merged coverage data ArrayLists
                                    alMergedConditionCoverage.Add(aPartLine[6].Trim(' '));
                                    alMergedBranchCoverage.Add(aPartLine[10].Trim(' '));
                            // System.Console.WriteLine("RunTotal = " + alMergedConditionCoverage[1]  + "   " + alMergedBranchCoverage[1]);
                                }
                                else    if (aPartLine[0].Equals("Sequence "))
                                        { // fill the coverage data ArrayLists
                                            alActionNumbers.Add(aPartLine[3].Trim(' '));
                                            alConditionCoverage.Add(aPartLine[9].Trim(' '));
                                            alBranchCoverage.Add(aPartLine[13].Trim(' '));
                                            // System.Console.WriteLine(aPartLine[3] + "   " + alConditionCoverage[counter] + "  " + alBranchCoverage[counter]);
                                            counter++;
                                            if (aPartLine[1].Trim(' ').Equals("1"))
                                            {
                                                alSequenceNumbers1.Add(aPartLine[1].Trim(' ')); 
                                                alActionNumbers1.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage1.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage1.Add(aPartLine[13].Trim(' '));
                                                line2 = alSequenceNumbers1[Int32.Parse(aPartLine[1].Trim(' '))] + "   " + alActionNumbers1[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage1[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage1[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }
                                            else if (aPartLine[1].Trim(' ').Equals("2"))
                                            {
                                                alSequenceNumbers2.Add(aPartLine[1].Trim(' '));
                                                alActionNumbers2.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage2.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage2.Add(aPartLine[13].Trim(' '));
                                                line2 = alActionNumbers2[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage2[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage2[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }
                                            else if (aPartLine[1].Trim(' ').Equals("3"))
                                            {
                                                alSequenceNumbers3.Add(aPartLine[1].Trim(' '));
                                                alActionNumbers3.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage3.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage3.Add(aPartLine[13].Trim(' '));
                                                line2 = alActionNumbers3[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage3[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage3[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }
                                            else if (aPartLine[1].Trim(' ').Equals("4"))
                                            {
                                                alSequenceNumbers4.Add(aPartLine[1].Trim(' '));
                                                alActionNumbers4.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage4.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage4.Add(aPartLine[13].Trim(' '));
                                                line2 = alActionNumbers4[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage4[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage4[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }
                                            if (aPartLine[1].Trim(' ').Equals("5"))
                                            {
                                                alSequenceNumbers5.Add(aPartLine[1].Trim(' '));
                                                alActionNumbers5.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage5.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage5.Add(aPartLine[13].Trim(' '));
                                                line2 = alActionNumbers5[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage5[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage5[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }
                                            else if (aPartLine[1].Trim(' ').Equals("6"))
                                            {
                                                alSequenceNumbers6.Add(aPartLine[1].Trim(' '));
                                                alActionNumbers6.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage6.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage6.Add(aPartLine[13].Trim(' '));
                                                line2 = alActionNumbers6[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage6[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage6[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }
                                            if (aPartLine[1].Trim(' ').Equals("7"))
                                            {
                                                alSequenceNumbers7.Add(aPartLine[1].Trim(' '));
                                                alActionNumbers7.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage7.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage7.Add(aPartLine[13].Trim(' '));
                                                line2 = alActionNumbers7[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage7[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage7[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }
                                            else if (aPartLine[1].Trim(' ').Equals("8"))
                                            {
                                                alSequenceNumbers8.Add(aPartLine[1].Trim(' '));
                                                alActionNumbers8.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage8.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage8.Add(aPartLine[13].Trim(' '));
                                                line2 = alActionNumbers8[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage8[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage8[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }
                                            else if (aPartLine[1].Trim(' ').Equals("9"))
                                            {
                                                alSequenceNumbers9.Add(aPartLine[1].Trim(' '));
                                                alActionNumbers9.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage9.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage9.Add(aPartLine[13].Trim(' '));
                                                line2 = alActionNumbers9[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage9[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage9[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }
                                            else if (aPartLine[1].Trim(' ').Equals("10"))
                                            {
                                                alSequenceNumbers10.Add(aPartLine[1].Trim(' '));
                                                alActionNumbers10.Add(aPartLine[3].Trim(' '));
                                                alConditionCoverage10.Add(aPartLine[9].Trim(' '));
                                                alBranchCoverage10.Add(aPartLine[13].Trim(' '));
                                                line2 = alActionNumbers10[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alConditionCoverage10[Int32.Parse(aPartLine[3].Trim(' '))] + "   " + alBranchCoverage10[Int32.Parse(aPartLine[3].Trim(' '))];
                                            }

                                        }
                                        else
                                        {
                                            line2 = "Geen goede lijnstructuur " + aPartLine[0].Trim(' ');
                                            System.Console.WriteLine("Geen goede lijnstructuur " + aPartLine[0].Trim(' '));
                                        }
                    }
                    reader.Close();
                }// end using
            } // end Open Dialog
        }// end method btnSelectFile_Click


        // Old method from the former ReadCoverage apps, maybe handy for later
        public string Reverse(string text)
        {
            if (text == null) return null;

            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }


        // Make some buttons invisible when app loads, to strenghen the user flow
        private void Form1_Load(object sender, EventArgs e)
        {
            btnInstructionCoverage.Visible = false;
            btnShowBranchCoverage.Visible = false;
            btnSaveReports.Visible = false;
            btnSaveValuesList.Visible = false;
            btnBoxPlot.Visible = false;

            btnShowMergedInstructionCoverage.Visible = false;
            btnShowMergedBranchCoverage.Visible = false;
            btnSaveMergeReport.Visible = false;
            brnSaveMergeValues.Visible = false;
            btnShowRuntimeActions.Visible = false;
            btnBoxPlot.Visible = false;

            btnSelectSecondSample.Visible = false;
            btnStartTTest.Visible = false;
            rbActionSamples.Visible = false;
            rbBranchSamples.Visible = false;
            rbConditionSamples.Visible = false;
            cbShowChart.Visible = false;
            cbShowBoxPlots.Visible = false;

            btnShowGraphs.Visible = false;

            btnShowMergedGraphs.Visible = false;
            btnShowMergedBranchGraphs.Visible = false;
            btnShowMergedBranchGraphsCollection.Visible = false;
            btnShowMergedGraphsCollection.Visible = false;
            btnShowInstructionGraphs1000.Visible = false;
            btnShowBranchGraphs1000.Visible = false;

            pnlGraphs.Visible = false;
            pnlInCollectionInFolder.Visible = false;
            pnlInMergedSingleFile.Visible = false;




        }


        // Show instruction Coverage in TextArea
        private void btnInstructionCoverage_Click(object sender, EventArgs e)
        {
            taOutput.Text = "";
            for (int index = 0; index < alConditionCoverage.Count; index++)
            {
                taOutput.AppendText(index + "         " + alActionNumbers[index] + "         " + alConditionCoverage[index]);
                taOutput.AppendText(Environment.NewLine);
            }
        }


        // Show Branch Coverage in TextArea
        private void btnShowBranchCoverage_Click(object sender, EventArgs e)
        {
            taOutput.Text = "";
            for (int index = 0; index < alBranchCoverage.Count; index++)
            {
                taOutput.AppendText(index + "          " + alActionNumbers[index] + "         " + alBranchCoverage[index]);
                taOutput.AppendText(Environment.NewLine);
            }
        }


        // Save Coverage Values to file in Same Folder where the Individual file was Read. 
        // Files including action count
        private void btnSaveReports_Click(object sender, EventArgs e)
        {
            StreamWriter writer1 = new StreamWriter(path + "\\InstructionCoverage.txt");
            StreamWriter writer2 = new StreamWriter(path + "\\BranchCoverage.txt");
            int index = 1;
            while (index < alConditionCoverage.Count)
            {
                writer1.WriteLine(index + ",  " + alActionNumbers[index] + ",  " + alConditionCoverage[index]);
                writer2.WriteLine(index + ",  " + alActionNumbers[index] + ",  " + alBranchCoverage[index]);
                index++;
            }
            writer1.Close();
            writer2.Close();
          }


        // Save Coverage Values to file in Same Folder where the Individual file was Read.
        // Files only containing the coverage values
        private void btnSaveValuesList_Click(object sender, EventArgs e)
        {
            StreamWriter writer1 = new StreamWriter(path + "\\InstructionCoverageValues.txt");
            StreamWriter writer2 = new StreamWriter(path + "\\BranchCoverageValues.txt");
            StreamWriter writer3 = new StreamWriter(path + "\\Actions.txt"); // file contains only the numer of actions
            int index = 1;
            while (index < alConditionCoverage.Count)
            {
                    writer1.WriteLine(alConditionCoverage[index]);
                    writer2.WriteLine(alBranchCoverage[index]);
                    writer3.WriteLine(index);
                    Console.WriteLine(index);
                    index++;
            }
            writer1.Close();
            writer2.Close();
            writer3.Close();
        }


        // No implementation of the Event yet
        private void taOutput_TextChanged(object sender, EventArgs e)
        {

        }

   
        // Save the values collected with merging of the individual test sequences, so the coverage values over one TestRun
        // File will be created in same folder as where the data was read
        private void btnSaveMergeReport_Click_1(object sender, EventArgs e)
        {
            StreamWriter writer1 = new StreamWriter(path + "\\MergedInstructionCoverage.txt");
            StreamWriter writer2 = new StreamWriter(path + "\\MergedBranchCoverage.txt");
            StreamWriter writer4 = new StreamWriter(path + "\\RuntimeSequenceActions.txt");
            int index = 1;
            while (index < alMergedConditionCoverageTestRun.Count)
            {
                writer1.WriteLine(index + ",  " + alMergedConditionCoverageTestRun[index]);
                writer2.WriteLine(index + ",  " + alMergedBranchCoverageTestRun[index]);
                writer4.WriteLine(index + ",  " + alSequenceActions[index]);
                index++;
            }
            writer1.Close();
            writer2.Close();
            writer4.Close();
        }

        
        // Show Merged Branch Coverage per TestRun in TextArea
        private void btnShowMergedBranchCoverage_Click(object sender, EventArgs e)
        {
            taOutput.Text = "";
            for (int index = 0; index < alMergedBranchCoverageTestRun.Count; index++)
            {
                taOutput.AppendText(index + "         " + alMergedBranchCoverageTestRun[index]);
                taOutput.AppendText(Environment.NewLine);
            }
        }


        // Save the collected Merged coverage results (sample per TestRun) to individual files
        // in same folder as where the data was collected
        private void brnSaveMergeValues_Click(object sender, EventArgs e)
        {
            StreamWriter writer1 = new StreamWriter(path + "\\MergedInstructionCoverageValues.txt");
            StreamWriter writer2 = new StreamWriter(path + "\\MergedBranchCoverageValues.txt");
            StreamWriter writer3 = new StreamWriter(path + "\\TestRuns.txt");
            StreamWriter writer4 = new StreamWriter(path + "\\RuntimeSequenceActionsValues.txt");
            int index = 1;
            while (index < alMergedConditionCoverageTestRun.Count)
            {
                writer1.WriteLine(alMergedConditionCoverageTestRun[index]);
                writer2.WriteLine(alMergedBranchCoverageTestRun[index]);
                writer3.WriteLine(index);
                writer4.WriteLine(alSequenceActions[index]);
                index++;
            }
            writer1.Close();
            writer2.Close();
            writer3.Close();
            writer4.Close();
        }


        // Show Merged Instruction Coverage per TestRun in TextArea
        private void btnShowMergedInstructionCoverage_Click(object sender, EventArgs e)
        {
            taOutput.Text = "";
            for (int index = 0; index < alMergedConditionCoverageTestRun.Count; index++)
            {
                taOutput.AppendText(index + "         " + alMergedConditionCoverageTestRun[index]);
                taOutput.AppendText(Environment.NewLine);
            }
        }


        // Show number of actions used per TestRun
        private void btnShowRuntimeActions_Click(object sender, EventArgs e)
        {
            taOutput.Text = "";
            for (int index = 0; index <  alSequenceActions.Count; index++)
            {
                taOutput.AppendText(index + "         " + alSequenceActions[index]);
                taOutput.AppendText(Environment.NewLine);
            }
        }


        // Method that starts the Welch T-Test after the Click event is generated on button btnStartTTest
        private void btnStartTTest_Click(object sender, EventArgs e)
        {
            double p_Value = 1; // declaration and default initialization of the P-Valu (default is Ho cannot be rejected (p==1))
            // Starting of the T-Test is only posible when one of the radion buttons is selected
            // The radio buttons are used to select the samples (included in the ArrayLists) on which the Test will be done
            if (rbConditionSamples.Checked == true)
            { // compare the Instruction Coverage Samples
                taOutput.Text = WelchTTest.initTTest(alMergedConditionCoverageTestRun, alMergedConditionCoverageTestRun2) + Environment.NewLine;
                p_Value = WelchTTest.getPValue();

                //Meta.Numerics
                double[] aMergedInstructionCoverageTestRun = new double[alMergedConditionCoverageTestRun.Count - 1];
                double[] aMergedInstructionCoverageTestRun2 = new double[alMergedConditionCoverageTestRun2.Count - 1];
                // Store the values of the received ArrayLists with the sample data in an Array
                for (int i = 0; i < aMergedInstructionCoverageTestRun.Length; ++i)
                { //iterate over the elements of the list
                    aMergedInstructionCoverageTestRun[i] = Double.Parse(alMergedConditionCoverageTestRun[i + 1].ToString()); //store each element as a double in the array
                    aMergedInstructionCoverageTestRun2[i] = Double.Parse(alMergedConditionCoverageTestRun2[i + 1].ToString());
                }
                TestResult mannWhitney = Univariate.MannWhitneyTest(aMergedInstructionCoverageTestRun, aMergedInstructionCoverageTestRun2);
                Console.WriteLine($"{mannWhitney.Statistic.Name} = {mannWhitney.Statistic.Value}");
                Console.WriteLine($"{mannWhitney.Type} P = {mannWhitney.Probability}");
                double U_value = mannWhitney.Statistic.Value;
                double p_value = mannWhitney.Probability;
                Console.WriteLine("U is " + U_value);
                Console.WriteLine("P is " + p_value);
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText("The two samples are also tested with the Mann-Whitney U-Test.");
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText("For the implementation of this test we used the C# Meta.Numerics framework.");
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText("The U values is " + U_value);
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText("The P-value coming from the Mann-Whitney U-Test is " + p_value);
                taOutput.AppendText(Environment.NewLine);
                if (p_value < 0.05)
                {
                    taOutput.AppendText("This means that we can assume that there is a significant difference between the samples coming from the two Action Selection Mechanisms");
                    taOutput.AppendText(Environment.NewLine);
                    taOutput.AppendText("So on basis of the Mann-Whitney U-Test we can reject the NullHypotheses which states there is no difference.");
                }
                else
                {
                    taOutput.AppendText("This means that we cannot reject the NullHypotheses. Because the test shows no significant difference between the samples coming from the two Action Selection Mechanisms");
                    taOutput.AppendText(Environment.NewLine);
                    taOutput.AppendText("So on basis of the Mann-Whitney U-Test we cannot reject the NullHypotheses which states there is no difference.");
                }





                if (cbShowChart.Checked == true)
                {
                    Chart chart = new Chart();
                    chart.Show();
                    //chart.showChart(alMergedConditionCoverageTestRun, alMergedConditionCoverageTestRun2);
                    chart.showChart(alMergedConditionCoverageTestRun, alMergedConditionCoverageTestRun2, "Line");
                }
                if (cbShowBoxPlots.Checked == true)
                {
                    // Prepare the BoxPlots
                    double[] yValues = new double[alMergedConditionCoverageTestRun.Count - 1];
                    double[] yValues2 = new double[alMergedConditionCoverageTestRun2.Count - 1];
                    // Store the values of the received ArrayLists with the sample data in an Array
                    for (int i = 0; i < yValues.Length; ++i)
                    { //iterate over the elements of the list
                        yValues[i] = Double.Parse(alMergedConditionCoverageTestRun[i + 1].ToString()); //store each element as a double in the array
                        yValues2[i] = Double.Parse(alMergedConditionCoverageTestRun2[i + 1].ToString());
                    }
                    BoxPlotChart bpc = new BoxPlotChart(yValues, yValues2);
                    bpc.Show();
                }
            }
            else if (rbBranchSamples.Checked == true)
            { // compare the Branch Coverage Samples
                taOutput.Text = WelchTTest.initTTest(alMergedBranchCoverageTestRun, alMergedBranchCoverageTestRun2) + Environment.NewLine;
                p_Value = WelchTTest.getPValue();

                //Meta.Numerics
                double[] aMergedBranchCoverageTestRun = new double[alMergedBranchCoverageTestRun.Count - 1];
                double[] aMergedBranchCoverageTestRun2 = new double[alMergedBranchCoverageTestRun2.Count - 1];
                // Store the values of the received ArrayLists with the sample data in an Array
                for (int i = 0; i < aMergedBranchCoverageTestRun.Length; ++i)
                { //iterate over the elements of the list
                    aMergedBranchCoverageTestRun[i] = Double.Parse(alMergedBranchCoverageTestRun[i + 1].ToString()); //store each element as a double in the array
                    aMergedBranchCoverageTestRun2[i] = Double.Parse(alMergedBranchCoverageTestRun2[i + 1].ToString());
                }
                TestResult mannWhitney = Univariate.MannWhitneyTest(aMergedBranchCoverageTestRun, aMergedBranchCoverageTestRun2);
                Console.WriteLine($"{mannWhitney.Statistic.Name} = {mannWhitney.Statistic.Value}");
                Console.WriteLine($"{mannWhitney.Type} P = {mannWhitney.Probability}");
                double U_value = mannWhitney.Statistic.Value;
                double p_value = mannWhitney.Probability;
                Console.WriteLine("U is " + U_value);
                Console.WriteLine("P is " + p_value);
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText("The two samples are also tested with the Mann-Whitney U-Test.");
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText("For the implementation of this test we used the C# Meta.Numerics framework.");
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText("The U values is " + U_value);
                taOutput.AppendText(Environment.NewLine);
                taOutput.AppendText("The P-value coming from the Mann-Whitney U-Test is " + p_value);
                taOutput.AppendText(Environment.NewLine);
                if (p_value < 0.05)
                {
                    //if (p_Value >= 0.05) taOutput.ForeColor = Color.Green;
                    taOutput.AppendText("This means that we can assume that there is a significant difference between the samples coming from the two Action Selection Mechanisms");
                    taOutput.AppendText(Environment.NewLine);
                    taOutput.AppendText("So on basis of the Mann-Whitney U-Test we can reject the NullHypotheses which states there is no difference.");
                }
                else
                {
                    //if (p_Value < 0.05) taOutput.ForeColor = Color.DarkRed;
                    taOutput.AppendText("This means that we cannot reject the NullHypotheses. Because the test shows no significant difference between the samples coming from the two Action Selection Mechanisms");
                    taOutput.AppendText(Environment.NewLine);
                    taOutput.AppendText("So on basis of the Mann-Whitney U-Test we cannot reject the NullHypotheses which states there is no difference.");
                }





                if (cbShowChart.Checked == true)
                {
                    Chart chart = new Chart();
                    chart.Show();
                    //chart.showChart(alMergedBranchCoverageTestRun, alMergedBranchCoverageTestRun2);
                    chart.showChart(alMergedBranchCoverageTestRun, alMergedBranchCoverageTestRun2, "BoxPlots");
                }
                if (cbShowBoxPlots.Checked == true)
                {
                    // Prepare the BoxPlots
                    double[] yValues = new double[alMergedBranchCoverageTestRun.Count - 1];
                    double[] yValues2 = new double[alMergedBranchCoverageTestRun2.Count - 1];
                    // Store the values of the received ArrayLists with the sample data in an Array
                    for (int i = 0; i < yValues.Length; ++i)
                    { //iterate over the elements of the list
                        yValues[i] = Double.Parse(alMergedBranchCoverageTestRun[i + 1].ToString()); //store each element as a double in the array
                        yValues2[i] = Double.Parse(alMergedBranchCoverageTestRun2[i + 1].ToString());
                    }
                    BoxPlotChart bpc = new BoxPlotChart(yValues, yValues2);
                    bpc.Show();
                }
            }
            else if (rbActionSamples.Checked == true)
            { // compare the Samples with the reach number of actions 
                taOutput.Text = WelchTTest.initTTest(alSequenceActions, alSequenceActions2) + Environment.NewLine;
                p_Value = WelchTTest.getPValue();
                if (cbShowChart.Checked == true)
                {
                    Chart chart = new Chart();
                    chart.Show();
                    //chart.showChart(alSequenceActions, alSequenceActions2);
                    chart.showChart(alSequenceActions, alSequenceActions2, "Line");
                }
            }
            else
            { 
                // do nothing
                return;
            }

            /*
            // Extra focus on the P-value, it is also showed in the TTestProgram class
           // taOutput.AppendText("P-VALUE = " + p_Value.ToString()); 
            if (p_Value < 0.05)
            {
                taOutput.BackColor = Color.LightGreen;
            }
            else
            {
                taOutput.BackColor = Color.LightCoral;
            }
            */
        } // end btnStartTTest_Click


        // Open folder in which the Code Coverage Results are collected per sample of ANOTHER set of TestRun
        // for example a folder with the results 30 TestRuns of another Action Selection Mechanism on the same SUT
        private void btnSelectSecondSample_Click(object sender, EventArgs e)
        {
            // Show the Button and RadioButtons needed to start the Welch TTest
            btnStartTTest.Visible = true;
            rbActionSamples.Visible = true;
            rbBranchSamples.Visible = true;
            rbConditionSamples.Visible = true;
            cbShowChart.Visible = true;
            cbShowBoxPlots.Visible = true;
            //taOutput.BackColor = Color.White;

            //taOutput.BackColor = Color.White;

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            if (path.Equals("")) path = @"C:\AAA_metrics\";
            folderDlg.SelectedPath = path;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                taOutput.Text = folderDlg.SelectedPath;
                path = folderDlg.SelectedPath;
                readMergedCoverage2(folderDlg.SelectedPath);
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        } // end btnSelectSecondSample_Click

        // Read the Coverage Values of the individual documents within the opened folder
        // and populate the ArrayLists used
        public void readMergedCoverage2(string folder)
        {
            // Clear already filled ArayLists
            alMergedConditionCoverageTestRun2.Clear();
            alMergedBranchCoverageTestRun2.Clear();
            alSequenceActions2.Clear();
            // Write to the 0-index of the ArrayLists the info over the contents of the ArrayLists
            alMergedConditionCoverageTestRun2.Add("MergedConditionCoverage");
            alMergedBranchCoverageTestRun2.Add("MergedBranchCoverage");
            alSequenceActions2.Add("TestRunActions");
            taOutput.Text = folder;
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("TestRun   conditionCoverage   branchCoverage   TestRunActions");
            taOutput.AppendText(Environment.NewLine);
            DirectoryInfo objDirectoryInfo = new DirectoryInfo(folder);
            FileInfo[] coverageFiles = objDirectoryInfo.GetFiles();

            int counter = 1;
            // Check every file in the Folder
            foreach (var file in coverageFiles)
            {
                // Use only the file with the text coverageMetrics in the filename, and discard the others
                if (file.Name.Contains("coverageMetrics") && !file.Name.Contains("coverageMetricsMerged"))
                {
                    string text = "";
                    string line = "";
                    int sequenceActionCounter2 = 0;
                    using (StreamReader sr = file.OpenText())
                    {
                        // Check every textline in the individual file
                        while ((line = sr.ReadLine()) != null)
                        {
                            // Read only the coverage values in the line starting with RunTotal
                            // these are the line with merged values
                            if (line.Substring(0, 8).Equals("RunTotal"))
                            {
                                string[] aPartLine = line.Split('|');
                                alMergedConditionCoverageTestRun2.Add(aPartLine[6]);
                                alMergedBranchCoverageTestRun2.Add(aPartLine[10]);
                            }
                            // Count the line starting with Sequence
                            // these are the lines with values obtained when an action is processed
                            if (line.Substring(0, 9).Equals("Sequence "))
                            {
                                sequenceActionCounter2++;
                            }
                        }
                        sr.Close();
                    }
                    // write to TextArea
                    taOutput.AppendText(counter + "               " + alMergedConditionCoverageTestRun2[counter] + "                            " + alMergedBranchCoverageTestRun2[counter] + "                            " + sequenceActionCounter2);
                    taOutput.AppendText(Environment.NewLine);
                    alSequenceActions2.Add(sequenceActionCounter2);
                    counter++;
                }
            }
        } // end readMergedCoverage2


        // Clear the TextArea
        private void btnClear_Click(object sender, EventArgs e)
        {
            taOutput.Text = "";
        }

        // Show the graphs of 10 condition coverage ArrayLists
        private void btnShowGraphs_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
            chart.showChartSeq(alConditionCoverage1, alConditionCoverage2, alConditionCoverage3, alConditionCoverage4,
                            alConditionCoverage5, alConditionCoverage6, alConditionCoverage7, alConditionCoverage8,
                            alConditionCoverage9, alConditionCoverage10);
        }


        // 
        private void btnSelectMergedFile_Click(object sender, EventArgs e)
        {
            btnInstructionCoverage.Visible = false;
            btnShowBranchCoverage.Visible = false;
            btnSaveReports.Visible = false;
            btnSaveValuesList.Visible = false;

            btnShowMergedInstructionCoverage.Visible = false;
            btnShowMergedBranchCoverage.Visible = false;
            btnSaveMergeReport.Visible = false;
            brnSaveMergeValues.Visible = false;
            btnShowRuntimeActions.Visible = false;
            btnBoxPlot.Visible = false;

            btnSelectSecondSample.Visible = false;
            btnStartTTest.Visible = false;
            rbActionSamples.Visible = false;
            rbBranchSamples.Visible = false;
            rbConditionSamples.Visible = false;
            cbShowChart.Visible = false;
            cbShowBoxPlots.Visible = false;

            btnShowGraphs.Visible = false;

            btnShowMergedGraphs.Visible = true;
            btnShowMergedBranchGraphs.Visible = true;
            btnShowMergedBranchGraphsCollection.Visible = false;
            btnShowMergedGraphsCollection.Visible = false;
            btnShowInstructionGraphs1000.Visible = false;
            btnShowBranchGraphs1000.Visible = false;

            pnlGraphs.Visible = false;
            pnlInCollectionInFolder.Visible = false;
            pnlInMergedSingleFile.Visible = true;



            taOutput.BackColor = Color.White;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\AAA_Metrics\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (!keepOld)
            {
                alActionNumbers.Clear();
                alConditionCoverage.Clear();
                alBranchCoverage.Clear();
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                taOutput.Text = "";

                //Get the path of specified file
                filePath = openFileDialog.FileName;
                path = Path.GetDirectoryName(filePath);

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    int counter = 1;
                    string line = "";
                    string line2 = "";

                    // Read the file and display it line by line.  
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line in an Array of strings, using the verticals
                        string[] aPartLine = line.Split('|');
                        // Use the first (index 0) element of this Array to determine the ArrayLists whereto line-data has to be written
                        if (aPartLine[0].Equals("Merged Sequence "))
                        { // fill the coverage data ArrayLists
                            alActionNumbers.Add(aPartLine[3].Trim(' '));
                            alConditionCoverage.Add(aPartLine[9].Trim(' '));
                            alBranchCoverage.Add(aPartLine[13].Trim(' '));
                        }
                        else
                        {
                            line2 = "Geen goede lijnstructuur " + aPartLine[0].Trim(' ');
                            System.Console.WriteLine("Geen goede lijnstructuur " + aPartLine[0].Trim(' '));
                        }
                        // System.Console.WriteLine(counter + "   " + alActionNumbers[counter] + "    " + alConditionCoverage[counter] + "  " + alBranchCoverage[counter]);
                        counter++;
                    }
                    reader.Close();
                }// end using
            } // end Open Dialog


            if (!File.Exists(path + "\\300MergedInstructionCoverage.txt"))
            {
                // Create a file to write to.
                StreamWriter sw = File.CreateText(path + "\\300MergedInstructionCoverage.txt");
                sw.Close();
            }

            if (!File.Exists(path + "\\300MergedBranchCoverage.txt"))
            {
                // Create a file to write to.
                StreamWriter sw = File.CreateText(path + "\\300MergedBranchCoverage.txt");
                sw.Close();
            }

            //StreamWriter writer1 = new StreamWriter(path + "\\MergedCoverage.txt");
            //StreamWriter writer4 = new StreamWriter(path + "\\300MergedBranchCoverage.txt");
            //int index = 1;

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path + "\\300MergedInstructionCoverage.txt"))
            {
                // while (index < alConditionCoverage.Count)
                //{
                // writer1.WriteLine(alActionNumbers[index] + "  " + alConditionCoverage[index] + "  " + alBranchCoverage[index]);
                //writer2.WriteLine(index + "  " + alActionNumbers[index] + "  " + alBranchCoverage[index]);
                //index++;
                //}
                //sw.WriteLine(300 + "  " + alActionNumbers[300] + "  " + alConditionCoverage[300] + "  " + alBranchCoverage[300]);
                sw.WriteLine(alConditionCoverage[300]);
                sw.Close();
            }

            using (StreamWriter sw = File.AppendText(path + "\\300MergedBranchCoverage.txt"))
            {
                //sw.WriteLine(300 + "  " + alActionNumbers[300] + "  " + alConditionCoverage[300] + "  " + alBranchCoverage[300]);
                sw.WriteLine(alBranchCoverage[300]);
                sw.Close();
            }


            // writer2.Close();




        } // ens btnSelectMergedFile_Click

        // Click button to show the Merged Instruction Coverage graphs
        private void btnShowMergedGraphs_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
            chart.showChart(alConditionCoverage);
        }

        // Select the folder with the Merged Coverage files
        private void btnSelectMergedFolder_Click(object sender, EventArgs e)
        {
            btnInstructionCoverage.Visible = false;
            btnShowBranchCoverage.Visible = false;
            btnSaveReports.Visible = false;
            btnSaveValuesList.Visible = false;

            btnShowMergedInstructionCoverage.Visible = false;
            btnShowMergedBranchCoverage.Visible = false;
            btnSaveMergeReport.Visible = false;
            brnSaveMergeValues.Visible = false;
            btnShowRuntimeActions.Visible = false;
            btnBoxPlot.Visible = false;

            btnSelectSecondSample.Visible = false;
            btnStartTTest.Visible = false;
            rbActionSamples.Visible = false;
            rbBranchSamples.Visible = false;
            rbConditionSamples.Visible = false;
            cbShowChart.Visible = false;
            cbShowBoxPlots.Visible = false;

            btnShowGraphs.Visible = false;

            btnShowMergedGraphs.Visible = false;
            btnShowMergedBranchGraphs.Visible = false;
            btnShowMergedBranchGraphsCollection.Visible = true;
            btnShowMergedGraphsCollection.Visible = true;
            btnShowInstructionGraphs1000.Visible = true;
            btnShowBranchGraphs1000.Visible = true;

            pnlGraphs.Visible = true;
            pnlInCollectionInFolder.Visible = true;
            pnlInMergedSingleFile.Visible = false;

            taOutput.BackColor = Color.White;

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            // PATH TO THE FOLDER WHICH OPENs BY DEFAULT
            if (path.Equals("")) path = @"C:\AAA_metrics\";
            folderDlg.SelectedPath = path;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                taOutput.Text = folderDlg.SelectedPath;
                path = folderDlg.SelectedPath;
                readMergedCoverage3(folderDlg.SelectedPath);
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        // Read the Coverage Values of the individual documents within the opened folder
        // and populate the ArrayLists used
        public void readMergedCoverage3(string folder)
        {
            /*
            // Clear already filled ArayLists
            alMergedConditionCoverageTestRun.Clear();
            alMergedBranchCoverageTestRun.Clear();
            alSequenceActions.Clear();
            
            // Write to the 0-index of the ArrayLists the info over the contents of the ArrayLists
            alMergedConditionCoverageTestRun.Add("MergedConditionCoverage");
            alMergedBranchCoverageTestRun.Add("MergedBranchCoverage");
            alSequenceActions.Add("TestRunActions");
            */

            taOutput.Text = folder;
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText(Environment.NewLine);
            //taOutput.AppendText("TestRun   conditionCoverage   branchCoverage   TestRunActions");
            taOutput.AppendText(Environment.NewLine);
            DirectoryInfo objDirectoryInfo = new DirectoryInfo(folder);
            FileInfo[] coverageFiles = objDirectoryInfo.GetFiles();

            // Make total ArrayList in which Sequence Arraylist are added as a collection
            alalInstructionMerged.Clear();
            alalBrancheMerged.Clear();
            int counter = 0;

            int timeTrial = 0;
            int timeTestRun = 0;

            // Check every file in the Folder
            foreach (var file in coverageFiles)
            {
                int runNumber = 0;
                

                // Use only the file with the text coverageMetricsMerge in the filename, and discard the others
                if (file.Name.Contains("coverageMetricsMerged"))
                {
                    // Make local ArrayList in which te sequence data are stored
                    ArrayList alInstructionMerged = new ArrayList();
                    ArrayList alBranchMerged = new ArrayList();
                    // add the local ArrayList to the total ArrayList collection
                    alalInstructionMerged.Add(alInstructionMerged);
                    alalBrancheMerged.Add(alBranchMerged);
                    string text = "";
                    string line = "";
                    string line2 = "";
                    counter = 0;
                    //int sequenceActionCounter = 0;
                    //Console.WriteLine(folder + "  " + file);
                    using (StreamReader sr = file.OpenText())
                    {

                        // Check every textline in the individual file
                        while ((line = sr.ReadLine()) != null)
                        {
                            // Split the line in an Array of strings, using the verticals
                            string[] aPartLine = line.Split('|');
                            // Use the first (index 0) element of this Array to determine the ArrayLists whereto line-data has to be written
                            if (aPartLine[0].Equals("Merged Sequence "))
                            { // fill the coverage data ArrayLists


                                /*
                                Console.WriteLine("Counter is " + counter);
                                if (counter > 0)
                                {
                                    Console.WriteLine("" + Convert.ToDouble(alInstructionMerged[counter - 1]));
                                    if (Convert.ToDouble(aPartLine[9].Trim(' ')) > Convert.ToDouble(alInstructionMerged[counter-1]))
                                    {
                                        alInstructionMerged.Add(aPartLine[9].Trim(' '));
                                        Console.WriteLine("alInstructionMerged is " + alInstructionMerged[counter-1]);
                                    }
                                    else
                                    {
                                        alInstructionMerged.Add(alInstructionMerged[counter - 1]);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(counter);
                                    */
                                    alInstructionMerged.Add(aPartLine[9].Trim(' '));
                                /*
                                    Console.WriteLine("alInstructionMerged is " + alInstructionMerged[counter]);
                                }
                                */
                                 alBranchMerged.Add(aPartLine[13].Trim(' '));

                                timeTestRun = Int32.Parse(aPartLine[5].Trim(' '));
                            }
                            else
                            {
                                line2 = "Geen goede lijnstructuur " + aPartLine[0].Trim(' ');
                                System.Console.WriteLine("Geen goede lijnstructuur " + aPartLine[0].Trim(' '));
                            }
                            //System.Console.WriteLine(counter + "   " + alActionNumbers[counter] + "    " + alConditionCoverage[counter] + "  " + alBranchCoverage[counter]);
                            counter++;
                        }
                        sr.Close();
                    }

                     //taOutput.AppendText(Environment.NewLine);
                    //alSequenceActions.Add(sequenceActionCounter);
                    //counter++;
                    runNumber++;
                    taOutput.AppendText(timeTestRun.ToString());
                    taOutput.AppendText(Environment.NewLine);
                    timeTrial += timeTestRun;
                }

            }
            // write to TextArea
            // taOutput.Text = timeTestRun.ToString();
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Time of Trial (total time of test runs) " + timeTrial);
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Done Reading.");
        } // end readMergedCoverage3


        // Show and save the collection of Instruction Coveage files in a folder
        private void btnShowMergedGraphsCollection_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
            chart.showChartCollectionOfArrayLists(alalInstructionMerged);
            SaveGraphs.saveChartCollectionOfArrayLists(alalInstructionMerged, "instruction", path);
            Chart chart1 = new Chart();
            chart1.Show();
            chart1.showMeanValuesCollectionOfArrayLists(alalInstructionMerged);
        }

        // Show and save the collection of Branch Coveage files in a folder
        private void btnShowMergedBranchGraphsCollection_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
            chart.showChartCollectionOfArrayLists(alalBrancheMerged);
            SaveGraphs.saveChartCollectionOfArrayLists(alalBrancheMerged, "branch", path);
            Chart chart1 = new Chart();
            chart1.Show();
            chart1.showMeanValuesCollectionOfArrayLists(alalBrancheMerged);
        }

        // Show the first actions of the collection of Instruction Coveage files in a folder
        private void btnShowInstructionGraphs1000_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
            chart.show1000ChartCollectionOfArrayLists(alalInstructionMerged, 300); 
        }

        // Show the first actions of the collection of Branch Coveage files in a folder
        private void btnShowBranchGraphs1000_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
            chart.show1000ChartCollectionOfArrayLists(alalBrancheMerged, 300);
        }

        private void btnKeepOld_Click(object sender, EventArgs e)
        {
            if (!keepOld)
            {
                keepOld = true;
                btnKeepOld.BackColor = Color.LightPink;
            }
            else
            {
                keepOld = false;
                btnKeepOld.BackColor = Color.LightGray;
            }
        }

        private void btnShowMergedBranchGraphs_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
            chart.showChart(alBranchCoverage);
        }



        //--------------------------------------------------------------------------------------------------------
        private void btnShowDifferentiateInstructionCoverage_Click(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
           // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            string tekst = "";

            // Maak van de ArryLists een Array
            double[] alx = new double[alActionNumbers.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            /*
            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
            }
            */
            double[] aly = new double[alConditionCoverage.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double) i;
                aly[i] = Double.Parse(alConditionCoverage[i + 1].ToString()); //store each element as a double in the array
            }

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aly);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         "  + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
               // taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                aSyDx[i] = Sydx[i];
            }
            double max = aDyDx.Max();
            int numberActions = 200;

            Chart chart = new Chart();
            chart.Show();
            // Laat gebruiker numberAction, beginAction en Type Chart kiezen
            chart.showChart(aX, aY, aDyDx, 0, 100, 0, numberActions, "Area"); 
            /*
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 310);
            */
        }

        //--------------------------------------------------------------------------------------------------------
        private void brnShowIntegrateInstructionCoverage_Click(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
            // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            string tekst = "";

            // Maak van de ArryLists een Array
            double[] alx = new double[alActionNumbers.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            /*
            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
            }
            */
            double[] aly = new double[alConditionCoverage.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i;
                aly[i] = Double.Parse(alConditionCoverage[i + 1].ToString()); //store each element as a double in the array
            }

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aly);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         " + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                //Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5} {Sydx[i],column_width:G5} {Math.Log(Sydx[i]),column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
                //taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                //aSyDx[i] = Sydx[i];
                aSyDx[i] = Math.Log(Sydx[i]);
                if (i >= 1)
                {
                    aSyDx[i] = Math.Log(Sydx[i]);
                }
                else
                {
                    aSyDx[i] = 0;
                }
                
                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5} {Sydx[i],column_width:G5} {aSyDx[i],column_width:G5} {Math.Log(aSyDx[i]),column_width:G5}");
            }
            double max = aSyDx.Max();

            //max = aSyDx[2999];
            max = 90;
            
            int numberActions = 2999;
            /*
            Chart chart = new Chart();
            chart.Show();
            chart.showChart(aX, aY, aDyDx, 35);
            */
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 0, max, 0, numberActions, "Line");// Laat gebruiker numberAction, beginAction en Type Chart kiezen
            
        }

        //----------------------------------------------------------------------------------------------------------
        private void btnShowDifferentiateBranchCoverage_Click(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
            // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            string tekst = "";

            // Maak van de ArryLists een Array
            double[] alx = new double[alActionNumbers.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            /*
            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
            }
            */
            double[] aly = new double[alConditionCoverage.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i;
                aly[i] = Double.Parse(alConditionCoverage[i + 1].ToString()); //store each element as a double in the array
            }

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aly);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         "  + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
                // taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                aSyDx[i] = Sydx[i];
            }
            double max = aDyDx.Max();
            int numberActions = 200;

            

            Chart chart = new Chart();
            chart.Show();
            // Laat gebruiker numberAction, beginAction en Type Chart kiezen
            chart.showChart(aX, aY, aDyDx, 0, max, 0, numberActions, "Area");
            /*
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 310);
            */
        }


        //---------------------------------------------------------------------------------------------------
        private void brnShowIntegrateInstructionCoverage_Click_1(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
            // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            string tekst = "";

            // Maak van de ArryLists een Array
            double[] alx = new double[alActionNumbers.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            /*
            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
            }
            */
            double[] aly = new double[alConditionCoverage.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i;
                aly[i] = Double.Parse(alConditionCoverage[i + 1].ToString()); //store each element as a double in the array
            }

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aly);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         " + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                //Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5} {Sydx[i],column_width:G5} {Math.Log(Sydx[i]),column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
                //taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                //aSyDx[i] = Sydx[i];
                aSyDx[i] = Math.Log(Sydx[i]);
                if (i >= 1)
                {
                    aSyDx[i] = Math.Log(Sydx[i]);
                }
                else
                {
                    aSyDx[i] = 0;
                }

                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5} {Sydx[i],column_width:G5} {aSyDx[i],column_width:G5} {Math.Log(aSyDx[i]),column_width:G5}");
            }
            double max = aSyDx.Max();

            //max = aSyDx[2999];
            max = 90;
            int numberActions = 2999;

            
            /*
            Chart chart = new Chart();
            chart.Show();
            chart.showChart(aX, aY, aDyDx, 35);
            */
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 0, max, 0, numberActions, "Line");// Laat gebruiker numberAction, beginAction en Type Chart kiezen

        }

        //---------------------------------------------------------------------------------------------------
        private void btnShowDifferentiateBranchCoverage_Click_1(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
            // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            string tekst = "";

            // Maak van de ArryLists een Array
            double[] alx = new double[alActionNumbers.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            /*
            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
            }
            */
            double[] aly = new double[alBranchCoverage.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i;
                aly[i] = Double.Parse(alBranchCoverage[i + 1].ToString()); //store each element as a double in the array
            }

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aly);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         "  + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
                // taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                aSyDx[i] = Sydx[i];
            }
            double max = aDyDx.Max();
            int numberActions = 200;

            Chart chart = new Chart();
            chart.Show();
            // Laat gebruiker numberAction, beginAction en Type Chart kiezen
            chart.showChart(aX, aY, aDyDx, 0, 100, 0, numberActions, "Area");
            /*
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 310);
            */
        }






        //--------------------------------------------------------------------------------------------
        // DEZE IS IN GEBRUIK
        private void btnShowDifferentiateInstructionCoverageMap_Click(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
            // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            ArrayList alTotalValues = new ArrayList();
            ArrayList alMeanValues = new ArrayList();
            double[] aTotalValues = new double[3000];
            double[] aMeanValues = new double[3000];
            for (int countAL = 0; countAL < alalInstructionMerged.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalInstructionMerged[countAL];

                for (int i = 0; i < al.Count && i < 3000; i++)
                {
                    aTotalValues[i] += Convert.ToDouble(al[i]);
                }
            }
            for (int i = 0; i < 3000; i++)
            {
                aMeanValues[i] = aTotalValues[i] / alalInstructionMerged.Count;
            }



            string tekst = "";

            // Maak van de ArryLists een Array
            // double[] alx = new double[alActionNumbers.Count - 1];
            double[] alx = new double[3000];
            // Store the values of the received ArrayLists with the sample data in an Array
            
            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                //alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
                alx[i] = (double) i; //store each element as a double in the array
            }
            
            /*
            double[] aly = new double[aMeanValues.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i;
                aly[i] = Double.Parse(alConditionCoverage[i + 1].ToString()); //store each element as a double in the array
            }
            */

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aMeanValues);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         "  + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
                // taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                aSyDx[i] = Sydx[i];
            }
            double max = aDyDx.Max();
            int numberActions = 200;

            string type = "Line";
            if (rbLine.Checked) type = "Line";
            else if (rbSpine.Checked) type = "Spline";
            else if (rbKagi.Checked) type = "Kagi";
            else if (rbColumn.Checked) type = "Column";
            else if (rbCandlestick.Checked) type = "Candlestick";
            else if (rbArea.Checked) type = "Area";
            else type = "Line";

            int start = 0;
            int end = 2999;
            if (!Int32.TryParse(tbStart.Text, out start)) start=0;
            if (!Int32.TryParse(tbEnd.Text, out end)) end = 200; ;
            double low = 0;
            //double high = max;

            if (!Double.TryParse(tbLow.Text, out low)) low = 0;
            if (!Double.TryParse(tbHigh.Text, out max)) max = aDyDx.Max(); 


            Console.WriteLine("begin van grafiek " + start);
            Console.WriteLine("einde van grafiek" + end);

            Chart chart = new Chart();
            chart.Show();
            // Laat gebruiker numberAction, beginAction en Type Chart kiezen
            chart.showChart(aX, aY, aDyDx, low, max, start, end, type);
            /*
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 310);
            */
        }

        //--------------------------------------------------------------------------------------------
        // DEZE IS IN GEBRUIK
        private void bnShowIntegrateInstructionCoverageMap_Click(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
            // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            ArrayList alTotalValues = new ArrayList();
            ArrayList alMeanValues = new ArrayList();
            double[] aTotalValues = new double[3000];
            double[] aMeanValues = new double[3000];
            for (int countAL = 0; countAL < alalInstructionMerged.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalInstructionMerged[countAL];

                for (int i = 0; i < al.Count && i < 3000; i++)
                {
                    aTotalValues[i] += Convert.ToDouble(al[i]);
                }
            }
            for (int i = 0; i < 3000; i++)
            {
                aMeanValues[i] = aTotalValues[i] / alalInstructionMerged.Count;
            }



            string tekst = "";

            // Maak van de ArryLists een Array
            // double[] alx = new double[alActionNumbers.Count - 1];
            double[] alx = new double[3000];
            // Store the values of the received ArrayLists with the sample data in an Array

            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                //alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
                alx[i] = (double)i; //store each element as a double in the array
            }

            /*
            double[] aly = new double[aMeanValues.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i;
                aly[i] = Double.Parse(alConditionCoverage[i + 1].ToString()); //store each element as a double in the array
            }
            */

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aMeanValues);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         "  + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {Sydx[i],column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
                // taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                //aSyDx[i] = Sydx[i];
                aSyDx[i] = Math.Log(Sydx[i]);
                if (i >= 1)
                {
                    aSyDx[i] = Math.Log(Sydx[i]);
                }
                else
                {
                    aSyDx[i] = 0;
                }
            }
            double max = aSyDx.Max();
            int numberActions = 200;

            string type = "Line";
            if (rbLine.Checked) type = "Line";
            else if (rbSpine.Checked) type = "Spline";
            else if (rbKagi.Checked) type = "Kagi";
            else if (rbColumn.Checked) type = "Column";
            else if (rbCandlestick.Checked) type = "Candlestick";
            else if (rbArea.Checked) type = "Area";
            else type = "Line";

            int start = 0;
            int end = 2999;
            if (!Int32.TryParse(tbStart.Text, out start)) start = 0;
            if (!Int32.TryParse(tbEnd.Text, out end)) end = 200; ;
            double low = 0;
            //double high = max;

            if (!Double.TryParse(tbLow.Text, out low)) low = 0;
            if (!Double.TryParse(tbHigh.Text, out max)) max = aSyDx.Max();


            Console.WriteLine("begin van grafiek " + start);
            Console.WriteLine("einde van grafiek" + end);

            Chart chart = new Chart();
            chart.Show();
            // Laat gebruiker numberAction, beginAction en Type Chart kiezen
            chart.showChart(aX, aY, aSyDx, low, max, start, end, type);
            /*
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 310);
            */
        }



        private void btnShowDifferentiateBranchCoverageMap_Click(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
            // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            ArrayList alTotalValues = new ArrayList();
            ArrayList alMeanValues = new ArrayList();
            double[] aTotalValues = new double[3000];
            double[] aMeanValues = new double[3000];
            for (int countAL = 0; countAL < alalBrancheMerged.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalBrancheMerged[countAL];

                for (int i = 0; i < al.Count && i < 3000; i++)
                {
                    aTotalValues[i] += Convert.ToDouble(al[i]);
                }
            }
            for (int i = 0; i < 3000; i++)
            {
                aMeanValues[i] = aTotalValues[i] / alalBrancheMerged.Count;
            }



            string tekst = "";

            // Maak van de ArryLists een Array
            // double[] alx = new double[alActionNumbers.Count - 1];
            double[] alx = new double[3000];
            // Store the values of the received ArrayLists with the sample data in an Array

            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                //alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
                alx[i] = (double)i; //store each element as a double in the array
            }

            /*
            double[] aly = new double[aMeanValues.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i;
                aly[i] = Double.Parse(alConditionCoverage[i + 1].ToString()); //store each element as a double in the array
            }
            */

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aMeanValues);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         "  + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
                // taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                aSyDx[i] = Sydx[i];
            }
            double max = aDyDx.Max();
            int numberActions = 200;

            string type = "Line";
            if (rbLine.Checked) type = "Line";
            else if (rbSpine.Checked) type = "Spline";
            else if (rbKagi.Checked) type = "Kagi";
            else if (rbColumn.Checked) type = "Column";
            else if (rbCandlestick.Checked) type = "Candlestick";
            else if (rbArea.Checked) type = "Area";
            else type = "Line";

            int start = 0;
            int end = 2999;
            if (!Int32.TryParse(tbStart.Text, out start)) start = 0;
            if (!Int32.TryParse(tbEnd.Text, out end)) end = 200; ;
            double low = 0;
            //double high = max;

            if (!Double.TryParse(tbLow.Text, out low)) low = 0;
            if (!Double.TryParse(tbHigh.Text, out max)) max = aDyDx.Max();


            Console.WriteLine("begin van grafiek " + start);
            Console.WriteLine("einde van grafiek" + end);

            Chart chart = new Chart();
            chart.Show();
            // Laat gebruiker numberAction, beginAction en Type Chart kiezen
            chart.showChart(aX, aY, aDyDx, low, max, start, end, type);
            /*
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 310);
            */
        }

        private void bnShowIntegrateBranchCoverageMap_Click(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
            // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            ArrayList alTotalValues = new ArrayList();
            ArrayList alMeanValues = new ArrayList();
            double[] aTotalValues = new double[3000];
            double[] aMeanValues = new double[3000];
            for (int countAL = 0; countAL < alalBrancheMerged.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalBrancheMerged[countAL];

                for (int i = 0; i < al.Count && i < 3000; i++)
                {
                    aTotalValues[i] += Convert.ToDouble(al[i]);
                }
            }
            for (int i = 0; i < 3000; i++)
            {
                aMeanValues[i] = aTotalValues[i] / alalBrancheMerged.Count;
            }



            string tekst = "";

            // Maak van de ArryLists een Array
            // double[] alx = new double[alActionNumbers.Count - 1];
            double[] alx = new double[3000];
            // Store the values of the received ArrayLists with the sample data in an Array

            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                //alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
                alx[i] = (double)i; //store each element as a double in the array
            }

            /*
            double[] aly = new double[aMeanValues.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i;
                aly[i] = Double.Parse(alConditionCoverage[i + 1].ToString()); //store each element as a double in the array
            }
            */

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aMeanValues);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         "  + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {Sydx[i],column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
                // taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                //aSyDx[i] = Sydx[i];
                aSyDx[i] = Math.Log(Sydx[i]);
                if (i >= 1)
                {
                    aSyDx[i] = Math.Log(Sydx[i]);
                }
                else
                {
                    aSyDx[i] = 0;
                }
            }
            double max = aSyDx.Max();
            int numberActions = 200;

            string type = "Line";
            if (rbLine.Checked) type = "Line";
            else if (rbSpine.Checked) type = "Spline";
            else if (rbKagi.Checked) type = "Kagi";
            else if (rbColumn.Checked) type = "Column";
            else if (rbCandlestick.Checked) type = "Candlestick";
            else if (rbArea.Checked) type = "Area";
            else type = "Line";

            int start = 0;
            int end = 2999;
            if (!Int32.TryParse(tbStart.Text, out start)) start = 0;
            if (!Int32.TryParse(tbEnd.Text, out end)) end = 200; ;
            double low = 0;
            //double high = max;

            if (!Double.TryParse(tbLow.Text, out low)) low = 0;
            if (!Double.TryParse(tbHigh.Text, out max)) max = aSyDx.Max();


            Console.WriteLine("begin van grafiek " + start);
            Console.WriteLine("einde van grafiek" + end);

            Chart chart = new Chart();
            chart.Show();
            // Laat gebruiker numberAction, beginAction en Type Chart kiezen
            chart.showChart(aX, aY, aSyDx, low, max, start, end, type);
            /*
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 310);
            */
        }

        private void ShowIntegrateBranchCoverage_Click(object sender, EventArgs e)
        {
            const int column_width = 24;

            //alActionNumbers.Add(aPartLine[3].Trim(' '));
            // alConditionCoverage.Add(aPartLine[9].Trim(' '));

            string tekst = "";

            // Maak van de ArryLists een Array
            double[] alx = new double[alActionNumbers.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            /*
            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = Double.Parse(alActionNumbers[i + 1].ToString()); //store each element as a double in the array
            }
            */
            double[] aly = new double[alBranchCoverage.Count - 1];
            // Store the values of the received ArrayLists with the sample data in an Array
            for (int i = 0; i < aly.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i;
                aly[i] = Double.Parse(alBranchCoverage[i + 1].ToString()); //store each element as a double in the array
            }

            // Maak van de Arrays een DenseVector
            // var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            // var yvec = new DenseVector(new double[] { 7.0, 7.7, 12.3, 10.2, 10.2, 17.0, 17.7, 22.3, 27.0, 27.7, 32.3, 32.3, 33.3, 33.3, 33.3 });
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aly);
            Console.WriteLine("Input Data Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width}");
            taOutput.AppendText("Input Data Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x          y");
            taOutput.AppendText(Environment.NewLine);
            for (int i = 0; i < xvec.Count; i++)
            {
                Console.WriteLine($"{i,column_width:G5} {xvec[i],column_width:G5} {yvec[i],column_width:G5}");
                //taOutput.AppendText(i + "         " + xvec[i] + "         " + yvec[i]);
                //taOutput.AppendText(Environment.NewLine);
            }
            Console.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);

            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            Console.WriteLine("Interpoaltion Results Table");
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("Interpoaltion Results Table");
            taOutput.AppendText(Environment.NewLine);
            taOutput.AppendText("x           y              dydx");
            taOutput.AppendText(Environment.NewLine);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            for (int i = 0; i < x.Count; i++)
            {
                //x[i] = (4.0 * i) / (x.Count - 1);
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);

                Sydx[i] = cs.Integrate(x[i]);

                //Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5} {Sydx[i],column_width:G5} {Math.Log(Sydx[i]),column_width:G5}");
                //taOutput.AppendText(x[i] + "        " + y[i] + "          " + dydx[i]);
                //taOutput.AppendText(Environment.NewLine);
                aX[i] = x[i];
                aY[i] = y[i];
                aDyDx[i] = dydx[i];
                //aSyDx[i] = Sydx[i];
                aSyDx[i] = Math.Log(Sydx[i]);
                if (i >= 1)
                {
                    aSyDx[i] = Math.Log(Sydx[i]);
                }
                else
                {
                    aSyDx[i] = 0;
                }

                Console.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5} {Sydx[i],column_width:G5} {aSyDx[i],column_width:G5} {Math.Log(aSyDx[i]),column_width:G5}");
            }
            double max = aSyDx.Max();

            //max = aSyDx[2999];
            max = 90;
            int numberActions = 2999;


            /*
            Chart chart = new Chart();
            chart.Show();
            chart.showChart(aX, aY, aDyDx, 35);
            */
            Chart chart2 = new Chart();
            chart2.Show();
            chart2.showChart(aX, aY, aSyDx, 0, max, 0, numberActions, "Line");// Laat gebruiker numberAction, beginAction en Type Chart kiezen

        }

        private void btnShowDiffValue_Click(object sender, EventArgs e)
        {
            ArrayList alTotalValues = new ArrayList();
            ArrayList alMeanValues = new ArrayList();
            double[] aTotalValues = new double[3000];
            double[] aMeanValues = new double[3000];

            int[] iMeanValues = new int[3000];

            for (int countAL = 0; countAL < alalInstructionMerged.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalInstructionMerged[countAL];

                for (int i = 0; i < al.Count && i < 3000; i++)
                {
                    aTotalValues[i] += Convert.ToDouble(al[i]);
                }
            }
            for (int i = 0; i < 3000; i++)
            {
                aMeanValues[i] = aTotalValues[i] / alalInstructionMerged.Count;
                iMeanValues[i] = (int) (aTotalValues[i] / alalInstructionMerged.Count);
            }

            // Maak van de ArryLists een Array
            // double[] alx = new double[alActionNumbers.Count - 1];
            double[] alx = new double[3000];
            // Store the values of the received ArrayLists with the sample data in an Array

            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                 alx[i] = (double)i; //store each element as a double in the array
            }

            // Maak van de Arrays een DenseVector
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aMeanValues);
 
            taOutput.Text = "";
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);
            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            int number = 0;
            try
            {
                if (Int32.TryParse(tbActionInstruct.Text, out number))
                {
                    if (number > 2999) number = 2999;
                }
            }
            catch (Exception exc)
            {
                number = 0;
            }

            Console.WriteLine("NUMBER IS " + number);

            for (int i = 1; i < x.Count; i++)
            {
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);
                Sydx[i] = cs.Integrate(x[i]);

                if (number == 0)
                {
                    taOutput.AppendText(x[i] + "          " + y[i].ToString("F") + "                    " + dydx[i].ToString("F") + "                    " + Sydx[i].ToString("F"));
                    taOutput.AppendText(Environment.NewLine);
                }
            }
            if (number != 0)
            {
                //taOutput.Font = new Font(taOutput.Font.FontFamily, taOutput.Font.Size +40);
                taOutput.AppendText("Action= " + x[number] + "     Graphvalue= " + y[number].ToString("F") + "    DifferentialValue= " + dydx[number].ToString("F") + "    IntegralValue= " + Sydx[number].ToString("#.##"));
                taOutput.AppendText(Environment.NewLine);
                //taOutput.Font = new Font(taOutput.Font.FontFamily, taOutput.Font.Size - 40);

                float integral = 0;
                for (int i = 1; i < iMeanValues.Length; i++)
                    integral += (iMeanValues[i] + iMeanValues[i - 1]) / 2 * (2999 - 0);
                taOutput.AppendText("Action= " + integral);
                taOutput.AppendText(Environment.NewLine);



            }
        }

        private void btnShowDiffValueBranch_Click(object sender, EventArgs e)
        {
            ArrayList alTotalValues = new ArrayList();
            ArrayList alMeanValues = new ArrayList();
            double[] aTotalValues = new double[3000];
            double[] aMeanValues = new double[3000];
            for (int countAL = 0; countAL < alalBrancheMerged.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalBrancheMerged[countAL];

                for (int i = 0; i < al.Count && i < 3000; i++)
                {
                    aTotalValues[i] += Convert.ToDouble(al[i]);
                }
            }
            for (int i = 0; i < 3000; i++)
            {
                aMeanValues[i] = aTotalValues[i] / alalBrancheMerged.Count;
            }

            // Maak van de ArryLists een Array
            // double[] alx = new double[alActionNumbers.Count - 1];
            double[] alx = new double[3000];
            // Store the values of the received ArrayLists with the sample data in an Array

            for (int i = 0; i < alx.Length; ++i)
            { //iterate over the elements of the list
                alx[i] = (double)i; //store each element as a double in the array
            }

            // Maak van de Arrays een DenseVector
            var xvec = new DenseVector(alx);
            var yvec = new DenseVector(aMeanValues);

            taOutput.Text = "";
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);
            var x = new DenseVector(3000);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            var Sydx = new DenseVector(x.Count);
            double[] aX = new double[x.Count];
            double[] aY = new double[x.Count];
            double[] aDyDx = new double[x.Count];
            double[] aSyDx = new double[x.Count];

            int number = 0;
            try
            {
                if (Int32.TryParse(tbActionBranch.Text, out number))
                {
                    if (number > 2999) number = 2999;
                }
            }
            catch (Exception exc)
            {
                number = 0;
            }

            Console.WriteLine("NUMBER IS " + number);

            for (int i = 1; i < x.Count; i++)
            {
                x[i] = i;
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);
                Sydx[i] = cs.Integrate(x[i]);

                if (number == 0)
                {
                    taOutput.AppendText(x[i] + "          " + y[i].ToString("F") + "                    " + dydx[i].ToString("F") + "                    " + Sydx[i].ToString("F"));
                    taOutput.AppendText(Environment.NewLine);
                }
            }
            if (number != 0)
            {
                //taOutput.Font = new Font(taOutput.Font.FontFamily, taOutput.Font.Size +40);
                taOutput.AppendText("Action= " + x[number] + "     Graphvalue= " + y[number].ToString("F") + "    DifferentialValue= " + dydx[number].ToString("F") + "    IntegralValue= " + Sydx[number].ToString("#.##"));
                taOutput.AppendText(Environment.NewLine);
                //taOutput.Font = new Font(taOutput.Font.FontFamily, taOutput.Font.Size - 40);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BoxPlotChart bpc = new BoxPlotChart();
            //bpc.Show();
        }

        private void btnBoxPlot_Click(object sender, EventArgs e)
        {
            //your object here
           // object objArrayList = new object();
            //Check if the object is null
            if (alMergedConditionCoverageTestRun != null)
            {
                //object not null. check if it is arrayList
                if (alMergedConditionCoverageTestRun is System.Collections.ArrayList)
                {
                    //Object is ArrayList, check for count
                    //System.Collections.ArrayList array = new System.Collections.ArrayList();
                    //array = (System.Collections.ArrayList) alMergedConditionCoverageTestRun;
                    if (alMergedConditionCoverageTestRun.Count > 1)
                    {
                        //double[] yValues = { 2, 3, 4, 5, 4, 5, 5, 2, 1, 9, 18, 4 };

                        // Declare the Arrays to determine the edges
                        double[] yValues = new double[alMergedConditionCoverageTestRun.Count - 1];
                        // Store the values of the received ArrayLists with the sample data in an Array
                        for (int i = 0; i < yValues.Length; ++i)
                        { //iterate over the elements of the list
                            yValues[i] = Double.Parse(alMergedConditionCoverageTestRun[i + 1].ToString()); //store each element as a double in the array
                        }


                        BoxPlotChart bpc = new BoxPlotChart(yValues);
                        bpc.Show();
                    }
                }
            }



            
           // alMergedBranchCoverageTestRun

        }

        private void cbShowChart_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pnlInCollectionInFolder_Paint(object sender, PaintEventArgs e)
        {

        }
    } // end class CoverageCollector
} // end namespace
