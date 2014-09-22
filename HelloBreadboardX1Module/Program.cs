using System;
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
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            
            /*******************************************************************************************
            Modules added in the Program.gadgeteer designer view are used by typing 
            their name followed by a period, e.g.  button.  or  camera.
            
            Many modules generate useful events. Type +=<tab><tab> to add a handler to an event, e.g.:
                button.ButtonPressed +=<tab><tab>
            
            If you want to do something periodically, use a GT.Timer and handle its Tick event, e.g.:
                GT.Timer timer = new GT.Timer(1000); // every second (1000ms)
                timer.Tick +=<tab><tab>
                timer.Start();
            *******************************************************************************************/


            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");

            _digitalInput = breadBoard_X1.SetupDigitalInput(GT.Socket.Pin.Three, GlitchFilterMode.On, ResistorMode.Disabled);

            var timer = new GT.Timer(50);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(GT.Timer timer)
        {
            Mainboard.SetDebugLED(_digitalInput.Read());
        }
    }
}
