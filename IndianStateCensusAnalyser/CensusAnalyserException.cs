using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    
    public class ExceptionFileNotFound : Exception
    {
        public StateCensusException FileFoundException;

       //filenot found custom exception
        public ExceptionFileNotFound(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.FileFoundException = exception;
        } 
    } 

    public class ExceptionWrongFile : Exception
    {
        public StateCensusException WrongFileException;

       //wrong file exception 
        public ExceptionWrongFile(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.WrongFileException = exception;
        } 
    } 

    public class ExceptionIncorrectDelimeter : Exception
    {
        public StateCensusException WrongDelimeter;
       
        //Incorrect delimiter exception
        public ExceptionIncorrectDelimeter(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.WrongDelimeter = exception;
        }
    }

    public class ExceptionInvalidHeaders : Exception
    {
        public StateCensusException InvalidHeaders;
      
        //invalid header exception
        public ExceptionInvalidHeaders(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.InvalidHeaders = exception;
        }
    }
}

