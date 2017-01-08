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

        public int RoundNumber
        {
            get
            {
                return roundNumber;
            }

            set
            {
                roundNumber = value;
            }
        }

        public Game(int shipsNumber, int shipsLength)
        {
            this.shipsLength = shipsLength;
            this.shipsNumber = shipsNumber;
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    fields[i, j] = new Field(State.WATER,i, j);
                }
            }
            
        } 




        public int handleClient(String name)
        {
            RoundNumber++;
            Shot currentShot = new Shot(name);


            return currentShot.hit(fields[currentShot.RowNumber,currentShot.ColumnNumber]);

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
            Random rd = new Random();

            
        }

        private bool otherShipsContain(Field field, List<Ship> otherShips)
        {
            foreach (Ship ship in otherShips)
            {
                foreach(Field otherShipField in ship.Fields)
                {
                    if(field.ColumnNumber == otherShipField.ColumnNumber && field.RowNumber == otherShipField.RowNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool outOfBoundary(int rowNumber, int columnNumber)
        {
            if (rowNumber < 0 || rowNumber > 10 || columnNumber < 0 || columnNumber > 10) return true;
            return false;
        }

        private List<Ship> otherShips(List<Ship> ships,Ship excluded)
        {
            List<Ship> ret = new List<Ship>;
            foreach(Ship ship in ships)
            {
                if (ship != excluded) ret.Add(ship);
            }
            return ret;
        }

    }
}
