using System;

namespace LR_3_code_Cch
{
    public class ClearEventArgs : EventArgs
    {
        public ClearEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}