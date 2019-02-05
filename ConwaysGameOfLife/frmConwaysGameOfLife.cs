// frmConwaysGameOfLife.cs, ConwaysGameOfLife.sln
// CS 1181
// Katherine Wilsdon
// 4 November 2018
// Dr. Cody Permann
/* Description - Create the classic Conway's Game of Life. The user picks a starting shape, the size of the grid, and 
 * the number of turns. The 4 rules are: A living cell with 0 or 1 living neighbors dies, A living cell with 2 or 3 
 * living neighbors lives, A living cell with 4 or more living neighbors dies, and A dead cell with exactly 3 living 
 * neighbors comes back to life. The game will play the number of turns by applying the 4 game rules to the current 
 * game board in order to generate the next gameboard. The results are displayed on the form and are repeated until all turns are 
 * played.*/
/* WOW: Add Diamond and Square starting patterns, where the Diamond is as tall and wide as the grid, and the square
 * is 80% as large as the total grid. */
/* Cited:
 * Seed generation for random number generator: https://stackoverflow.com/questions/1785744/how-do-i-seed-a-random-class-to-avoid-getting-duplicate-random-values
 * Form.AutoSize Property https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.autosize?view=netframework-4.7.2
 * Diamond https://stackoverflow.com/questions/43530327/fill-a-2d-array-as-a-diamond-shape
 * Clear the combobox https://stackoverflow.com/questions/9321844/how-do-i-clear-a-combobox
 * Book, Chapters 5, 6, and 7: Gaddis, T. (2017). Starting out with Visual C# (4th ed.). Boston, PA: Pearson.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife {
    public partial class frmConwaysGameOfLife : Form {
        public frmConwaysGameOfLife() {
            InitializeComponent();
        }

        // Declare field variables
        char[,] currentBoard;
        char[,] nextBoard;
        private int size;
        private int turns = 0;
        private int totalTurns;
        string errorMessage = "";
        private char dead = ' ';
        private char alive = 'O';
        Random random = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Intialize the size
        /// </summary>
        /// <returns>the size of the grid</returns>
        private int InitializeSize() {
            // Gets the size of the grid from the textbox
            int.TryParse(txtSizeInput.Text, out int size);
            return size;
        }

        /// <summary>
        /// Intialize the total turns
        /// </summary>
        /// <returns>the total turns played</returns>
        private int InitializeTotalTurns() {
            // Gets the total turns from the textbox
            int.TryParse(txtTurnsToPlayInput.Text, out int totalTurns);
            return totalTurns;
        }

        /// <summary>
        /// Initialize the arrays for the game board
        /// </summary>
        private void InitializeArrays() {
            currentBoard = new char[size, size];
            nextBoard = new char[size, size];
        }

        /// <summary>
        /// Shows a error message box
        /// </summary>
        private void Errors() {
            // when there is an error, show a message box
            if (size < 10 || totalTurns < 0 || cmbStartingShapes.SelectedIndex == -1) {
                if (cmbStartingShapes.SelectedIndex == -1) {
                    errorMessage += "Starting Shapes Error: Select a starting shape.\r\n";                    
                }
                if (size < 10) {
                    errorMessage += "Size Error: Enter an integer greater than or equal to 10.\r\n";
                }
                if (totalTurns < 0) {
                    errorMessage += "Turns Error: Enter an integer greater than or equal to 0.";
                }               
                MessageBox.Show(errorMessage);
            }
        }

        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <returns></returns>
        private int RandomNumberGenerator() {
            return random.Next(2);
        }

        /// <summary>
        /// Generates a randomize game board
        /// </summary>
        private void Random() {
            for (int r = 0; r < currentBoard.GetLength(0); r++) {
                for (int c = 0; c < currentBoard.GetLength(1); c++) {
                    // Get a random number
                    int randomNum = RandomNumberGenerator();
                    // When the random number is even, assign the position in the array to dead
                    if (randomNum % 2 == 0) 
                        currentBoard[r, c] = dead;
                    // When the random number is odd, assign the position in the array to alive
                    else if (randomNum % 2 == 1) 
                        currentBoard[r, c] = alive;                    
                }
            }
        }

        /// <summary>
        /// Generates a horizontal game board
        /// </summary>
        private void Horizontal() {
            for (int r = 0; r < currentBoard.GetLength(0); r++) {
                for (int c = 0; c < currentBoard.GetLength(1); c++) {
                    // When the row is even, assign the position in the array to dead
                    if (r % 2 == 0) 
                        currentBoard[r, c] = dead;
                    // When the row is odd, assign the position in the array to alive
                    else if (r % 2 == 1) 
                        currentBoard[r, c] = alive;
                    
                }
            }
        }

        /// <summary>
        /// Generates a vertical game boad
        /// </summary>
        private void Vertical() {
            for (int c = 0; c < currentBoard.GetLength(1); c++) {
                for (int r = 0; r < currentBoard.GetLength(0); r++) {
                    // When the column is even, assign the position in the array to dead
                    if (c % 2 == 0) 
                        currentBoard[r, c] = dead;
                    // When the column is odd, assign the position in the array to alive
                    else if (c % 2 == 1) 
                        currentBoard[r, c] = alive;                   
                }
            }
        }

        /// <summary>
        /// Generates a Odd Diamond game board
        /// </summary>
        private void OddDiamond() {
            // The middle is not subtracted by 1 since the result is truncated
            int middle = size / 2;
            // Assigns dead to every position in the array
            for (int r = 0; r < currentBoard.GetLength(0); r++) {
                for (int c = 0; c < currentBoard.GetLength(1); c++) {
                    currentBoard[r, c] = dead;
                }
            }
            // Creates the dimond shape in the array
            for (int r = 0; r < currentBoard.GetLength(0); r++) {
                // if the row is <= middle, then fill amount equal row, else fill amount 
                // equals the index size of the array - the row
                int fillAmount = (r <= middle) ? r : currentBoard.GetUpperBound(0) - r;
                for (int c = 0; c <= fillAmount; c++) {                 
                    currentBoard[r, middle - c] = alive;
                    currentBoard[r, middle + c] = alive;
                }
            }
        }
        /// <summary>
        /// Generates a Even Diamond game board
        /// </summary>
        private void EvenDiamond() {
            // The middle is subtracted by 1 to convert the size to the index
            int middle = (size / 2) - 1;
            // Assigns dead to every position in the array
            for (int r = 0; r < currentBoard.GetLength(0); r++) {
                for (int c = 0; c < currentBoard.GetLength(1); c++) {
                    currentBoard[r, c] = dead;
                }
            }
            // Creates the dimond shape in the array
            for (int r = 0; r < currentBoard.GetLength(0); r++) {
                // if the row is <= middle, then fill amount equal row, else fill amount 
                // equals the index size of the array - the row
                int fillAmount = (r <= middle) ? r : currentBoard.GetUpperBound(0) - r;
                for (int c = 0; c <= fillAmount; c++) {
                    currentBoard[r, middle - c] = alive;
                    currentBoard[r, middle + c] = alive;
                }
            }
        }

        /// <summary>
        /// Generates a Square board game
        /// </summary>
        private void Square() {
            // Gets the 20 and 80 percent values of the size and convert the size to the index
            int twentyPercent = (int)(size * 0.2) - 1;
            int eightyPercent = (int)(size * 0.8) - 1;
            for (int r = 0; r < currentBoard.GetLength(0); r++) {
                for (int c = 0; c < currentBoard.GetLength(1); c++) {
                    // Create the square shape in the array
                    if (r >= twentyPercent && r <= eightyPercent && c >= twentyPercent && c <= eightyPercent) {
                        currentBoard[r, c] = alive;
                    } else {
                        currentBoard[r, c] = dead;
                    }
                }
            }
        }
        /// <summary>
        /// Generate the game board depending on which starting shape is selected
        /// </summary>
        private void StartingShapes() {
            if (cmbStartingShapes.SelectedItem == cmbStartingShapes.Items[0]) {
                Random();
            } else if (cmbStartingShapes.SelectedItem == cmbStartingShapes.Items[1]) {
                Horizontal();
            } else if (cmbStartingShapes.SelectedItem == cmbStartingShapes.Items[2]) {
                Vertical();
            } else if (cmbStartingShapes.SelectedItem == cmbStartingShapes.Items[3]) {
                if (size % 2 == 0)
                    EvenDiamond();
                else if (size % 2 == 1)
                    OddDiamond();
            } else if (cmbStartingShapes.SelectedItem == cmbStartingShapes.Items[4]) {
                Square();
            }
        }
        /// <summary>
        /// Outputs the array to the the game board label
        /// </summary>
        private void GameBoard() {
            string board = "";
            // Adds the contents of the array to board
            for (int r = 0; r < currentBoard.GetLength(0); r++) {
                for (int c = 0; c < currentBoard.GetLength(1); c++) {
                    board += currentBoard[r, c].ToString() + " ";
                }
                board += "\r\n";
            }
            //Displays board in the label
            lblGameBoard.Text = board;
        }

            /// <summary>
            /// Determines if a cell should live depending on Conway's 4 rules
            /// </summary>
            /// <param name="row">the row coordinates of the array </param>
            /// <param name="column">the column coordinates of the array</param>
            /// <returns> whether the cell should live or die</returns>
            private bool ShouldCellLive(int row, int column) {
            bool shouldLive = false;
            int count = 0;            
            // When the position is in the top left corner of the array
            if (row == 0 && column == 0) {
                // Possible 3 neighboring cells
                for (int r = 0; r <= 1; r++) {
                    for (int c = 0; c <= 1; c++) {
                        // Do not count the middle cell
                        if (!(r == 0 && c == 0)) {
                            // When neighboring cell is alive, add 1 to the count
                            if (currentBoard[r + row, c + column] == alive) {
                                count += 1;
                            }
                        }
                    }
                }
                // When the position is in the top right corner of the array
            } else if (row == 0 && column == size - 1) {                
                // Possible 3 neighboring cells
                for (int r = 0; r <= 1; r++) {
                    for (int c = -1; c <= 0; c++) {
                        // Do not count the middle cell
                        if (!(r == 0 && c == 0)) {
                            // When neighboring cell is alive, add 1 to the count
                            if (currentBoard[r + row, c + column] == alive) {
                                count += 1;
                            }
                        }
                    }
                }
                // When the position is in the bottom left corner of the array
            } else if (row == size - 1 && column == 0) {
                // Possible 3 neighboring cells
                for (int r = -1; r <= 0; r++) {
                    for (int c = 0; c <= 1; c++) {
                        // Do not count the middle cell
                        if (!(r == 0 && c == 0)) {
                            // When neighboring cell is alive, add 1 to the count
                            if (currentBoard[r + row, c + column] == alive) {
                                count += 1;
                            }
                        }
                    }
                }
                // When the position is in the bottom right corner of the array
            } else if (row == size - 1 && column == size - 1) {
                // Possible 3 neighboring cells
                for (int r = -1; r <= 0; r++) {
                    for (int c = -1; c <= 0; c++) {
                        // Do not count the middle cell
                        if (!(r == 0 && c == 0)) {
                            // When neighboring cell is alive, add 1 to the count
                            if (currentBoard[r + row, c + column] == alive) {
                                count += 1;
                            }
                        }
                    }
                }
                // When the position is in the top row of the array
            } else if (row == 0) {
                // Possible 5 neighboring cells
                for (int r = 0; r <= 1; r++) {
                    for (int c = -1; c <= 1; c++) {
                        // Do not count the middle cell
                        if (!(r == 0 && c == 0)) {
                            // When neighboring cell is alive, add 1 to the count
                            if (currentBoard[r + row, c + column] == alive) {
                                count += 1;
                            }
                        }
                    }
                }
                // When the position is in the top column of the array
            } else if (column == 0) {
                // Possible 5 neighboring cells
                for (int r = -1; r <= 1; r++) {
                    for (int c = 0; c <= 1; c++) {
                        // Do not count the middle cell
                        if (!(r == 0 && c == 0)) {
                            // When neighboring cell is alive, add 1 to the count
                            if (currentBoard[r + row, c + column] == alive) {
                                count += 1;
                            }
                        }
                    }
                }
                // When the position is in the bottom row of the array
            } else if (row == size - 1) {
                // Possible 5 neighboring cells
                for (int r = -1; r <= 0; r++) {
                    for (int c = -1; c <= 1; c++) {
                        // Do not count the middle cell
                        if (!(r == 0 && c == 0)) {
                            // When neighboring cell is alive, add 1 to the count
                            if (currentBoard[r + row, c + column] == alive) {
                                count += 1;
                            }
                        }
                    }
                }
                // When the position is in the bottom column of the array
            } else if (column == size - 1) {
                // Possible 5 neighboring cells
                for (int r = -1; r <= 1; r++) {
                    for (int c = -1; c <= 0; c++) {
                        // Do not count the middle cell
                        if (!(r == 0 && c == 0)) {
                            // When neighboring cell is alive, add 1 to the count
                            if (currentBoard[r + row, c + column] == alive) {
                                count += 1;
                            }
                        }
                    }
                }
                // When the position is not on the edges of the array
            } else {
                // Possible 8 neighboring cells
                for (int r = -1; r <= 1; r++) {
                    for (int c = -1; c <= 1; c++) {
                        // Do not count the middle cell
                        if (!(r == 0 && c == 0)) {
                            // When neighboring cell is alive, add 1 to the count
                            if (currentBoard[r + row, c + column] == alive) {
                                count += 1;
                            }
                        }
                    }
                }
            } 
            // Conway's 4 rules
            if (currentBoard[row, column] == alive) {
                if (count <= 1)
                    shouldLive = false;
                else if (count <= 3)
                    shouldLive = true;
                else if (count >= 4)
                    shouldLive = false;
            } else if (currentBoard[row, column] == dead) {
                if (count == 3)
                    shouldLive = true;
                else
                    shouldLive = false;
            }
            return shouldLive;
        }

        /// <summary>
        /// Generates the next playing board
        /// </summary>
        private void FillInArray() {
            for (int r = 0; r < currentBoard.GetLength(0); r++) {
                for (int c = 0; c < currentBoard.GetLength(1); c++) {
                    bool shouldItLive = ShouldCellLive(r, c);
                    // when ShouldCellLive is true, assign the position of the array to alive
                    if (shouldItLive == true) {
                        nextBoard[r, c] = alive;
                        // when ShouldCellLive is false, assign the position of the array to dead
                    } else if (shouldItLive == false) {
                        nextBoard[r, c] = dead;
                    }
                }
            }
        }
        /// <summary>
        /// Runs the program
        /// </summary>
        private void Main() {
            // Initialization
            ClearFieldVariables();
            size = InitializeSize();
            totalTurns = InitializeTotalTurns();
            InitializeArrays();
            // Checks for errors
            Errors();
            // When there isn't an error and is less than total turns
            while (turns <= totalTurns && errorMessage == "") {
                // Display starting board
                if (turns == 0) {
                    // Display number of turns
                    lblTurnsOutput.Text = turns.ToString();   
                    // Create array depending on the starting shape and output to the game board
                    StartingShapes();                    
                    GameBoard();
                    // Update board every second
                    this.Update();
                    System.Threading.Thread.Sleep(1000);
                    // Add 1 to turns
                    turns++;
                } else {
                    // Display number of turns
                    lblTurnsOutput.Text = turns.ToString();
                    // Fill the next board array, copy next board to current board, and output to the game board
                    FillInArray();
                    Array.Copy(nextBoard, currentBoard, currentBoard.Length);
                    GameBoard();
                    // Update board every second
                    this.Update();
                    System.Threading.Thread.Sleep(1000);
                    // Add 1 to turns
                    turns++;
                }
            }           
        }
        /// <summary>
        /// Clears the output labels
        /// </summary>
        private void ClearOutputLabels() {
            lblGameBoard.Text = "";
            lblTurnsOutput.Text = "";
        }

        /// <summary>
        /// Clear the input textboxes for size and turns
        /// </summary>
        private void ClearSizeAndTurns() {
            txtSizeInput.Text = "50";
            txtTurnsToPlayInput.Text = "100";
        }

        /// <summary>
        /// Clear the ComboBox
        /// </summary>
        private void ClearCombBox() {
            cmbStartingShapes.SelectedIndex = -1;

        }

        /// <summary>
        /// Resets the field variables
        /// </summary>
        private void ClearFieldVariables() {
            // Uninitialize the arrays
            currentBoard = null;
            nextBoard = null;
            // Clear the field variables
            size = 0;
            turns = 0;
            totalTurns = 0;
            errorMessage = "";
        }
        /// <summary>
        /// The main clear program
        /// </summary>
        private void ClearMain() {
            ClearOutputLabels();
            ClearSizeAndTurns();
            ClearCombBox();
            ClearFieldVariables();
        }
        /// <summary>
        /// Starts the game when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miStartGame_Click(object sender, EventArgs e) {
            Main();
        }

        /// <summary>
        /// Clears the game when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miClear_Click(object sender, EventArgs e) {
            ClearMain();
        }

        /// <summary>
        /// Closes the game when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miExit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
