using System;
using System.Collections.Generic;

namespace NewsLibrary
{
    public class Website
    {
        private List<Writer> _writers;

        public Website()
        {
            _writers = new List<Writer>();
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

        public List<Writer> GetWriters()
        {
            return _writers;
        }
    }
}