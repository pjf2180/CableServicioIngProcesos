﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.View_models
{
    public class ListaDeNominasViewModel
    {
        public ICollection<RegistroTrabajo> Trabajos { get; set; }
    }
}