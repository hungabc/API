﻿using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class LoaispRepository:ILoaispRepository
    {
        private IDatabaseHelper _dbHelper;
        public LoaispRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<LoaispModel> GetDataAll()
        {
            return null;
        }
    }
}
