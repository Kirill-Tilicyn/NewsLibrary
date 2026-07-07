using System;
using System.Collections.Generic;

namespace NewsLibrary
{
    internal class Website
    {
        private List<string> _writers;

        public Website()
        {
            _writers = new List<string>();
        }

        public bool SetWriter(Writer writer)
        {
            if (writer == null)
            {
                return false;
            }

            _writers.Add(writer);
            return true;
        }

        public List<string> GetWriters()
        {
            return _writers;
        }
    }
}