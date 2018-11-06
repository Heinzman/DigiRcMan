using System;
using System.Diagnostics;
using PostSharp.Aspects;

namespace Heinzman.Tracing
{
    [Serializable]
    public sealed class QuickTraceAttribute : OnMethodBoundaryAspect
    {
        private string _enteringMessage, _leavingMessage;

        public override void CompileTimeInitialize(System.Reflection.MethodBase method, AspectInfo aspectInfo)
        {
            string methodName = method.DeclaringType.FullName + "." + method.Name;
            _enteringMessage = "Entering " + methodName;
            _leavingMessage = "Leaving " + methodName;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            Trace.WriteLine(_enteringMessage + GetDateTime());
            Trace.Indent();
        }

        private static string GetDateTime()
        {
            return " " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Trace.Unindent();
            Trace.WriteLine(_leavingMessage + GetDateTime());
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Trace.Unindent();
            Trace.WriteLine(_leavingMessage + " with exception: " + args.Exception.Message + Environment.NewLine + args.Exception + GetDateTime());
        }
    }
}
