﻿using System;
using System.Collections.Generic;
using System.Text;

 

namespace Biblioteca.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
