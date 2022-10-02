using Meo.Service.RequestModel;
using Meo.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.Interface
{
    public interface IFormService
    {
        Task<IActionResult> Create(FormModelRequest formViewModel);
    }
}
