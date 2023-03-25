﻿using Domain.Entities;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IHumanoRepository : IRepositorioGenerico<HumanoDTO,int>
    {
    }
}
