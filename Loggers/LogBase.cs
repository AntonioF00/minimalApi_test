﻿namespace minimalApi_test.Loggers
{
    public abstract class LogBase
    {
        public abstract void Log(string message);
        protected readonly object lockObj = new object();
    }
}
