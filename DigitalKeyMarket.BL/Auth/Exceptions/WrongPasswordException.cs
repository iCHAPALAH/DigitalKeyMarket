﻿namespace DigitalKeyMarket.BL.Auth.Exceptions;

public class WrongPasswordException : Exception
{
    public WrongPasswordException() { }
    public WrongPasswordException(string message) : base(message) { }
}