using LifeBudget.Views;
using System;
using System.Collections.Generic;
using System.Text;
using LifeBudget.Models;


namespace LifeBudget.Models
{

    public class PinNumber
    {
        public PinNumber()
        {
            EnteredPin = new byte[4];        // allocate 4 bytes to the entered pin
            pinIndex = 0;
        }

        public byte enterNumber(byte num)
        {
            if (pinIndex >= 4)
                return 0;
            else
            {
                EnteredPin[pinIndex] = num;
                pinIndex++;

                return pinIndex;
            }
        }

        public void clearPin()
        {
            pinIndex = 0;

        }

        public bool isComplete()
        {
            if (pinIndex == 4)
                return true;
            else
                return false;
        }

        public byte[] returnPin()
        {
            return EnteredPin;
        }

        private byte[] EnteredPin;                // This variable will hold the value of the entered pin number
        public byte pinIndex;                     // This will hold which index in the current pin number has been entered
    }
}
