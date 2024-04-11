using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_lockers.WPF
{
  public partial  class MainViewModel:ObservableObject
    {
        [ObservableProperty]
        List<Box> boxes = Enumerable.Range(0, 150).Select(n => new Box { Id = n + 1 }).ToList();
    }
}
