using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid_World_MDP
{
    public partial class Form1 : Form
    {
        private const int n_grid = 12;
        private const int n_col = 4;
        private double[] map = new double[] { 0, 0, 0, 1,
                                            0, double.PositiveInfinity, 0, -1,
                                            0, 0, 0, 0 };
        private List<int> terminal_states = new List<int>(new int[] { 3, 7 });
        private List<string> actions = new List<string>(new string[] { "←", "↑", "→", "↓" });

        private double[,] transition_probabilities ={
                                                       {0.8,0.1,0,0.1},
                                                       {0.1,0.8,0.1,0},
                                                       {0,0.1,0.8,0.1},
                                                       {0.1,0,0.1,0.8}
                                                    };

        private double[] v;
        private int[] policy;

        private PictureBox[] grid;
        private Label[] label_q;
        private Label[] label_dir;
        
        private int iteration = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeComponent2();
            cmdReset_Click(null, null);
        }




        private void InitializeComponent2()
        {
           
            grid = new PictureBox[n_grid];
            label_q = new Label[n_grid];
            label_dir = new Label[n_grid];
            policy = new int[n_grid];

            for (int i=0; i< n_grid; i++)
            {
                grid[i] = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)(this.grid[0])).BeginInit();
                this.grid[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;           
                this.grid[i].Name = "grid" + i.ToString();
                this.grid[i].Size = new System.Drawing.Size(125, 125);
                this.grid[i].TabIndex = 100 + i;
                this.grid[i].TabStop = false;               
                this.grid[i].SizeMode = PictureBoxSizeMode.CenterImage;

                int row = i / n_col;
                int col = i % n_col;

                this.grid[i].Location = new Point(col * 124, row * 124);

               

                label_q[i] = new Label();
                label_dir[i] = new Label();

                this.label_dir[i].AutoSize = false;
                this.label_dir[i].Location = new System.Drawing.Point(grid[i].Left + 10, grid[i].Top + 10);
                this.label_dir[i].Name = "labeldir" + i.ToString();
                this.label_dir[i].Size = new System.Drawing.Size(100, 70);
                this.label_dir[i].TabIndex = 26;
                this.label_dir[i].Text = "label2";
                this.label_dir[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label_dir[i].TextAlign = ContentAlignment.TopCenter;
                this.label_dir[i].ForeColor = Color.White;
                this.label_dir[i].Parent = grid[i];
                this.label_dir[i].BackColor = Color.Transparent;
                
              

                this.label_q[i].AutoSize = false;
                this.label_q[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                this.label_q[i].Name = "labelq" + i.ToString();
                
                this.label_q[i].TabIndex = 27;
                this.label_q[i].Text = "label4";
                this.label_q[i].TextAlign = ContentAlignment.TopCenter;
                this.label_q[i].ForeColor = Color.White;
                this.label_q[i].Parent = grid[i];
                this.label_q[i].BackColor = Color.Transparent;
                
             

                if (double.IsPositiveInfinity(map[i]))
                {
                    grid[i].BackColor = Color.Gray;
                    label_dir[i].BackColor = Color.Gray;
                    label_q[i].BackColor = Color.Gray;
                    this.label_q[i].Text = "";
                    this.label_dir[i].Text = "";                   
                }


            }
            panel1.Width = n_col * 125;
            panel1.Height = (n_grid / n_col) * 125;

           

            for (int i=0; i< n_grid; i++)
            {
              
                this.panel1.Controls.Add(this.label_dir[i]);
                this.panel1.Controls.Add(this.label_q[i]);
                this.panel1.Controls.Add(this.grid[i]);

                ((System.ComponentModel.ISupportInitialize)(this.grid[i])).EndInit();
            }

          
        }


        int transition(int current_state, string action)
        {
            int new_state = current_state;

            switch (action)
            {
                case "←":
                    if (current_state% n_col == 0)
                    { //The robot is in the first column
                        return current_state;
                    }
                    else
                    {
                        if (double.IsPositiveInfinity(map[current_state - 1]))
                        {
                            return current_state;
                        }
                        else
                        {
                            return current_state - 1;
                        }
                    }                 
                case "↑":
                    if (current_state<n_col)
                    { //The robot is in the first row
                        return current_state;
                    }
                    else
                    {
                        if (double.IsPositiveInfinity(map[current_state - n_col]))
                        {
                            return current_state;
                        }
                        else
                        {
                            return current_state - n_col;
                        }
                    }                    
                case "→":
                    if ((current_state+1)%n_col==0)
                    { //The robot is the last column
                        return current_state;
                    }
                    else
                    {
                        

                        if (double.IsPositiveInfinity(map[current_state + 1]))
                        {
                            return current_state;
                        }
                        else
                        {
                            return current_state + 1;
                        }
                    }
                case "↓":
                    if (current_state >= n_grid - n_col) 
                    { //The robot is in last row
                        return current_state;
                    }
                    else
                    {
                        

                        if (double.IsPositiveInfinity(map[current_state + n_col]))
                        {
                            return current_state;
                        }
                        else
                        {
                            return current_state + n_col;
                        }
                    }
            }

            return new_state;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            iteration = 0;
            v = new double[n_grid];
            for (int i = 0; i < n_grid; i++)
            {
                if (double.IsPositiveInfinity(map[i]))
                {
                    continue;
                }
                if (terminal_states.Contains(i))
                {                   
                    label_dir[i].Text = "No action";
                    continue;
                }
                label_dir[i].Text = "";
                for (int j=0; j<actions.Count; j++)
                {
                    label_dir[i].Text += actions[j] + " 0" + Environment.NewLine;
                }
                policy[i] = 0;
                v[i] = 0;

               
            }
            RefreshMap();
        }

        private void valueIteration(double discount, double reward)
        {
            double[] v_copy = new List<double>(v).ToArray();
            for (int i = 0; i < n_grid; i++)
            {
                if (double.IsPositiveInfinity(map[i]))
                {
                    continue;
                }

                if (terminal_states.Contains(i))
                {
                    v[i] = map[i] + reward;
                    label_dir[i].Text = "No action";
                    continue;
                }

                if (i == 2)
                {

                }

                double[] va = new double[actions.Count];
                label_dir[i].Text = "";

                double max = double.NegativeInfinity;
                for (int j = 0; j < actions.Count; j++)
                {

                    for (int k = 0; k < actions.Count; k++)
                    {
                        int newstate = transition(i, actions[k]);
                        va[j] += transition_probabilities[j, k] * v_copy[newstate];
                    }

                    va[j] *= discount;
                    va[j] += map[i] + reward;

                    if (va[j] > max)
                    {
                        max = va[j];
                        policy[i] = j;
                    }

                    label_dir[i].Text += actions[j] + " " + Math.Round(va[j], 2) + Environment.NewLine;


                }

                v[i] = va.Max();
            }
        }
        private void policyIteration(double discount, double reward)
        {
            double[] v_copy = new List<double>(v).ToArray();

            for (int i=0; i< n_grid; i++)
            {
                double[] va = new double[actions.Count];
                label_dir[i].Text = "";

                double max = double.NegativeInfinity;
                for (int j = 0; j < actions.Count; j++)
                {
                    for (int k = 0; k < actions.Count; k++)
                    {
                        int newstate = transition(i, actions[k]);
                        va[j] += transition_probabilities[j, k] * v_copy[newstate];
                    }

                    va[j] *= discount;
                    va[j] += map[i] + reward;

                    if (va[j] > max)
                    {
                        max = va[j];
                        policy[i] = j;
                    }

                }
            }










            for (int i = 0; i < n_grid; i++)
            {
                if (double.IsPositiveInfinity(map[i]))
                {
                    continue;
                }
                if (terminal_states.Contains(i))
                {
                    v[i] = map[i] + reward;
                    label_dir[i].Text = "No action";
                    continue;
                }

                if (i==2)
                {

                }


                v[i] = 0;
                int intended_action = policy[i];
                for (int j=0; j<actions.Count; j++)
                {
                    int newstate = transition(i, actions[j]);
                    v[i] += transition_probabilities[intended_action, j] * v_copy[newstate];
                }
                v[i] *= discount;
                v[i] += map[i] + reward;
           
            }
        }

        private void cmdOneStep_Click(object sender, EventArgs e)
        {
           


            double discount = 0;
            try
            {
                discount = double.Parse(txtDiscount.Text);
            }
            catch
            {
                MessageBox.Show("Discount has to be a number.");
                return;
            }
            if (discount <= 0 || discount > 1)
            {
                MessageBox.Show("Discount has to be greater than 0 and less than or equal to 1");
                return;
            }

            double reward = 0;
            try
            {
                reward = double.Parse(txtReward.Text);
            }
            catch
            {
                MessageBox.Show("Reward has to be a number.");
                return;
            }
            if (reward > 0)
            {
                MessageBox.Show("Reward has to be less than or equal to 0.");
                return;
            }

            if (radioButton1.Checked)
            {
                valueIteration(discount, reward);
            }
            else
            {
                policyIteration(discount, reward);
            }
          
            iteration++;
            RefreshMap();

        }


       

        private void RefreshMap()
        {
            if (radioButton1.Checked)
            {
                #region value iteration
                double max = v.Max();
                double min = v.Min();

                for (int i = 0; i < n_grid; i++)
                {
                    this.label_q[i].Location = new Point(grid[i].Left + 10, grid[i].Top + 80);
                    this.label_q[i].Size = new System.Drawing.Size(100, 40);
                    if (double.IsPositiveInfinity(map[i]))
                    {
                        continue;
                    }
                    label_dir[i].Visible = true;
                    grid[i].Image = null;


                    if (v[i] > 0)
                    {
                        int range = 0;

                        if (max > 0)
                        {
                            range = (int)(v[i] * 255 / max);
                        }
                        grid[i].BackColor = Color.FromArgb(0, range, 0);
                        label_q[i].BackColor = Color.FromArgb(0, range, 0);
                        label_dir[i].BackColor = Color.FromArgb(0, range, 0);

                        if (range < 128)
                        {
                            label_q[i].ForeColor = Color.White;
                            label_dir[i].ForeColor = Color.White;
                        }
                        else
                        {
                            label_q[i].ForeColor = Color.Black;
                            label_dir[i].ForeColor = Color.Black;
                        }
                    }
                    else if (v[i] == 0)
                    {
                        grid[i].BackColor = Color.Black;
                        label_q[i].BackColor = Color.Black;
                        label_dir[i].BackColor = Color.Black;
                        label_q[i].ForeColor = Color.White;
                        label_dir[i].ForeColor = Color.White;
                    }
                    else
                    {
                        int range = 0;

                        if (min < 0)
                        {
                            range = (int)(v[i] * 255 / min);
                        }

                        grid[i].BackColor = Color.FromArgb(range, 0, 0);
                        label_q[i].BackColor = Color.FromArgb(range, 0, 0);
                        label_dir[i].BackColor = Color.FromArgb(range, 0, 0);

                        if (range < 128)
                        {
                            label_q[i].ForeColor = Color.White;
                            label_dir[i].ForeColor = Color.White;
                        }
                        else
                        {
                            label_q[i].ForeColor = Color.Black;
                            label_dir[i].ForeColor = Color.Black;
                        }
                    }

                    if (label_dir[i].Text != "No action")
                    {
                        this.label_q[i].Text = "Best = " + actions[policy[i]] + " " + Environment.NewLine + Math.Round(v[i], 2).ToString();
                    }
                    else
                    {
                        this.label_q[i].Text = Math.Round(v[i], 2).ToString();
                    }

                }
                #endregion
            }
            else
            {
                #region policy iteration               
                for (int i = 0; i < n_grid; i++)
                {

                    this.label_q[i].Location = new Point(grid[i].Left + 10, grid[i].Top + 90);
                    this.label_q[i].Size = new System.Drawing.Size(100, 22);
                    if (double.IsPositiveInfinity(map[i]))
                    {
                        continue;
                    }


                    this.grid[i].BackColor = Color.White;
                    this.label_q[i].BackColor = Color.White;
                    this.label_dir[i].BackColor = Color.White;
                    this.label_q[i].ForeColor = Color.Black;
                    this.label_dir[i].BackColor = Color.Black;

                    if (!terminal_states.Contains(i))
                    {
                        switch (policy[i])
                        {
                            case 0:
                                grid[i].Image = picLeft.Image;
                                break;
                            case 1:
                                grid[i].Image = picUp.Image;
                                break;
                            case 2:
                                grid[i].Image = picRight.Image;
                                break;
                            case 3:
                                grid[i].Image = picDown.Image;
                                break;
                        }
                    }
                    label_dir[i].Visible = false;

                    this.label_q[i].Text = Math.Round(v[i], 2).ToString();

                }
                #endregion
            }

            label7.Text = "Step #" + iteration.ToString();
        }

        private void cmd10Steps_Click(object sender, EventArgs e)
        {
            double discount = 0;
            try
            {
                discount = double.Parse(txtDiscount.Text);
            }
            catch
            {
                MessageBox.Show("Discount has to be a number.");
                return;
            }
            if (discount <= 0 || discount > 1)
            {
                MessageBox.Show("Discount has to be greater than 0 and less than or equal to 1");
                return;
            }

            double reward = 0;
            try
            {
                reward = double.Parse(txtReward.Text);
            }
            catch
            {
                MessageBox.Show("Reward has to be a number.");
                return;
            }
            if (reward > 0)
            {
                MessageBox.Show("Reward has to be less than or equal to 0.");
                return;
            }


            for (int i=0; i<10; i++)
            {
                cmdOneStep_Click(sender, e);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cmdReset_Click(sender, e);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cmdReset_Click(sender, e);
        }
    }
}
