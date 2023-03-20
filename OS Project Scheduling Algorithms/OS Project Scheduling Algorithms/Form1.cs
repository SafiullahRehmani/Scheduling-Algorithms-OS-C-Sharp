using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace OS_Project_Scheduling_Algorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Worker W = new Worker();
        private void Enter_Button_Click(object sender, EventArgs e)
        {
            EmptyTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (Number_of_Processes_TextBox.Text == "")
            {
                Enter_Button.Enabled = true;
            }
            else
            {
                Enter_Button.Enabled = false;
                //Reset_Button.Enabled = false;
                GV.Compute = false;
                GV.Scheduling = false;
                GV.NumberOfProcessesRange = int.Parse(Number_of_Processes_TextBox.Text);
                W.TableCreation();
                EmptyTable.DataSource = GV.Table;
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void Compute_Button_Click(object sender, EventArgs e)
        {
            if (GV.Compute != false)
            {
                ArraysandVariablesClearer();
            }
            GV.BurstTime = new int[GV.NumberOfProcessesRange];
            GV.BursttTime = new int[GV.NumberOfProcessesRange];
            GV.TurnaroundTimee = new int[GV.NumberOfProcessesRange];
            GV.PRIORITY = new int[GV.NumberOfProcessesRange];
            if (AlgorithmSelector_ComboBox.Text == "")
            {
                MessageBox.Show("Select A Scheduling Algorithm!!!!!!!!");
            }
            else if (AlgorithmSelector_ComboBox.Text == "FCFS" && Enter_Button.Enabled != true)
            {
                GV.FCFS = true;
                GV.AlgoName = AlgorithmSelector_ComboBox.Text;
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    if (EmptyTable.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        string P = EmptyTable.Rows[i].Cells[0].Value.ToString();
                        GV.Processes[i] = int.Parse(P[1].ToString());
                        GV.BurstTime[i] = int.Parse(EmptyTable.Rows[i].Cells[1].Value.ToString());
                        //Compute_Button.Enabled = false;
                        GV.Compute = true;
                    }
                    else
                    {
                        MessageBox.Show("!!!Attention: Insert the Burst-Time Values of each Process's");
                        break;
                    }
                }
                W.FCFS();
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    if (EmptyTable.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        EmptyTable.Rows[i].Cells[0].Value = "P" + GV.Processes[i].ToString();
                        EmptyTable.Rows[i].Cells[1].Value = GV.BurstTime[i].ToString();
                        EmptyTable.Rows[i].Cells[2].Value = GV.WaitingTime[i].ToString();
                        EmptyTable.Rows[i].Cells[3].Value = GV.TurnaroundTime[i].ToString();
                        if (i == GV.NumberOfProcessesRange - 1)
                        {
                            EmptyTable.Rows[GV.NumberOfProcessesRange].Cells[2].Value = GV.AvgWaitingTime.ToString();
                            EmptyTable.Rows[GV.NumberOfProcessesRange].Cells[3].Value = GV.AvgTurnaroundTime.ToString();
                        }
                    }
                }
                W.GanttChart();
            }
            else if (AlgorithmSelector_ComboBox.Text == "SJF" && Enter_Button.Enabled != true)
            {
                GV.SJF = true;
                GV.AlgoName = AlgorithmSelector_ComboBox.Text;
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    if (EmptyTable.Rows[i].Cells[0].Value.ToString() != "" && EmptyTable.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        string P = EmptyTable.Rows[i].Cells[0].Value.ToString();
                        GV.Processes[i] = int.Parse(P[1].ToString());
                        GV.BurstTime[i] = int.Parse(EmptyTable.Rows[i].Cells[1].Value.ToString());
                        //Compute_Button.Enabled = false;
                        GV.Compute = true;
                    }
                    else
                    {
                        MessageBox.Show("!!!Attention: Insert the Burst-Time Values of each Process's");
                        break;
                    }
                }
                W.SJF();
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    if (EmptyTable.Rows[i].Cells[0].Value.ToString() != "" && EmptyTable.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        EmptyTable.Rows[i].Cells[0].Value = "P" + GV.Processes[i].ToString();
                        EmptyTable.Rows[i].Cells[1].Value = GV.BurstTime[i].ToString();
                        EmptyTable.Rows[i].Cells[2].Value = GV.WaitingTime[i].ToString();
                        EmptyTable.Rows[i].Cells[3].Value = GV.TurnaroundTime[i].ToString();
                        GV.TurnaroundTimee[i] = int.Parse(EmptyTable.Rows[i].Cells[3].Value.ToString());
                        if (i == GV.NumberOfProcessesRange - 1)
                        {
                            EmptyTable.Rows[GV.NumberOfProcessesRange].Cells[2].Value = GV.AvgWaitingTime.ToString();
                            EmptyTable.Rows[GV.NumberOfProcessesRange].Cells[3].Value = GV.AvgTurnaroundTime.ToString();
                        }
                    }
                }
                W.GanttChart();
            }
            else if (AlgorithmSelector_ComboBox.Text == "Round-Robin" && Time_Slice_Textbox.Text != "" && Enter_Button.Enabled != true)
            {
                GV.RR = true;
                GV.AlgoName = AlgorithmSelector_ComboBox.Text;
                GV.t = int.Parse(Time_Slice_Textbox.Text.ToString());
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    if (EmptyTable.Rows[i].Cells[0].Value.ToString() != "" && EmptyTable.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        string P = EmptyTable.Rows[i].Cells[0].Value.ToString();
                        GV.Processes[i] = int.Parse(P[1].ToString());
                        GV.BurstTime[i] = int.Parse(EmptyTable.Rows[i].Cells[1].Value.ToString());
                        GV.BursttTime[i] = GV.BurstTime[i];
                        //Compute_Button.Enabled = false;
                        GV.Compute = true;
                    }
                    else
                    {
                        MessageBox.Show("!!!Attention: Insert the Burst-Time Values of each Process's");
                        break;
                    }
                }
                W.RR();
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    if (EmptyTable.Rows[i].Cells[0].Value.ToString() != "" && EmptyTable.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        EmptyTable.Rows[i].Cells[0].Value = "P" + GV.Processes[i].ToString();
                        EmptyTable.Rows[i].Cells[1].Value = GV.BursttTime[i].ToString();
                        EmptyTable.Rows[i].Cells[2].Value = GV.WaitingTime[i].ToString();
                        EmptyTable.Rows[i].Cells[3].Value = GV.TurnaroundTime[i].ToString();
                        if (i == GV.NumberOfProcessesRange - 1)
                        {
                            EmptyTable.Rows[GV.NumberOfProcessesRange].Cells[2].Value = GV.AvgWaitingTime.ToString();
                            EmptyTable.Rows[GV.NumberOfProcessesRange].Cells[3].Value = GV.AvgTurnaroundTime.ToString();
                        }
                    }
                }
                W.GanttChart();
            }
            else if(AlgorithmSelector_ComboBox.Text == "Priority" && Enter_Button.Enabled != true)
            {
                GV.Priority = true;
                GV.AlgoName = AlgorithmSelector_ComboBox.Text; 
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    if (EmptyTable.Rows[i].Cells[0].Value.ToString() != "" && EmptyTable.Rows[i].Cells[1].Value.ToString() != "" && EmptyTable.Rows[i].Cells[2].Value.ToString() != "")
                    {
                        string P = EmptyTable.Rows[i].Cells[0].Value.ToString();
                        GV.Processes[i] = int.Parse(P[1].ToString());
                        GV.BurstTime[i] = int.Parse(EmptyTable.Rows[i].Cells[1].Value.ToString());
                        GV.PRIORITY[i] = int.Parse(EmptyTable.Rows[i].Cells[2].Value.ToString());
                        GV.BursttTime[i] = GV.BurstTime[i];
                        //Compute_Button.Enabled = false;
                        GV.Compute = true;
                    }
                    else
                    {
                        MessageBox.Show("!!!Attention: Insert both Burst-Time && Priority Values of each Process's");
                        break;
                    }
                }
                W.Priority_Scheduling();
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    if (EmptyTable.Rows[i].Cells[0].Value.ToString() != "" && EmptyTable.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        EmptyTable.Rows[i].Cells[0].Value = "P" + GV.Processes[i].ToString();
                        EmptyTable.Rows[i].Cells[1].Value = GV.BurstTime[i].ToString();
                        EmptyTable.Rows[i].Cells[2].Value = GV.PRIORITY[i].ToString();
                        EmptyTable.Rows[i].Cells[3].Value = GV.WaitingTime[i].ToString();
                        EmptyTable.Rows[i].Cells[4].Value = GV.TurnaroundTime[i].ToString();
                        if (i == GV.NumberOfProcessesRange - 1)
                        {
                            EmptyTable.Rows[GV.NumberOfProcessesRange].Cells[3].Value = GV.AvgWaitingTime.ToString();
                            EmptyTable.Rows[GV.NumberOfProcessesRange].Cells[4].Value = GV.AvgTurnaroundTime.ToString();
                        }
                    }
                }
                W.GanttChart();
            }
            else
            {
                MessageBox.Show("Enter Number of Processes first!!!!!");
            }
        }

        private void AlgorithmSelector_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlgorithmSelector_ComboBox.Text == "FCFS" || AlgorithmSelector_ComboBox.Text == "SJF")
            {
                GV.Scheduling = true;
                GV.RR = false;  GV.Priority = false;
                W.TableCreation();
                EmptyTable.DataSource = GV.Table;
                Enter_Quantum_Time_Slice_label.Enabled = false;
                Time_Slice_Textbox.Enabled = false;
            }
            else if (AlgorithmSelector_ComboBox.Text == "Round-Robin")
            {
                GV.Scheduling = true;
                GV.FCFS = false;    GV.SJF = false;     GV.Priority = false;
                GV.RR = true;
                W.TableCreation();
                EmptyTable.DataSource = GV.Table;
                Enter_Quantum_Time_Slice_label.Enabled = true;
                Time_Slice_Textbox.Enabled = true;
            }
            else if (AlgorithmSelector_ComboBox.Text == "Priority")
            {
                GV.Scheduling = true;
                GV.FCFS = false;    GV.SJF = false;     GV.RR = false;
                GV.Priority = true;
                W.TableCreation();
                EmptyTable.DataSource = GV.Table;
                Enter_Quantum_Time_Slice_label.Enabled = false;
                Time_Slice_Textbox.Enabled = false;
            }
        }

        private void EmptyTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //GV.Table.Load(eachrow.Cells[2].Value.ToString());
        }

        public void ArraysandVariablesClearer()
        {
            Array.Clear(GV.Processes, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.BurstTime, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.WaitingTime, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.TurnaroundTime, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.BursttTime, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.TurnaroundTimee, 0, GV.NumberOfProcessesRange);
            GV.AvgWaitingTime = 0;
            GV.AvgTurnaroundTime = 0;
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            if (GV.BurstTime != null)
            {
                W.Resetter();
                EmptyTable.Columns.Clear();
                EmptyTable.DataSource = null;
                EmptyTable.Refresh();
                Enter_Button.Enabled = true;
                Compute_Button.Enabled = true;
                AlgorithmSelector_ComboBox.Text = null;
                Number_of_Processes_TextBox.Text = null;
                GV.Compute = false;
            }
            else
            {
                GV.Table.Columns.Clear();
                GV.Table.Clear();
                EmptyTable.DataSource = null;
                EmptyTable.Refresh();
                Enter_Button.Enabled = true;
                Compute_Button.Enabled = true;
                AlgorithmSelector_ComboBox.Text = null;
                Number_of_Processes_TextBox.Text = null;
                GV.Compute = false;
            }
        }
        private void Gantt_Chart_Button_Click(object sender, EventArgs e)
        {
        }
    }
    public static class GV
    {
        public static int NumberOfProcessesRange, t, temp, max, GCTC = 0;
        public static float AvgWaitingTime, AvgTurnaroundTime;
        public static int[] Processes, PRIORITY, BurstTime, WaitingTime, TurnaroundTime, BursttTime, TurnaroundTimee;
        public static DataTable Table;
        public static bool Scheduling, FCFS, SJF, RR, Priority, Compute;
        public static string AlgoName;
    }
    public class Worker
    {
        public Worker()
        {
            GV.Table = new DataTable();
        }
        public void TableCreation()
        {
            GV.Processes = new int[GV.NumberOfProcessesRange];
            if (GV.NumberOfProcessesRange != 0 && GV.Scheduling != true && GV.Compute != true)
            {
                GV.Table.Columns.Add("Process");
                GV.Table.Columns.Add("Burst_Time");
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    GV.Processes[i] = i;
                    GV.Table.Rows.Add("P" + (GV.Processes[i]+1).ToString());
                }
                GV.Table.Rows.Add("All-Processes-Average:");
            }
            else if (GV.Scheduling == true && GV.Priority != true && GV.Compute != true && GV.Table.Columns.Count <= 5)
            {
                if (GV.Table.Columns.Contains("Process") == true && GV.Table.Columns.Contains("Burst_Time") == true && !GV.Table.Columns.Contains("Waiting_Time")
                    && !GV.Table.Columns.Contains("Turnaround_Time"))
                {
                    GV.Table.Columns.Add("Waiting_Time");
                    GV.Table.Columns.Add("Turnaround_Time");
                }
                else if (GV.Table.Columns.Contains("Process") == true && GV.Table.Columns.Contains("Burst_Time") == true &&
                    GV.Table.Columns.Contains("Waiting_Time") && GV.Table.Columns.Contains("Turnaround_Time") &&
                    GV.Table.Columns.Contains("Priority") == true)
                {
                    GV.Table.Columns.Remove("Priority");
                }
                else if (GV.Table.Columns.Contains("Process") && GV.Table.Columns.Contains("Burst_Time") && GV.Table.Columns.Contains("Waiting_Time") 
                    && GV.Table.Columns.Contains("Turnaround_Time"))
                {
                    GV.Table.Columns.Remove("Waiting_Time");
                    GV.Table.Columns.Remove("Turnaround_Time");
                    GV.Table.Columns.Add("Waiting_Time");
                    GV.Table.Columns.Add("Turnaround_Time");
                }
                else
                {
                    MessageBox.Show("!!!Attention: Enter Number of Processes First!!!!!!");
                }
            }
            else if (GV.Scheduling == true && GV.Priority != true && GV.Compute != false && GV.Table.Columns.Count <= 5)
            {
                if (GV.Table.Columns.Contains("Process") == true && GV.Table.Columns.Contains("Burst_Time") == true && !GV.Table.Columns.Contains("Waiting_Time")
                    && !GV.Table.Columns.Contains("Turnaround_Time"))
                {
                    GV.Table.Columns.Add("Waiting_Time");
                    GV.Table.Columns.Add("Turnaround_Time");
                }
                else if (GV.Table.Columns.Contains("Process") == true && GV.Table.Columns.Contains("Burst_Time") == true &&
                    GV.Table.Columns.Contains("Waiting_Time") && GV.Table.Columns.Contains("Turnaround_Time") &&
                    GV.Table.Columns.Contains("Priority") == true)
                {
                    GV.Table.Columns.Remove("Priority");
                }
                else if (GV.Table.Columns.Contains("Process") && GV.Table.Columns.Contains("Burst_Time") && GV.Table.Columns.Contains("Waiting_Time")
                    && GV.Table.Columns.Contains("Turnaround_Time"))
                {
                    GV.Table.Columns.Remove("Waiting_Time");
                    GV.Table.Columns.Remove("Turnaround_Time");
                    GV.Table.Columns.Add("Waiting_Time");
                    GV.Table.Columns.Add("Turnaround_Time");
                }
                else
                {
                    MessageBox.Show("!!!Attention: Enter Number of Processes First!!!!!!");
                }
            }
            else if (GV.Scheduling == true && GV.Priority == true && GV.Compute != true && GV.Table.Columns.Count < 5)
            {
                if (GV.Table.Columns.Contains("Process") == true && GV.Table.Columns.Contains("Burst_Time") == true 
                    && GV.Table.Columns.Contains("Waiting_Time") == true && GV.Table.Columns.Contains("Turnaround_Time") == true)
                {
                    GV.Table.Columns.Remove("Waiting_Time");
                    GV.Table.Columns.Remove("Turnaround_Time");
                    GV.Table.Columns.Add("Priority");
                    GV.Table.Columns.Add("Waiting_Time");
                    GV.Table.Columns.Add("Turnaround_Time");
                }
                else if(GV.Table.Columns.Contains("Process") == true && GV.Table.Columns.Contains("Burst_Time") == true)
                {
                    GV.Table.Columns.Add("Priority");
                    GV.Table.Columns.Add("Waiting_Time");
                    GV.Table.Columns.Add("Turnaround_Time");
                }
                else
                {
                    MessageBox.Show("!!!Attention: Enter Number of Processes First!!!!!!");
                }
            }
            else if (GV.Scheduling == true && GV.Priority == true && GV.Compute == true && GV.Table.Columns.Count < 5)
            {
                if (GV.Table.Columns.Contains("Process") == true && GV.Table.Columns.Contains("Burst_Time") == true
                    && GV.Table.Columns.Contains("Waiting_Time") == true && GV.Table.Columns.Contains("Turnaround_Time") == true)
                {
                    GV.Table.Columns.Remove("Waiting_Time");
                    GV.Table.Columns.Remove("Turnaround_Time");
                    GV.Table.Columns.Add("Priority");
                    GV.Table.Columns.Add("Waiting_Time");
                    GV.Table.Columns.Add("Turnaround_Time");
                }
                else if (GV.Table.Columns.Contains("Process") == true && GV.Table.Columns.Contains("Burst_Time") == true)
                {
                    GV.Table.Columns.Add("Priority");
                    GV.Table.Columns.Add("Waiting_Time");
                    GV.Table.Columns.Add("Turnaround_Time");
                }
                else
                {
                    MessageBox.Show("!!!Attention: Enter Number of Processes First!!!!!!");
                }
            }
        }
        public void FCFS()//First-Come-First-Serve-Algo
        {
            GV.WaitingTime = new int[GV.NumberOfProcessesRange];
            GV.TurnaroundTime = new int[GV.NumberOfProcessesRange];
            int temp;
            for (int i = 0; i < GV.NumberOfProcessesRange; i++)
            {
                for (int j = i + 1; j < GV.NumberOfProcessesRange; j++)
                {
                    if (GV.Processes[i] > GV.Processes[j])
                    {
                        temp = GV.Processes[i];
                        GV.Processes[i] = GV.Processes[j];
                        GV.Processes[j] = temp;
                        temp = GV.BurstTime[i];
                        GV.BurstTime[i] = GV.BurstTime[j];
                        GV.BurstTime[j] = temp;
                    }
                }
            }
            for (int i = 0; i < GV.NumberOfProcessesRange; i++)
            {
                if (i == 0)
                {
                    GV.WaitingTime[i] = 0;
                    GV.TurnaroundTime[i] = GV.BurstTime[i] + GV.WaitingTime[i];
                }
                else
                {
                    GV.WaitingTime[i] = GV.TurnaroundTime[i - 1];
                    GV.TurnaroundTime[i] = GV.BurstTime[i] + GV.WaitingTime[i];
                }
                GV.AvgWaitingTime += GV.WaitingTime[i];
                GV.AvgTurnaroundTime += GV.TurnaroundTime[i];
            }
            AverageTimesCalculator();
        }
        public void SJF()//Shortest-Job-First
        {
            GV.WaitingTime = new int[GV.NumberOfProcessesRange];
            GV.TurnaroundTime = new int[GV.NumberOfProcessesRange];
            int temp;
            for (int i = 0; i < GV.NumberOfProcessesRange; i++)
            {
                for (int j = i + 1; j < GV.NumberOfProcessesRange; j++)
                {
                    if (GV.BurstTime[i] > GV.BurstTime[j])
                    {
                        temp = GV.BurstTime[i];
                        GV.BurstTime[i] = GV.BurstTime[j];
                        GV.BurstTime[j] = temp;
                        temp = GV.Processes[i];
                        GV.Processes[i] = GV.Processes[j];
                        GV.Processes[j] = temp;
                    }
                }
            }
            for (int i = 0; i < GV.NumberOfProcessesRange; i++)
            {
                if (i == 0)
                {
                    GV.WaitingTime[i] = 0;
                    GV.TurnaroundTime[i] = GV.BurstTime[i] + GV.WaitingTime[i];
                }
                else
                {
                    GV.WaitingTime[i] = GV.TurnaroundTime[i - 1];
                    GV.TurnaroundTime[i] = GV.BurstTime[i] + GV.WaitingTime[i];
                }
                GV.AvgWaitingTime += GV.WaitingTime[i];
                GV.AvgTurnaroundTime += GV.TurnaroundTime[i];
            }
            AverageTimesCalculator();
        }
        public void RR()
        {
            GV.WaitingTime = new int[GV.NumberOfProcessesRange];
            GV.TurnaroundTime = new int[GV.NumberOfProcessesRange];
            int temp = 0;
            for (int i = 0; i < GV.NumberOfProcessesRange; i++)
            {
                for (int j = i + 1; j < GV.NumberOfProcessesRange; j++)
                {
                    if (GV.Processes[i] > GV.Processes[j]) // shortest job first
                    {
                        temp = GV.Processes[i];
                        GV.Processes[i] = GV.Processes[j];
                        GV.Processes[j] = temp;
                        temp = GV.BurstTime[i];
                        GV.BurstTime[i] = GV.BurstTime[j];
                        GV.BurstTime[j] = temp;
                    }
                }
                GV.BursttTime[i] = GV.BurstTime[i];
            }

            GV.max = GV.BurstTime[0];
            for (int i = 1; i < GV.NumberOfProcessesRange; i++)
            {
                if (GV.max < GV.BurstTime[i])
                {
                    GV.max = GV.BurstTime[i];
                }
            }
            temp = 0;
            for (int j = 0; j < (GV.max / GV.t) + 1; j++)
            {
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    if (GV.BurstTime[i] != 0)
                    {
                        if (GV.BurstTime[i] <= GV.t)
                        {
                            GV.TurnaroundTime[i] = temp + GV.BurstTime[i];
                            temp = temp + GV.BurstTime[i];
                            GV.BurstTime[i] = 0;
                        }
                        else
                        {
                            GV.BurstTime[i] = GV.BurstTime[i] - GV.t;
                            temp = temp + GV.t;
                        }
                    }
                }
            }
            for (int i = 0; i < GV.NumberOfProcessesRange; i++)
            {
                GV.WaitingTime[i] = GV.TurnaroundTime[i] - GV.BursttTime[i];
                if (GV.WaitingTime[i] == 0)
                {
                    GV.WaitingTime[i] = GV.t;
                    GV.TurnaroundTime[i] += GV.t;
                }
                GV.AvgTurnaroundTime += GV.TurnaroundTime[i];
                GV.AvgWaitingTime += GV.WaitingTime[i];
            }
            AverageTimesCalculator();
        }
        public void Priority_Scheduling()
        {
            GV.WaitingTime = new int[GV.NumberOfProcessesRange];
            GV.TurnaroundTime = new int[GV.NumberOfProcessesRange];
            int temp = 0;
            for (int i = 0; i < GV.NumberOfProcessesRange; i++)
            {
                for (int j = 0; j < GV.NumberOfProcessesRange - i - 1; j++)
                {
                    if (GV.PRIORITY[j] > GV.PRIORITY[j + 1])
                    {
                        temp = GV.PRIORITY[j];
                        GV.PRIORITY[j] = GV.PRIORITY[j + 1];
                        GV.PRIORITY[j + 1] = temp;
                        temp = GV.Processes[j];
                        GV.Processes[j] = GV.Processes[j + 1];
                        GV.Processes[j + 1] = temp;
                        temp = GV.BurstTime[j];
                        GV.BurstTime[j] = GV.BurstTime[j + 1];
                        GV.BurstTime[j + 1] = temp;
                    }
                }
            }
            temp = 0;
            for (int i = 0; i < GV.NumberOfProcessesRange; i++)
            {
                if (i == 0)
                {
                    GV.WaitingTime[i] = 0;
                    GV.TurnaroundTime[i] = GV.BurstTime[i] + GV.WaitingTime[i];
                }
                else
                {
                    GV.WaitingTime[i] = GV.TurnaroundTime[i - 1];
                    GV.TurnaroundTime[i] = GV.BurstTime[i] + GV.WaitingTime[i];
                }
                GV.AvgWaitingTime += GV.WaitingTime[i];
                GV.AvgTurnaroundTime += GV.TurnaroundTime[i];
            }
            AverageTimesCalculator();
        }
        public void AverageTimesCalculator()
        {
            GV.AvgWaitingTime /= GV.NumberOfProcessesRange;
            GV.AvgTurnaroundTime /= GV.NumberOfProcessesRange;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public void GanttChart()        // to create Gantt Chart
        {
            AllocConsole();
            Console.Clear();
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("================================================" + GV.AlgoName + "-" + "Gantt-Chart========================================================");
            GV.GCTC = 0;
            int temp = 0;
            Console.WriteLine("\n\nGantt-Chart-Format: \n\n");
            Console.WriteLine("\t\tArrival-Time[Process-Number]Completion-Time ---> Means:   At[Pn]Ct\n\n");
            Console.WriteLine("\n\nGantt-Chart-Simulation:\n\n\t");
            Console.Write("\t\t");
            if (GV.Scheduling == true && GV.FCFS || GV.SJF)         // for First Come First Server  and  Shortest Job First
            {                                                       // we've done the sorting of SJF already, so no need to do it again
                Console.Write(GV.GCTC);
                for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                { 
                    GV.GCTC += GV.BurstTime[i];
                    Console.Write(" [P" + GV.Processes[i] + "] ");
                    Console.Write(GV.GCTC);
                }
            }
            else if (GV.Scheduling == true && GV.RR)                // for Round Robin
            {
                GV.TurnaroundTimee = new int[GV.NumberOfProcessesRange];
                int t1 = 0;
                Console.Write(t1);
                for (int j = 0; j < (GV.max / GV.t) + 1; j++)
                {
                    for (int i = 0; i < GV.NumberOfProcessesRange; i++)
                    {
                        if (GV.BursttTime[i] != 0)
                        {
                            if (GV.BursttTime[i] >= GV.t)
                            {
                                t1 += GV.t;
                                Console.Write(" [P" + GV.Processes[i] + "] " + t1);
                            }
                            else
                            {
                                t1 += GV.BursttTime[i];
                                Console.Write(" [P" + GV.Processes[i] + "] " + t1);
                            }
                            if (GV.BursttTime[i] <= GV.t)
                            {
                                GV.TurnaroundTimee[i] = temp + GV.BursttTime[i];
                                temp = temp + GV.BursttTime[i];
                                GV.BursttTime[i] = 0;
                            }
                            else
                            {
                                GV.BursttTime[i] = GV.BursttTime[i] - GV.t;
                                temp = temp + GV.t;
                            }
                        }
                    }
                }
            }
            else if (GV.Scheduling == true && GV.Priority)
            {
                Console.Write(GV.GCTC);
                for(int i = 0; i < GV.NumberOfProcessesRange; i++)
                {
                    GV.GCTC += GV.BurstTime[i];
                    Console.Write(" [P" + GV.Processes[i] + "] ");
                    Console.Write(GV.GCTC);
                }
            }
            Console.WriteLine("\n=======================================================================================================================");
            Warning();
            //FreeConsole();
        }
        public void Warning()
        {
            Console.WriteLine("\n\n=======================================================================================================================");
            Console.WriteLine("\n\n!!!!!!!!!ATTENTION!!!!!NOW DON'T CLOSE THIS CONSOLE SCREEN SINCE IT IS ATTACHED TO YOUR WINFORM PROJECT NOW IF YOU \nCLOSED IT WHOLE PROJECT WILL STOP RUNNING AND YOU WILL LOOSE YOUR DATA, CONTINUE YOUR WORK ON WINFORM NORMALLY WITHOUT \nCLOSING THIS CONSOLE SCREEN!!!!");
            Console.WriteLine("\n=======================================================================================================================");
        }
        //[DllImport("kernel32.dll")]
        //static extern bool FreeConsole();
        public void Resetter()
        {
            GV.Table.Columns.Clear();
            GV.Table.Clear();
            Array.Clear(GV.Processes, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.BurstTime, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.WaitingTime, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.TurnaroundTime, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.BursttTime, 0, GV.NumberOfProcessesRange);
            Array.Clear(GV.TurnaroundTimee, 0, GV.NumberOfProcessesRange);
            GV.AvgWaitingTime = 0;
            GV.AvgTurnaroundTime = 0;
        }
    }
}