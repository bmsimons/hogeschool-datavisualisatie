using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeschoolDatavisualisatie.DataRepository
{
    /// <summary>
    /// Interface that all (file) data parsers should adhere to 
    /// </summary>
    /// <typeparam name="T"> The type of model that the parser should create</typeparam>
    /// <typeparam name="T2"> Intermediary data structure to hold model values</typeparam>
    /// <typeparam name="T3"> Data type of data points</typeparam>
    interface IDataParser<T,T2, T3>
    {
        /// <summary>
        /// Generic function name, main entry for a data parser class
        /// </summary>
        void ParseData();

        /// <summary>
        /// Class that defines the conversion of data to a representing data model
        /// </summary>
        /// <param name="data"> Intermediary array</param>
        /// <returns>Object of model class<returns>
        T ConvertDataToModel(T2 data);

        /// <summary>
        /// Accesor for intermediary array storage
        /// </summary>
        T2 GetDataPoint(T3 i);
    }
}
