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

        private List<Ship> ships = new List<Ship>();

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
            Shot currentShot = new Shot(name);

            int ret = currentShot.hit(fields[currentShot.RowNumber, currentShot.ColumnNumber]);

            if(ret != -1) RoundNumber++;


            return ret;
        }

        public bool isOver()
        {
                bool isOver = true;
                foreach(Ship ship in ships)
                {
                    if (!ship.checkIfDrowned())
                    {
                        return false;
                    }
                }
                return true;         
        }

        public void setShips()
        {
            Random rd = new Random();

            while(ships.Count < shipsNumber)
            {
                int randomColumnNumber = rd.Next(0, 10);
                int randomRowNumber = rd.Next(0, 10);
                int randomDirection = rd.Next(0, 4);

                List<Field> potentialFields = new List<Field>();
                switch (randomDirection)
                {
                    case 0: //idze na północ (randomColumnNumber++)
                        for (int i = 0; i < shipsLength; i++)
                        {

                            if(!outOfBoundary(randomRowNumber, randomColumnNumber))
                            {
                                if(!otherShipsContain(fields[randomRowNumber, randomColumnNumber], ships))
                                {
                                    potentialFields.Add(fields[randomRowNumber, randomColumnNumber]);

                                }
                            }
                            randomColumnNumber++;
                        
                        }
                        break;
                    case 1: //idze na wschód (randomRowNumber++)
                        for (int i = 0; i < shipsLength; i++)
                        {
                            if (!outOfBoundary(randomRowNumber, randomColumnNumber))
                            {
                                if (!otherShipsContain(fields[randomRowNumber, randomColumnNumber], ships))
                                {
                                    potentialFields.Add(fields[randomRowNumber, randomColumnNumber]);

                                }
                            }
                            randomRowNumber++;

                        }
                        break;
                    case 2: //idze na południe (randomColumnNumber--)
                        for (int i = 0; i < shipsLength; i++)
                        {
                            if (!outOfBoundary(randomRowNumber, randomColumnNumber))
                            {
                                if (!otherShipsContain(fields[randomRowNumber, randomColumnNumber], ships))
                                {
                                    potentialFields.Add(fields[randomRowNumber, randomColumnNumber]);

                                }
                            }
                            randomColumnNumber--;
                        }

                        break;
                    case 3: //idze na zachód (randomRowNumber--)
                        for (int i = 0; i < shipsLength; i++)
                        {
                            if (!outOfBoundary(randomRowNumber, randomColumnNumber))
                            {
                                if (!otherShipsContain(fields[randomRowNumber, randomColumnNumber], ships))
                                {
                                    potentialFields.Add(fields[randomRowNumber, randomColumnNumber]);

                                }
                            }
                            randomRowNumber--;

                        }
                        break;

                }

                if(potentialFields.Count() == shipsLength)
                {
                    ships.Add(new Ship(shipsLength,potentialFields));
                    System.Diagnostics.Debug.WriteLine("Udało się statek dodać");
                }


            }           
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
            if (rowNumber < 0 || rowNumber > 9 || columnNumber < 0 || columnNumber > 9) return true;
            return false;
        }

        /*private List<Ship> otherShips(List<Ship> ships,Ship excluded)
        {
            List<Ship> ret = new List<Ship>();
            foreach(Ship ship in ships)
            {
                if (ship != excluded) ret.Add(ship);
            }
            return ret;
        }*/ //myślałem, ze się przyda : ((

    }
}
