using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Field
    {
        State currentState;

        public Field(State state)
        {
            currentState = state;
        }

        internal State CurrentState
        {
            get
            {
                return currentState;
            }

            set
            {
                currentState = value;
            }
        }
    }




}
