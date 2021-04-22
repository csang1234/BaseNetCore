using System;

namespace CtrlShiftH.Data.Models
{
    public class ResultOrException<T>
    {
        public ResultOrException(T result)
        {
            IsSuccess = true;
            Result = result;
        }

        public ResultOrException(Exception ex)
        {
            IsSuccess = false;
            Exception = ex;
        }

        public bool IsSuccess { get; }
        public T Result { get; }
        public Exception Exception { get; }
    }
}