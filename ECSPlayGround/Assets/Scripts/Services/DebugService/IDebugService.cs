﻿public interface IDebugService
{
    void Log(string message);
    void LogError(string message);
    void LogWarning(string message);
}