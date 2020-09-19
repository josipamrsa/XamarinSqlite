using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinSqlite.Data.Interfaces
{
    public interface ISQLite
    {
        //----SQLITE CONNECTION INTERFACE----//
        SQLiteAsyncConnection GetConnection();
    }
}
