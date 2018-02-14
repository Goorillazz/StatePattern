using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class PrePaidHandy
    {        
        private State _currentState;

        public PrePaidHandy(double anrufKosten)
        {
            if (anrufKosten < 0)
                throw new Exception("die Kosten für ein Anruf müssen immer positiv sein");

            var guthaben = 0.0;
            _currentState = new GuthabenNichtVorhandenState(SetState, anrufKosten, guthaben);            
        }

        private void SetState(State state)
        {
            _currentState = state;
        }

        public void GuthabenAufladen(double einzahlung)
        {
            _currentState.GuthabenAufladen(einzahlung);
        }

        public bool Telefonieren()
        {
            return _currentState.Telefonieren();
        }        
    }
}
