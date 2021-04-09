namespace RegistroNotas.Core.Clases.Excepciones
{
    using System;
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }
        public BusinessException(string message) : base(message)
        {

        }
    }
}