using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using XamarinSqlite.Data.Interfaces;
using XamarinSqlite.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]
namespace XamarinSqlite.Droid.Data
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid() { }
        public SQLiteAsyncConnection GetConnection()
        {
            // Create database on Android device
            var sqliteFileName = "FleeDatabaseSQLite";
            string docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(docPath, sqliteFileName);
            var conn = new SQLiteAsyncConnection(path);
            return conn;
        }
    }
}