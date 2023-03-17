using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace Form1
{
    public partial class Main : Form
    {
        // Atributos
        Menu myMenu = new Menu();

        FlightPlanList myFlightPlanList = new FlightPlanList();
        List<PictureBox> myPicBoxLista = new List<PictureBox>();
        double mySecDist;
        double myCycleTime;

        Stack<FlightPlanList> myStack = new Stack<FlightPlanList>();

        int clicks = 0;

        List<FlightPlan> oldVels = new List<FlightPlan>();
        List<FlightPlan> newVels = new List<FlightPlan>();

        User userClass;

        // InitializeComponent()
        public Main()
        {
            InitializeComponent();
        }

        // Métodos
        public void TomaDatos(User user)
        {
            this.userClass = user;
        }

        private void Main_Load(object sender, EventArgs e)
        // Before opening Main(), we open Menu() so that the user can input Flight Plans, the 'Security distance' and the 'Cycle time'
        {
            this.Hide();
            myMenu.ShowDialog();
            this.Show();

            if(myMenu.GetFlightPlanList().GetLista().Count != 0 && myMenu.GetPicBoxList().Count != 0 && myMenu.GetSecurityDistance() != 0 && myMenu.GetCycleTime() != 0)
            {
                this.Show();
                myFlightPlanList = myMenu.GetFlightPlanList();
                myPicBoxLista = myMenu.GetPicBoxList();
                mySecDist = myMenu.GetSecurityDistance();
                myCycleTime = myMenu.GetCycleTime();

                this.AddPictureBoxes();

                panel1.Invalidate();

                if(myFlightPlanList.GetLista()[0].DameCurrentPosition().GetX() != myFlightPlanList.GetLista()[0].DameInitialPosition().GetX() || myFlightPlanList.GetLista()[0].DameCurrentPosition().GetY() != myFlightPlanList.GetLista()[0].DameInitialPosition().GetY())
                {
                    FlightPlanList fpListCopia1 = new FlightPlanList();
                    fpListCopia1.CopyList(this.myFlightPlanList);
                    fpListCopia1.Restart();

                    FlightPlanList fpl0 = new FlightPlanList();
                    fpl0.CopyList(fpListCopia1);
                    myStack.Push(fpl0);

                    if(myFlightPlanList.GetLista()[0].DameInitialPosition().GetX() <= myFlightPlanList.GetLista()[0].DameFinalPosition().GetX() && myFlightPlanList.GetLista()[0].DameInitialPosition().GetY() <= myFlightPlanList.GetLista()[0].DameFinalPosition().GetY())
                    {
                        fpListCopia1.Mover(this.myCycleTime);

                        while (fpListCopia1.GetLista()[0].DameCurrentPosition().GetX() < myFlightPlanList.GetLista()[0].DameCurrentPosition().GetX() || fpListCopia1.GetLista()[0].DameCurrentPosition().GetY() < myFlightPlanList.GetLista()[0].DameCurrentPosition().GetY())
                        {
                            FlightPlanList fpl1 = new FlightPlanList();
                            fpl1.CopyList(fpListCopia1);
                            myStack.Push(fpl1);

                            fpListCopia1.Mover(this.myCycleTime);
                        }
                    }

                    if (myFlightPlanList.GetLista()[0].DameInitialPosition().GetX() <= myFlightPlanList.GetLista()[0].DameFinalPosition().GetX() && myFlightPlanList.GetLista()[0].DameInitialPosition().GetY() >= myFlightPlanList.GetLista()[0].DameFinalPosition().GetY())
                    {
                        fpListCopia1.Mover(this.myCycleTime);

                        while (fpListCopia1.GetLista()[0].DameCurrentPosition().GetX() < myFlightPlanList.GetLista()[0].DameCurrentPosition().GetX() || fpListCopia1.GetLista()[0].DameCurrentPosition().GetY() > myFlightPlanList.GetLista()[0].DameCurrentPosition().GetY())
                        {
                            FlightPlanList fpl1 = new FlightPlanList();
                            fpl1.CopyList(fpListCopia1);
                            myStack.Push(fpl1);

                            fpListCopia1.Mover(this.myCycleTime);
                        }
                    }

                    if (myFlightPlanList.GetLista()[0].DameInitialPosition().GetX() >= myFlightPlanList.GetLista()[0].DameFinalPosition().GetX() && myFlightPlanList.GetLista()[0].DameInitialPosition().GetY() <= myFlightPlanList.GetLista()[0].DameFinalPosition().GetY())
                    {
                        fpListCopia1.Mover(this.myCycleTime);

                        while (fpListCopia1.GetLista()[0].DameCurrentPosition().GetX() > myFlightPlanList.GetLista()[0].DameCurrentPosition().GetX() || fpListCopia1.GetLista()[0].DameCurrentPosition().GetY() < myFlightPlanList.GetLista()[0].DameCurrentPosition().GetY())
                        {
                            FlightPlanList fpl1 = new FlightPlanList();
                            fpl1.CopyList(fpListCopia1);
                            myStack.Push(fpl1);

                            fpListCopia1.Mover(this.myCycleTime);
                        }
                    }

                    if (myFlightPlanList.GetLista()[0].DameInitialPosition().GetX() >= myFlightPlanList.GetLista()[0].DameFinalPosition().GetX() && myFlightPlanList.GetLista()[0].DameInitialPosition().GetY() >= myFlightPlanList.GetLista()[0].DameFinalPosition().GetY())
                    {
                        fpListCopia1.Mover(this.myCycleTime);

                        while (fpListCopia1.GetLista()[0].DameCurrentPosition().GetX() > myFlightPlanList.GetLista()[0].DameCurrentPosition().GetX() || fpListCopia1.GetLista()[0].DameCurrentPosition().GetY() > myFlightPlanList.GetLista()[0].DameCurrentPosition().GetY())
                        {
                            FlightPlanList fpl1 = new FlightPlanList();
                            fpl1.CopyList(fpListCopia1);
                            myStack.Push(fpl1);

                            fpListCopia1.Mover(this.myCycleTime);
                        }
                    }
                }

                this.Conflict();
            }
            else
            {
                MessageBox.Show("The program will close because there's data missing!");
                this.Close();
            }
        }

        private void Conflict()
        {
            // We create a copy in order to not change the values of the original FlightPlanList
            FlightPlanList fpListCopia = new FlightPlanList();
            fpListCopia.CopyList(this.myFlightPlanList);

            // This loop detects if any of the aircraft inside the FlightPlanList has the same final or initial position as another aircraft. If this was the case, the user would be informed that the conflict can't be solved
            bool conflictCanBeSolved = true;
            for (int i = 0; i < fpListCopia.GetLista().Count; i++)
            {
                for (int j = 0; j < fpListCopia.GetLista().Count; j++)
                {
                    if (j != i)
                    {
                        if ((fpListCopia.GetLista()[i].DameFinalPosition().GetX() == fpListCopia.GetLista()[j].DameFinalPosition().GetX() && fpListCopia.GetLista()[i].DameFinalPosition().GetY() == fpListCopia.GetLista()[j].DameFinalPosition().GetY()) || (fpListCopia.GetLista()[i].DameInitialPosition().GetX() == fpListCopia.GetLista()[j].DameInitialPosition().GetX() && fpListCopia.GetLista()[i].DameInitialPosition().GetY() == fpListCopia.GetLista()[j].DameInitialPosition().GetY()))
                        {
                            conflictCanBeSolved = false;
                        }
                    }
                }
            }

            if (conflictCanBeSolved is true)
            {
                if (fpListCopia.WillBeInConflict(this.mySecDist, this.myCycleTime) is true)
                {
                    MessageBox.Show("DANGER!\nFlights will be in conflict!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    for (int i = 0; i < fpListCopia.GetLista().Count; i++)
                    {
                        for (int j = 0; j < fpListCopia.GetLista().Count; j++)
                        {
                            if (j != i)
                            {
                                bool conflict = fpListCopia.GetLista()[i].WillBeInConflict(fpListCopia.GetLista()[j], this.mySecDist, this.myCycleTime);
                                if (conflict is true)
                                {
                                    bool newConflict = true;
                                    double proposedVelocity = 0;

                                    while (newConflict != false)
                                    {
                                        fpListCopia.Restart();
                                        double badVelocity = fpListCopia.GetLista()[j].DameVelocidad();
                                        proposedVelocity = badVelocity - 5;

                                        if (badVelocity <= 10)
                                        {
                                            //MessageBox.Show(Convert.ToString(proposedVelocity));
                                            newConflict = false;
                                        }
                                        else
                                        {
                                            fpListCopia.GetLista()[j].SetVelocidad(proposedVelocity);
                                            newConflict = fpListCopia.GetLista()[i].WillBeInConflict(fpListCopia.GetLista()[j], this.mySecDist, this.myCycleTime);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    bool conflictCanBeSolved2 = true;
                    for (int i = 0; i < fpListCopia.GetLista().Count; i++)
                    {
                        if (fpListCopia.GetLista()[i].DameVelocidad() < 10)
                        {
                            conflictCanBeSolved2 = false;
                        }
                    }

                    if (conflictCanBeSolved2 is true)
                    {
                        ProposeVelocity propVelForm = new ProposeVelocity();

                        propVelForm.TomaDatos(this.myFlightPlanList, fpListCopia);
                        propVelForm.ShowDialog();

                        List<FlightPlan> oldVelsForm2 = propVelForm.GetOldVels();
                        List<FlightPlan> newVelsForm2 = propVelForm.GetNewVels();

                        //MessageBox.Show(Convert.ToString(propVelForm.GetNewVels().Count));

                        if(newVelsForm2.Count != 0)
                        {
                            for (int i = 0; i < oldVelsForm2.Count; i++)
                            {
                                if (oldVelsForm2[i].DameVelocidad() != newVelsForm2[i].DameVelocidad())
                                {
                                    this.oldVels.Add(oldVelsForm2[i]);
                                    this.newVels.Add(newVelsForm2[i]);
                                }
                            }

                            if (propVelForm.DameAccept() is true)
                            {
                                for (int i = 0; i < this.myFlightPlanList.GetLista().Count; i++)
                                {
                                    this.myFlightPlanList.GetLista()[i].SetVelocidad(fpListCopia.GetLista()[i].DameVelocidad());
                                }
                                MessageBox.Show("Velocities successfully changed!");
                            }
                            else
                            {
                                MessageBox.Show("Velocity changes have been rejected!");
                            }
                        }
                        // else: if the users closes the form clicking the red cross
                        else
                        {
                            MessageBox.Show("Velocity changes have been rejected!");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Conflict can't be solved!");
                    }
                }
                else
                {
                    MessageBox.Show("Don't worry.\nFlights won't be in conflict!");
                }
            }
            else
            {
                MessageBox.Show("Conflict can't be solved!");
            }
        }

        private void AddPictureBoxes()
        // Adds all the PictureBoxes to the panel
        {
            for (int i = 0; i < myFlightPlanList.GetLista().Count; i++)
            {
                panel1.Controls.Add(myPicBoxLista[i]);
            }
        }

        private void MoverPictureBoxes()
        // Moves the PictureBoxes to the current position of the aircrafts
        {
            for (int i = 0; i < this.myPicBoxLista.Count; i++)
            {
                this.myPicBoxLista[i].Location = new Point(Convert.ToInt32(this.myFlightPlanList.GetLista()[i].DameCurrentPosition().GetX()) - 10, Convert.ToInt32(this.myFlightPlanList.GetLista()[i].DameCurrentPosition().GetY()) - 10);
            }
        }

        private void RestartPictureBoxes()
        // Restarts the PictureBoxes to the initial position of the aircrafts
        {
            for (int i = 0; i < this.myPicBoxLista.Count; i++)
            {
                this.myPicBoxLista[i].Location = new Point(Convert.ToInt32(this.myFlightPlanList.GetLista()[i].DameInitialPosition().GetX()) - 10, Convert.ToInt32(this.myFlightPlanList.GetLista()[i].DameInitialPosition().GetY()) - 10);
            }
        }

        private void RestartAll()
        // Restarts the FlightPlanList and the PictureBoxList
        {
            Reloj.Stop();
            moveAutoBtn.Text = "Move Automatically";
            clicks = 2;

            this.myFlightPlanList.Restart();
            this.RestartPictureBoxes();

            myStack.Clear();
            panel1.Invalidate();
        }

        private bool IsOdd()
        // Used to change the button "Move Automatically" to "Stop" without needing two different buttons
        {
            if (this.clicks%2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        // Shows the position of the mouse in the panel
        {
            posLabel.Text = "X = " + e.X + " Y = " + e.Y;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        // Informs the user when the mouse is not inside the panel
        {
            posLabel.Text = "Te has salido!";
        }

        private void moveOneCycleBtn_Click(object sender, EventArgs e)
        // Moves all the aircrafts one cycle if there is no immediate conflict
        {
            FlightPlanList fpListCopia = new FlightPlanList();
            fpListCopia.CopyList(this.myFlightPlanList);

            if(myStack.Count == 0)
            {
                FlightPlanList fpl1 = new FlightPlanList();
                fpl1.CopyList(this.myFlightPlanList);
                myStack.Push(fpl1);
            }

            if(this.myFlightPlanList.EstanDestino() is false)
            {
                if (fpListCopia.ImmediateConflict(this.mySecDist, this.myCycleTime) is false)
                {
                    this.myFlightPlanList.Mover(this.myCycleTime);
                    this.MoverPictureBoxes();
                }
                else
                {
                    this.RestartAll();

                    MessageBox.Show("Conflict between aircrafts has been detected!\nRestarting all aircrafts to their initial position.");
                }

                FlightPlanList fpl = new FlightPlanList();
                fpl.CopyList(this.myFlightPlanList);
                myStack.Push(fpl);
            }
            else
            {
                Reloj.Stop();
                moveAutoBtn.Text = "Move Automatically";
                clicks = 2;

                MessageBox.Show("All aircrafts have arrived at their final positions!");
            }
            
            panel1.Invalidate();
        }

        private void moveAutoBtn_Click(object sender, EventArgs e)
        // Starts the timer and activates the event timer_Tick
        {
            this.clicks += 1;
            if(this.IsOdd() == true)
            {
                //Reloj.Interval = x * 1000; (units: [ms])
                int tiempo = Convert.ToInt32(this.myCycleTime * 1000);
                Reloj.Interval = tiempo;
                Reloj.Start();
                moveAutoBtn.Text = "Stop";
            }
            else
            {
                Reloj.Stop();
                moveAutoBtn.Text = "Move Automatically";
            }
            
        }

        private void Reloj_Tick(object sender, EventArgs e)
        // Moves all the aircrafts one cycle every certain time (interval) when moveAutoBtn is clicked
        {
            moveOneCycleBtn_Click(sender, e);
        }

        private void flightDataBtn_Click(object sender, EventArgs e)
        // Opens the FlightData Form in order to show in a DataGriedView the data of all the FlightPlans
        {
            FlightData flightData = new FlightData();
            flightData.TomaDatos(this.myFlightPlanList.GetLista(), this.myFlightPlanList.GetLista());
            flightData.ShowDialog();
        }

        private void conflictBtn_Click(object sender, EventArgs e)
        // Detects if there will be conflict between the aircrafts. If it detects conflict, ProposeVelocity Form will open (only if conflict can be solved, otherwise the program will advertise the user that the conflict can't be solved) in order to indicate you what velocity changes need to be applied so that there is no longer conflict, and the user can accept the velocity changes or reject them
        {
            // We reset all the aircrafts to their initial positions
            this.RestartAll();

            this.Conflict();
        }

        private void restartBtn_Click(object sender, EventArgs e)
        // Restarts all the aircrafts to their initial positions
        {
            this.RestartAll();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        // Paints into the panel the trajectory lines of the aircrafts and a circle around every aircraft that shows the security distance
        {
            // Tools
            System.Drawing.Graphics graphics = e.Graphics;
            Pen myPen = new Pen(Color.DarkOliveGreen);
            myPen.Width = 2;
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            SolidBrush myBrush = new SolidBrush(Color.Tomato);

            // Trajectory lines
            for (int i = 0; i<myFlightPlanList.GetLista().Count; i++)
            {
                Point initialPos = new Point(Convert.ToInt32(myFlightPlanList.GetLista()[i].DameInitialPosition().GetX()), Convert.ToInt32(myFlightPlanList.GetLista()[i].DameInitialPosition().GetY()));
                Point finalPos = new Point(Convert.ToInt32(myFlightPlanList.GetLista()[i].DameFinalPosition().GetX()), Convert.ToInt32(myFlightPlanList.GetLista()[i].DameFinalPosition().GetY()));
                graphics.DrawLine(myPen, initialPos, finalPos);
            }

            // Ellipse (Circle around the aircrafts)
            for (int i = 0; i < myFlightPlanList.GetLista().Count; i++)
            {
                Rectangle rec = new Rectangle();
                rec.X = Convert.ToInt32(myFlightPlanList.GetLista()[i].DameCurrentPosition().GetX()) - Convert.ToInt32(mySecDist);
                rec.Y = Convert.ToInt32(myFlightPlanList.GetLista()[i].DameCurrentPosition().GetY()) - Convert.ToInt32(mySecDist);
                rec.Height = 2 * Convert.ToInt32(mySecDist);
                rec.Width = 2 * Convert.ToInt32(mySecDist);
                graphics.FillEllipse(myBrush, rec);
            }
        }

        private void changeVelBtn_Click(object sender, EventArgs e)
        // Opens the ChangeSpeeds Form so that you can change any velocity of any aircraft you want. It restarts all the aircrafts to their initial positions when closing the Form
        {
            ChangeSpeeds changeSpeedsForm = new ChangeSpeeds();
            changeSpeedsForm.TomaDatos(myFlightPlanList);
            changeSpeedsForm.ShowDialog();

            myFlightPlanList = changeSpeedsForm.GetFlightPlanList();
            List<FlightPlan> oldVelsForm = changeSpeedsForm.GetOldVels();
            List<FlightPlan> newVelsForm = changeSpeedsForm.GetNewVels();

            if(newVelsForm.Count != 0)
            {
                for (int i = 0; i < oldVelsForm.Count; i++)
                {
                    if (oldVelsForm[i].DameVelocidad() != newVelsForm[i].DameVelocidad())
                    {
                        this.oldVels.Add(oldVelsForm[i]);
                        this.newVels.Add(newVelsForm[i]);
                    }
                }

                this.RestartAll();
            }
            // else: if the users closes the form clicking the red cross
            else
            {
                MessageBox.Show("No velocity changes have been applied because the Form closed unexpectedly!");
            }
        }

        private void undoBtn_Click(object sender, EventArgs e)
        // Undoes one step of the simulation
        {
            Reloj.Stop();
            moveAutoBtn.Text = "Move Automatically";
            clicks = 2;
            if (myStack.Count > 0)
            {
                myStack.Pop();
                if (myStack.Count > 0)
                {
                    myFlightPlanList = myStack.ElementAt(0);

                    this.MoverPictureBoxes();
                    panel1.Invalidate();
                }
                else
                {
                    MessageBox.Show("There are no more steps to undo");
                }
            }
            else
            {
                MessageBox.Show("Aircraft have not been moved yet!");
            }            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        // Saves the current FlightPlanList into a (.txt) file, so that the user can load it later and simulation can be restarted from the last position simulated in the previous simulation session
        {
            try
            {
                saveFileDialog1.ShowDialog();
                string name = saveFileDialog1.FileName;
                if (name != "")
                {
                    name = name + ".txt";
                    this.myFlightPlanList.WriteFile(name);
                    MessageBox.Show("Flight Plan List saved successfully!");

                    SendEmailWithFile sendEmailForm = new SendEmailWithFile();
                    sendEmailForm.TomaDatos(userClass, name);
                    sendEmailForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Flight Plan List could NOT be saved because the Form closed unexpectedly!");
                }
            }
            catch
            {
                MessageBox.Show("Error. Try again!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveFileVelChangesBtn_Click(object sender, EventArgs e)
        // Obtains a file describing each change and including telephone and email of the companies involved so that these companies can be adequately informed
        {
            try
            {
                bool changes = false;
                for(int i = 0; i < this.oldVels.Count; i++)
                {
                    if (this.oldVels[i].DameVelocidad() != this.newVels[i].DameVelocidad())
                    {
                        changes = true;
                    }
                }
                if (changes is true)
                {
                    saveFileDialog1.ShowDialog();
                    string name = saveFileDialog1.FileName;
                    if (name != "")
                    {
                        name = name + ".txt";
                        this.myFlightPlanList.WriteFileSpeedChanges(this.oldVels, this.newVels, name);
                        MessageBox.Show("Flight Plan List saved successfully!");

                        SendEmailWithFile sendEmailForm = new SendEmailWithFile();
                        sendEmailForm.TomaDatos(userClass, name);
                        sendEmailForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("The List describing all the velocity changess could NOT be saved because the Form closed unexpectedly!");
                    }
                }
                else
                {
                    MessageBox.Show("There hasn't been any velocity change yet!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error. Try again!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showDatabaseBtn_Click(object sender, EventArgs e)
        // Shows all the information in the data base. And the user can insert and remove companies form the Database
        {
            ShowDataBase showDataBaseForm = new ShowDataBase();
            showDataBaseForm.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        // Displays a tutorial explaining the functionality of each botton
        {
            Tutorial tutorial = new Tutorial();

            Queue<string> infoMessages = new Queue<string>();
            string info = "Moves all the aircrafts one cycle\nif there is no immediate conflict, otherwise all aircrafts\nare restarted to their initial positions.";
            infoMessages.Enqueue(info);
            string info2 = "Moves all the aircrafts one cycle\nevery certain time (Cycle Time).";
            infoMessages.Enqueue(info2);
            string info3 = "Shows the data of every\nFlightPlan in a DataGriedView";
            infoMessages.Enqueue(info3);
            string info4 = "Checks if the aircrafts will be in conflict or not.\nIf conflict is detected and it can be solved,\na Form displaying the proposed velocities opens\nand the user decides whether to accept those\nvelocity changes or not.";
            infoMessages.Enqueue(info4);
            string info5 = "Restarts all the aircrafts to\ntheir initial positions.";
            infoMessages.Enqueue(info5);
            string info6 = "Opens a DataGriedView displaying the\ncurrent velocities of all the aircrafts,\nand the user can change those velocities.";
            infoMessages.Enqueue(info6);
            string info7 = "Undoes one step of the simulation only if\nthe aircrafts have already been moved.";
            infoMessages.Enqueue(info7);
            string info8 = "Saves a (.txt) File with the current Flight Plans.\nSo that the user can resume the program\nat another time.";
            infoMessages.Enqueue(info8);
            string info9 = "Saves a (.txt) File decribing all the velocity\nchanges that have been applied alongside the\ninformation of the companies of the aircrafts which\nvelocity has been modified.";
            infoMessages.Enqueue(info9);
            string info10 = "Shows two DataGriedViews displaying the two\ntables that are in our Database.\nInside this Form, the user has an option to\ninsert or delete new companies to the Database.";
            infoMessages.Enqueue(info10);

            Queue<Button> myBotons = new Queue<Button>();
            myBotons.Enqueue(moveOneCycleBtn);
            myBotons.Enqueue(moveAutoBtn);
            myBotons.Enqueue(flightDataBtn);
            myBotons.Enqueue(conflictBtn);
            myBotons.Enqueue(restartBtn);
            myBotons.Enqueue(changeVelBtn);
            myBotons.Enqueue(undoBtn);
            myBotons.Enqueue(saveBtn);
            myBotons.Enqueue(saveFileVelChangesBtn);
            myBotons.Enqueue(showDatabaseBtn);

            bool continueTutorial = true;
            int i = 0;
            while (continueTutorial is true && i < 10)
            {
                Button button = myBotons.Dequeue();
                button.BackColor = Color.Red;
                tutorial.TomaDatos(infoMessages.Dequeue());
                tutorial.ShowDialog();
                button.BackColor = SystemColors.Control;
                continueTutorial = tutorial.GetContinueTutorial();
                if (continueTutorial is false)
                {
                    MessageBox.Show("Tutorial has been stopped.\nReturning to the main program.");
                }
                i++;
            }
            if (i == 10)
            {
                MessageBox.Show("Tutorial has ended, thank you for your attention!\nReturning to the main program.");
            }
        }
    }
}
