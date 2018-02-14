using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public abstract class State
    {
        protected double Guthaben;
        protected readonly Action<State> SetState;
        protected readonly double AnrufKosten;

        protected State(Action<State> setState, double anrufKosten, double guthaben)
        {
            if (AnrufKosten < 0)
                throw new Exception("die Kosten für ein Anruf müssen immer positiv sein");

            SetState = setState;
            AnrufKosten = anrufKosten;
            Guthaben = guthaben;
        }

        public abstract void GuthabenAufladen(double einzahlung);

        public abstract bool Telefonieren();
    }

    public class GuthabenVorhandenState : State
    {
        public GuthabenVorhandenState(Action<State> setState, double anrufKosten, double guthaben) : base(setState, anrufKosten, guthaben)
        {
        }

        public override void GuthabenAufladen(double einzahlung)
        {
            if (einzahlung < 0)
                throw new Exception("Eine Einzahlung muss immer positiv sein.");

            Guthaben += einzahlung;
        }

        public override bool Telefonieren()
        {
            if (Guthaben - AnrufKosten < 0)
                return false;

            Guthaben -= AnrufKosten;
            if (Guthaben <= 0)
                SetState(new GuthabenNichtVorhandenState(SetState, AnrufKosten, Guthaben));

            return true;
        }
    }

    public class GuthabenNichtVorhandenState : State
    {
        public GuthabenNichtVorhandenState(Action<State> setState, double anrufKosten, double guthaben) : base(setState, anrufKosten, guthaben)
        {
        }

        public override void GuthabenAufladen(double einzahlung)
        {
            if (einzahlung < 0)
                throw new Exception("Eine Einzahlung muss immer positiv sein.");

            Guthaben += einzahlung;
            if (Guthaben > 0)
                SetState(new GuthabenVorhandenState(SetState, AnrufKosten, Guthaben));
        }

        public override bool Telefonieren()
        {
            return false;
        }
    }

}
