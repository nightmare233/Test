﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chaint.Common.Core.Enums;
namespace Chaint.Common.Core.Sql
{
    public class InsertItem:BaseItem
    {
        public InsertItem(string dbFieldName, string parameterName, object parameterValue, Enums_FieldType fieldype):
            base(dbFieldName, parameterName, parameterValue, fieldype)
        {
        }
    }
}