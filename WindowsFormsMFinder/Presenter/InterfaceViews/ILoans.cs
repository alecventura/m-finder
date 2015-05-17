﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.InterfaceViews
{
    public interface ILoans : IBase
    {
        void fillDptoList(List<dpto> list);
        void fillRoleList(List<role> list);
    }
}
