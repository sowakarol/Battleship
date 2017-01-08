using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Game : GameInterface
    {
        private int shipsNumber;
        private int shipsLength;
        private int roundNumber = 0; //numer rundy
        private Field[,] fields = new Field[10,10];

        private List<Ship> ships;

        public Game(int shipsNumber, int shipsLength)
        {
            this.shipsLength = shipsLength;
            this.shipsNumber = shipsNumber;
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    fields[i, j] = new Field(State.WATER);
                }
            }
            
        } 




        public int handleClient(String name)
        {
            roundNumber++;
            Shot currentShot = new Shot(name);


            return currentShot.hit(fields[]);

        }

        public bool isOver()
        {
                bool isOver = true;
                foreach(Ship ship in ships)
                {
                    if (!ship.checkIfBroken())
                    {
                        return false;
                    }
                }
                return true;         
        }

        public void setShips()
        {
            throw new NotImplementedException();
        }



    }
}
