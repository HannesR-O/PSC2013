using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.IO.Files
{
    /// <summary>
    /// Interface for classes containing large amounts of data thus are persisted as binaries
    /// </summary>
    public interface IBinaryFile
    {
        /// <summary>
        /// Returns a binary representation of the IBinaryFile
        /// </summary>
        /// <returns>A byte[] containing all data of the IBinaryFile</returns>
        byte[] GetBytes();

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="bytes"></param>
        ///// <returns></returns>
        //void InitializeFromFile(byte[] bytes);
    }
}