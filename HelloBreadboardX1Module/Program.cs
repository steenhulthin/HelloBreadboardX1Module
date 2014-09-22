﻿using System;
using System.Collections;
using System.Threading;
using Gadgeteer.Interfaces;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace HelloBreadboardX1Module
{
    public partial class Program
    {
        private DigitalInput _digitalInput; 
        private DigitalOutput _digitalOutput; 
        void ProgramStarted()
        {
            Debug.Print("Program Started");

            _digitalInput = breadBoard_X1.SetupDigitalInput(GT.Socket.Pin.Three, GlitchFilterMode.On, ResistorMode.Disabled);
            _digitalOutput = breadBoard_X1.SetupDigitalOutput(GT.Socket.Pin.Four, false);

            var timer = new GT.Timer(50);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(GT.Timer timer)
        {
            var isButtonPressed = _digitalInput.Read();
            Mainboard.SetDebugLED(isButtonPressed);
            _digitalOutput.Write(isButtonPressed);
        }
    }
}
