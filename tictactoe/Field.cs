using System.Text;

namespace tictactoe {
    public class Field {
        private char[,] playingField;

        /// <summary>
        /// Creates the field for the game
        /// </summary>
        /// <returns>
        /// A 3 by 3 character array with ' ' at each index
        /// </returns>
        public Field() {
            playingField = new char[3,3];
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    playingField[i, j] = ' ';
                }
            }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0;i < 3;i++) { 
                for(int j = 0;j < 3; j++) {
                    sb.Append('[');
                    sb.Append(playingField[i,j]);
                    sb.Append(']');
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        /// <summary>
        /// Prints out the playing field to console
        /// </summary>
        public void showField() {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Updates a cell in the field with an X or an O
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="XorO">'X' or 'O'</param>
        public void updateCell(int x, int y, char XorO) {
            if (!(XorO == 'X' || XorO == 'O')) throw new ArgumentException(String.Format("Did not receive an 'X' or a 'O'. Received instead: {0}", XorO)); //Program error, don't catch
            else if (playingField[x, y] != ' ') throw new ArgumentException(String.Format("Trying to update an already filled cell! At: {0},{1} which has {2}", x, y, playingField[x,y])); //TODO: User error must be caught!
            playingField[x,y] = XorO;
        } 
        /// <summary>
        /// Clears the field of all naughts and crosses
        /// </summary>
        public void clearField() {
            for (int i = 0; i < 3;i++) { for(int j = 0; j < 3;j++) { playingField[i, j] = ' '; } }
        }
        /// <summary>
        /// Returns the character stored in the coordinates given as parameters
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Element at the coordinates given</returns>
        public char getCellAt(int x, int y) {
            return playingField[x, y];
        }
    }
}
