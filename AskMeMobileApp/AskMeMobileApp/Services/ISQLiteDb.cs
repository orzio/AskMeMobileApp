﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AskMeMobileApp.Database
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
