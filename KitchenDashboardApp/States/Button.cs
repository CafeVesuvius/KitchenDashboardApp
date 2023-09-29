using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.States
{
    public partial class Button : Microsoft.Maui.Controls.Button
    {
        private State _state = new Idle();
    }

    public partial class Button
    {
        private interface State
        {
            void OnClick(Button button);
        }

        private class Idle : State
        {
            public void OnClick(Button button)
            {
                button.
            }
        }
    }
}
