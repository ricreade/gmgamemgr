using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class to encapsulate a list of stored procedure arguments.
    /// </summary>
    public class DataArgumentList : IEnumerable
    {
        private DataArgument[] _args;

        public DataArgumentList()
        {
            _args = new DataArgument[] { };
        }

        public DataArgumentList(DataArgument[] ArgList)
        {
            _args = new DataArgument[ArgList.Length];

            for (int i = 0; i < _args.Length; i++)
            {
                _args[i] = ArgList[i];
            }
        }

        /// <summary>
        /// Adds a new DataArgument to the list.
        /// </summary>
        /// <param name="Argument">The DataArgument object to add.  If
        /// this argument is null, this method does nothing.</param>
        public void Add(DataArgument Argument)
        {
            if (Argument != null)
            {
                Array.Resize<DataArgument>(ref _args, _args.Length + 1);
                _args[_args.Length] = Argument;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public DataArgumentEnum GetEnumerator()
        {
            return new DataArgumentEnum(_args);
        }

        public class DataArgumentEnum : IEnumerator
        {
            private DataArgument[] _args;

            int _pos = -1;

            public DataArgumentEnum(DataArgument[] list)
            {
                _args = list;
            }

            public bool MoveNext()
            {
                _pos++;
                return _pos < _args.Length;
            }

            public void Reset()
            {
                _pos = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public DataArgument Current
            {
                get
                {
                    try
                    {
                        return _args[_pos];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        /// <summary>
        /// A class representing argument information from which a
        /// SQLParameter can be constructed.
        /// </summary>
        public class DataArgument
        {
            private string _key;
            private object _value;
            private SqlDbType _type;

            public DataArgument(string Key, object Value, SqlDbType Type)
            {
                _key = Key;
                _value = Value;
                _type = Type;
            }

            public DataArgument(DataArgument Argument)
            {
                if (Argument != null)
                {
                    _key = Argument.Key;
                    _value = Argument.Value;
                    _type = Argument.SqlDataType;
                }
            }

            public string Key
            {
                get { return _key; }
                set {
                    if (value != null && value.Length > 0)
                        _key = value; 
                }
            }

            public object Value
            {
                get { return _value; }
                set {
                    if (value != null)
                        _value = value; 
                }
            }

            public SqlDbType SqlDataType
            {
                get { return _type; }
                set { _type = value; }
            }
        }
    }
}
