using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class PrePaidHandy
    {
        private double _guthaben;
        private readonly double _anrufKosten;
        private Guthaben _guthabenState;

        public PrePaidHandy(double anrufKosten)
        {
            if (_anrufKosten < 0)
                throw new Exception("die Kosten für ein Anruf müssen immer positiv sein");

            _anrufKosten = anrufKosten;
            _guthaben = 0.0;
            _guthabenState = Guthaben.NichtVorhanden;
        }

        public void GuthabenAufladen(double einzahlung)
        {
            if (einzahlung < 0)
                throw new Exception("Eine Einzahlung muss immer positiv sein.");

            _guthaben += einzahlung;

            if (_guthaben > 0)
                _guthabenState = Guthaben.Vorhanden;
        }

        public bool Telefonieren()
        {
            if (_guthaben - _anrufKosten < 0)
                return false;

            _guthaben -= _anrufKosten;
            if (_guthaben <= 0)
                _guthabenState = Guthaben.NichtVorhanden;

            return true;
        }

        private enum Guthaben
        {
            Vorhanden,
            NichtVorhanden
        }
    }
}
