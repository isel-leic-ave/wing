using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Csvier
{
    public class CsvParser
    {
        public CsvParser(Type klass, char separator)
        {
        }
        public CsvParser(Type klass) : this(klass, ',')
        {
        }

        public CsvParser CtorArg(string arg, int col)
        {
            return this;
        }

        public CsvParser PropArg(string arg, int col)
        {
            return this;
        }

        public CsvParser FieldArg(string arg, int col)
        {
            return this;
        }

        public CsvParser Load(String src)
        {
            string[] arr = src.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            return this;
        }

        public CsvParser Remove(int count)
        {
            return this;
        }

        public CsvParser RemoveEmpties()
        {
            return this;
        }
        
        public CsvParser RemoveWith(string word)
        {
            return this;
        }
        public CsvParser RemoveEvenIndexes()
        {
            return this;
        }
        public CsvParser RemoveOddIndexes()
        {
            return this;
        }
        public object[] Parse()
        {
            throw new NotImplementedException();
        }

    }
}
