using System.Diagnostics;

namespace Elreg.HelperClasses
{
    public class TraceListenenerDebugAssert : TraceListener
    {
        public override void Write(string msg)
        {
            BreakInCode();
        }

        public override void Write(object obj)
        {
            BreakInCode();
        }

        public override void Write(string msg, string cat)
        {
            BreakInCode();
        }

        public override void Write(object obj, string cat)
        {
            BreakInCode();
        }

        public override void WriteLine(string msg)
        {
            BreakInCode();
        }

        public override void WriteLine(object obj)
        {
            BreakInCode();
        }

        public override void WriteLine(string msg, string cat)
        {
            BreakInCode();
        }

        public override void WriteLine(object obj, string cat)
        {
            BreakInCode();
        }

        private void BreakInCode()
        {
            //BooleanSwitch assertSwitch = new BooleanSwitch("BreakOnAssert", "");

            //if (assertSwitch.Enabled)
            //{
            if (Debugger.IsAttached)
                Debugger.Break();
            else
                Debugger.Launch();
            //}
        }
    }
}